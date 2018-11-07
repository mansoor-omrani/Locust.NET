using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Shetab.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string PaymentCode { get; set; }
        public int BankTypeId { get;set; }
        public string BankTypeCode { get;set; }
        public string BankTypeCodeName { get;set; }
        public string BankTypeName { get;set; }
        public string Amount { get; set; }
        public string Info { get; set; }
        public string Data { get; set; }
        public List<PaymentStep> Steps { get; set; }
        public Payment()
        {
            Steps = new List<PaymentStep>();
        }
    }
}
