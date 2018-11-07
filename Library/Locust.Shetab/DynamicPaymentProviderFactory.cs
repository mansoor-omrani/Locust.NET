using Locust.Shetab.Mellat;
using Locust.Shetab.Parsian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Shetab.Ayandeh;
using Locust.Shetab.Saman;

namespace Locust.Shetab
{
    public class DynamicPaymentProviderFactory : IPaymentProviderFactory
    {
        private List<IPaymentProvider> providers;
        public DynamicPaymentProviderFactory()
        {
            providers = new List<IPaymentProvider>();
        }
        public DynamicPaymentProviderFactory(params IPaymentProvider[] providers)
        {
            this.providers = providers?.ToList() ?? new List<IPaymentProvider>();
        }
        public void AddProvider(IPaymentProvider provider)
        {
            if (provider == null)
                throw new ArgumentException(nameof(provider));

            providers.Add(provider);
        }
        public bool RemoveProvider(string type)
        {
            var i = 0;
            var found = false;

            if (!string.IsNullOrEmpty(type))
            {
                foreach (var provider in providers)
                {
                    if (provider.ProviderType == type)
                    {
                        found = true;
                        break;
                    }
                    i++;
                }

                if (found)
                {
                    providers.RemoveAt(i);
                }
            }
            
            return found;
        }
        public IPaymentProvider GetProvider(string providerType)
        {
            var result = string.IsNullOrEmpty(providerType) ? null : providers.FirstOrDefault(p => p.ProviderType == providerType);

            return result;
        }

        public IPaymentProvider[] GetProviders()
        {
            return providers.ToArray();
        }
    }
}
