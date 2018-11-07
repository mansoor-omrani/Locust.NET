using Locust.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Reflection
{
    public class ReflectionPropertyCache
    {
        private ISafeDictionary<Type, ISafeDictionary<BindingFlags, List<PropertyInfo>>> propStore;
        protected bool useConcurrentDictionary;
        public ReflectionPropertyCache(bool useConcurrentDictionary = true)
        {
            this.useConcurrentDictionary = useConcurrentDictionary;

            if (useConcurrentDictionary)
                propStore = new SafeConcurrentDictionary<Type, ISafeDictionary<BindingFlags, List<PropertyInfo>>>();
            else
                propStore = new SafeDictionary<Type, ISafeDictionary<BindingFlags, List<PropertyInfo>>>();
        }
        public List<PropertyInfo> GetProperties(Type type, BindingFlags attrs, Func<PropertyInfo, bool> predicate)
        {
            var props = propStore.GetOrAdd(type, (t) =>
                useConcurrentDictionary ?
                    (ISafeDictionary<BindingFlags, List<PropertyInfo>>)(new SafeConcurrentDictionary<BindingFlags, List<PropertyInfo>>())
                    :
                    (ISafeDictionary<BindingFlags, List<PropertyInfo>>)(new SafeDictionary<BindingFlags, List<PropertyInfo>>())
            );
            var result = props.GetOrAdd(attrs, (a) => type.GetProperties(a)
                    .Where(predicate)
                    .ToList()
            );
            return result;
        }
        #region Public-Instance
        public List<PropertyInfo> GetPublicInstanceProperties(Type type)
        {
            return GetProperties(type, BindingFlags.Instance | BindingFlags.Public, p => true);
        }
        public List<PropertyInfo> GetPublicInstanceProperties<T>()
        {
            return GetProperties(typeof(T), BindingFlags.Instance | BindingFlags.Public, p => true);
        }
        #endregion
        #region Public-Instance-Readable
        public List<PropertyInfo> GetPublicInstanceReadableProperties(Type type)
        {
            return GetProperties(type, BindingFlags.Instance | BindingFlags.Public, p => p.CanRead);
        }
        public List<PropertyInfo> GetPublicInstanceReadableProperties<T>()
        {
            return GetProperties(typeof(T), BindingFlags.Instance | BindingFlags.Public, p => p.CanRead);
        }
        #endregion
        #region Public-Instance-Writable
        public List<PropertyInfo> GetPublicInstanceWritableProperties(Type type)
        {
            return GetProperties(type, BindingFlags.Instance | BindingFlags.Public, p => p.CanWrite);
        }
        public List<PropertyInfo> GetPublicInstanceWritableProperties<T>()
        {
            return GetProperties(typeof(T), BindingFlags.Instance | BindingFlags.Public, p => p.CanWrite);
        }
        #endregion
        public List<PropertyInfo> GetProperties(Type type, BindingFlags attrs)
        {
            return GetProperties(type, attrs, p => true);
        }
        public List<PropertyInfo> GetProperties<T>(BindingFlags attrs)
        {
            return GetProperties(typeof(T), attrs, p => true);
        }
        public List<PropertyInfo> GetProperties<T>(BindingFlags attrs, Func<PropertyInfo, bool> predicate)
        {
            return GetProperties(typeof(T), attrs, predicate);
        }
        public PropertyInfo GetPublicInstanceProperty(Type type, string name)
        {
            return GetPublicInstanceProperties(type).FirstOrDefault(pi => string.Compare(pi.Name, name, StringComparison.InvariantCultureIgnoreCase) == 0);
        }
        public PropertyInfo GetPublicInstanceProperty<T>(string name)
        {
            return GetPublicInstanceProperties<T>().FirstOrDefault(pi => string.Compare(pi.Name, name, StringComparison.InvariantCultureIgnoreCase) == 0);
        }
        public PropertyInfo GetProperty(Type type, string name, BindingFlags flags)
        {
            return GetProperties(type, flags).FirstOrDefault(pi => string.Compare(pi.Name, name, StringComparison.InvariantCultureIgnoreCase) == 0);
        }
        public PropertyInfo GetProperty<T>(string name, BindingFlags flags)
        {
            return GetProperties<T>(flags).FirstOrDefault(pi => string.Compare(pi.Name, name, StringComparison.InvariantCultureIgnoreCase) == 0);
        }
    }
}
