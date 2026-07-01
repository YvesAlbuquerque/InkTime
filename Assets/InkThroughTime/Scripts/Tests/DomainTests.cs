using NUnit.Framework;
using InkThroughTime.Domain;

namespace InkThroughTime.Tests
{
    /// <summary>
    /// Unit tests for CalendarState and era boundary detection.
    /// All tests run without Unity dependency (Domain is noEngineReferences).
    /// </summary>
    public class CalendarStateTests
    {
        [Test]
        public void EraForYear_1980_ReturnsEighties()
        {
            Assert.AreEqual(Era.Eighties, CalendarState.EraForYear(1980));
        }

        [Test]
        public void EraForYear_1989_ReturnsEighties()
        {
            Assert.AreEqual(Era.Eighties, CalendarState.EraForYear(1989));
        }

        [Test]
        public void EraForYear_1990_ReturnsNineties()
        {
            Assert.AreEqual(Era.Nineties, CalendarState.EraForYear(1990));
        }

        [Test]
        public void EraForYear_2000_ReturnsTwoThousands()
        {
            Assert.AreEqual(Era.TwoThousands, CalendarState.EraForYear(2000));
        }

        [Test]
        public void EraForYear_2010_ReturnsTens()
        {
            Assert.AreEqual(Era.Tens, CalendarState.EraForYear(2010));
        }

        [Test]
        public void EraForYear_2020_ReturnsTwenties()
        {
            Assert.AreEqual(Era.Twenties, CalendarState.EraForYear(2020));
        }

        [Test]
        public void EraForYear_2030_ReturnsRetrospective()
        {
            Assert.AreEqual(Era.Retrospective, CalendarState.EraForYear(2030));
        }

        [Test]
        public void AdvanceMonth_WrapsDecemberToJanuaryNextYear()
        {
            var cal = new CalendarState { Year = 1985, Month = 12 };
            cal.AdvanceMonth();
            Assert.AreEqual(1986, cal.Year);
            Assert.AreEqual(1, cal.Month);
        }

        [Test]
        public void AdvanceMonth_CrossingEra_UpdatesCurrentEra()
        {
            var cal = new CalendarState { Year = 1989, Month = 12, CurrentEra = Era.Eighties };
            cal.AdvanceMonth();
            Assert.AreEqual(Era.Nineties, cal.CurrentEra);
        }
    }

    /// <summary>
    /// Unit tests for the studio bankruptcy counter logic.
    /// </summary>
    public class StudioStateTests
    {
        [Test]
        public void UpdateNegativeMonthCounter_ThreeConsecutiveNegative_ReturnsBankruptcy()
        {
            var studio = new StudioState { Cash = -100f, ConsecutiveNegativeMonths = 2 };
            bool bankrupt = studio.UpdateNegativeMonthCounter();
            Assert.IsTrue(bankrupt);
            Assert.AreEqual(3, studio.ConsecutiveNegativeMonths);
        }

        [Test]
        public void UpdateNegativeMonthCounter_CashPositive_ResetsCounter()
        {
            var studio = new StudioState { Cash = 500f, ConsecutiveNegativeMonths = 2 };
            studio.UpdateNegativeMonthCounter();
            Assert.AreEqual(0, studio.ConsecutiveNegativeMonths);
        }

        [Test]
        public void UpdateNegativeMonthCounter_TwoNegative_NotBankrupt()
        {
            var studio = new StudioState { Cash = -50f, ConsecutiveNegativeMonths = 1 };
            bool bankrupt = studio.UpdateNegativeMonthCounter();
            Assert.IsFalse(bankrupt);
        }
    }

    /// <summary>
    /// Unit tests for EmployeeState Creativity drain and recovery.
    /// </summary>
    public class EmployeeStateTests
    {
        [Test]
        public void TickCreativity_Writing_DrainsCreativity()
        {
            var emp = new EmployeeState { Creativity = 80f, Assignment = EmployeeAssignment.Writing };
            emp.TickCreativity(drainRate: 5f, idleRecovery: 1f, restRecovery: 3f);
            Assert.AreEqual(75f, emp.Creativity, 0.001f);
        }

        [Test]
        public void TickCreativity_Idle_RecoversCreativity()
        {
            var emp = new EmployeeState { Creativity = 50f, Assignment = EmployeeAssignment.Idle };
            emp.TickCreativity(drainRate: 5f, idleRecovery: 2f, restRecovery: 5f);
            Assert.AreEqual(52f, emp.Creativity, 0.001f);
        }

        [Test]
        public void TickCreativity_Resting_RecoversMoreThanIdle()
        {
            var empRest = new EmployeeState { Creativity = 50f, Assignment = EmployeeAssignment.Resting };
            var empIdle = new EmployeeState { Creativity = 50f, Assignment = EmployeeAssignment.Idle };
            empRest.TickCreativity(drainRate: 5f, idleRecovery: 1f, restRecovery: 4f);
            empIdle.TickCreativity(drainRate: 5f, idleRecovery: 1f, restRecovery: 4f);
            Assert.Greater(empRest.Creativity, empIdle.Creativity);
        }

        [Test]
        public void TickCreativity_NeverExceeds100()
        {
            var emp = new EmployeeState { Creativity = 99f, Assignment = EmployeeAssignment.Resting };
            emp.TickCreativity(drainRate: 5f, idleRecovery: 1f, restRecovery: 5f);
            Assert.LessOrEqual(emp.Creativity, 100f);
        }

        [Test]
        public void TickCreativity_NeverFallsBelowZero()
        {
            var emp = new EmployeeState { Creativity = 2f, Assignment = EmployeeAssignment.Writing };
            emp.TickCreativity(drainRate: 10f, idleRecovery: 1f, restRecovery: 3f);
            Assert.GreaterOrEqual(emp.Creativity, 0f);
        }
    }

    /// <summary>
    /// Unit tests for ComicEvaluation weighted total.
    /// </summary>
    public class ComicEvaluationTests
    {
        [Test]
        public void WeightedTotal_AllHalf_ReturnsHalf()
        {
            var eval = new ComicEvaluation
            {
                EraInterestScore = 0.5f,
                QualityScore = 0.5f,
                CreativityScore = 0.5f,
                EvaluationScore = 0.5f
            };
            Assert.AreEqual(0.5f, eval.WeightedTotal, 0.001f);
        }

        [Test]
        public void WeightedTotal_AllOne_ReturnsOne()
        {
            var eval = new ComicEvaluation
            {
                EraInterestScore = 1f,
                QualityScore = 1f,
                CreativityScore = 1f,
                EvaluationScore = 1f
            };
            Assert.AreEqual(1f, eval.WeightedTotal, 0.001f);
        }

        [Test]
        public void WeightedTotal_AllZero_ReturnsZero()
        {
            var eval = new ComicEvaluation();
            Assert.AreEqual(0f, eval.WeightedTotal, 0.001f);
        }
    }
}
