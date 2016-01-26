using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;

namespace LawAppWeb.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((HyperLink)RegisterUser.FindControl("CreateUserStepContainer").FindControl("LoginHyperLink")).NavigateUrl = "Login";

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                ((HyperLink)RegisterUser.FindControl("CreateUserStepContainer").FindControl("LoginHyperLink")).NavigateUrl += "?ReturnUrl=" + returnUrl;
            }

            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        // OAuth: http://go.microsoft.com/fwlink/?LinkId=252803

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            // add them to initial roles... for now hard code, should have a UserType table that maps types to certain roles
            if (Roles.RoleExists("LEVEL0"))
            {
                Roles.AddUserToRole(RegisterUser.UserName, "LEVEL0");
            }

            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, createPersistentCookie: false);

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (!OpenAuth.IsLocalUrl(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect("~/");
        }
    }
}