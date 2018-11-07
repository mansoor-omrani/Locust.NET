using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Locust.ServiceLocator
{
    public enum LifeTimeType
    {
        Unknown,
        Transient,
        Singleton,
        WebRequest
    }
    public abstract class LifeTimeManager : IDisposable
    {
        public abstract object GetInstance();
        public abstract void Dispose();
        private readonly Func<IServiceLocator, object> factory;
        public Func<IServiceLocator, object> Factory
        {
            get
            {
                return factory;
            }
        }
        public readonly Type objectType;
        public Type ObjectType
        {
            get
            {
                return objectType;
            }
        }
        protected readonly IServiceLocator parentLocator;
        public LifeTimeManager(IServiceLocator parentLocator, Type type)
        {
            objectType = type;
            this.parentLocator = parentLocator;
            factory = (locator) => Activator.CreateInstance(type);
        }
        public LifeTimeManager(IServiceLocator parentLocator, Type type, Func<IServiceLocator, object> factory)
        {
            objectType = type;
            this.parentLocator = parentLocator;
            if (factory == null)
                this.factory = (locator) => Activator.CreateInstance(type);
            else
                this.factory = factory;
        }
    }
    public class TransientLifeTimeManager : LifeTimeManager
    {
        public TransientLifeTimeManager(IServiceLocator parentLocator, Type type): base(parentLocator, type)
        { }
        public TransientLifeTimeManager(IServiceLocator parentLocator, Type type, Func<IServiceLocator, object> factory): base(parentLocator, type, factory)
        { }
        public override void Dispose()
        { }
        public override object GetInstance()
        {
            return Factory(parentLocator);
        }
    }
    public class SingletonLifeTimeManager : LifeTimeManager
    {
        private Lazy<object> instance;
        public SingletonLifeTimeManager(IServiceLocator parentLocator, Type type) : base(parentLocator, type)
        {
            instance = new Lazy<object>(() => Factory(parentLocator), true);
        }
        public SingletonLifeTimeManager(IServiceLocator parentLocator, Type type, Func<IServiceLocator, object> factory): base(parentLocator, type, factory)
        {
            instance = new Lazy<object>(() => Factory(parentLocator), true);
        }
        public override object GetInstance()
        {
            return instance.Value;
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    instance = null;
                }
            }
            this.disposed = true;
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
    public class PerRequestLifeTimeManager : LifeTimeManager
    {
        private object _sync;
        public PerRequestLifeTimeManager(IServiceLocator parentLocator, Type type) : base(parentLocator, type)
        {
            _sync = new object();
        }
        public PerRequestLifeTimeManager(IServiceLocator parentLocator, Type type, Func<IServiceLocator, object> factory): base(parentLocator, type, factory)
        {
            _sync = new object();
        }
        protected virtual object GetItem()
        {
            return HttpContext.Current.Items[ObjectType];
        }
        protected virtual void SetItem(object value)
        {
            HttpContext.Current.Items[ObjectType] = value;
        }
        public override object GetInstance()
        {
            var result = GetItem();

            if (result == null)
            {
                lock (_sync)
                {
                    if (GetItem() == null)
                    {
                        result = Factory(parentLocator);

                        SetItem(result);
                    }
                }
            }

            return result;
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _sync = null;
                    SetItem(null);
                }
            }
            this.disposed = true;
        }

        public override void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
