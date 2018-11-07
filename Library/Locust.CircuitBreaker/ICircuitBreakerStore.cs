using CircuitBreaker.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.CircuitBreaker
{
    public interface ICircuitBreakerStore
    {
        void Set(ICircuitBreaker c, object state);
        ICircuitBreaker Get(object state);
    }
}
