using System;
using UnityEngine;
using InkThroughTime.Domain;

namespace InkThroughTime.Application
{
    /// <summary>
    /// Configuration ScriptableObject for SimulationClock.
    /// </summary>
    [CreateAssetMenu(menuName = "InkThroughTime/SimulationClockConfig", fileName = "SimulationClockConfig")]
    public class SimulationClockConfig : ScriptableObject
    {
        [Tooltip("Simulated days per real-time second at normal speed.")]
        public float DaysPerSecond = 1f;

        [Tooltip("Multiplier applied in fast-forward mode.")]
        public float FastForwardMultiplier = 4f;

        [Tooltip("Creativity drain per tick when writing or drawing.")]
        public float WritingDrawingDrainPerTick = 2f;

        [Tooltip("Creativity recovery per tick when idle.")]
        public float IdleRecoveryPerTick = 0.5f;

        [Tooltip("Creativity recovery per tick when resting.")]
        public float RestRecoveryPerTick = 2f;
    }

    /// <summary>
    /// Deterministic simulation clock. Advances in simulated days and fires
    /// month-end and era-change events. Does not use real wall-clock time for logic.
    /// </summary>
    public class SimulationClock
    {
        public event Action OnMonthEnd;
        public event Action<Era> OnEraChanged;

        private readonly SimulationClockConfig _config;
        private readonly GameFlowController _flowController;
        private readonly ProductionService _productionService;
        private readonly GameSession _session;

        private bool _running;
        private bool _fastForward;
        private float _accumulatedDays;
        private Era _lastKnownEra;

        public bool IsRunning => _running;
        public bool IsFastForward => _fastForward;

        public SimulationClock(
            SimulationClockConfig config,
            GameFlowController flowController,
            ProductionService productionService,
            GameSession session)
        {
            _config = config;
            _flowController = flowController;
            _productionService = productionService;
            _session = session;
            _lastKnownEra = session.Calendar.CurrentEra;
        }

        public void Start() => _running = true;
        public void Stop() => _running = false;
        public void Pause() => _running = false;
        public void Resume() => _running = true;
        public void SetFastForward(bool enabled) => _fastForward = enabled;

        /// <summary>
        /// Called by Unity's Update loop from a MonoBehaviour owner.
        /// </summary>
        public void Tick(float deltaTime)
        {
            if (!_running) return;

            float speed = _fastForward ? _config.FastForwardMultiplier : 1f;
            _accumulatedDays += deltaTime * _config.DaysPerSecond * speed;

            while (_accumulatedDays >= 1f)
            {
                _accumulatedDays -= 1f;
                AdvanceOneDay();
            }
        }

        private int _currentDay = 1;
        private const int DaysPerMonth = 30; // simplified fixed month length

        private void AdvanceOneDay()
        {
            TickCreativity();
            _productionService.TickProduction();

            _currentDay++;
            if (_currentDay > DaysPerMonth)
            {
                _currentDay = 1;
                AdvanceMonth();
            }
        }

        private void AdvanceMonth()
        {
            var cal = _session.Calendar;
            Era prevEra = cal.CurrentEra;

            cal.AdvanceMonth();

            _flowController.ProcessMonthEnd();
            OnMonthEnd?.Invoke();

            if (cal.CurrentEra != prevEra)
            {
                OnEraChanged?.Invoke(cal.CurrentEra);
            }
        }

        private void TickCreativity()
        {
            foreach (var emp in _session.Employees)
            {
                emp.TickCreativity(
                    _config.WritingDrawingDrainPerTick,
                    _config.IdleRecoveryPerTick,
                    _config.RestRecoveryPerTick);
            }
        }
    }
}
