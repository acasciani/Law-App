using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Membership.OpenAuth;
using LawAppWeb.Emails;
using LawAppModel;

namespace LawAppWeb.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect("/", true);
            }

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                
                LoginHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            MembershipCreateStatus status;
            MembershipUser user = Membership.CreateUser(txtUsername.Text.Trim(), txtPassword.Text, txtUsername.Text.Trim(), null, null, false, out status);

            switch (status)
            {
                case MembershipCreateStatus.DuplicateEmail: AlertBox.AddAlert("The email address entered is already registered.", false, AlertType.Error); break;
                case MembershipCreateStatus.DuplicateUserName: AlertBox.AddAlert("The email address entered is already registered.", false, AlertType.Error); break;
                case MembershipCreateStatus.InvalidPassword: AlertBox.AddAlert("The password entered is invalid.", false, AlertType.Error); break;
                case MembershipCreateStatus.Success: AlertBox.AddAlert(string.Format("Successfully created a new account for {0}.", txtUsername.Text.Trim())); break;
                default: AlertBox.AddAlert("An error occurred while trying to create a new account. Please contact support.", false, AlertType.Error); break;
            }

            if (status == MembershipCreateStatus.Success)
            {
                try
                {
                    Guid verifyToken = Guid.NewGuid();

                    using (SignedWebUsersController swuc = new SignedWebUsersController())
                    {
                        SignedWebUser updateUser = swuc.Get((int)user.ProviderUserKey);
                        updateUser.AccountVerifyToken = verifyToken;
                        swuc.Update(updateUser);
                    }

                    // attempt to send email notification
                    Dictionary<string, string> recipients = new Dictionary<string, string>();
                    recipients.Add(txtUsername.Text.Trim(), txtUsername.Text.Trim());

                    Dictionary<string, string> variables = new Dictionary<string, string>();
                    variables.Add("email", txtUsername.Text.Trim());
                    variables.Add("token", verifyToken.ToString());

                    EmailHandler.SendEmail("~/Emails/Account/RegisterSuccess.aspx", true, "Account Support", "lawapp15@gmail.com", recipients, variables);

                    AlertBox.AddAlert(string.Format("Your account must be verified before logging in. An email was sent to {0} with instructions on how to verify your new account. The verification process will expire in 24 hours.", txtUsername.Text.Trim()), false, AlertType.Warning);
                    txtPassword.Text = "";
                    txtConfirmPassword.Text = "";
                    txtUsername.Text = "";
                }
                catch (Exception ex)
                {
                    ex.HandleException();
                    AlertBox.AddAlert(string.Format("An error occurred while trying to send the verification email to {0}. Please contact support.", txtUsername.Text.Trim()), false, AlertType.Error);
                }
            }
        }


        protected void validatorPasswordLength_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = txtPassword.Text.Length >= 8;
        }
    }
}