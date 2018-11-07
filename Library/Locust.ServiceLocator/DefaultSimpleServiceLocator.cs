using Locust.Collections;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.ServiceLocator
{
    public class DefaultSimpleServiceLocator : ISimpleServiceLocator
    {
        protected ISafeDictionary<Type, ServiceEntry> services;

        public DefaultSimpleServiceLocator(bool useConcurrentDictionary = false)
        {
            if (useConcurrentDictionary)
                services = new SafeConcurrentDictionary<Type, ServiceEntry>();
            else
                services = new SafeDictionary<Type, ServiceEntry>();
        }
        public T GetService<T>()
        {
            return (T) GetService(typeof (T));
        }
        public object GetService(Type type)
        {
            try
            {
                ServiceEntry se;

                if (services.TryGetValue(type, out se))
                {
                    return se.Service;
                }
                else
                {
                    throw new KeyNotFoundException();
                }

            }
            catch (KeyNotFoundException)
            {
                throw new ApplicationException("The requested service is not registered");
            }
        }

        public bool Register<T, U>(bool stat = false) where U : new()
        {
            return Register<T, U>(false, stat);
        }
        public bool Register<T, U>(bool singleton, bool stat) where U : new()
        {
            var se = new ServiceEntry(factory: () => new U(), service: null, singleton: singleton, stat: stat);

            return this.services.TryAdd(typeof(T), se);
        }

        public bool Register<T, U>(U u, bool stat = false)
        {
            var se = new ServiceEntry(factory: () => u, service: u, singleton: true, stat: stat);

            return this.services.TryAdd(typeof(T), se);
        }


        public bool Register<T, U>(Func<U> u, bool stat = false)
        {
            return Register<T, U>(u, false, stat);
        }

        public bool Register<T, U>(Func<U> u, bool singleton, bool stat)
        {
            var se = new ServiceEntry(factory: () => u(), service: null, singleton: singleton, stat: stat);

            return this.services.TryAdd(typeof(T), se);
        }


        public Tuple<long, long> GetStat<T>()
        {
            return GetStat(typeof (T));
        }

        public Tuple<long, long> GetStat(Type t)
        {
            try
            {
                ServiceEntry se;

                if (services.TryGetValue(t, out se))
                {
                    return Tuple.Create<long, long>(se.ServiceHits, se.FactoryHits);
                }
                else
                {
                    throw new KeyNotFoundException();
                }

            }
            catch (KeyNotFoundException)
            {
                throw new ApplicationException("The requested service is not registered");
            }
        }


        public bool Unregister<T>()
        {
            return Unregister(typeof (T));
        }

        public bool Unregister(Type type)
        {
            ServiceEntry se;

            return services.TryRemove(type, out se);
        }
    }
}
