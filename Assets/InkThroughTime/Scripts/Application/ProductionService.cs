using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using InkThroughTime.Domain;
using InkThroughTime.Infrastructure.AI;
using InkThroughTime.Infrastructure.Persistence;

namespace InkThroughTime.Application
{
    /// <summary>
    /// Manages the comic production pipeline. Advances project phases, dispatches
    /// AI jobs via AiCoordinator, and finalizes publications.
    /// </summary>
    public class ProductionService
    {
        public event Action<ProjectState> OnProjectPhaseChanged;
        public event Action<PublishedComic> OnComicPublished;

        private readonly GameSession _session;
        private readonly AiCoordinator _aiCoordinator;
        private readonly ComicArtefactStore _artefactStore;

        public ProductionService(
            GameSession session,
            AiCoordinator aiCoordinator,
            ComicArtefactStore artefactStore)
        {
            _session = session;
            _aiCoordinator = aiCoordinator;
            _artefactStore = artefactStore;
        }

        /// <summary>
        /// Called by SimulationClock each tick to advance active projects.
        /// </summary>
        public void TickProduction()
        {
            foreach (var project in _session.Projects)
            {
                if (project.Phase == ProjectPhase.Drafting ||
                    project.Phase == ProjectPhase.Published ||
                    project.Phase == ProjectPhase.Cancelled ||
                    project.Phase == ProjectPhase.Failed)
                    continue;

                // AI-driven phases are handled asynchronously; skip if already in flight
                if (project.Phase == ProjectPhase.GeneratingScript ||
                    project.Phase == ProjectPhase.GeneratingPanels ||
                    project.Phase == ProjectPhase.Evaluating)
                    continue;

                AdvanceProject(project);
            }
        }

        /// <summary>
        /// Assigns a writer to a Drafting project and begins script generation.
        /// </summary>
        public void AssignWriter(string projectId, string employeeId)
        {
            var project = FindProject(projectId);
            var employee = FindEmployee(employeeId);
            if (project == null || employee == null) return;
            if (project.Phase != ProjectPhase.Drafting) return;

            project.WriterEmployeeId = employeeId;
            employee.Assignment = EmployeeAssignment.Writing;
            employee.CurrentProjectId = projectId;
            project.WriterCreativitySnapshot = employee.Creativity;

            TransitionPhase(project, ProjectPhase.GeneratingScript);
            _ = RunScriptGenerationAsync(project, CancellationToken.None);
        }

        /// <summary>
        /// Assigns an artist to an AwaitingArt project and begins panel generation.
        /// </summary>
        public void AssignArtist(string projectId, string employeeId)
        {
            var project = FindProject(projectId);
            var employee = FindEmployee(employeeId);
            if (project == null || employee == null) return;
            if (project.Phase != ProjectPhase.AwaitingArt) return;

            project.ArtistEmployeeId = employeeId;
            employee.Assignment = EmployeeAssignment.Drawing;
            employee.CurrentProjectId = projectId;
            project.ArtistCreativitySnapshot = employee.Creativity;

            TransitionPhase(project, ProjectPhase.Drawing);
        }

        /// <summary>
        /// Creates a new project in the Drafting phase.
        /// </summary>
        public ProjectState CreateProject(string ipId)
        {
            var project = new ProjectState
            {
                ProjectId = Guid.NewGuid().ToString("N"),
                IpId = ipId,
                Era = _session.Calendar.CurrentEra,
                Phase = ProjectPhase.Drafting,
                StartYear = _session.Calendar.Year,
                StartMonth = _session.Calendar.Month
            };
            _session.Projects.Add(project);
            return project;
        }

        private async Task RunScriptGenerationAsync(ProjectState project, CancellationToken ct)
        {
            var writer = FindEmployee(project.WriterEmployeeId);
            var brief = new ComicBrief
            {
                IpName = GetIpName(project.IpId),
                Era = project.Era,
                WriterSkill = writer?.WritingSkill ?? 50f,
                WriterAuthenticity = writer?.Authenticity ?? 50f,
                DeterministicSeed = BuildSeed(project)
            };

            try
            {
                var plan = await _aiCoordinator.WriteAsync(brief, ct);
                project.Plan = plan;
                TransitionPhase(project, ProjectPhase.AwaitingArt);
                FreeEmployee(project.WriterEmployeeId);
            }
            catch (OperationCanceledException)
            {
                TransitionPhase(project, ProjectPhase.Cancelled);
            }
            catch (Exception)
            {
                TransitionPhase(project, ProjectPhase.Failed);
            }
        }

