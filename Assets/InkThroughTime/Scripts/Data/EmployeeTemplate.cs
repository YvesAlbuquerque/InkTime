using UnityEngine;

namespace InkThroughTime.Data
{
    /// <summary>
    /// Template for creating employees of a given archetype.
    /// Place instances in Assets/InkThroughTime/Data/Employees/.
    /// </summary>
    [CreateAssetMenu(menuName = "InkThroughTime/Data/EmployeeTemplate", fileName = "Employee_")]
    public class EmployeeTemplate : ScriptableObject
    {
        [Header("Identity")]
        public string DisplayName = string.Empty;

        [Header("Starting Stats")]
        [Range(0f, 100f)] public float WritingSkill = 50f;
        [Range(0f, 100f)] public float ArtSkill = 50f;
        [Range(0f, 100f)] public float Speed = 50f;
        [Range(0f, 100f)] public float Adaptability = 50f;
        [Range(0f, 100f)] public float Authenticity = 50f;
        [Range(0f, 100f)] public float StartingCreativity = 100f;

        [Header("Salary")]
        public float MonthlySalary = 300f;
    }
}
