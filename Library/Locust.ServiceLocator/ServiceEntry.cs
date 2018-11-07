using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.ServiceLocator
{
    public class ServiceEntry
    {
        private Func<object> _factory;

        public Func<object> Factory
        {
            get { return _factory; }
            set
            {
                if (Statistics)
                {
                    _factory = () =>
                    {
                        Interlocked.Increment(ref _factoryHits);

                        return value();
                    };
                }
                else
                {
                    _factory = value;
                }
            }
        }

        private object _service;
        public object Service
        {
            get
            {
                if (Statistics)
                {
                    Interlocked.Increment(ref _serviceHits);
                }

                if (Singleton)
                {
                    if (_service == null)
                    {
                        LazyInitializer.EnsureInitialized(ref _service, _factory);
                    }

                    return _service;
                }
                else
                {
                    return Factory();
                }
            }
        }

        private bool _singleton;

        public bool Singleton
        {
            get { return _singleton; }
        }
        private long _factoryHits;
        public long FactoryHits
        {
            get { return _factoryHits; }
        }

        private long _serviceHits;
        public long ServiceHits
        {
            get { return _serviceHits; }
        }
        public bool Statistics { get; set; }

        public ServiceEntry(Func<object> factory, object service, bool singleton, bool stat)
        {
            _singleton = singleton;
            _service = service;
            Statistics = stat;
            Factory = factory;
        }
    }
}
