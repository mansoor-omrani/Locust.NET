using Locust.Collections;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.ServiceLocator
{
    public class DefaultServiceLocator : IServiceLocator
    {
        private readonly ISafeDictionary<Type, ISafeDictionary<Type, LifeTimeManager>> services;
        private readonly bool useConcurrentDictionary;
        public ILifeTimeFactory LifeTimeFactory { get; set; }
        public DefaultServiceLocator(bool useConcurrentDictionary = false)
        {
            this.useConcurrentDictionary = useConcurrentDictionary;
            this.services = GetDictionary<Type, ISafeDictionary<Type, LifeTimeManager>>();
            this.LifeTimeFactory = new DefaultLifeTimeFactory();
        }
        public DefaultServiceLocator(ILifeTimeFactory lifeTimeFactory, bool useConcurrentDictionary = false)
        {
            this.useConcurrentDictionary = useConcurrentDictionary;
            this.services = GetDictionary<Type, ISafeDictionary<Type, LifeTimeManager>>();
            this.LifeTimeFactory = lifeTimeFactory ?? new DefaultLifeTimeFactory();
        }
        private ISafeDictionary<TKey, TValue> GetDictionary<TKey, TValue>()
        {
            if (useConcurrentDictionary)
                return new SafeConcurrentDictionary<TKey, TValue>();
            else
                return new SafeDictionary<TKey, TValue>();
        }
        private Tuple<Func<Type, ISafeDictionary<Type, LifeTimeManager>>, Func<Type, ISafeDictionary<Type, LifeTimeManager>, ISafeDictionary<Type, LifeTimeManager>>> GetManipulationFuncs(Type requester, Type targetType, string lifetimeType, Func<IServiceLocator, object> factory)
        {
            Func<Type, ISafeDictionary<Type, LifeTimeManager>> addFactory = (x) =>
            {
                var entry = LifeTimeFactory.GetLifeTimeManager(this, lifetimeType, targetType, factory);
                var resolvers = GetDictionary<Type, LifeTimeManager>();

                resolvers.AddOrUpdate(requester, entry, (t, r) => entry);

                return resolvers;
            };
            Func<Type, ISafeDictionary<Type, LifeTimeManager>, ISafeDictionary<Type, LifeTimeManager>> updateFactory = (t, r) =>
            {
                var entry = LifeTimeFactory.GetLifeTimeManager(this, lifetimeType, targetType, factory);
                r.AddOrUpdate(requester, entry, (t1, r1) => entry);

                return r;
            };

            return Tuple.Create<Func<Type, ISafeDictionary<Type, LifeTimeManager>>, Func<Type, ISafeDictionary<Type, LifeTimeManager>, ISafeDictionary<Type, LifeTimeManager>>>(addFactory, updateFactory);
        }
        private void RegisterInternal(Type abstraction, Type concretion, Type requester, string lifetimeType, Func<IServiceLocator, object> factory)
        {
            var x = GetManipulationFuncs(requester, concretion, lifetimeType, factory);

            this.services.AddOrUpdate(abstraction, x.Item1, x.Item2);
        }
        public void Register(Type abstraction, Type concretion, string lifetimeType)
        {
            RegisterInternal(abstraction, concretion, typeof(object), lifetimeType, null);
        }
        public void Register(Type abstraction, string lifetimeType, Func<IServiceLocator, object> factory)
        {
            RegisterInternal(abstraction, abstraction, typeof(object), lifetimeType, factory);
        }
        public void RegisterFor(Type abstraction, Type concretion, Type requester, string lifetimeType)
        {
            RegisterInternal(abstraction, concretion, requester, lifetimeType, null);
        }
        public void RegisterFor(Type abstraction, Type requester, string lifetimeType, Func<IServiceLocator, object> factory)
        {
            RegisterInternal(abstraction, abstraction, requester, lifetimeType, factory);
        }
        private object GetServiceInternal(Type abstraction, Type requester, object requesterObject)
        {
            object result = null;
            var requesterType = requesterObject == null ? requester : requesterObject.GetType();

            if (requesterType != null)
            {
                ISafeDictionary<Type, LifeTimeManager> resolvers;

                if (services.TryGetValue(abstraction, out resolvers))
                {
                    LifeTimeManager entry;

                    if (resolvers.TryGetValue(requesterType, out entry))
                    {
                        result = entry.GetInstance();
                    }
                }
            }

            return result;
        }
        public object GetServiceFor(Type abstraction, object x)
        {
            return GetServiceInternal(abstraction, null, x);
        }
        public object GetServiceFor(Type abstraction, Type requester)
        {
            return GetServiceInternal(abstraction, requester, null);
        }
        public object GetService(Type abstraction)
        {
            return GetServiceInternal(abstraction, typeof(object), null);
        }
        public bool Contains(Type type)
        {
            return services.ContainsKey(type);
        }
        public bool ContainsFor(Type abstraction, Type requester)
        {
            if (services.ContainsKey(abstraction))
            {
                ISafeDictionary<Type, LifeTimeManager> entries;

                if (services.TryGetValue(abstraction, out entries))
                {
                    return entries.ContainsKey(requester);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool ContainsFor(Type abstraction, object requester)
        {
            if (requester != null)
                return ContainsFor(abstraction, requester.GetType());
            else
                return false;
        }
        public void Unregister(Type abstraction)
        {
            ISafeDictionary<Type, LifeTimeManager> config;

            services.TryRemove(abstraction, out config);
        }
        public void Unregister(Type abstraction, Type requester)
        {
            ISafeDictionary<Type, LifeTimeManager> config;

            if (services.TryGetValue(abstraction, out config))
            {
                LifeTimeManager lifetime;

                config.TryRemove(requester, out lifetime);
            }
        }
    }
}
