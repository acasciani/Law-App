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
        private Month Month { get; set; }
        public DateTime MonthReference { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetMonth(MonthReference);

                lblMonthYear.Text = MonthReference.ToString("MMMM yyyy");
                CalendarWeeks.DataSource = Month.Weeks;
                CalendarWeeks.DataBind();
            }
        }

        private void SetMonth(DateTime month)
        {
            Month = new Month(month);
        }

        protected void On_DayClicked(object sender, EventArgs e)
        {
            CalendarDay day = sender as CalendarDay;

            // If we can't find the control or if the Day doesn't have a date (think dates listed in calendar before the 1st of month)
            if (day == null || !day.Date.HasValue) return;

            if (day.IsChecked)
            {
                day.CssClass = day.CssClass.RemoveClass("day-checked");
            }
            else
            {
                day.CssClass = day.CssClass.AddClass("day-checked");
            }
        }
    }
}