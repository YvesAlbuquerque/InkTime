using System;
using InkThroughTime.Domain;

namespace InkThroughTime.Application
{
    /// <summary>
    /// Controls high-level game flow: era transitions, bankruptcy, and 2030 retrospective.
    /// Called by SimulationClock at month-end and by EconomyService on bankruptcy.
    /// </summary>
    public class GameFlowController
    {
        public event Action OnBankruptcy;
        public event Action<Era> OnEraTransition;
        public event Action OnRetrospectiveTriggered;

        private readonly GameSession _session;
        private readonly EconomyService _economyService;
        private readonly CatalogueService _catalogueService;
        private readonly OpportunityService _opportunityService;

        private bool _bankruptcyTriggered;
        private bool _retrospectiveTriggered;

        public bool IsBankrupt => _bankruptcyTriggered;
        public bool IsRetrospective => _retrospectiveTriggered;

        public GameFlowController(
            GameSession session,
            EconomyService economyService,
            CatalogueService catalogueService,
            OpportunityService opportunityService)
        {
            _session = session;
            _economyService = economyService;
            _catalogueService = catalogueService;
            _opportunityService = opportunityService;
        }

        /// <summary>
        /// Called by SimulationClock at each month-end.
        /// </summary>
        public void ProcessMonthEnd()
        {
            if (_bankruptcyTriggered || _retrospectiveTriggered) return;

            _economyService.ProcessMonthEnd();
            _catalogueService.ProcessMonthEnd();
            _opportunityService.ProcessMonthEnd();

            if (_session.Studio.UpdateNegativeMonthCounter())
            {
                TriggerBankruptcy();
                return;
            }

            CheckEraTransition();
            CheckRetrospective();
        }

        /// <summary>
        /// Triggers the bankruptcy game-over state.
        /// Called by ProcessMonthEnd when three consecutive negative months are detected.
        /// </summary>
        public void TriggerBankruptcy()
        {
            if (_bankruptcyTriggered) return;
            _bankruptcyTriggered = true;
            OnBankruptcy?.Invoke();
        }

        private void CheckEraTransition()
        {
            Era newEra = CalendarState.EraForYear(_session.Calendar.Year);
            if (newEra != _session.Calendar.CurrentEra)
            {
                _session.Calendar.CurrentEra = newEra;
                OnEraTransition?.Invoke(newEra);
            }
        }

        private void CheckRetrospective()
        {
            if (_session.Calendar.Year >= 2030 && !_retrospectiveTriggered)
            {
                _retrospectiveTriggered = true;
                OnRetrospectiveTriggered?.Invoke();
            }
        }
    }
}
