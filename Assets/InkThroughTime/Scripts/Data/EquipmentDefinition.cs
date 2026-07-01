using UnityEngine;
using InkThroughTime.Domain;

namespace InkThroughTime.Data
{
    /// <summary>
    /// Defines studio equipment available in a specific era.
    /// Place instances in Assets/InkThroughTime/Data/Equipment/.
    /// </summary>
    [CreateAssetMenu(menuName = "InkThroughTime/Data/EquipmentDefinition", fileName = "Equipment_")]
    public class EquipmentDefinition : ScriptableObject
    {
        [Header("Identity")]
        public string EquipmentId = string.Empty;
        public string DisplayName = string.Empty;
        public Era RequiredEra;

        [Header("Costs")]
        public float PurchaseCost = 500f;
        public float MonthlyUpkeep = 50f;

        [Header("Bonuses")]
        [Range(0f, 50f)]
        [Tooltip("Flat quality bonus added to the quality component of the reception formula.")]
        public float QualityBonus = 0f;

        [Range(0f, 50f)]
        [Tooltip("Flat speed bonus applied when this equipment is in use.")]
        public float SpeedBonus = 0f;
    }
}
