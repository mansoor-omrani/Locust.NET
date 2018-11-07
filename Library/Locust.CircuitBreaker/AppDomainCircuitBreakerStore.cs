using CircuitBreaker.Net;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.CircuitBreaker
{
    public class AppDomainCircuitBreakerStore : ICircuitBreakerStore, IDisposable
    {
        protected ConcurrentDictionary<object, ICircuitBreaker> store;
        protected string _store_key;
        public AppDomainCircuitBreakerStore()
            : this("circuit_breaker_store")
        { }
        public AppDomainCircuitBreakerStore(string key)
        {
            _store_key = key;

            store = AppDomain.CurrentDomain.GetData(_store_key) as ConcurrentDictionary<object, ICircuitBreaker>;

            if (store == null)
            {
                store = new ConcurrentDictionary<object, ICircuitBreaker>();

                AppDomain.CurrentDomain.SetData(_store_key, store);
            }
        }
        public void Set(ICircuitBreaker c, object state)
        {
            if (state != null)
            {
                store.AddOrUpdate(state, c, (key, old) => c);
            }
            else
            {
                throw new ArgumentException(nameof(state));
            }
        }
        public ICircuitBreaker Get(object state)
        {
            ICircuitBreaker result = null;

            store.TryGetValue(state, out result);

            return result;
        }
        public void Dispose()
        {
            AppDomain.CurrentDomain.SetData(_store_key, store);
        }
    }
}
