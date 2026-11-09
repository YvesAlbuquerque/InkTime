using System;

namespace InkThroughTime.Domain
{
    /// <summary>
    /// Persistent creative identity for an InkTime fictional property.
    /// Publication, AI-provider, economy, and presentation concerns do not belong here.
    /// </summary>
    [Serializable]
    public class IpState
    {
        public string IpId = string.Empty;
        public string Title = string.Empty;
        public string Premise = string.Empty;
        public string ToneNotes = string.Empty;
        public string VisualStyleNotes = string.Empty;

        public static IpState Create(
            string title,
            string premise = "",
            string toneNotes = "",
            string visualStyleNotes = "")
        {
            var ip = new IpState
            {
                IpId = Guid.NewGuid().ToString("N")
            };

            ip.UpdateCreativeIdentity(title, premise, toneNotes, visualStyleNotes);
            return ip;
        }

        public void UpdateCreativeIdentity(
            string title,
            string premise,
            string toneNotes,
            string visualStyleNotes)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("An IP title is required.", nameof(title));

            Title = title.Trim();
            Premise = NormalizeOptional(premise);
            ToneNotes = NormalizeOptional(toneNotes);
            VisualStyleNotes = NormalizeOptional(visualStyleNotes);
        }

        private static string NormalizeOptional(string value)
        {
            return string.IsNullOrWhiteSpace(value) ? string.Empty : value.Trim();
        }
    }

    /// <summary>
    /// Compatibility-only state for the superseded era/economy scaffold.
    /// Kept separate so historical progression does not define the renewed IP entity.
    /// </summary>
    [Serializable]
    public class LegacyIpProgressionState
    {
        public string IpId = string.Empty;
        public Era IntroducedEra;
        public int PublicationCount;
        public float Recognition;
        public bool OwnsFirstPrint;
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
