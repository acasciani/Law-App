using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using PayPal.AdaptivePayments;
using PayPal.AdaptivePayments.Model;

namespace LawAppWeb.Account.Subscriptions
{
    public class SubscriptionsCore
    {
        public static string PayPal_AppID = ConfigurationManager.AppSettings["PayPal_AppID"];


    }
}