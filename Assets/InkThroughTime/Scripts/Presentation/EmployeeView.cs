using UnityEngine;
using UnityEngine.UI;
using TMPro;
using InkThroughTime.Domain;

namespace InkThroughTime.Presentation
{
    /// <summary>
    /// Displays a single employee's state: name, current assignment, and Creativity bar.
    /// </summary>
    public class EmployeeView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _nameLabel;
        [SerializeField] private TextMeshProUGUI _assignmentLabel;
        [SerializeField] private Slider _creativityBar;

        private EmployeeState _employee;

        public string EmployeeId => _employee?.Id ?? string.Empty;

        public void Bind(EmployeeState employee)
        {
            _employee = employee;
            Refresh();
        }

        /// <summary>
        /// Called each frame from a parent presenter to reflect live Creativity changes.
        /// </summary>
        public void Refresh()
        {
            if (_employee == null) return;

            if (_nameLabel != null)
                _nameLabel.text = _employee.Name;

            if (_assignmentLabel != null)
                _assignmentLabel.text = _employee.Assignment.ToString();

            if (_creativityBar != null)
                _creativityBar.value = _employee.Creativity / 100f;
        }
    }
}
