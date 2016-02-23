using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawAppModel
{
    public class AdaptivePaymentsPayIPN
    {
        public enum Status { CANCELED, CREATED, COMPLETED, INCOMPLETE, ERROR, REVERSALERROR, PROCESSING, PENDING }
        public enum PayAction { PAY, CREATE }

        public string transaction_type { get; set; }
        public Status? status { get; set; }
        public string sender_email { get; set; }
        public PayAction? action_type { get; set; }
        public DateTime? payment_request_date { get; set; }
        public bool reverse_all_parallel_payments_on_error { get; set; }
        public string pay_key { get; set; }
        public string trackingId { get; set; }

        // Populate
        public AdaptivePaymentsPayIPN(NameValueCollection form)
        {
            bool tryBool;
            DateTime tryDateTime;
            Status tryStatus;
            PayAction tryAction;

            this.transaction_type = form["transaction_type"];
            this.status = Enum.TryParse<Status>(form["status"], out tryStatus) ? (Status?)tryStatus : null;
            this.sender_email = form["sender_email"];
            this.action_type = Enum.TryParse<PayAction>(form["action_type"], out tryAction) ? tryAction : (PayAction?)null;
            this.payment_request_date = DateTime.TryParse(form["payment_request_date"], out tryDateTime) ? tryDateTime : (DateTime?)null;
            this.reverse_all_parallel_payments_on_error = bool.TryParse(form["reverse_all_parallel_payments_on_error"], out tryBool) ? tryBool : false;
            this.pay_key = form["pay_key"];
            this.trackingId = form["trackingId"];
        }
    }
}
