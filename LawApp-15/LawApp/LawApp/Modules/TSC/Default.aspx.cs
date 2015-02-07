using LawAppWeb.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;

namespace LawAppWeb.Modules.TSC
{
    public partial class Default : System.Web.UI.Page
    {

        private List<Calendar> calendars = new List<Calendar>();

        protected void Page_Init(object sender, EventArgs e)
        {
            for (int i = 1; i <= 12; i++)
            {
                Calendar control = (Calendar)LoadControl("~/Source/Controls/Calendar.ascx");
                control.MonthReference = new DateTime(DateTime.Today.Year, i, 1);
                calendars.Add(control);
                CalendarsHolder.Controls.Add(control);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string script = "$('.CalendarDay').click(function(){alert();});";

                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "UpdateClicks", script, true);
            }
        }

        private void CalculateDaysClicked()
        {
            if (calendars != null)
            {
                int totalClicked = 0;
                int totalDays = 0;

                foreach (Calendar calendar in calendars)
                {
                    totalClicked += calendar.Month.CalculateDaysChecked();
                    totalDays += calendar.Month.CalculateDaysInMonthNotNull();
                }
                
                txtDaysClicked.Text = string.Format("You have selected {0} days out of {1} total days for Parent B.", totalClicked, totalDays);
            }
        }
    }
}