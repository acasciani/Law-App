using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LawAppWeb.Utilities;

namespace LawAppWeb.Modules.TSC
{
    public partial class Existing : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AuthorizePage(PermissionHelper.AddNew);

            if (IsPostBack)
            {
                return;
            }

            BindResults();
        }

        private void BindResults()
        {
            using (TSC_CalendarsController c = new TSC_CalendarsController())
            {
                int userId = this.GetCurrentUser().WebUserId;

                Results.DataSource = c.GetWhere(i => i.WebUserId == userId).Select(r => new
                {
                    CaseNumber = r.CaseNumber,
                    CaseName = r.CaseName,
                    Exhibit = r.Exhibit,
                    CalendarId = r.CalendarId
                }).OrderBy(i => i.CaseName).ThenBy(i => i.CaseNumber).ThenBy(i => i.Exhibit);
                Results.DataBind();
            }
        }
    }
}