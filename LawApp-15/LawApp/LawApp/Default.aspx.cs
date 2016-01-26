using LawAppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawAppWeb
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Welcome");
            }

            if (IsPostBack)
            {
                return;
            }

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