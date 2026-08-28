using System;
using System.Collections.Generic;
using InkThroughTime.Domain;

namespace InkThroughTime.Application
{
    /// <summary>
    /// Manages nostalgia and reprint opportunities that appear during the 2030 retrospective.
    /// </summary>
    public class OpportunityService
    {
        public event Action<OpportunityRecord> OnOpportunityAvailable;

        private readonly GameSession _session;
        private readonly List<OpportunityRecord> _activeOpportunities = new List<OpportunityRecord>();

        public IReadOnlyList<OpportunityRecord> ActiveOpportunities => _activeOpportunities;

        public OpportunityService(GameSession session)
        {
            _session = session;
        }

        /// <summary>
        /// Called at month-end to generate retrospective opportunities in the 2030 era.
        /// </summary>
        public void ProcessMonthEnd()
        {
            if (_session.Calendar.CurrentEra != Era.Retrospective) return;

            GenerateNostalgiaOpportunities();
        }

        /// <summary>
        /// Accepts an opportunity, adding its value to studio cash.
        /// </summary>
        public void AcceptOpportunity(string opportunityId)
        {
            var opp = FindOpportunity(opportunityId);
            if (opp == null || opp.Resolved) return;

            _session.Studio.Cash += opp.Value;
            opp.Resolved = true;
        }

        private void GenerateNostalgiaOpportunities()
        {
            foreach (var comic in _session.PublishedComics)
            {
                if (AlreadyHasOpportunity(comic.ProjectId)) continue;

                var ip = FindIp(comic.IpId);
                if (ip == null || !ip.OwnsFirstPrint) continue;

                var opp = new OpportunityRecord
                {
                    OpportunityId = Guid.NewGuid().ToString("N"),
                    ProjectId = comic.ProjectId,
                    Title = $"Collector Auction: {ip.Name} #1",
                    Value = ip.FirstPrintValue,
                    Resolved = false
                };
                _activeOpportunities.Add(opp);
                OnOpportunityAvailable?.Invoke(opp);
            }
        }

        private bool AlreadyHasOpportunity(string projectId)
        {
            foreach (var o in _activeOpportunities)
                if (o.ProjectId == projectId) return true;
            return false;
        }

        private OpportunityRecord FindOpportunity(string id)
        {
            foreach (var o in _activeOpportunities)
                if (o.OpportunityId == id) return o;
            return null;
        }

        private IpState FindIp(string ipId)
        {
            foreach (var ip in _session.IpCatalogue)
                if (ip.IpId == ipId) return ip;
            return null;
        }
    }

    [Serializable]
    public class OpportunityRecord
    {
        public string OpportunityId = string.Empty;
        public string ProjectId = string.Empty;
        public string Title = string.Empty;
        public float Value;
        public bool Resolved;
    }
}
