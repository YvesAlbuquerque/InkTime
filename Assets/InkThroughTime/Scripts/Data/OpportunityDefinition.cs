using UnityEngine;
using InkThroughTime.Domain;

namespace InkThroughTime.Data
{
    /// <summary>
    /// Defines a nostalgia or reprint opportunity available during the 2030 retrospective.
    /// Place instances in Assets/InkThroughTime/Data/Offers/.
    /// </summary>
    [CreateAssetMenu(menuName = "InkThroughTime/Data/OpportunityDefinition", fileName = "Offer_")]
    public class OpportunityDefinition : ScriptableObject
    {
        [Header("Identity")]
        public string DisplayName = string.Empty;

        [Header("Trigger Conditions")]
        [Tooltip("Minimum IP recognition required to trigger this opportunity.")]
        [Range(0f, 100f)] public float MinIpRecognition = 50f;

        [Tooltip("Minimum number of publications in the series required.")]
        public int MinPublicationCount = 1;

        [Header("Value")]
        [Tooltip("Cash reward when this opportunity is accepted.")]
        public float RewardValue = 500f;

        [TextArea(2, 4)]
        public string Description = string.Empty;
    }
}
