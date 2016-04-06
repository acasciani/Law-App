using LawAppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.OpenAccess.FetchOptimization;

namespace LawAppWeb.Account.Subscriptions
{
    public partial class CancelSubscription : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // The api should pass back a application specific guid which is the token for this payment
            Guid token;

            if (Guid.TryParse(Request.QueryString["token"], out token))
            {
                try
                {
                    using (SubscriptionsController sc = new SubscriptionsController())
                    {
                        FetchStrategy fetch = new FetchStrategy();
                        fetch.LoadWith<Subscription>(i => i.SubscriptionPlan);

                        int userID = this.GetCurrentUser().WebUserId;
                        Subscription subscription = sc.GetWhere(i => i.Token == token && i.UserID == userID && i.Active == false && !i.EffectiveTo.HasValue && !i.EffectiveFrom.HasValue, fetch).FirstOrDefault();

                        if (subscription != null)
                        {
                            // delete it
                            sc.Delete(subscription.SubscriptionID);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Session["SubscriptionCompleteMessage"] = "An error occurred while trying to cancel the subscription process. Please contact technical support.";
                    Session["SubscriptionCompleteMessageIsError"] = true;
                    ex.HandleException();
                }
            }

            Response.Redirect("~/Account/Subscriptions/Default.aspx");
        }
    }
}