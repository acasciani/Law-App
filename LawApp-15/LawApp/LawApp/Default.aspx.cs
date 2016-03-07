using LawAppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LawAppWeb.Utilities;

namespace LawAppWeb
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated || this.GetCurrentUser() == null)
            {
                Response.Redirect("~/Welcome", true);
            }

            if (IsPostBack)
            {
                return;
            }

            bool hasTSCAccess = this.IsCurrentUserAuthorized(LawAppWeb.Modules.TSC.PermissionHelper.AddNew);

            pnlTSCLinks.Visible = hasTSCAccess;
            pnlTSCNoAccess.Visible = !hasTSCAccess;

            LoadPersonInfo();
        }

        private void LoadPersonInfo()
        {
            SignedWebUser user = this.GetCurrentUser();

            if (user.Person == null)
            {
                litPersonName.Text = user.Email;
            }
            else
            {
                litPersonName.Text = user.Person.FName;
            }
        }
    }
}