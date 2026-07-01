using System.Collections.Generic;
using UnityEngine;
using InkThroughTime.Application;
using InkThroughTime.Domain;

namespace InkThroughTime.Presentation
{
    /// <summary>
    /// Displays the project queue rail: shows all active projects and their current phase.
    /// Listens to ProductionService events to update in real time.
    /// </summary>
    public class ProjectRailPresenter : MonoBehaviour
    {
        [SerializeField] private GameObject _projectCardPrefab;
        [SerializeField] private Transform _railContainer;

        private readonly Dictionary<string, ProjectCardView> _cards =
            new Dictionary<string, ProjectCardView>();

        private InkGameRoot _root;

        private void Start()
        {
            _root = FindObjectOfType<InkGameRoot>();
            if (_root == null) return;

            _root.ProductionService.OnProjectPhaseChanged += HandlePhaseChanged;
            _root.ProductionService.OnComicPublished += HandleComicPublished;

            RebuildRail();
        }

        private void OnDestroy()
        {
            if (_root == null) return;
            _root.ProductionService.OnProjectPhaseChanged -= HandlePhaseChanged;
            _root.ProductionService.OnComicPublished -= HandleComicPublished;
        }

        private void HandlePhaseChanged(ProjectState project)
        {
            if (_cards.TryGetValue(project.ProjectId, out var card))
                card.UpdatePhase(project.Phase);
            else
                AddCard(project);
        }

        private void HandleComicPublished(PublishedComic comic)
        {
            if (_cards.TryGetValue(comic.ProjectId, out var card))
            {
                Destroy(card.gameObject);
                _cards.Remove(comic.ProjectId);
            }
        }

        private void RebuildRail()
        {
            foreach (Transform child in _railContainer)
                Destroy(child.gameObject);
            _cards.Clear();

            foreach (var project in _root.Session.Projects)
            {
                if (project.Phase == ProjectPhase.Published ||
                    project.Phase == ProjectPhase.Cancelled ||
                    project.Phase == ProjectPhase.Failed)
                    continue;

                AddCard(project);
            }
        }

        private void AddCard(ProjectState project)
        {
            if (_projectCardPrefab == null || _railContainer == null) return;

            var go = Instantiate(_projectCardPrefab, _railContainer);
            var card = go.GetComponent<ProjectCardView>();
            if (card == null) card = go.AddComponent<ProjectCardView>();

            card.Bind(project.ProjectId, project.Phase);
            _cards[project.ProjectId] = card;
        }
    }

    /// <summary>
    /// A single card in the project rail showing project ID and current phase.
    /// </summary>
    public class ProjectCardView : MonoBehaviour
    {
        [SerializeField] private TMPro.TextMeshProUGUI _phaseLabel;

        private string _projectId;

        public void Bind(string projectId, ProjectPhase phase)
        {
            _projectId = projectId;
            UpdatePhase(phase);
        }

        public void UpdatePhase(ProjectPhase phase)
        {
            if (_phaseLabel != null)
                _phaseLabel.text = phase.ToString();
        }
    }
}
