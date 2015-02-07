using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawAppWeb
{
    [Serializable]
    public class Day
    {
        public DateTime Date { get; private set; }
        public bool IsChecked { get; set; }

        public Day(DateTime date)
        {
            Date = date;
        }

        public override bool Equals(object obj)
        {
            Day day = obj as Day;
            if (day != null) return day.Date == Date;
            return base.Equals(obj);
        }
    }
}