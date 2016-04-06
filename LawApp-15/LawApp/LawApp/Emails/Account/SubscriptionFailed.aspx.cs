using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawAppWeb.Emails.Account
{
    public partial class SubscriptionFailed : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = HttpUtility.UrlDecode(Request.Form.Get("name"));
            string product = HttpUtility.UrlDecode(Request.Form.Get("product"));

            litName.Text = name;
            litProductName.Text = product;
        }
    }
}