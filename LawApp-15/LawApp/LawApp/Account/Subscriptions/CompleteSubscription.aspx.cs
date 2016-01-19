using LawAppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.OpenAccess.FetchOptimization;
using PayPal.AdaptivePayments;
using PayPal.AdaptivePayments.Model;

namespace LawAppWeb.Account.Subscriptions
{
    public partial class CompleteSubscription : Page
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
                            // ensure payment is verified
                            AdaptivePaymentsService service = new AdaptivePaymentsService();
                            PaymentDetailsRequest request = new PaymentDetailsRequest(new RequestEnvelope("en-US"))
                            {
                                payKey = subscription.PayKey
                            };
                            var details = service.PaymentDetails(request);

                            switch (details.status.ToUpper())
                            {
                                case "COMPLETED":
                                    Session["SubscriptionCompleteMessage"] = "Product subscription completed successfully. It may take up-to one hour for the subscription process to complete. Please check back.";
                                    Session["SubscriptionCompleteMessageIsError"] = false;
                                    break;

                                case "ERROR":
                                    sc.Delete(subscription.SubscriptionID);
                                    Session["SubscriptionCompleteMessage"] = "An error occurred with the payment and the subscription has been reverted. Please try again.";
                                    Session["SubscriptionCompleteMessageIsError"] = true;
                                    break;

                                default:
                                    Session["SubscriptionCompleteMessage"] = "The payment has not been verified yet. Please check back later.";
                                    Session["SubscriptionCompleteMessageIsError"] = true;
                                    break;
                            }
                        }
                        else
                        {
                            Session["SubscriptionCompleteMessage"] = "Unable to locate the subscription you signed up. Please contact technical support.";
                            Session["SubscriptionCompleteMessageIsError"] = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Session["SubscriptionCompleteMessage"] = "An error occurred while trying to complete the subscription process. Please contact technical support.";
                    Session["SubscriptionCompleteMessageIsError"] = true;
                }
            }

            Response.Redirect("~/Account/Subscriptions/Default.aspx");
        }
    }
}