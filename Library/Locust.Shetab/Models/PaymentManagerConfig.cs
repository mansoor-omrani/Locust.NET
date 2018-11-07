using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Shetab.Models
{
    public class PaymentManagerConfig
    {
        public bool SaveOnlySuccessfulOperations { get; set; }
        public bool AutoReverseFailedPayments { get; set; }
        public PaymentManagerConfig()
        {
        }
    }
}
