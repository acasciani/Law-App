using System;

namespace LawAppWeb
{
    public class Week
    {
        public const DayOfWeek StartOfWeek = DayOfWeek.Sunday;
        public DateTime? Monday { get; private set; }
        public DateTime? Tuesday { get; private set; }
        public DateTime? Wednesday { get; private set; }
        public DateTime? Thursday { get; private set; }
        public DateTime? Friday { get; private set; }
        public DateTime? Saturday { get; private set; }
        public DateTime? Sunday { get; private set; }

        private void AddDay(DateTime date)
        {
            switch (date.DayOfWeek)
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
        public static Week Create(DateTime aDate)
        {
            // Get start of the week
            DateTime startDate = aDate;
            while (startDate.DayOfWeek != StartOfWeek) startDate = startDate.AddDays(-1);

            Week week = new Week();
            for (int i = 0; i < 7; i++) week.AddDay(startDate.AddDays(i));

            return week;
        }

        /// <summary>Removes all dates that aren't in the specified month.</summary>
        /// <param name="month">The month to match</param>
        /// <returns>A new Week object with only the dates in the given month</returns>
        public Week RemoveDatesNotInMonth(int month)
        {
            Week cleansed = new Week();
            if (Monday.HasValue && Monday.Value.Month == month) cleansed.AddDay(Monday.Value);
            if (Tuesday.HasValue && Tuesday.Value.Month == month) cleansed.AddDay(Tuesday.Value);
            if (Wednesday.HasValue && Wednesday.Value.Month == month) cleansed.AddDay(Wednesday.Value);
            if (Thursday.HasValue && Thursday.Value.Month == month) cleansed.AddDay(Thursday.Value);
            if (Friday.HasValue && Friday.Value.Month == month) cleansed.AddDay(Friday.Value);
            if (Saturday.HasValue && Saturday.Value.Month == month) cleansed.AddDay(Saturday.Value);
            if (Sunday.HasValue && Sunday.Value.Month == month) cleansed.AddDay(Sunday.Value);

            return cleansed;
        }

        /// <summary>Checks whether or not all the days in this week are null</summary>
        /// <returns>True if all days are null, otherwise False</returns>
        public bool IsNull()
        {
            return !Monday.HasValue && !Tuesday.HasValue && !Wednesday.HasValue && !Thursday.HasValue && !Friday.HasValue && !Saturday.HasValue && !Sunday.HasValue;
        }
    }
}