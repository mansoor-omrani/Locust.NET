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
        public List<PropertyInfo> GetProperties(Type type, BindingFlags attrs, Func<PropertyInfo, bool> predicate = null)
        {
            var props = propStore.GetOrAdd(type, (t) =>
                useConcurrentDictionary ?
                    (ISafeDictionary<BindingFlags, List<PropertyInfo>>)(new SafeConcurrentDictionary<BindingFlags, List<PropertyInfo>>())
                    :
                    (ISafeDictionary<BindingFlags, List<PropertyInfo>>)(new SafeDictionary<BindingFlags, List<PropertyInfo>>())
            );
            
            var result = props.GetOrAdd(attrs, (a) => type.GetProperties(attrs).ToList());
            if (predicate != null)
            {
                result = result.Where(predicate).ToList();
            }

            return result ?? new List<PropertyInfo>();
        }
        public List<PropertyInfo> GetProperties<T>(BindingFlags attrs, Func<PropertyInfo, bool> predicate = null)
        {
            return GetProperties(typeof(T), attrs, predicate);
        }
        #region Public-Instance
        public List<PropertyInfo> GetPublicInstanceProperties(Type type)
        {
            return GetProperties(type, BindingFlags.Instance | BindingFlags.Public);
        }
        public List<PropertyInfo> GetPublicInstanceProperties<T>()
        {
            return GetProperties(typeof(T), BindingFlags.Instance | BindingFlags.Public);
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
        
        /* ------------------- Public Instance --------------- */
        public PropertyInfo GetPublicInstanceProperty(Type type, string name, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            return GetPublicInstanceProperties(type).FirstOrDefault(pi => string.Compare(pi.Name, name, comparison) == 0);
        }
        /* ------------------- Public Instance Readable--------------- */
        public PropertyInfo GetPublicInstanceReadableProperty(Type type, string name, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            return GetPublicInstanceReadableProperties(type).FirstOrDefault(pi => string.Compare(pi.Name, name, comparison) == 0);
        }
        /* ------------------- Public Instance Writable --------------- */
        public PropertyInfo GetPublicInstanceWritableProperty(Type type, string name, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            return GetPublicInstanceWritableProperties(type).FirstOrDefault(pi => string.Compare(pi.Name, name, comparison) == 0);
        }
        /* ------------------- Generic Public Instance --------------- */
        public PropertyInfo GetPublicInstanceProperty<T>(string name, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            return GetPublicInstanceProperties<T>().FirstOrDefault(pi => string.Compare(pi.Name, name, comparison) == 0);
        }
        /* ------------------- Generic Public Instance Readable --------------- */
        public PropertyInfo GetPublicInstanceReadableProperty<T>(string name, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            return GetPublicInstanceReadableProperties<T>().FirstOrDefault(pi => string.Compare(pi.Name, name, comparison) == 0);
        }
        /* ------------------- Generic Public Instance Writable --------------- */
        public PropertyInfo GetPublicInstanceWritableProperty<T>(string name, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            return GetPublicInstanceWritableProperties<T>().FirstOrDefault(pi => string.Compare(pi.Name, name, comparison) == 0);
        }
        /* ------------------- Property --------------- */
        public PropertyInfo GetProperty(Type type, string name, BindingFlags flags, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            return GetProperties(type, flags).FirstOrDefault(pi => string.Compare(pi.Name, name, comparison) == 0);
        }
        /* ------------------- Generic Property --------------- */
        public PropertyInfo GetProperty<T>(string name, BindingFlags flags, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            return GetProperties<T>(flags).FirstOrDefault(pi => string.Compare(pi.Name, name, comparison) == 0);
        }
    }
    public static class GlobalReflectionPropertyCache
    {
        public static ReflectionPropertyCache Cache { get; set; }
        static GlobalReflectionPropertyCache()
        {
            Cache = new ReflectionPropertyCache();
        }
    }
}
