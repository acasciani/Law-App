using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawAppWeb.Controls
{
    public partial class Calendar : System.Web.UI.UserControl
    {
        // Currently this calendar only supports month view. Future support for year view.
        private Month Month { get; set; }
        public DateTime MonthReference { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            SetMonth(MonthReference);

            lblMonthYear.Text = MonthReference.ToString("MMMM yyyy");
            CalendarWeeks.DataSource = Month.Weeks;
            CalendarWeeks.DataBind();
        }

        private void SetMonth(DateTime month)
        {
            Month = new Month(month);
        }
    }
}