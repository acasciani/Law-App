using LawAppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawAppWeb.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((HyperLink)loginForm.FindControl("RegisterHyperLink")).NavigateUrl = "Register";

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                ((HyperLink)loginForm.FindControl("RegisterHyperLink")).NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void loginForm_LoggedIn(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }

        protected void loginForm_LoginError(object sender, EventArgs e)
        {
            TextBox txtUsername = loginForm.FindControl("UserName") as TextBox;

            using (SignedWebUsersController swuc = new SignedWebUsersController())
            {
                SignedWebUser user = swuc.GetWhere(i => i.Email == txtUsername.Text).FirstOrDefault();

                if (user != null && !user.AccountVerifyDate.HasValue && user.AccountVerifyToken.HasValue)
                {
                    AlertBox.AddAlert("This account requires verification. Please see your email for further instructions.", false, AlertType.Warning);
                }
            }
        }
    }
}