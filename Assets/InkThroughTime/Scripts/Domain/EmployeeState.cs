using System;

namespace InkThroughTime.Domain
{
    /// <summary>
    /// Represents a single employee in the studio.
    /// All numeric attributes are in the [0, 100] range unless noted.
    /// </summary>
    [Serializable]
    public class EmployeeState
    {
        public string Id = string.Empty;
        public string Name = string.Empty;

        // Skills
        public float WritingSkill;
        public float ArtSkill;
        public float Speed;
        public float Adaptability;
        public float Authenticity;

        // Creativity: 0–100; drained by work, recovered by rest/idle
        public float Creativity = 100f;

        public EmployeeAssignment Assignment = EmployeeAssignment.Idle;

        /// <summary>
        /// ID of the project this employee is currently assigned to, or null.
        /// </summary>
        public string CurrentProjectId = null;

        /// <summary>
        /// Apply one simulation tick of Creativity change based on current assignment.
        /// </summary>
        /// <param name="drainRate">Drain per tick when writing or drawing.</param>
        /// <param name="idleRecovery">Recovery per tick when idle.</param>
        /// <param name="restRecovery">Recovery per tick when resting.</param>
        public void TickCreativity(float drainRate, float idleRecovery, float restRecovery)
        {
            switch (Assignment)
            {
                case EmployeeAssignment.Writing:
                case EmployeeAssignment.Drawing:
                    Creativity = Math.Max(0f, Creativity - drainRate);
                    break;
                case EmployeeAssignment.Idle:
                    Creativity = Math.Min(100f, Creativity + idleRecovery);
                    break;
                case EmployeeAssignment.Resting:
                    Creativity = Math.Min(100f, Creativity + restRecovery);
                    break;
            }
        }
    }

    public enum EmployeeAssignment
    {
        Idle,
        Writing,
        Drawing,
        Resting
    }
}
