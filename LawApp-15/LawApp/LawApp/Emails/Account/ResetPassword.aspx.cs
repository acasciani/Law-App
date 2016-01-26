using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawAppWeb.Emails.Account
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        public string GetResetPath
        {
            get
            {
                return new System.Uri(Page.Request.Url, ResolveUrl("~/Account/ManagePassword.aspx")).AbsoluteUri;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}