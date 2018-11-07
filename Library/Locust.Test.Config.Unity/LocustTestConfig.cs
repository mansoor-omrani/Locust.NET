using Locust.ServiceLocator;
using System;
using Unity;

namespace Locust.Test.Config.Unity
{
    public static class LocustTestConfig
    {
        public static void Configure(IUnityContainer container)
        {
            var mappings = Configuration.GetMappings();

            foreach (var item in mappings)
            {
                switch (item.LifeTime)
                {
                    case LifeTimeType.Transient:
                        container.RegisterType(from: item.From, to: item.To);
                        break;
                    case LifeTimeType.Singleton:
                        container.RegisterInstance(item.From, Activator.CreateInstance(item.To));
                        break;
                    default:
                        throw new ApplicationException("invalid mapping");
                }
            }
        }
    }
}
