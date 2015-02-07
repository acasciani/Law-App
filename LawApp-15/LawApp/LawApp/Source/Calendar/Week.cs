using System;

namespace LawAppWeb
{
    [Serializable]
    public class Week
    {
        public const DayOfWeek StartOfWeek = DayOfWeek.Sunday;
        public Day Monday { get; private set; }
        public Day Tuesday { get; private set; }
        public Day Wednesday { get; private set; }
        public Day Thursday { get; private set; }
        public Day Friday { get; private set; }
        public Day Saturday { get; private set; }
        public Day Sunday { get; private set; }

        private void AddDay(Day date)
        {
            switch (date.Date.DayOfWeek)
            {
                case DayOfWeek.Monday: Monday = date; break;
                case DayOfWeek.Tuesday: Tuesday = date; break;
                case DayOfWeek.Wednesday: Wednesday = date; break;
                case DayOfWeek.Thursday: Thursday = date; break;
                case DayOfWeek.Friday: Friday = date; break;
                case DayOfWeek.Saturday: Saturday = date; break;
                case DayOfWeek.Sunday: Sunday = date; break;
            }
        }

        /// <summary>Creates a new week given a date within the week. Uses the StartOfWeek as the first day of the week (e.g. Sunday).</summary>
        /// <param name="aDate">A date that occurs within the week to create.</param>
        /// <returns>A Week with populated dates</returns>
        public static Week Create(Day aDate)
        {
            // Get start of the week
            DateTime startDate = aDate.Date;
            while (startDate.DayOfWeek != StartOfWeek) startDate = startDate.AddDays(-1);

            Week week = new Week();
            for (int i = 0; i < 7; i++) week.AddDay(new Day(startDate.Date.AddDays(i)));

            return week;
        }

        /// <summary>Removes all dates that aren't in the specified month.</summary>
        /// <param name="month">The month to match</param>
        /// <returns>A new Week object with only the dates in the given month</returns>
        public Week RemoveDatesNotInMonth(int month)
        {
            Week cleansed = new Week();
            if (Monday != null && Monday.Date.Month == month) cleansed.AddDay(Monday);
            if (Tuesday != null && Tuesday.Date.Month == month) cleansed.AddDay(Tuesday);
            if (Wednesday != null && Wednesday.Date.Month == month) cleansed.AddDay(Wednesday);
            if (Thursday != null && Thursday.Date.Month == month) cleansed.AddDay(Thursday);
            if (Friday != null && Friday.Date.Month == month) cleansed.AddDay(Friday);
            if (Saturday != null && Saturday.Date.Month == month) cleansed.AddDay(Saturday);
            if (Sunday != null && Sunday.Date.Month == month) cleansed.AddDay(Sunday);

            return cleansed;
        }

        /// <summary>Checks whether or not all the days in this week are null</summary>
        /// <returns>True if all days are null, otherwise False</returns>
        public bool IsNull()
        {
            return Monday == null && Tuesday == null && Wednesday == null && Thursday == null && Friday == null && Saturday == null && Sunday == null;
        }

        public int CalculateDaysChecked()
        {
            int total = 0;
            if (Monday != null && Monday.IsChecked) total++;
            if (Tuesday != null && Tuesday.IsChecked) total++;
            if (Wednesday != null && Wednesday.IsChecked) total++;
            if (Thursday != null && Thursday.IsChecked) total++;
            if (Friday != null && Friday.IsChecked) total++;
            if (Saturday != null && Saturday.IsChecked) total++;
            if (Sunday != null && Sunday.IsChecked) total++;

            return total;
        }

        public int CalculateDaysInWeekNotNull()
        {
            int total = 0;
            if (Monday != null) total++;
            if (Tuesday != null) total++;
            if (Wednesday != null) total++;
            if (Thursday != null) total++;
            if (Friday != null) total++;
            if (Saturday != null) total++;
            if (Sunday != null) total++;

            return total;
        }

        public Day LastNonNullDay()
        {
            if(Saturday != null) return Saturday;
            if(Friday != null) return Friday;
            if(Thursday != null) return Thursday;
            if(Wednesday != null) return Wednesday;
            if(Tuesday != null) return Tuesday;
            if(Monday != null) return Monday;
            if(Sunday != null) return Sunday;

            throw new ApplicationException("All days are null");
        }

        public Day GetDay(Day anotherDay)
        {
            if (anotherDay.Equals(Sunday)) return Sunday;
            if (anotherDay.Equals(Monday)) return Monday;
            if (anotherDay.Equals(Tuesday)) return Tuesday;
            if (anotherDay.Equals(Wednesday)) return Wednesday;
            if (anotherDay.Equals(Thursday)) return Thursday;
            if (anotherDay.Equals(Friday)) return Friday;
            if (anotherDay.Equals(Saturday)) return Saturday;
            return null;
        }
    }
}