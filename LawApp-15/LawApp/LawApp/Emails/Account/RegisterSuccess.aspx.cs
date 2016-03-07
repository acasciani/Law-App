using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawAppWeb.Emails.Account
{
    public partial class RegisterSuccess : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string email = HttpUtility.UrlDecode(Request.Form.Get("email"));
            string token = HttpUtility.UrlDecode(Request.Form.Get("token"));

            litName.Text = email;
            lnkVerify.NavigateUrl = string.Format(lnkVerify.NavigateUrl, HttpUtility.UrlEncode(email), HttpUtility.UrlEncode(token));
            lnkVerify.Text = lnkVerify.NavigateUrl;
        }
    }
}