using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LawAppWeb.Utilities;

namespace LawAppWeb.Controls
{
    public partial class Calendar : System.Web.UI.UserControl
    {
        // Currently this calendar only supports month view. Future support for year view.
        public Month Month { get; private set; }
        public DateTime MonthReference { get; set; }

        protected void Page_Init(object sender, EventArgs e)
        {
            SetMonth(MonthReference);
            lblMonthYear.Text = MonthReference.ToString("MMMM yyyy");
            CalendarWeeks.DataSource = Month.Weeks;
            CalendarWeeks.DataBind();
        }

        private void SetMonth(DateTime month)
        {
            Dictionary<DateTime, Month> tmp = Session["Months"] as Dictionary<DateTime, Month>;
            if (tmp == null) Session["Months"] = new Dictionary<DateTime, Month>();
            tmp = Session["Months"] as Dictionary<DateTime, Month>;
            if (!tmp.ContainsKey(month)) tmp.Add(month, new Month(month));
            Month = tmp[month];
        }

        protected void On_DayClicked(object sender, EventArgs e)
        {
            CalendarDay day = sender as CalendarDay;

            // If we can't find the control or if the Day doesn't have a date (think dates listed in calendar before the 1st of month)
            if (day == null || day.Date == null) return;

            Day actualDayObj = Month.GetActualDay(day.Date);

            if (actualDayObj.IsChecked)
            {
                day.CssClass = day.CssClass.RemoveClass("day-checked");
            }
            else
            {
                day.CssClass = day.CssClass.AddClass("day-checked");
            }

            actualDayObj.IsChecked = !actualDayObj.IsChecked;
        }
    }
}