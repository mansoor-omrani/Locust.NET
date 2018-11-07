using CircuitBreaker.Net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Conversion;
using CB = CircuitBreaker.Net.CircuitBreaker;

namespace Locust.CircuitBreaker
{
    public class AppConfigCircuitBreakerFactory: ICircuitBreakerFactory
    {
        public AppConfigCircuitBreakerFactory()
        {
        }
        public ICircuitBreaker CreateBreaker(object arg)
        {
            ICircuitBreaker result;

            var maxFailures = SafeClrConvert.ToInt32(ConfigurationManager.AppSettings["CircuitBreakerMaxFailures"]);

            if (maxFailures <= 0)
            {
                maxFailures = 5;
            }
            var invocationTimeout = SafeClrConvert.ToInt32(ConfigurationManager.AppSettings["CircuitBreakerInvocationTimeout"]);
            if (invocationTimeout <= 0)
            {
                invocationTimeout = 500;
            }
            var circuitResetTimeout = SafeClrConvert.ToInt32(ConfigurationManager.AppSettings["CircuitBreakerResetTimeout"]);
            if (circuitResetTimeout <= 0)
            {
                circuitResetTimeout = 5000;
            }

            result = new CB(
                TaskScheduler.Current,
                maxFailures: maxFailures,
                invocationTimeout: TimeSpan.FromMilliseconds(invocationTimeout),
                circuitResetTimeout: TimeSpan.FromMilliseconds(circuitResetTimeout));

            return result;
        }
    }
}
