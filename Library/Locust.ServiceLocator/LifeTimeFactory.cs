using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.ServiceLocator
{
    public interface ILifeTimeFactory
    {
        LifeTimeManager GetLifeTimeManager(IServiceLocator parentLocator, string lifetimeType, Type type, Func<IServiceLocator, object> factory = null);
    }
    public class DefaultLifeTimeFactory : ILifeTimeFactory
    {
        public LifeTimeManager GetLifeTimeManager(IServiceLocator parentLocator, string lifetimeType, Type type, Func<IServiceLocator, object> factory = null)
        {
            LifeTimeManager result = null;
            LifeTimeType _lifeTimeType;
            if (!Enum.TryParse(lifetimeType, out _lifeTimeType))
                _lifeTimeType = LifeTimeType.Unknown;

            switch (_lifeTimeType)
            {
                case LifeTimeType.Transient:
                    result = new TransientLifeTimeManager(parentLocator, type, factory);
                    break;
                case LifeTimeType.Singleton:
                    result = new SingletonLifeTimeManager(parentLocator, type, factory);
                    break;
                case LifeTimeType.WebRequest:
                    result = new PerRequestLifeTimeManager(parentLocator, type, factory);
                    break;
                default:
                    throw new ArgumentException("Invalid lifetime type");
            }

            return result;
        }
    }
}
