using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Shetab.Models
{
    public class BeginPaymentRequest
    {
        public string PaymentCode { get; set; }
        public string BankType { get; set; }
        public decimal Amount { get; set; }
        public string Info { get; set; }
        public string Data { get; set; }
        public string ReturnUrl { get; set; }
    }
}
