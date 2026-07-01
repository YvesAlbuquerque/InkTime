using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using InkThroughTime.Application;
using InkThroughTime.Domain;

namespace InkThroughTime.Presentation
{
    /// <summary>
    /// Displays the 2030 retrospective: legacy score summary, complete archive review,
    /// and nostalgia opportunity resolution UI.
    /// </summary>
    public class RetrospectivePresenter : MonoBehaviour
    {
        [Header("Legacy Summary")]
        [SerializeField] private TextMeshProUGUI _legacyScoreLabel;
        [SerializeField] private TextMeshProUGUI _totalComicsLabel;
        [SerializeField] private TextMeshProUGUI _totalRevenueLabel;

        [Header("Opportunities")]
        [SerializeField] private GameObject _opportunityPrefab;
        [SerializeField] private Transform _opportunityContainer;

        private InkGameRoot _root;

        private void Start()
        {
            _root = FindObjectOfType<InkGameRoot>();
            if (_root == null) return;

            _root.FlowController.OnRetrospectiveTriggered += HandleRetrospectiveTriggered;
            _root.OpportunityService.OnOpportunityAvailable += HandleOpportunityAvailable;
        }

        private void OnDestroy()
        {
            if (_root == null) return;
            _root.FlowController.OnRetrospectiveTriggered -= HandleRetrospectiveTriggered;
            _root.OpportunityService.OnOpportunityAvailable -= HandleOpportunityAvailable;
        }

        private void HandleRetrospectiveTriggered() => RefreshSummary();

        private void HandleOpportunityAvailable(OpportunityRecord opp) => AddOpportunityCard(opp);

        private void RefreshSummary()
        {
            var session = _root.Session;
            int total = session.PublishedComics.Count;
            float totalRevenue = 0f;
            float scoreSum = 0f;

            foreach (var comic in session.PublishedComics)
            {
                totalRevenue += comic.Revenue;
                if (comic.Score != null) scoreSum += comic.Score.WeightedTotal;
            }

            float legacy = total > 0 ? scoreSum / total : 0f;

            if (_legacyScoreLabel != null) _legacyScoreLabel.text = $"Legacy: {legacy:P0}";
            if (_totalComicsLabel != null) _totalComicsLabel.text = $"Comics Published: {total}";
            if (_totalRevenueLabel != null) _totalRevenueLabel.text = $"Total Revenue: ${totalRevenue:N0}";

            gameObject.SetActive(true);
        }

        private void AddOpportunityCard(OpportunityRecord opp)
        {
            if (_opportunityPrefab == null || _opportunityContainer == null) return;

            var go = Instantiate(_opportunityPrefab, _opportunityContainer);

            var label = go.GetComponentInChildren<TextMeshProUGUI>();
            if (label != null) label.text = $"{opp.Title} — ${opp.Value:N0}";

            var btn = go.GetComponent<Button>();
            if (btn != null)
            {
                var captured = opp;
                btn.onClick.AddListener(() =>
                {
                    _root.OpportunityService.AcceptOpportunity(captured.OpportunityId);
                    btn.interactable = false;
                    if (label != null) label.text += " ✓";
                });
            }
        }
    }
}
