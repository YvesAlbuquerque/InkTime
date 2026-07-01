using System;
using System.Collections.Generic;

namespace InkThroughTime.Domain
{
    /// <summary>
    /// Root serializable game session state. Contains all authoritative simulation data.
    /// This class owns no Unity dependencies and is safe to serialize/deserialize with Newtonsoft.Json.
    /// </summary>
    [Serializable]
    public class GameSession
    {
        public int SaveVersion = 1;
        public CalendarState Calendar = new CalendarState();
        public StudioState Studio = new StudioState();
        public List<EmployeeState> Employees = new List<EmployeeState>();
        public List<ProjectState> Projects = new List<ProjectState>();
        public List<PublishedComic> PublishedComics = new List<PublishedComic>();
        public List<IpState> IpCatalogue = new List<IpState>();
    }
}
