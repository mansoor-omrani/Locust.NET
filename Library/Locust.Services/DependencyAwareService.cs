using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.ServiceLocator;

namespace Locust.Services
{
    public interface IDependencyStore
    {
        IEnumerable<KeyValuePair<Type, bool>> GetAll();
        IEnumerable<KeyValuePair<Type, bool>> GetMissing();
        IEnumerable<KeyValuePair<Type, bool>> GetResolved();
        bool Ready();
    }
    public class DependencyAwareService
    {
        protected DependencyStore _dependencystore;
        protected class DependencyStore : IDependencyStore
        {
            private readonly Dictionary<Type, bool> dependencies;
            private IServiceLocator _locator;

            public DependencyStore(IServiceLocator locator)
            {
                _locator = locator;
                dependencies = new Dictionary<Type, bool>();
            }
            public IEnumerable<KeyValuePair<Type, bool>> GetAll()
            {
                return dependencies;
            }
            public IEnumerable<KeyValuePair<Type, bool>> GetMissing()
            {
                return dependencies.Where(d => !d.Value);
            }
            public IEnumerable<KeyValuePair<Type, bool>> GetResolved()
            {
                return dependencies.Where(d => d.Value);
            }
            public void Add(Type type)
            {
                try
                {
                    dependencies.Add(type, false);
                }
                finally
                { }
            }
            public void Check()
            {

            }
            public void Check(bool check)
            {
                if (check)
                {
                    foreach (var key in dependencies.Keys)
                    {
                        dependencies[key] = _locator.Contains(key);

                        if (dependencies[key])
                        {
                            throw new ArgumentException(key.ToString());
                        }
                    }
                }
            }
            public bool Ready()
            {
                return GetMissing() == null;
            }
        }
        public DependencyAwareService(IServiceLocator locator)
            : this(locator, false)
        {

        }
        public DependencyAwareService(IServiceLocator locator, bool checkDependencies)
        {
            this._dependencystore = new DependencyStore(locator);
        }
        protected void Requires<T>()
        {
            _dependencystore.Add(typeof(T));
        }
        protected void CheckPoint()
        {
            _dependencystore.Check(true);
        }
        protected void CheckPoint(bool check)
        {
            _dependencystore.Check(check);
        }
        public IDependencyStore Dependencies
        {
            get
            {
                return (IDependencyStore)_dependencystore;
            }
        }
    }
}
