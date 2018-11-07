using Locust.Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Extensions
{
    public static class EnumHelper
    {
        public static object ToEnum(Type type, object value, bool ignoreCase = true)
        {
            object result = null;

            if (value != null)
            {
                if (value is string)
                {
                    try
                    {
                        result = Enum.Parse(type, (string)value, ignoreCase);
                        return result;
                    }
                    catch
                    { }
                }

                result = SafeClrConvert.ToInt(value).ToEnum(type);
            }

            return result;
        }
        public static T ToEnum<T>(object value, bool ignoreCase = true)
        {
            return (T)ToEnum(typeof(T), value, ignoreCase);
        }
        public static object ToEnum(Type type, object value, object defaultValue, bool ignoreCase = true)
        {
            object result = null;

            if (value != null)
            {
                if (value is string)
                {
                    try
                    {
                        result = Enum.Parse(type, (string)value, ignoreCase);

                        return result;
                    }
                    catch
                    {
                        result = defaultValue;
                    }
                }

                result = SafeClrConvert.ToInt(value).ToEnum(type, defaultValue);
            }

            return result;
        }
        public static T ToEnum<T>(object value, object defaultValue, bool ignoreCase = true)
        {
            return (T)ToEnum(typeof(T), value, defaultValue, ignoreCase);
        }
    }
}