        private void AdvanceProject(ProjectState project)
        {
            if (project.Phase == ProjectPhase.Drawing)
            {
                TransitionPhase(project, ProjectPhase.GeneratingPanels);
                _ = RunPanelGenerationAsync(project, CancellationToken.None);
            }
            else if (project.Phase == ProjectPhase.Assembling)
            {
                TransitionPhase(project, ProjectPhase.Evaluating);
                _ = RunEvaluationAsync(project, CancellationToken.None);
            }
        }

        private async Task RunPanelGenerationAsync(ProjectState project, CancellationToken ct)
        {
            var artist = FindEmployee(project.ArtistEmployeeId);
            var direction = new ArtDirection
            {
                Era = project.Era,
                AuthenticityHint = artist?.Authenticity ?? 50f,
                DeterministicSeed = BuildSeed(project) + 1
            };

            try
            {
                var art = await _aiCoordinator.DrawAsync(project.Plan, direction, ct);
                for (int i = 0; i < 3; i++)
                    project.PanelImagePaths[i] = art.PanelImagePaths[i];

                TransitionPhase(project, ProjectPhase.Assembling);
                FreeEmployee(project.ArtistEmployeeId);
            }
            catch (OperationCanceledException)
            {
                TransitionPhase(project, ProjectPhase.Cancelled);
            }
            catch (Exception)
            {
                TransitionPhase(project, ProjectPhase.Failed);
            }
        }

        private async Task RunEvaluationAsync(ProjectState project, CancellationToken ct)
        {
            var writer = FindEmployee(project.WriterEmployeeId);
            var artist = FindEmployee(project.ArtistEmployeeId);
            var context = new EvaluationContext
            {
                Era = project.Era,
                ArtistSkill = artist?.ArtSkill ?? 50f,
                ArtistAuthenticity = artist?.Authenticity ?? 50f,
                WriterAuthenticity = writer?.Authenticity ?? 50f,
                DeterministicSeed = BuildSeed(project) + 2
            };

            try
            {
                var evaluation = await _aiCoordinator.EvaluateAsync(project.Plan, null, context, ct);
                project.Evaluation = evaluation;
                FinalizePublication(project);
            }
            catch (OperationCanceledException)
            {
                TransitionPhase(project, ProjectPhase.Cancelled);
            }
            catch (Exception)
            {
                TransitionPhase(project, ProjectPhase.Failed);
            }
        }

        private void FinalizePublication(ProjectState project)
        {
            var comic = new PublishedComic
            {
                ProjectId = project.ProjectId,
                IpId = project.IpId,
                Era = project.Era,
                WriterEmployeeId = project.WriterEmployeeId,
                ArtistEmployeeId = project.ArtistEmployeeId,
                EquipmentId = project.EquipmentId,
                WriterCreativitySnapshot = project.WriterCreativitySnapshot,
                ArtistCreativitySnapshot = project.ArtistCreativitySnapshot,
                Plan = project.Plan,
                PanelImagePaths = project.PanelImagePaths,
                Evaluation = project.Evaluation,
                PublicationYear = _session.Calendar.Year,
                PublicationMonth = _session.Calendar.Month
            };

            _session.PublishedComics.Add(comic);
            TransitionPhase(project, ProjectPhase.Published);
            OnComicPublished?.Invoke(comic);
        }

        private void TransitionPhase(ProjectState project, ProjectPhase newPhase)
        {
            project.Phase = newPhase;
            OnProjectPhaseChanged?.Invoke(project);
        }

        private void FreeEmployee(string employeeId)
        {
            var emp = FindEmployee(employeeId);
            if (emp == null) return;
            emp.Assignment = EmployeeAssignment.Idle;
            emp.CurrentProjectId = null;
        }

        private ProjectState FindProject(string id)
        {
            foreach (var p in _session.Projects)
                if (p.ProjectId == id) return p;
            return null;
        }

        private EmployeeState FindEmployee(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;
            foreach (var e in _session.Employees)
                if (e.Id == id) return e;
            return null;
        }

        private string GetIpName(string ipId)
        {
            foreach (var ip in _session.IpCatalogue)
                if (ip.IpId == ipId) return ip.Name;
            return "Unknown";
        }

        private int BuildSeed(ProjectState project) =>
            (project.ProjectId.GetHashCode() ^ project.Era.GetHashCode()) & int.MaxValue;
    }
}
