using LawAppWeb.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI;
using LawAppWeb.Utilities;

namespace LawAppWeb.Modules.TSC
{
    public partial class Default : System.Web.UI.Page
    {

        private List<Calendar> calendars = new List<Calendar>();

        protected void Page_Init(object sender, EventArgs e)
        {
            this.AuthorizePage(PermissionHelper.AddNew);

            if (IsPostBack)
            {
                return;
            }

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
                if (!Page.ClientScript.IsClientScriptIncludeRegistered(this.GetType(), "TSC_Main"))
                {
                    Page.ClientScript.RegisterClientScriptInclude(this.GetType(), "TSC_Main", "../../Scripts/Modules/TSC/Main.js");
                }
            }
        }

        protected void Exhibit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CaseName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void CaseNumber_TextChanged(object sender, EventArgs e)
        {

        }
    }
}