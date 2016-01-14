using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawAppWeb
{
    public partial class NewLanding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginForm_LoggedIn(object sender, EventArgs e)
        {
            Response.Redirect("~/Modules/TSC/Default.aspx");
        }

        protected void loginForm_LoginError(object sender, EventArgs e)
        {

        }

        protected void loginForm_Authenticate(object sender, AuthenticateEventArgs e)
        {

        }
    }
}