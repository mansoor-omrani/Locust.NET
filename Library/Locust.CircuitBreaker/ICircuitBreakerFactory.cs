using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CircuitBreaker.Net;

namespace Locust.CircuitBreaker
{
    public interface ICircuitBreakerFactory
    {
        ICircuitBreaker CreateBreaker(object arg);
    }

}
