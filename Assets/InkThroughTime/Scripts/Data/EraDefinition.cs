using UnityEngine;
using InkThroughTime.Domain;

namespace InkThroughTime.Data
{
    /// <summary>
    /// Configures the characteristics of one playable era.
    /// Place instances in Assets/InkThroughTime/Data/Eras/.
    /// </summary>
    [CreateAssetMenu(menuName = "InkThroughTime/Data/EraDefinition", fileName = "Era_")]
    public class EraDefinition : ScriptableObject
    {
        [Header("Identity")]
        public Era Era;
        public string DisplayName = string.Empty;
        public int StartYear;
        public int EndYear;

        [Header("Creativity Rates")]
        [Tooltip("Creativity drained per tick when writing or drawing in this era.")]
        public float WritingDrawingDrainPerTick = 2f;

        [Tooltip("Creativity recovered per tick when idle.")]
        public float IdleRecoveryPerTick = 0.5f;

        [Tooltip("Creativity recovered per tick when resting.")]
        public float RestRecoveryPerTick = 2f;

        [Header("Economy")]
        [Tooltip("Base sale price multiplier for comics published in this era.")]
        public float BaseSaleMultiplier = 1f;

        [Tooltip("Monthly equipment upkeep cost for era-specific equipment.")]
        public float EquipmentUpkeepCost = 50f;
    }
}
