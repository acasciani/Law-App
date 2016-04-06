using LawAppModel;
using LawAppWeb.Emails;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.OpenAccess.FetchOptimization;

namespace LawAppWeb.IPN
{
    public partial class Notify : System.Web.UI.Page
    {
        private static string _PayPalEndpoint = null;
        private string PayPalEndpoint
        {
            get
            {
                if (_PayPalEndpoint == null)
                {
                    _PayPalEndpoint = ConfigurationManager.AppSettings["PayPalIPNEndpoint"];
                }
                return _PayPalEndpoint;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            SecurityProtocolType originalProtocolType = ServicePointManager.SecurityProtocol;

            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(PayPalEndpoint);
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                byte[] param = Request.BinaryRead(HttpContext.Current.Request.ContentLength);
                string strRequest = Encoding.ASCII.GetString(param);
                strRequest += "&cmd=_notify-validate";
                req.ContentLength = strRequest.Length;

                using (StreamWriter streamOut = new StreamWriter(req.GetRequestStream(), Encoding.ASCII))
                {
                    streamOut.Write(strRequest);
                    streamOut.Close();

                    using (StreamReader streamIn = new StreamReader(req.GetResponse().GetResponseStream()))
                    {
                        string strResponse = streamIn.ReadToEnd();

                        if (strResponse == "VERIFIED")
                        {
                            // DO WORK
                            Response.StatusCode = 200;

                            AdaptivePaymentsPayIPN ipn = new AdaptivePaymentsPayIPN(HttpContext.Current.Request.Form);

                            using (SubscriptionsController sc = new SubscriptionsController())
                            using (LawApp la = new LawApp())
                            {
                                FetchStrategy fetch = new FetchStrategy();
                                fetch.LoadWith<Subscription>(i => i.SubscriptionPlan);
                                fetch.LoadWith<Subscription>(i => i.SignedWebUser);
                                fetch.LoadWith<SignedWebUser>(i => i.Person);

                                Subscription subscription = sc.GetWhere(i => i.PayKey == ipn.pay_key, fetch).First();
                                PaymentLog log = new PaymentLog()
                                {
                                    CreateDate = DateTime.Now,
                                    Payer_email = ipn.sender_email,
                                    Payment_status = ipn.status.HasValue ? ipn.status.ToString() : null,
                                    Txn_type = ipn.transaction_type,
                                    SubscriptionID = subscription.SubscriptionID
                                };

                                la.Add(log);
                                la.SaveChanges();

                                string emailTemplate;

                                switch (ipn.status)
                                {
                                    case AdaptivePaymentsPayIPN.Status.COMPLETED:
                                        subscription.Active = true;
                                        subscription.EffectiveFrom = DateTime.Now;
                                        subscription.EffectiveTo = LawAppWeb.Account.Subscriptions.SubscriptionsCore.GetEffectiveEndDate(subscription.SubscriptionPlan, subscription.EffectiveFrom.Value);
                                        subscription.InActiveDate = null;
                                        subscription.ModifyDate = DateTime.Now;
                                        emailTemplate = "SubscriptionCompleted.aspx";
                                        break;

                                    default:
                                        subscription.Active = false;
                                        subscription.EffectiveFrom = null;
                                        subscription.EffectiveTo = null;
                                        subscription.InActiveDate = DateTime.Now;
                                        subscription.ModifyDate = DateTime.Now;
                                        emailTemplate = "SubscriptionFailed.aspx";
                                        break;
                                }

                                sc.Update(subscription);

                                // send email notification
                                string email = subscription.SignedWebUser.Email.Trim();
                                string name = email;

                                if(subscription.SignedWebUser.Person != null){
                                    string assembleName = ((subscription.SignedWebUser.Person.FName ?? "").Trim() + " " + (subscription.SignedWebUser.Person.LName ?? "").Trim()).Trim();
                                    name = string.IsNullOrWhiteSpace(assembleName) ? name : assembleName;
                                }

                                Dictionary<string, string> recipients = new Dictionary<string, string>();
                                recipients.Add(email, name);

                                Dictionary<string, string> variables = new Dictionary<string, string>();
                                variables.Add("name", name);
                                variables.Add("product", subscription.SubscriptionPlan.PlanName);
                                variables.Add("effectivefrom", (subscription.EffectiveFrom.HasValue ? subscription.EffectiveFrom.Value : DateTime.MinValue).ToString());
                                variables.Add("effectiveto", (subscription.EffectiveTo.HasValue ? subscription.EffectiveTo.Value : DateTime.MinValue).ToString());

                                EmailHandler.SendEmail("~/Emails/Account/" + emailTemplate, true, "Account Support", "lawapp15+Support@gmail.com", recipients, variables);
                            }
                        }
                        else if (strResponse == "INVALID")
                        {
                            // INVALID DO LOG
                            Response.StatusCode = 200;
                            try
                            {
                                throw new Exception("/IPN/Notify.aspx called, but the validation returned was INVALID from PayPal");
                            }
                            catch (Exception ex)
                            {
                                ex.HandleException(ExceptionPriority.Low);
                            }
                        }
                        else
                        {
                            // SOMETHING WENT TERRIBLY WRONG
                            Response.StatusCode = 500;
                            try
                            {
                                throw new Exception("/IPN/Notify.aspx called, but the validation returned was UNKNOWN from PayPal");
                            }
                            catch (Exception ex)
                            {
                                ex.HandleException(ExceptionPriority.High);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ServicePointManager.SecurityProtocol = originalProtocolType;
                ex.HandleException();
            }

            finally
            {
                ServicePointManager.SecurityProtocol = originalProtocolType;
            }
        }
    }
}