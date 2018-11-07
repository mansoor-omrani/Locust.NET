using Locust.Expressions;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Extensions
{
    public static class ObjectExtensions
    {
        private static PropertyProvider propertyProvider;
        static ObjectExtensions()
        {
            propertyProvider = new PropertyProvider();
        }
        public static string ToLowerCase(this object x)
        {
            return x.ToString().ToLower();
        }
        public static string ToUpperCase(this object x)
        {
            return x.ToString().ToUpper();
        }
        public static string ToLowerCaseInvariant(this object x)
        {
            return x.ToString().ToLowerInvariant();
        }
        public static string ToUpperCaseInvariant(this object x)
        {
            return x.ToString().ToUpperInvariant();
        }
        public static string ToTrimmedLowerCase(this object x)
        {
            return x.ToString().Trim().ToLower();
        }
        public static string ToTrimmedUpperCase(this object x)
        {
            return x.ToString().Trim().ToUpper();
        }
        public static string ToTrimmedLowerCaseInvariant(this object x)
        {
            return x.ToString().Trim().ToLowerInvariant();
        }
        public static string ToTrimmedUpperCaseInvariant(this object x)
        {
            return x.ToString().Trim().ToUpperInvariant();
        }
        public static object Extend(this object x, object y)
        {
            IDictionary<string, object> result = new ExpandoObject();

            var props = PropertyProvider.PropertyCache.GetPublicInstanceReadableProperties(x.GetType());

            foreach (var prop in props)
            {
                var value = propertyProvider.Read(x, prop.Name);

                result.Add(prop.Name, value);
            }

            if (y != null)
            {
                props = PropertyProvider.PropertyCache.GetPublicInstanceReadableProperties(y.GetType());

                foreach (var prop in props)
                {
                    var value = propertyProvider.Read(y, prop.Name);

                    if (result.ContainsKey(prop.Name))
                    {
                        result[prop.Name] = value;
                    }
                    else
                    {
                        result.Add(prop.Name, value);
                    }
                }
            }

            return (object)result;
        }
    }
}
