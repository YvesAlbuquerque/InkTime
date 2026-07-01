using System;

namespace InkThroughTime.Domain
{
    /// <summary>
    /// Tracks studio-level financial and reputation state.
    /// </summary>
    [Serializable]
    public class StudioState
    {
        public float Cash = 2000f;
        public int Reputation = 0;
        public int ConsecutiveNegativeMonths = 0;

        /// <summary>
        /// Call at month-end after applying income and expenses.
        /// Returns true if bankruptcy is triggered (3+ consecutive negative months).
        /// </summary>
        public bool UpdateNegativeMonthCounter()
        {
            if (Cash < 0f)
            {
                ConsecutiveNegativeMonths++;
            }
            else
            {
                ConsecutiveNegativeMonths = 0;
            }

            return ConsecutiveNegativeMonths >= 3;
        }
    }
}
