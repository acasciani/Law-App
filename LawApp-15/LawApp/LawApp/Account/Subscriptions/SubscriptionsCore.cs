using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using PayPal.AdaptivePayments;
using PayPal.AdaptivePayments.Model;
using LawAppModel;

namespace LawAppWeb.Account.Subscriptions
{
    public class SubscriptionsCore
    {
        public static DateTime GetNextBillingDate(SubscriptionPlan plan, DateTime currentBillDate)
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

        public static DateTime GetEffectiveEndDate(SubscriptionPlan plan, DateTime effectiveStartDate)
        {
            DateTime effectiveEnd;

            switch (plan.SubscriptionDurationID)
            {
                case 1:  // year
                    effectiveEnd = effectiveStartDate.AddYears(plan.DurationLength);
                    break;

                case 2: // month
                    effectiveEnd = effectiveStartDate.AddMonths(plan.DurationLength);
                    break;

                case 3: // day
                    effectiveEnd = effectiveStartDate.AddDays(plan.DurationLength);
                    break;

                default: throw new Exception("Specified subscription duration id is invalid");
            }

            return effectiveEnd;
        }
    }
}