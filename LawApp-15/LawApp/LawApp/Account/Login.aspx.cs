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
    }
}