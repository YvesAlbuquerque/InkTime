using UnityEngine;
using InkThroughTime.Application;
using InkThroughTime.Domain;

namespace InkThroughTime.Presentation
{
    /// <summary>
    /// Represents one of the studio stations (Writing, Art, Rest) in the scene.
    /// Handles employee assignment interactions.
    /// </summary>
    public class StationPresenter : MonoBehaviour
    {
        [SerializeField] private EmployeeAssignment _stationType;
        [SerializeField] private Transform _employeeSlot;

        private InkGameRoot _root;

        private void Start()
        {
            _root = FindObjectOfType<InkGameRoot>();
        }

        /// <summary>
        /// Called when an EmployeeView is dragged onto this station.
        /// </summary>
        public void OnEmployeeDropped(string employeeId)
        {
            if (_root == null) return;

            var session = _root.Session;
            foreach (var emp in session.Employees)
            {
                if (emp.Id != employeeId) continue;
                emp.Assignment = _stationType;
                break;
            }
        }

        public EmployeeAssignment StationType => _stationType;
    }
}
