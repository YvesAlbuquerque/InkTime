using System;

namespace InkThroughTime.Domain
{
    /// <summary>
    /// Represents a studio-owned intellectual property (comic series).
    /// </summary>
    [Serializable]
    public class IpState
    {
        public string IpId = string.Empty;
        public string Name = string.Empty;
        public Era IntroducedEra;

        /// <summary>
        /// Number of published comics in this IP series. Drives recognition growth.
        /// </summary>
        public int PublicationCount;

        /// <summary>
        /// Recognition score [0, 100]. Grows with each publication.
        /// </summary>
        public float Recognition;

        /// <summary>
        /// Whether the studio owns the first-print of the debut issue.
        /// </summary>
        public bool OwnsFirstPrint;

        /// <summary>
        /// Estimated collectible value of the first print (in-game currency).
        /// </summary>
        public float FirstPrintValue;

        public void RecordPublication(float receptionScore)
        {
            PublicationCount++;
            Recognition = Math.Min(100f, Recognition + receptionScore * 10f);
            if (PublicationCount == 1)
            {
                OwnsFirstPrint = true;
                FirstPrintValue = 50f + receptionScore * 200f;
            }
        }
    }
}
