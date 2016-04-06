using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawAppWeb.Emails.Account
{
    public partial class SubscriptionCompleted : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string name = HttpUtility.UrlDecode(Request.Form.Get("name"));
            string product = HttpUtility.UrlDecode(Request.Form.Get("product"));
            DateTime effectiveFrom = DateTime.Parse(HttpUtility.UrlDecode(Request.Form.Get("effectivefrom")));
            DateTime effectiveTo = DateTime.Parse(HttpUtility.UrlDecode(Request.Form.Get("effectiveto")));

            litName.Text = name;
            litProductName.Text = product;
            litActiveFrom.Text = effectiveFrom.ToLongDateString() + " " + effectiveFrom.ToShortTimeString();
            litActiveTo.Text = effectiveTo.ToLongDateString() + " " + effectiveTo.ToShortTimeString();
        }
    }
}