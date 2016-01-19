using LawAppModel;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Telerik.OpenAccess;
using System.Linq.Expressions;
using LawAppWeb.Account.Subscriptions;
using Telerik.OpenAccess.FetchOptimization;
using System.Globalization;

namespace LawAppWeb
{
    public partial class IPNController : ApiController
    {
        private enum VerifyResponse { VERIFIED, INVALID }

        [ActionName("CreateSubscription")]
        [HttpPost]
        public async Task<HttpResponseMessage> CreateSubscription()
        {
            string post = await Request.Content.ReadAsStringAsync();

            if (Verify(true, post) == VerifyResponse.INVALID)
            {
                // Everything passed validation. Now continue with logic
                PayPalIPNModel model = new PayPalIPNModel(HttpContext.Current.Request.Form);

                using (SubscriptionsController sc = new SubscriptionsController())
                using(LawApp la = new LawApp())
                {
                    if (model.PaymentStatus == PayPalPaymentStatus.Completed || model.PaymentStatus == PayPalPaymentStatus.Pending)
                    {
                        // if there was a completed status then we need to make sure its not a duplicate transaction
                        if (la.PaymentLogs.Where(i =>  i.Txn_id.ToUpper() == model.txn_id.ToUpper() && i.Payment_status == model.payment_status).Count() == 0)
                        {
                            // no existing transaction id with payment status completed... add it and perform complete subscription 
                            FetchStrategy fetch = new FetchStrategy();
                            fetch.LoadWith<Subscription>(i => i.SubscriptionPlan);

                            Subscription relatedSubscription = sc.GetWhere(i => i.Token.HasValue && i.Token.Value == model.AppToken && !i.EffectiveFrom.HasValue && !i.EffectiveTo.HasValue, fetch).FirstOrDefault();

                            DateTime paymentDate;

                            string dateReplaced = model.payment_date.Replace("PDT", "-7:00").Replace("PST", "-8:00");
                            if (relatedSubscription != null && DateTime.TryParseExact(dateReplaced, "HH:mm:ss MMM dd, yyyy zzz", CultureInfo.InvariantCulture, DateTimeStyles.None, out paymentDate))
                            {
                                // create payment log
                                PaymentLog payment = new PaymentLog()
                                {
                                    Payer_email = model.payer_email,
                                    Payment_status = model.payment_status,
                                    SubscriptionID = relatedSubscription.SubscriptionID,
                                    Txn_id = model.txn_id,
                                    Txn_type = model.txn_type,
                                    Receiver_email = model.receiver_email,
                                    CreateDate = DateTime.Now
                                };
                                la.Add(payment);
                                la.SaveChanges();

                                // found it, update
                                relatedSubscription.EffectiveFrom = paymentDate;
                                relatedSubscription.EffectiveTo = SubscriptionsCore.GetNextBillingDate(relatedSubscription.SubscriptionPlan, paymentDate);
                                relatedSubscription.InActiveDate = null;
                                relatedSubscription.ModifyDate = DateTime.Now;
                                relatedSubscription.Active = true;
                                sc.Update(relatedSubscription);
                            }
                        }
                    }
                    else
                    {
                        // remove subscription
                        Subscription relatedSubscription = sc.GetWhere(i => i.Token.HasValue && i.Token.Value == model.AppToken && i.EffectiveFrom.HasValue && i.EffectiveTo.HasValue).FirstOrDefault();

                        if (relatedSubscription != null)
                        {
                            // create payment log
                            PaymentLog payment = new PaymentLog()
                            {
                                Payer_email = model.payer_email,
                                Payment_status = model.payment_status,
                                SubscriptionID = relatedSubscription.SubscriptionID,
                                Txn_id = model.txn_id,
                                Txn_type = model.txn_type,
                                Receiver_email = model.receiver_email,
                                CreateDate = DateTime.Now
                            };
                            la.Add(payment);
                            la.SaveChanges();

                            // found it, update
                            relatedSubscription.InActiveDate = DateTime.Now;
                            relatedSubscription.ModifyDate = DateTime.Now;
                            relatedSubscription.Active = false;
                            sc.Update(relatedSubscription);
                        }
                    }
                }
            }


            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        private VerifyResponse Verify(bool isSandbox, string post)
        {
            string response = "";

            string url = isSandbox ? "https://www.sandbox.paypal.com/cgi-bin/webscr" : "https://www.paypal.com/cgi-bin/webscr";

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";

            //must keep the original intact and pass back to PayPal with a _notify-validate command
            string data = "cmd=_notify-validate";
            data += "&" + post;

            webRequest.ContentLength = data.Length;

            //Send the request to PayPal and get the response                 
            using (StreamWriter streamOut = new StreamWriter(webRequest.GetRequestStream(), System.Text.Encoding.ASCII)){
                streamOut.Write(data);
                streamOut.Close();
            }

            using (StreamReader streamIn = new StreamReader(webRequest.GetResponse().GetResponseStream()))
            {
                response = streamIn.ReadToEnd();
                streamIn.Close();
            }

            switch (response)
            {
                case "VERIFIED": return VerifyResponse.VERIFIED;
                default: return VerifyResponse.INVALID;
            }
        }
    }
}