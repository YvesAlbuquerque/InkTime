using System;
using InkThroughTime.Domain;

namespace InkThroughTime.Application
{
    /// <summary>
    /// Manages the IP catalogue: tracks recognition growth and first-print ownership.
    /// </summary>
    public class CatalogueService
    {
        public event Action<IpState> OnIpRecognitionChanged;

        private readonly GameSession _session;

        public CatalogueService(GameSession session)
        {
            _session = session;
        }

        /// <summary>
        /// Called at month-end to update IP recognition for published comics.
        /// </summary>
        public void ProcessMonthEnd()
        {
            int currentYear = _session.Calendar.Year;
            int currentMonth = _session.Calendar.Month;

            foreach (var comic in _session.PublishedComics)
            {
                if (comic.PublicationYear == currentYear && comic.PublicationMonth == currentMonth)
                {
                    UpdateIpForComic(comic);
                }
            }
        }

        /// <summary>
        /// Registers a new IP series in the catalogue.
        /// </summary>
        public IpState CreateIp(string name, Era introducedEra)
        {
            var ip = new IpState
            {
                IpId = Guid.NewGuid().ToString("N"),
                Name = name,
                IntroducedEra = introducedEra
            };
            _session.IpCatalogue.Add(ip);
            return ip;
        }

        /// <summary>
        /// Returns IP by id, or null.
        /// </summary>
        public IpState FindIp(string ipId)
        {
            foreach (var ip in _session.IpCatalogue)
                if (ip.IpId == ipId) return ip;
            return null;
        }

        private void UpdateIpForComic(PublishedComic comic)
        {
            var ip = FindIp(comic.IpId);
            if (ip == null) return;

            float receptionScore = comic.Evaluation?.WeightedTotal ?? 0f;
            ip.RecordPublication(receptionScore);
            OnIpRecognitionChanged?.Invoke(ip);
        }
    }
}
