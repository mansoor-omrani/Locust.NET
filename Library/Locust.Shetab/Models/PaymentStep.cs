using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Shetab.Models
{
    public class PaymentStep
    {
        public int Id { get; set; }
        public int PaymentId { get; set; }
        public int PaymentStepTypeId { get; set; }
        public string PaymentStepTypeCode { get; set; }
        public string PaymentStepTypeCodeName { get; set; }
        public string PaymentStepTypeName { get; set; }
        public DateTime StepDate { get; set; }
        public string StepStatus { get; set; }
        public string StepCode { get; set; }
        public string StepData { get; set; }
        public bool Succeeded { get; set; }
    }
}
