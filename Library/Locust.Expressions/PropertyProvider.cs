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
    public class PropertyAccessor<T>
    {
        public Func<T, object> Read { get; set; }
        public Action<T, object> Write { get; set; }
        public PropertyAccessor(Func<T, object> read, Action<T, object> write)
        {
            Read = read;
            Write = write;
        }
    }

    public static class GlobalPropertyBuilder
    {
        public static StringComparison GetStringComparison(IEqualityComparer<string> comparer)
        {
            var result = StringComparison.InvariantCultureIgnoreCase;
            var hash = comparer.GetHashCode();

            if (hash == StringComparer.InvariantCulture.GetHashCode())
            {
                result = StringComparison.InvariantCulture;
            }
            if (hash == StringComparer.InvariantCultureIgnoreCase.GetHashCode())
            {
                result = StringComparison.InvariantCultureIgnoreCase;
            }
            if (hash == StringComparer.CurrentCulture.GetHashCode())
            {
                result = StringComparison.CurrentCulture;
            }
            if (hash == StringComparer.CurrentCultureIgnoreCase.GetHashCode())
            {
                result = StringComparison.CurrentCultureIgnoreCase;
            }
            if (hash == StringComparer.Ordinal.GetHashCode())
            {
                result = StringComparison.Ordinal;
            }
            if (hash == StringComparer.OrdinalIgnoreCase.GetHashCode())
            {
                result = StringComparison.OrdinalIgnoreCase;
            }

            return result;
        }
        public static IEqualityComparer<string> GetStringComparer(StringComparison comparison)
        {
            switch (comparison)
            {
                case StringComparison.InvariantCulture:
                    return StringComparer.InvariantCulture;
                case StringComparison.InvariantCultureIgnoreCase:
                    return StringComparer.InvariantCultureIgnoreCase;
                case StringComparison.CurrentCulture:
                    return StringComparer.CurrentCulture;
                case StringComparison.CurrentCultureIgnoreCase:
                    return StringComparer.CurrentCultureIgnoreCase;
                case StringComparison.Ordinal:
                    return StringComparer.Ordinal;
                case StringComparison.OrdinalIgnoreCase:
                    return StringComparer.OrdinalIgnoreCase;
                default:
                    return StringComparer.InvariantCultureIgnoreCase;
            }
        }
        public static Func<object, object> GetReader(Type type, string propertyName, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            var property = GlobalReflectionPropertyCache.Cache.GetPublicInstanceReadableProperty(type, propertyName, comparison);

            if (property == null)
                return (object x) => null;

            var arg = Expression.Parameter(TypeHelper.TypeOfObject, "x");
            var a = Expression.Convert(arg, type);
            var p = Expression.Property(a, property);
            var expr = Expression.Convert(p, TypeHelper.TypeOfObject);

            return Expression.Lambda<Func<object, object>>(expr, arg).Compile();
        }
        public static Func<T, object> GetReader<T>(string propertyName, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            var property = GlobalReflectionPropertyCache.Cache.GetPublicInstanceReadableProperty(typeof(T), propertyName, comparison);

            if (property == null || !property.CanRead)
                return (T x) => null;

            var arg = Expression.Parameter(typeof(T), "x");
            var p = Expression.Property(arg, property);
            var expr = Expression.Convert(p, TypeHelper.TypeOfObject);

            return Expression.Lambda<Func<T, object>>(expr, arg).Compile();
        }
        public static Action<object, object> GetWriter(Type type, string propertyName, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            var property = GlobalReflectionPropertyCache.Cache.GetPublicInstanceWritableProperty(type, propertyName, comparison);

            if (property == null)
                return (object x, object _arg) => { };

            var arg = Expression.Parameter(TypeHelper.TypeOfObject, "x");
            var argValue = Expression.Parameter(TypeHelper.TypeOfObject, "value");
            var a = Expression.Convert(arg, type);
            var av = Expression.Convert(argValue, property.PropertyType);
            var p = Expression.Property(a, propertyName);
            var assign = Expression.Assign(p, av);

            return Expression.Lambda<Action<object, object>>(assign, arg, argValue).Compile();
        }
        public static Action<T, object> GetWriter<T>(string propertyName, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            var type = typeof(T);
            var property = GlobalReflectionPropertyCache.Cache.GetPublicInstanceProperty(type, propertyName, comparison);

            if (property == null || !property.CanWrite)
                return (T x, object _arg) => { };

            var arg = Expression.Parameter(type, "x");
            var argValue = Expression.Parameter(TypeHelper.TypeOfObject, "value");
            var av = Expression.Convert(argValue, property.PropertyType);
            var p = Expression.Property(arg, propertyName);
            var assign = Expression.Assign(p, av);

            return Expression.Lambda<Action<T, object>>(assign, arg, argValue).Compile();
        }
        public static PropertyAccessor GetAccessor(object x, string propertyName, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            var type = x.GetType();

            return new PropertyAccessor(GetReader(type, propertyName, comparison), GetWriter(type, propertyName, comparison));
        }
        public static PropertyAccessor<T> GetAccessor<T>(T x, string propertyName, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            return new PropertyAccessor<T>(GetReader<T>(propertyName, comparison), GetWriter<T>(propertyName, comparison));
        }
    }
    public interface IPropertyProvider
    {
        object Read(object x, string propertyName);
        void Write(object x, string propertyName, object value);
    }
    public class PropertyProvider: IPropertyProvider
    {
        protected ISafeDictionary<Type, ISafeDictionary<string, PropertyAccessor>> propertyAccessorStore;
        protected bool useConcurrentDictionary;
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
        protected PropertyAccessor GetAccessor(object x, string propertyName)
        {
            var type = x.GetType();
            var props = propertyAccessorStore.GetOrAdd(type, (key) =>
                useConcurrentDictionary ?
                (ISafeDictionary<string, PropertyAccessor>)(new SafeConcurrentDictionary<string, PropertyAccessor>(StringComparer.InvariantCulture))
                    :
                (ISafeDictionary<string, PropertyAccessor>)(new SafeDictionary<string, PropertyAccessor>(StringComparer.InvariantCulture))
            );

            return props.GetOrAdd(propertyName, (key) =>
                new PropertyAccessor(GlobalPropertyBuilder.GetReader(type, propertyName, StringComparison.InvariantCulture),
                                     GlobalPropertyBuilder.GetWriter(type, propertyName, StringComparison.InvariantCulture)));
        }
        public virtual object Read(object x, string propertyName)
        {
            if (x == null)
                throw new NullReferenceException("x");

            var accessor = GetAccessor(x, propertyName);

            return accessor.Read(x);
        }
        public virtual void Write(object x, string propertyName, object value)
        {
            if (x == null)
                throw new NullReferenceException("x");

            var accessor = GetAccessor(x, propertyName);

            accessor.Write(x, value);
        }
    }
    
    public static class GlobalPropertyProvider
    {
        public static ISafeDictionary<Type, ISafeDictionary<string, PropertyAccessor>> Cache { get; set; }
        static GlobalPropertyProvider()
        {
            Cache = new SafeConcurrentDictionary<Type, ISafeDictionary<string, PropertyAccessor>>();
        }
        
        public static PropertyAccessor GetAccessor(object x, string propertyName)
        {
            var type = x.GetType();
            var props = Cache.GetOrAdd(type, (key) => new SafeConcurrentDictionary<string, PropertyAccessor>(StringComparer.InvariantCulture));

            return props.GetOrAdd(propertyName, (key) =>
                new PropertyAccessor(GlobalPropertyBuilder.GetReader(type, propertyName, StringComparison.InvariantCulture),
                                     GlobalPropertyBuilder.GetWriter(type, propertyName, StringComparison.InvariantCulture)));
        }
        public static object Read(object x, string propertyName)
        {
            if (x == null)
                throw new NullReferenceException("x");

            var accessor = GetAccessor(x, propertyName);

            return accessor.Read(x);
        }
        public static void Write(object x, string propertyName, object value)
        {
            if (x == null)
                throw new NullReferenceException("x");

            var accessor = GetAccessor(x, propertyName);

            accessor.Write(x, value);
        }
    }
    public static class GlobalPropertyProvider<T>
    {
        public static ISafeDictionary<string, PropertyAccessor<T>> Cache { get; set; }
        static GlobalPropertyProvider()
        {
            Cache = new SafeConcurrentDictionary<string, PropertyAccessor<T>>();
        }

        public static PropertyAccessor<T> GetAccessor(T x, string propertyName)
        {
            return Cache.GetOrAdd(propertyName, (key) =>
                new PropertyAccessor<T>(GlobalPropertyBuilder.GetReader<T>(propertyName, StringComparison.InvariantCulture),
                                        GlobalPropertyBuilder.GetWriter<T>(propertyName, StringComparison.InvariantCulture)));
        }
        public static object Read(T x, string propertyName)
        {
            if (x == null)
                throw new NullReferenceException("x");

            var accessor = GetAccessor(x, propertyName);

            return accessor.Read(x);
        }
        public static void Write(T x, string propertyName, object value)
        {
            if (x == null)
                throw new NullReferenceException("x");

            var accessor = GetAccessor(x, propertyName);

            accessor.Write(x, value);
        }
    }
}
