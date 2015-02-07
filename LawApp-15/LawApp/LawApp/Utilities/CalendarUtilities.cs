using System;
using LawAppWeb;

namespace LawAppWeb.Utilities
{
    public static class CalendarUtilities
    {
        public static Week RemoveDatesNotInMonth(this Week reference, int month)
        {
            return reference.RemoveDatesNotInMonth(month);
        }

        public static bool IsEntireWeekNull(this Week reference)
        {
            return reference.IsNull();
        }

        /// <summary>Performs a deep search on each day</summary>
        public static bool Equals(this Week week1, Week week2)
        {
            bool equals = week1.Monday == week2.Monday && week1.Tuesday == week2.Tuesday && week1.Wednesday == week2.Wednesday
                && week1.Thursday == week2.Thursday && week1.Friday == week2.Friday && week1.Saturday == week2.Saturday && week1.Sunday == week2.Sunday;

            return equals;
        }

        /// <summary>Checks if the two days have the same month and year</summary>
        public static bool Equals(this DateTime day1, DateTime day2)
        {
            return day1.Month == day2.Month && day1.Year == day2.Year;
        }
    }
}