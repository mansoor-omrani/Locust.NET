using Locust.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Shetab.Models
{
    public class PaymentProviderReversalPaymentResponse
    {
        public string ProviderType { get; set; }
        public DateTime Date { get; set; }
        public virtual dynamic Status { get; set; }
        public bool Succeeded { get; set; }
        public PaymentProviderReversalPaymentResponse()
        {
            Date = DateTime.Now;
        }
        public PaymentProviderReversalPaymentResponse(INow now)
        {
            Date = now.Value;
        }
    }
    public class PaymentProviderReversalPaymentResponse<T> : PaymentProviderReversalPaymentResponse
    {
        private dynamic _status;
        private T _strongStatus;
        public override dynamic Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;

                try
                {
                    _strongStatus = (T)_status;
                }
                catch
                {
                    _strongStatus = default(T);
                }
            }
        }
        public T StrongStatus
        {
            get { return _strongStatus; }
            set { _strongStatus = value; }
        }
        public PaymentProviderReversalPaymentResponse() : base()
        {
        }
        public PaymentProviderReversalPaymentResponse(INow now) : base(now)
        {
        }
    }
}
