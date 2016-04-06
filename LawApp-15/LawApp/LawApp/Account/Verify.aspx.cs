using LawAppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawAppWeb.Account
{
    public partial class Verify : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = Request.QueryString["email"] ?? "";
            string tokenIn = Request.QueryString["token"] ?? "";

            Guid token;
            if (!Guid.TryParse(tokenIn, out token))
            {
                Response.Redirect("/", true);
            }

            using (SignedWebUsersController swuc = new SignedWebUsersController())
            {
                SignedWebUser user = swuc.GetWhere(i => i.AccountVerifyToken.HasValue && i.Email.ToLower() == email.Trim().ToLower() && i.AccountVerifyToken.Value == token).FirstOrDefault();

                if (user != null)
                {
                    // verified
                    user.AccountVerifyDate = DateTime.Now;
                    user.AccountVerifyToken = null;
                    swuc.Update(user);
                }
            }

            Response.Redirect("/Account/Login");
        }
    }
}