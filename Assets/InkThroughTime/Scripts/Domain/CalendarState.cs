using System;

namespace InkThroughTime.Domain
{
    /// <summary>
    /// Tracks the in-game calendar date and current era.
    /// </summary>
    [Serializable]
    public class CalendarState
    {
        public int Year = 1980;
        public int Month = 1;
        public Era CurrentEra = Era.Eighties;

        public static Era EraForYear(int year)
        {
            if (year >= 2030) return Era.Retrospective;
            if (year >= 2020) return Era.Twenties;
            if (year >= 2010) return Era.Tens;
            if (year >= 2000) return Era.TwoThousands;
            if (year >= 1990) return Era.Nineties;
            return Era.Eighties;
        }

        public void AdvanceMonth()
        {
            Month++;
            if (Month > 12)
            {
                Month = 1;
                Year++;
                CurrentEra = EraForYear(Year);
            }
        }
    }

    public enum Era
    {
        Eighties,       // 1980–1989: handmade pencil and ink
        Nineties,       // 1990–1999: photocopy and zine production
        TwoThousands,   // 2000–2009: early digital art
        Tens,           // 2010–2019: polished online production
        Twenties,       // 2020–2029: generative abundance and authenticity backlash
        Retrospective   // 2030: retrospective only, no production
    }
}
