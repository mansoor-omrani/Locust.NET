using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.GlobalServices
{
    internal class ServiceLocatorEntry
    {
        public Func<object> Resolver { get; set; }
        public bool Singleton { get; set; }
        private object _service;
        public object Service
        {
            get
            {
                if (Resolver != null)
                {
                    LazyInitializer.EnsureInitialized<object>(ref _service, Resolver);

                    return _service;
                }
                else
                {
                    throw new ApplicationException("No resolver has specified");
                }
            }
        }
        public void SetService(object service)
        {
            Interlocked.Exchange(ref _service, service);
        }
    }
}
