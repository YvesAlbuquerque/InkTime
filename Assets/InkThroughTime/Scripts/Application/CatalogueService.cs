using System;
using InkThroughTime.Domain;

namespace InkThroughTime.Application
{
    /// <summary>
    /// Owns create/find/edit operations for persistent creative IP roots.
    /// Historical era/economy progression is maintained separately for scaffold compatibility.
    /// </summary>
    public class CatalogueService
    {
        public event Action<IpState> OnIpChanged;

        private readonly GameSession _session;

        public CatalogueService(GameSession session)
        {
            _session = session ?? throw new ArgumentNullException(nameof(session));
        }

        public IpState CreateIp(
            string title,
            string premise = "",
            string toneNotes = "",
            string visualStyleNotes = "")
        {
            var ip = IpState.Create(title, premise, toneNotes, visualStyleNotes);
            _session.IpCatalogue.Add(ip);
            OnIpChanged?.Invoke(ip);
            return ip;
        }

        public bool EditIp(
            string ipId,
            string title,
            string premise,
            string toneNotes,
            string visualStyleNotes)
        {
            var ip = FindIp(ipId);
            if (ip == null) return false;

            ip.UpdateCreativeIdentity(title, premise, toneNotes, visualStyleNotes);
            OnIpChanged?.Invoke(ip);
            return true;
        }

        /// <summary>
        /// Returns an IP by its stable identifier, or null when no match exists.
        /// </summary>
        public IpState FindIp(string ipId)
        {
            if (string.IsNullOrEmpty(ipId)) return null;

            foreach (var ip in _session.IpCatalogue)
                if (ip.IpId == ipId) return ip;

            return null;
        }

        /// <summary>
        /// Compatibility hook for the superseded era/economy scaffold.
        /// Progression is deliberately kept out of IpState.
        /// </summary>
        public void ProcessMonthEnd()
        {
            int currentYear = _session.Calendar.Year;
            int currentMonth = _session.Calendar.Month;

            foreach (var comic in _session.PublishedComics)
            {
                if (comic.PublicationYear != currentYear ||
                    comic.PublicationMonth != currentMonth)
                    continue;

                UpdateLegacyProgression(comic);
            }
        }

        private void UpdateLegacyProgression(PublishedComic comic)
        {
            if (FindIp(comic.IpId) == null) return;

            var progression = FindLegacyProgression(comic.IpId);
            if (progression == null)
            {
                progression = new LegacyIpProgressionState
                {
                    IpId = comic.IpId,
                    IntroducedEra = comic.Era
                };
                _session.LegacyIpProgression.Add(progression);
            }

            float receptionScore = comic.Evaluation?.WeightedTotal ?? 0f;
            progression.RecordPublication(receptionScore);
        }

        private LegacyIpProgressionState FindLegacyProgression(string ipId)
        {
            foreach (var progression in _session.LegacyIpProgression)
                if (progression.IpId == ipId) return progression;

            return null;
        }
    }
}
