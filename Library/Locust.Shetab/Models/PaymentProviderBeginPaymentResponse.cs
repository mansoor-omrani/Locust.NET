using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Shetab.Models;
using Locust.Date;

namespace Locust.Shetab.Models
{
    public class PaymentProviderBeginPaymentResponse
    {
        public string ProviderType { get; set; }
        public dynamic Code { get; set; }
        public DateTime Date { get; set; }
        public virtual dynamic Status { get; set; }
        public HttpMethod SendMethod { get; set; }
        public Dictionary<string, string> SendData { get; private set; }
        public bool Succeeded { get; set; }
        public string GatewayUrl { get; set; }
        public string Message { get; set; }
        public PaymentProviderBeginPaymentResponse()
        {
            SendData = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
            Date = DateTime.Now;
        }
        public PaymentProviderBeginPaymentResponse(INow now)
        {
            SendData = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);
            Date = now.Value;
        }
    }

    public class PaymentProviderBeginPaymentResponse<T> : PaymentProviderBeginPaymentResponse
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
        public PaymentProviderBeginPaymentResponse():base()
        {
        }
        public PaymentProviderBeginPaymentResponse(INow now):base(now)
        {
        }
    }
}
