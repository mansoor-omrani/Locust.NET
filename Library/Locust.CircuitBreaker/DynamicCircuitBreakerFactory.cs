using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CircuitBreaker.Net;

namespace Locust.CircuitBreaker
{
    public enum CircuitBreakerFactoryType
    {
        None = 0,
        AppConfig = 1
    }
    public class DynamicCircuitBreakerFactory : ICircuitBreakerFactory
    {
        public ICircuitBreakerFactory CurrentFactory { get; set; }
        private CircuitBreakerFactoryType? type;
        public CircuitBreakerFactoryType Type
        {
            get
            {
                if (!type.HasValue)
                {
                    CircuitBreakerFactoryType _type;

                    if (!Enum.TryParse(ConfigurationManager.AppSettings["CircuitBreakerFactoryType"], out _type))
                    {
                        _type = CircuitBreakerFactoryType.None;
                    }

                    type = _type;
                    CurrentFactory = null;
                }

                return type.Value;
            }
            set
            {
                type = value;
            }
        }
        public ICircuitBreaker CreateBreaker(object arg)
        {
            if (CurrentFactory == null)
            {
                switch (Type)
                {
                    case CircuitBreakerFactoryType.None:
                        CurrentFactory = new NoCircuitBreakerFactory();
                        break;
                    case CircuitBreakerFactoryType.AppConfig:
                        CurrentFactory = new AppConfigCircuitBreakerFactory();
                        break;
                }
            }

            return CurrentFactory?.CreateBreaker(arg);
        }
    }
}
