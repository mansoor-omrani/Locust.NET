using Locust.Db;
using Locust.Service;
using Locust.Shetab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Shetab.Models
{
    public class PaymentManagerBeginPaymentResponse: ServiceResponse<int>
    {
        public PaymentProviderBeginPaymentResponse ProviderResponse { get; set; }
        public BeginPaymentRequest Request { get; set; }
        public DbResult<int> DbResult { get; set; }
    }
}
