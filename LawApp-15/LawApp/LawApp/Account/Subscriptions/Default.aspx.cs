using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayPal.AdaptivePayments;
using PayPal.AdaptivePayments.Model;
using LawAppModel;

namespace LawAppWeb.Account.Subscriptions
{
    public partial class Default : Page
    {
        private readonly string CancelSubscription = "~/Account/Subscriptions/CancelSubscription.aspx?token={0}";
        private readonly string FinishSubscription = "~/Account/Subscriptions/CompleteSubscription.aspx?token={0}";


        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        private void CreatePlan(int subscriptionPlanID, int userID)
        {
            Guid token = Guid.NewGuid();

                            using (SubscriptionPlansController spc = new SubscriptionPlansController())
                using (SubscriptionsController sc = new SubscriptionsController())
                {
                    SubscriptionPlan plan = spc.Get(subscriptionPlanID);

            AdaptivePaymentsService service = new AdaptivePaymentsService();

            RequestEnvelope envelope = new RequestEnvelope("en-US");

            PayRequest req = new PayRequest(envelope, "PAY", new System.Uri(Page.Request.Url, ResolveClientUrl(string.Format(CancelSubscription, token))).AbsoluteUri, "USD", GetReceivers(plan.PlanCost), new System.Uri(Page.Request.Url, ResolveClientUrl(string.Format(FinishSubscription, token))).AbsoluteUri);
            PayResponse response = service.Pay(req);

            if (response.error.Count() == 0)
            {
                // we have a response, now let's add it to the database
                    

                    DateTime currBillDate = DateTime.Now;

                    Subscription subscription = new Subscription()
                    {
                        Active = false,
                        NextBillDate = GetNextBillingDate(plan, currBillDate),
                        CreateDate = currBillDate,
                        SubscriptionPlanID = subscriptionPlanID,
                        UserID = userID,
                        PayKey = response.payKey,
                        Token = token
                    };

                    sc.AddNew(subscription);

                    Response.Redirect(string.Format("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_ap-payment&paykey={0}", response.payKey));
            }
            else
            {
                throw new Exception("Error occurred generating preapproval key");
            }

                }
        }

        private static ReceiverList GetReceivers(decimal totalAmount)
        {
            List<Receiver> receivers = new List<Receiver>();

            // owner 65 %
            receivers.Add(new Receiver(totalAmount * 0.65M)
            {
                primary = true,
                email = "lawapp15@gmail.com"
            });

            // developer 35%
            receivers.Add(new Receiver(totalAmount - receivers[0].amount.Value)
            {
                primary = false,
                email = "lawapp15-facilitator@gmail.com"
            });

            return new ReceiverList(receivers);
        }


        private static DateTime GetNextBillingDate(SubscriptionPlan plan, DateTime currentBillDate)
        {
            DateTime nextBillDate;

            switch (plan.SubscriptionDurationID)
            {
                case 1:  // year
                    nextBillDate = currentBillDate.AddYears(plan.DurationLength);
                    break;

                case 2: // month
                    nextBillDate = currentBillDate.AddMonths(plan.DurationLength);
                    break;

                case 3: // day
                    nextBillDate = currentBillDate.AddDays(plan.DurationLength);
                    break;

                default: throw new Exception("Specified subscription duration id is invalid");
            }

            return nextBillDate;
        }

        protected void lnkSubscribe_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;

            divSubscribeToProduct.Visible = true;
            litProductName.Text = lnk.CommandName;

            List<int> planIDs = lnk.CommandArgument.Split(',').Select(i => int.Parse(i)).ToList();

            using (SubscriptionPlansController spc = new SubscriptionPlansController())
            {
                var plans = spc.GetWhere(i => planIDs.Contains(i.SubscriptionPlanID) && i.IsActive).Select(i=> new {
                    SubscriptionPlanID = i.SubscriptionPlanID,
                    Text = i.PlanName + " - " + i.PlanCost,
                    Price = i.PlanCost
                }).ToList();

                chkPlans.DataSource = plans.OrderBy(i => i.Price);
                chkPlans.DataTextField = "Text";
                chkPlans.DataValueField = "SubscriptionPlanID";
                chkPlans.DataBind();
            }
        }

        protected void chkPlans_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SubscriptionPlanID = int.Parse(chkPlans.SelectedValue);

            using (SubscriptionPlansController spc = new SubscriptionPlansController())
            {
                SubscriptionPlan plan = spc.Get(SubscriptionPlanID);

                lblPlanCost.Text = plan.PlanCost.ToString("C");
                lblPlanExpires.Text = GetNextBillingDate(plan, DateTime.Today).ToLocalTime().ToString("MMMM dd, yyyy");
                lblDescription.Text = plan.PlanName;
            }
        }

        protected void lnkPurchaseSubscription_Click(object sender, EventArgs e)
        {
            int SubscriptionPlanID = int.Parse(chkPlans.SelectedValue);

            using (SubscriptionPlansController spc = new SubscriptionPlansController())
            {
                SubscriptionPlan plan = spc.Get(SubscriptionPlanID);

                CreatePlan(plan.SubscriptionPlanID, this.GetCurrentUser().WebUserId);
            }
        }




    }
}