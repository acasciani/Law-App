using System;
using System.Collections.Generic;
using LawAppWeb.Utilities;

namespace LawAppWeb
{
    public class Month
    {
        public IList<Week> Weeks { get; private set; }

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

            for (int i = 0; i < totalDays / 7; i++)
            {
                DateTime refDate = new DateTime(month.Year, month.Month, (i * 7) + 1);
                Week week = Week.Create(refDate).RemoveDatesNotInMonth(month.Month);
                if (!week.IsNull() && !Contains(week))
                {
                    Weeks.Add(week);
                }
            }
        }
    }
}