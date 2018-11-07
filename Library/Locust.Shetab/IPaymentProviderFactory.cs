using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Shetab
{
    public interface IPaymentProviderFactory
    {
        IPaymentProvider GetProvider(string bankType);
        IPaymentProvider[] GetProviders();
    }
}
