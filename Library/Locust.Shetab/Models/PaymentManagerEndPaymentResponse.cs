using Locust.Db;
using Locust.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Shetab.Models
{
    public class PaymentManagerEndPaymentResponse : ServiceResponse
    {
        public PaymentProviderEndPaymentResponse ProviderResponse { get; set; }
        public PaymentManagerReversalPaymentResponse ReversalResponse { get; set; }
        public IDictionary<string, string> Request { get; set; }
        public DbResult DbResult { get; set; }
        public string QueryCode { get; set; }
    }
}
