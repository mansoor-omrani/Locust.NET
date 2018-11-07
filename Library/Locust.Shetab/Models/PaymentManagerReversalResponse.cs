using Locust.Db;
using Locust.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Shetab.Models
{
    public class PaymentManagerReversalPaymentResponse : ServiceResponse
    {
        public PaymentProviderReversalPaymentResponse ProviderResponse { get; set; }
        public ReversalRequest Request { get; set; }
        public DbResult DbResult { get; set; }
    }
}
