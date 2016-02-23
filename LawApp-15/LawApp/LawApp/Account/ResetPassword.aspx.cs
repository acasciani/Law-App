using LawAppModel;
using LawAppWeb.Emails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawAppWeb.Account
{
    public partial class ResetPassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                MembershipUser user = Membership.Provider.GetUser(UserName.Text, false);

                if (user == null)
                {
                    AlertBox.AddAlert("There is not account with that email address.", false, AlertType.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(user.Email))
                {
                    AlertBox.AddAlert("Unable to reset account password. Please contact support for more help.", false, AlertType.Error);
                    return;
                }

                if (!Membership.Provider.EnablePasswordReset)
                {
                    AlertBox.AddAlert("Unable to reset account password at this time.", false, AlertType.Error);
                    return;
                }

                string newPassword = user.ResetPassword();

                using (SignedWebUsersController swuc = new SignedWebUsersController())
                {
                    SignedWebUser webUser = swuc.GetWhere(i => i.WebUserId == (int)user.ProviderUserKey).FirstOrDefault();

                    string firstName = webUser != null && webUser.Person != null ? webUser.Person.FName : null;
                    string lastName = webUser != null && webUser.Person != null ? webUser.Person.LName : null;


                    Dictionary<string, string> recipients = new Dictionary<string, string>();
                    recipients.Add(user.Email, (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName)) ? (firstName + " " + lastName) : user.Email);

                    Dictionary<string, string> variables = new Dictionary<string, string>();
                    variables.Add("name", string.IsNullOrWhiteSpace(firstName) ? user.Email : firstName);
                    variables.Add("newpw", newPassword);

                    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    EmailHandler.SendEmail("~/Emails/Account/ResetPassword.aspx", true, "Account Support", "support@mylawtools.com", recipients, variables);

                    AlertBox.AddAlert("Successfully reset your password. Please check your email with instructions on how to continue.");
                }
            }
            catch (Exception ex)
            {
                ex.HandleException();
                AlertBox.AddAlert("An error occurred while trying to reset your password.", false, AlertType.Error);
                return;
            }
        }
    }
}