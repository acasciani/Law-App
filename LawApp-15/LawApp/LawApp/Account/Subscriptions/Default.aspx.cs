using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PayPal.AdaptivePayments;
using PayPal.AdaptivePayments.Model;
using LawAppModel;
using Telerik.OpenAccess.FetchOptimization;
using System.Configuration;

namespace LawAppWeb.Account.Subscriptions
{
    public partial class Default : Page
    {
        private readonly string CancelSubscription = "~/Account/Subscriptions/CancelSubscription.aspx?token={0}";
        private readonly string FinishSubscription = "~/Account/Subscriptions/CompleteSubscription.aspx?token={0}";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Session["SubscriptionCompleteMessage"] as string))
            {
                bool isError = Session["SubscriptionCompleteMessageIsError"] as bool? ?? false;
                AlertBox.AddAlert(Session["SubscriptionCompleteMessage"] as string, false, isError ? AlertType.Error : AlertType.Success);

                Session.Remove("SubscriptionCompleteMessage");
                Session.Remove("SubscriptionCompleteMessageIsError");
            }

            if (IsPostBack)
            {
                return;
            }

            LoadSubscription_TSC();
        }

        private void LoadSubscription_TSC()
        {
            using (SubscriptionsController sc = new SubscriptionsController())
            {
                int userID = this.GetCurrentUser().WebUserId;
                List<int> planIDs = new List<int>() { 1, 3, 5, 6 };

                FetchStrategy fetch = new FetchStrategy();
                fetch.LoadWith<Subscription>(i => i.SubscriptionPlan);

                Subscription subscription = sc.GetWhere(i => i.UserID == userID && planIDs.Contains(i.SubscriptionPlanID) && i.Active && i.EffectiveTo.HasValue && i.EffectiveFrom.HasValue, fetch).FirstOrDefault();

                if (subscription != null)
                {
                    // currently has active TSC calendar
                    lblSubTSC_Expires.Text = subscription.EffectiveTo.Value.ToString("MMMM dd, yyyy h:mm tt");
                    lblSubTSC_Plan.Text = subscription.SubscriptionPlan.PlanName;
                    lblSubTSC_PurchasedOn.Text = subscription.EffectiveFrom.Value.ToString("MMMM dd, yyyy");
                    divTSCDetails.Visible = true;
                    divTSCDetails_NoPlan.Visible = false;
                }
                else
                {
                    bool doesPendingExist = sc.GetWhere(i => i.UserID == userID && planIDs.Contains(i.SubscriptionPlanID) && !i.Active && !i.EffectiveTo.HasValue && !i.EffectiveFrom.HasValue && !i.InActiveDate.HasValue).Count() > 0;
                    divTSCDetails.Visible = false;
                    divTSCDetails_NoPlan.Visible = true;

                    divTSCDetails_NoPlan_None.Visible = !doesPendingExist;
                    divTSCDetails_NoPlan_Pending.Visible = doesPendingExist;
                }

            }
        }


        private void CreatePlan(int subscriptionPlanID, int userID)
        {
            Guid token = Guid.NewGuid();

            try
            {
                using (SubscriptionPlansController spc = new SubscriptionPlansController())
                using (SubscriptionsController sc = new SubscriptionsController())
                {
                    SubscriptionPlan plan = spc.Get(subscriptionPlanID);

                    AdaptivePaymentsService service = new AdaptivePaymentsService();

                    RequestEnvelope envelope = new RequestEnvelope("en-US");

                    PayRequest req = new PayRequest(envelope, "PAY", new System.Uri(Page.Request.Url, ResolveClientUrl(string.Format(CancelSubscription, token))).AbsoluteUri, "USD", GetReceivers(plan.PlanCost), new System.Uri(Page.Request.Url, ResolveClientUrl(string.Format(FinishSubscription, token))).AbsoluteUri);
                    req.feesPayer = "EACHRECEIVER";//each receiver pays fees
                    req.ipnNotificationUrl = ConfigurationManager.AppSettings["PayIPNEndpiont"].Trim();

                    PayResponse response = service.Pay(req);

                    if (response.error.Count() == 0)
                    {
                        // we have a response, now let's add it to the database


                        DateTime currBillDate = DateTime.Now;

                        Subscription subscription = new Subscription()
                        {
                            Active = false,
                            NextBillDate = SubscriptionsCore.GetNextBillingDate(plan, currBillDate),
                            CreateDate = currBillDate,
                            SubscriptionPlanID = subscriptionPlanID,
                            UserID = userID,
                            PayKey = response.payKey,
                            Token = token
                        };

                        sc.AddNew(subscription);

                        Response.Redirect(string.Format("https://www.paypal.com/cgi-bin/webscr?cmd=_ap-payment&paykey={0}", response.payKey));
                    }
                    else
                    {
                        throw new Exception("Error occurred generating preapproval key: " +  string.Join(", ", response.error));
                    }
                }

            }
            catch (Exception ex)
            {
                ex.HandleException();
            }
        }

        private static ReceiverList GetReceivers(decimal totalAmount)
        {
            List<Receiver> receivers = new List<Receiver>();

            // developer 35%
            receivers.Add(new Receiver(totalAmount)
            {
                primary = true,
                email = "lawapp15@gmail.com"
            });

            // owner 65 %
            receivers.Add(new Receiver(totalAmount * .65M)
            {
                primary = false,
                email = "leitman@gmail.com"
            });

            return new ReceiverList(receivers);
        }


        protected void lnkSubscribe_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;

            divSubscribeToProduct.Visible = true;
            litProductName.Text = lnk.CommandName;

            List<int> planIDs = lnk.CommandArgument.Split(',').Select(i => int.Parse(i)).ToList();

            using (SubscriptionPlansController spc = new SubscriptionPlansController())
            {
                var plans = spc.GetWhere(i => planIDs.Contains(i.SubscriptionPlanID) && i.IsActive).Select(i => new
                {
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
                lblPlanExpires.Text = SubscriptionsCore.GetNextBillingDate(plan, DateTime.Today).ToLocalTime().ToString("MMMM dd, yyyy");
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