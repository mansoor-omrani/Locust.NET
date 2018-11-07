using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.GlobalServices
{
    public static class Extensions
    {
        public static object Resolve(this IServiceLocator locator, Type type)
        {
            return locator.GetService(type);
        }
        public static object ResolveFor(this IServiceLocator locator, Type abstraction, Type requester)
        {
            return locator.GetServiceFor(abstraction, requester);
        }
        public static object ResolveFor(this IServiceLocator locator, Type abstraction, object x)
        {
            return locator.GetServiceFor(abstraction, x);
        }
        public static void RegisterTransient<TAbstraction, TConcretion>(this IServiceLocator locator)
        {
            locator.Register(typeof(TAbstraction), typeof(TConcretion), LifeTimeType.Transient.ToString());
        }
        public static void RegisterTransient<TAbstraction>(this IServiceLocator locator, Func<IServiceLocator, TAbstraction> factory)
        {
            locator.Register(typeof(TAbstraction), LifeTimeType.Transient.ToString(), (_locator) => factory(_locator));
        }
        public static void RegisterInstance<TAbstraction, TConcretion>(this IServiceLocator locator)
        {
            locator.Register(typeof(TAbstraction), typeof(TConcretion), LifeTimeType.Singleton.ToString());
        }
        public static void RegisterInstance<TAbstraction>(this IServiceLocator locator, Func<IServiceLocator, TAbstraction> factory)
        {
            locator.Register(typeof(TAbstraction), LifeTimeType.Singleton.ToString(), (_locator) => factory(_locator));
        }
        public static void RegisterPerRequest<TAbstraction, TConcretion>(this IServiceLocator locator)
        {
            locator.Register(typeof(TAbstraction), typeof(TConcretion), LifeTimeType.WebRequest.ToString());
        }
        public static void RegisterPerRequest<TAbstraction>(this IServiceLocator locator, Func<IServiceLocator, TAbstraction> factory)
        {
            locator.Register(typeof(TAbstraction), LifeTimeType.WebRequest.ToString(), (_locator) => factory(_locator));
        }
        public static void RegisterTransientFor<TAbstraction, TConcretion, TRequester>(this IServiceLocator locator)
        {
            locator.RegisterFor(typeof(TAbstraction), typeof(TConcretion), typeof(TRequester), LifeTimeType.Transient.ToString());
        }
        public static void RegisterTransientFor<TAbstraction, TRequester>(this IServiceLocator locator, Func<IServiceLocator, TAbstraction> factory)
        {
            locator.RegisterFor(typeof(TAbstraction), typeof(TRequester), LifeTimeType.Transient.ToString(), (_locator) => factory(_locator));
        }
        public static void RegisterInstanceFor<TAbstraction, TConcretion, TRequester>(this IServiceLocator locator)
        {
            locator.RegisterFor(typeof(TAbstraction), typeof(TConcretion), typeof(TRequester), LifeTimeType.Singleton.ToString());
        }
        public static void RegisterInstanceFor<TAbstraction, TRequester>(this IServiceLocator locator, Func<IServiceLocator, TAbstraction> factory)
        {
            locator.RegisterFor(typeof(TAbstraction), typeof(TRequester), LifeTimeType.Singleton.ToString(), (_locator) => factory(_locator));
        }
        public static void RegisterPerRequestFor<TAbstraction, TConcretion, TRequester>(this IServiceLocator locator)
        {
            locator.RegisterFor(typeof(TAbstraction), typeof(TConcretion), typeof(TRequester), LifeTimeType.WebRequest.ToString());
        }
        public static void RegisterPerRequestFor<TAbstraction, TRequester>(this IServiceLocator locator, Func<IServiceLocator, TAbstraction> factory)
        {
            locator.RegisterFor(typeof(TAbstraction), typeof(TRequester), LifeTimeType.WebRequest.ToString(), (_locator) => factory(_locator));
        }
        public static T GetServiceFor<T>(this IServiceLocator locator, object x)
        {
            return (T)locator.GetServiceFor(typeof(T), x);
        }
        public static TAbstraction GetServiceFor<TAbstraction, TRequester>(this IServiceLocator locator)
        {
            return (TAbstraction)locator.GetServiceFor(typeof(TAbstraction), typeof(TRequester));
        }
        public static TAbstraction ResolveFor<TAbstraction>(this IServiceLocator locator, object requester)
        {
            return (TAbstraction)locator.ResolveFor(typeof(TAbstraction), requester);
        }
        public static TAbstraction ResolveFor<TAbstraction, TRequester>(this IServiceLocator locator)
        {
            return (TAbstraction)locator.ResolveFor(typeof(TAbstraction), typeof(TRequester));
        }
        public static bool Contains<TAbstraction>(this IServiceLocator locator)
        {
            return locator.Contains(typeof(TAbstraction));
        }
        public static bool ContainsFor<TAbstraction, TRequester>(this IServiceLocator locator)
        {
            return locator.ContainsFor(typeof(TAbstraction), typeof(TRequester));
        }
        public static bool ContainsFor<TAbstraction>(this IServiceLocator locator, object requester)
        {
            return locator.ContainsFor(typeof(TAbstraction), requester);
        }
        public static TAbstraction GetService<TAbstraction>(this IServiceLocator locator)
        {
            return (TAbstraction)locator.GetService(typeof(TAbstraction));
        }
        public static TAbstraction Resolve<TAbstraction>(this IServiceLocator locator)
        {
            return locator.GetService<TAbstraction>();
        }
    }
}
