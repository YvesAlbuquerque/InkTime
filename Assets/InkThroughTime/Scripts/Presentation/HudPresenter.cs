using UnityEngine;
using UnityEngine.UI;
using TMPro;
using InkThroughTime.Application;
using InkThroughTime.Domain;

namespace InkThroughTime.Presentation
{
    /// <summary>
    /// Updates the HUD elements: cash, calendar date, reputation, and employee Creativity bars.
    /// Subscribes to events from EconomyService and SimulationClock.
    /// </summary>
    public class HudPresenter : MonoBehaviour
    {
        [Header("Cash Display")]
        [SerializeField] private TextMeshProUGUI _cashLabel;

        [Header("Calendar Display")]
        [SerializeField] private TextMeshProUGUI _dateLabel;

        [Header("Reputation Display")]
        [SerializeField] private TextMeshProUGUI _reputationLabel;

        private InkGameRoot _root;

        private void Start()
        {
            _root = FindObjectOfType<InkGameRoot>();
            if (_root == null) return;

            _root.EconomyService.OnCashChanged += HandleCashChanged;
            _root.Clock.OnMonthEnd += HandleMonthEnd;
            Refresh();
        }

        private void OnDestroy()
        {
            if (_root == null) return;
            _root.EconomyService.OnCashChanged -= HandleCashChanged;
            _root.Clock.OnMonthEnd -= HandleMonthEnd;
        }

        private void HandleCashChanged(float cash) => UpdateCashLabel(cash);

        private void HandleMonthEnd() => UpdateDateLabel();

        private void Refresh()
        {
            UpdateCashLabel(_root.Session.Studio.Cash);
            UpdateDateLabel();
            UpdateReputationLabel(_root.Session.Studio.Reputation);
        }

        private void UpdateCashLabel(float cash)
        {
            if (_cashLabel != null)
                _cashLabel.text = $"${cash:N0}";
        }

        private void UpdateDateLabel()
        {
            if (_dateLabel == null || _root == null) return;
            var cal = _root.Session.Calendar;
            _dateLabel.text = $"{System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(cal.Month)} {cal.Year}";
        }

        private void UpdateReputationLabel(int reputation)
        {
            if (_reputationLabel != null)
                _reputationLabel.text = $"Rep: {reputation}";
        }
    }
}
