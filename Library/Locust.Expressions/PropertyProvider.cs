using Locust.Base;
using Locust.Collections;
using Locust.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Expressions
{
    public class PropertyAccessor
    {
        public Func<object, object> Read { get; set; }
        public Action<object, object> Write { get; set; }
        public PropertyAccessor(Func<object, object> read, Action<object, object> write)
        {
            Read = read;
            Write = write;
        }
    }
    public class PropertyProvider
    {
        public static ReflectionPropertyCache PropertyCache { get; set; }
        protected ISafeDictionary<Type, ISafeDictionary<string, PropertyAccessor>> propertyAccessorStore;
        protected bool useConcurrentDictionary;
        static PropertyProvider()
        {
            PropertyCache = new ReflectionPropertyCache();
        }
        public PropertyProvider(bool useConcurrentDictionary = true)
        {
            this.useConcurrentDictionary = useConcurrentDictionary;

            if (useConcurrentDictionary)
            {
                propertyAccessorStore = new SafeConcurrentDictionary<Type, ISafeDictionary<string, PropertyAccessor>>();
            }
            else
            {
                propertyAccessorStore = new SafeDictionary<Type, ISafeDictionary<string, PropertyAccessor>>();
            }
        }
        public static Func<object, object> GetReader(Type type, string propertyName)
        {
            var property = PropertyCache.GetPublicInstanceProperty(type, propertyName);

            if (property == null || !property.CanRead)
                return (object x) => null;

            var arg = Expression.Parameter(TypeHelper.TypeOfObject, "x");
            var a = Expression.Convert(arg, type);
            var p = Expression.Property(a, property);
            var expr = Expression.Convert(p, TypeHelper.TypeOfObject);

            return Expression.Lambda<Func<object, object>>(expr, arg).Compile();
        }
        public static Func<T, object> GetReader<T>(string propertyName)
        {
            var property = PropertyCache.GetPublicInstanceProperty(typeof(T), propertyName);

            if (property == null || !property.CanRead)
                return (T x) => null;

            var arg = Expression.Parameter(typeof(T), "x");
            var p = Expression.Property(arg, property);
            var expr = Expression.Convert(p, TypeHelper.TypeOfObject);

            return Expression.Lambda<Func<T, object>>(expr, arg).Compile();
        }
        public static Action<object, object> GetWriter(Type type, string propertyName)
        {
            var property = PropertyCache.GetPublicInstanceProperty(type, propertyName);

            if (property == null || !property.CanWrite)
                return (object x, object _arg) => { };

            var arg = Expression.Parameter(TypeHelper.TypeOfObject, "x");
            var argValue = Expression.Parameter(TypeHelper.TypeOfObject, "value");
            var a = Expression.Convert(arg, type);
            var av = Expression.Convert(argValue, property.PropertyType);
            var p = Expression.Property(a, propertyName);
            var assign = Expression.Assign(p, av);

            return Expression.Lambda<Action<object, object>>(assign, arg, argValue).Compile();
        }
        public static Action<T, object> GetWriter<T>(string propertyName)
        {
            var type = typeof(T);
            var property = PropertyCache.GetPublicInstanceProperty(type, propertyName);

            if (property == null || !property.CanWrite)
                return (T x, object _arg) => { };

            var arg = Expression.Parameter(type, "x");
            var argValue = Expression.Parameter(TypeHelper.TypeOfObject, "value");
            var av = Expression.Convert(argValue, property.PropertyType);
            var p = Expression.Property(arg, propertyName);
            var assign = Expression.Assign(p, av);

            return Expression.Lambda<Action<T, object>>(assign, arg, argValue).Compile();
        }
        protected PropertyAccessor GetAccessor(object x, string propertyName)
        {
            var type = x.GetType();
            var props = propertyAccessorStore.GetOrAdd(type, (key) =>
                useConcurrentDictionary ?
                (ISafeDictionary<string, PropertyAccessor>)(new SafeConcurrentDictionary<string, PropertyAccessor>())
                    :
                (ISafeDictionary<string, PropertyAccessor>)(new SafeDictionary<string, PropertyAccessor>())
            );

            return props.GetOrAdd(propertyName, (key) => {
                var fr = GetReader(type, propertyName);
                var fw = GetWriter(type, propertyName);
                return new PropertyAccessor(fr, fw);
            });
        }
        public object Read(object x, string propertyName)
        {
            if (x == null)
                throw new NullReferenceException("x");

            var accessor = GetAccessor(x, propertyName);

            return accessor.Read(x);
        }
        public void Write(object x, string propertyName, object value)
        {
            if (x == null)
                throw new NullReferenceException("x");

            var accessor = GetAccessor(x, propertyName);

            accessor.Write(x, value);
        }
    }
}
