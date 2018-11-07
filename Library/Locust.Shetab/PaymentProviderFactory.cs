using Locust.Shetab.Mellat;
using Locust.Shetab.Parsian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.Shetab
{
    public static class PaymentProviderFactory
    {
        private static IPaymentProviderFactory _default = new DynamicPaymentProviderFactory();
        public static IPaymentProviderFactory Default
        {
            get { return _default; }
            set
            {
                Interlocked.Exchange(ref _default, value);
            }
        }
    }
}
