using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CircuitBreaker.Net;

namespace Locust.CircuitBreaker
{
    public class NoCircuitBreakerFactory : ICircuitBreakerFactory
    {
        public ICircuitBreaker CreateBreaker(object arg)
        {
            return null;
        }
    }
}
