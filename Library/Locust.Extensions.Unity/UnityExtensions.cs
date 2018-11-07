using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace Locust.Extensions.Unity
{
    public static class UnityExtensions
    {
        public static IUnityContainer RegisterType<T>(this IUnityContainer container, Func<IUnityContainer, object> factory)
        {
            return container.RegisterType<T>(new InjectionFactory(factory));
        }
        public static IUnityContainer RegisterType<T>(this IUnityContainer container, Func<IUnityContainer, object> factory, LifetimeManager lifetimeManager)
        {
            return container.RegisterType<T>(lifetimeManager, new InjectionFactory(factory));
        }
        public static IUnityContainer RegisterInstance<T>(this IUnityContainer container, Func<IUnityContainer, T> factory)
        {
            var x = factory(container);

            return container.RegisterInstance<T>(x);
        }
        public static IUnityContainer RegisterInstance<T, U>(this IUnityContainer container) where U:class, new()
        {
            return container.RegisterInstance(typeof(T), Activator.CreateInstance<U>());
        }
    }
}
