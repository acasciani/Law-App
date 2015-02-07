using System;
using System.Collections.Generic;
using LawAppWeb.Utilities;

namespace LawAppWeb
{
    [Serializable]
    public class Month
    {
        public IList<Week> Weeks { get; private set; }
        public bool IsDirty { get; private set; }

        public Month(DateTime reference)
        {
            AddWeeks(reference);
        }

        public Month(int month, int year)
        {
            AddWeeks(new DateTime(year, month, 1));
        }

        /// <summary>Does a deep search to see if there is a week that has the same Days (the week must match each Day to be True)</summary>
        public bool Contains(Week searchWeek)
        {
            if (Weeks.Contains(searchWeek)) return true;

            //Do deep search
            foreach (Week week in Weeks)
            {
                if (week.Equals(searchWeek)) { return true; }
            }

            return false;
        }

        private void AddWeeks(DateTime month)
        {
            Weeks = new List<Week>();

            decimal totalDays = DateTime.DaysInMonth(month.Year, month.Month);
            int totalDaysInt = DateTime.DaysInMonth(month.Year, month.Month);

            DateTime refDate = new DateTime(month.Year, month.Month, 1);
            bool valid = true;
            while(valid)
            {
                Week week = Week.Create(new Day(refDate)).RemoveDatesNotInMonth(month.Month);
                if (!week.IsNull() && !Contains(week))
                {
                    Weeks.Add(week);
                }

                refDate = refDate.AddDays(7);
                int currentWeekLastDay = week.LastNonNullDay().Date.Day;
                if (currentWeekLastDay < totalDays && (refDate.Month != month.Month || refDate.Year != month.Year))
                {
                    Week specialCaseWeek = Week.Create(new Day(new DateTime(month.Year, month.Month, totalDaysInt))).RemoveDatesNotInMonth(month.Month);
                    if (!specialCaseWeek.IsNull() && !Contains(specialCaseWeek)) Weeks.Add(specialCaseWeek);
                    valid = false;
                    break;
                }
                else if (currentWeekLastDay == totalDays)
                {
                    valid = false;
                    break;
                }
            }
        }

        public int CalculateDaysChecked()
        {
            int total = 0;

            foreach (Week week in Weeks) total += week.CalculateDaysChecked();
            
            return total;
        }

        public int CalculateDaysInMonthNotNull()
        {
            int total = 0;

            foreach (Week week in Weeks) total += week.CalculateDaysInWeekNotNull();

            return total;
        }

        public Day GetActualDay(Day refDay)
        {
            Day foundDay = null;
            foreach (Week week in Weeks)
            {
                foundDay = week.GetDay(refDay);
                if (foundDay != null)
                {
                    return foundDay;
                }
            }
            return null;
        }
    }
}