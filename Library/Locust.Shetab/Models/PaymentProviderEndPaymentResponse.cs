using Locust.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Shetab.Models
{
    public class PaymentProviderEndPaymentResponse
    {
        public string ProviderType { get; set; }
        public dynamic Code { get; set; }
        public dynamic Query { get; set; }
        public DateTime Date { get; set; }
        public virtual dynamic Status { get; set; }
        public bool Succeeded { get; set; }
        public PaymentProviderEndPaymentResponse()
        {
            Date = DateTime.Now;
        }
        public PaymentProviderEndPaymentResponse(INow now)
        {
            Date = now.Value;
        }
    }
    public class PaymentProviderEndPaymentResponse<T> : PaymentProviderEndPaymentResponse
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
        public PaymentProviderEndPaymentResponse():base()
        {
        }
        public PaymentProviderEndPaymentResponse(INow now):base(now)
        {
        }
    }
}
