using System;
using InkThroughTime.Domain;

namespace InkThroughTime.Application
{
    /// <summary>
    /// Handles all money flow: revenue collection, salary deductions, equipment upkeep,
    /// and the consecutive-negative-month counter. Called by GameFlowController at month-end.
    /// Runtime AI must never directly call this service.
    /// </summary>
    public class EconomyService
    {
        public event Action<float> OnCashChanged;

        private readonly GameSession _session;

        // Configurable rates (could be driven by EraDefinition ScriptableObjects in future)
        private const float BaseSalePrice = 100f;
        private const float SalaryPerEmployee = 300f;

        public EconomyService(GameSession session)
        {
            _session = session;
        }

        /// <summary>
        /// Executes the economy tick for the current month.
        /// </summary>
        public void ProcessMonthEnd()
        {
            CollectRevenue();
            DeductSalaries();
            DeductEquipmentUpkeep();
            OnCashChanged?.Invoke(_session.Studio.Cash);
        }

        /// <summary>
        /// Adds revenue from comics published this month.
        /// </summary>
        private void CollectRevenue()
        {
            int currentYear = _session.Calendar.Year;
            int currentMonth = _session.Calendar.Month;

            foreach (var comic in _session.PublishedComics)
            {
                if (comic.PublicationYear == currentYear && comic.PublicationMonth == currentMonth)
                {
                    float revenue = CalculateRevenue(comic);
                    comic.Revenue = revenue;
                    _session.Studio.Cash += revenue;
                }
            }
        }

        /// <summary>
        /// Calculates revenue for a comic based on its reception score.
        /// </summary>
        public float CalculateRevenue(PublishedComic comic)
        {
            if (comic.Evaluation == null) return 0f;

            float score = comic.Evaluation.WeightedTotal;
            float revenue = BaseSalePrice * score * 10f;

            var breakdown = new ScoreBreakdown
            {
                EraInterest = comic.Evaluation.EraInterestScore,
                Quality = comic.Evaluation.QualityScore,
                CreativityAverage = (comic.WriterCreativitySnapshot + comic.ArtistCreativitySnapshot) / 2f / 100f,
                EvaluationComponent = comic.Evaluation.EvaluationScore,
                WeightedTotal = score,
                BaseSalePrice = BaseSalePrice
            };
            comic.Score = breakdown;
            comic.SalesUnits = (int)(score * 100f);

            return revenue;
        }

        private void DeductSalaries()
        {
            float totalSalaries = _session.Employees.Count * SalaryPerEmployee;
            _session.Studio.Cash -= totalSalaries;
        }

        private void DeductEquipmentUpkeep()
        {
            // Placeholder: equipment upkeep driven by owned equipment list in future milestone
        }
    }
}
