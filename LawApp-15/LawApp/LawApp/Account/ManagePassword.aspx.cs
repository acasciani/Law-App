using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNet.Membership.OpenAuth;
using System.Web.UI.WebControls;
using LawAppWeb.Controls;

namespace LawAppWeb.Account
{
    public partial class ManagePassword : Page
    {
        protected void Page_Load()
        {
            if (!IsPostBack)
            {
                // Render success message
                var message = Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/ManagePassword");

                    var successMessage =
                        message == "ChangePwdSuccess" ? "Your password has been successfully changed."
                        : message == "SetPwdSuccess" ? "Your password has been successfully set."
                        : message == "RemoveLoginSuccess" ? "The external login was removed."
                        : String.Empty;

                    if (!String.IsNullOrEmpty(successMessage))
                    {
                        AlertBox.AddAlert(successMessage);
                    }
                }
            }
        }

        protected void changePassword_ChangePasswordError(object sender, EventArgs e)
        {
            ((AlertBox)((ChangePassword)sender).FindControl("AlertBox")).AddAlert("test");
        }
    }
}