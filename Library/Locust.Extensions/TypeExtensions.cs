using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Locust.Base;
using Locust.Expressions;

namespace Locust.Extensions
{
    public static class TypeExtensions
    {
        public static object ReadProperty(this object x, string name)
        {
            return GlobalPropertyProvider.Read(x, name);
        }
        
        public static bool IsBasicType(this Type type)
        {
            return type.IsPrimitive || type.IsEnum || type == TypeHelper.TypeOfDateTime || type == TypeHelper.TypeOfTimeSpan || type == TypeHelper.TypeOfString;
        }
        
        public static bool IsByteArray(this Type type)
        {
            return type.IsArray && type.GetElementType() == TypeHelper.TypeOfByte;
        }
        public static List<Type> GetSubClasses(this Type type, Assembly assembly = null)
        {
            if (assembly != null)
                return assembly.GetSubClasses(type);
            else
                return Assembly.GetCallingAssembly().GetSubClasses(type);
        }

        public static bool IsNumeric(this Type type)
        {
            var result = false;

            result = (type == TypeHelper.TypeOfInt64) || (type == TypeHelper.TypeOfInt32) || (type == TypeHelper.TypeOfInt16) || (type == TypeHelper.TypeOfByte) ||
                    (type == TypeHelper.TypeOfUInt64) || (type == TypeHelper.TypeOfUInt32) || (type == TypeHelper.TypeOfUInt16) || (type == TypeHelper.TypeOfSByte) ||
                    (type == TypeHelper.TypeOfSingle) || (type == TypeHelper.TypeOfDouble || type == TypeHelper.TypeOfDecimal);

            return result;
        }
        public static bool IsNullableNumeric(this Type type)
        {
            var result = false;

            result = (type == TypeHelper.TypeOfNullableInt64) || (type == TypeHelper.TypeOfNullableInt32) || (type == TypeHelper.TypeOfNullableInt16) || (type == TypeHelper.TypeOfNullableByte) ||
                    (type == TypeHelper.TypeOfNullableUInt64) || (type == TypeHelper.TypeOfNullableUInt32) || (type == TypeHelper.TypeOfNullableUInt16) || (type == TypeHelper.TypeOfNullableSByte) ||
                    (type == TypeHelper.TypeOfNullableSingle) || (type == TypeHelper.TypeOfNullableDouble || type == TypeHelper.TypeOfNullableDecimal);

            return result;
        }
        public static bool IsNullableOrNumeric(this Type type)
        {
            var result = false;

            result =
                    (type == TypeHelper.TypeOfInt64) || (type == TypeHelper.TypeOfInt32) || (type == TypeHelper.TypeOfInt16) || (type == TypeHelper.TypeOfByte) ||
                    (type == TypeHelper.TypeOfUInt64) || (type == TypeHelper.TypeOfUInt32) || (type == TypeHelper.TypeOfUInt16) || (type == TypeHelper.TypeOfSByte) ||
                    (type == TypeHelper.TypeOfSingle) || (type == TypeHelper.TypeOfDouble || type == TypeHelper.TypeOfDecimal) ||
                    (type == TypeHelper.TypeOfNullableInt64) || (type == TypeHelper.TypeOfNullableInt32) || (type == TypeHelper.TypeOfNullableInt16) || (type == TypeHelper.TypeOfNullableByte) ||
                    (type == TypeHelper.TypeOfNullableUInt64) || (type == TypeHelper.TypeOfNullableUInt32) || (type == TypeHelper.TypeOfNullableUInt16) || (type == TypeHelper.TypeOfNullableSByte) ||
                    (type == TypeHelper.TypeOfNullableSingle) || (type == TypeHelper.TypeOfNullableDouble || type == TypeHelper.TypeOfNullableDecimal);

            return result;
        }
        public static bool IsNullableOrBasicType(this Type type)
        {
            return type.IsNullable() || type.IsBasicType();
        }
        public static bool IsNullable(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == TypeHelper.TypeOfNullable;
        }
        public static bool TryGetItemType(this Type type, out Type innerType)
        {
            //source: https://stackoverflow.com/questions/1043755/c-sharp-generic-list-t-how-to-get-the-type-of-t/13608408#13608408
            Contract.Requires(type != null);

            var interfaceTest = new Func<Type, Type>(i => i.IsGenericType && i.GetGenericTypeDefinition() == TypeHelper.TypeOfIEnumerableOfT ? i.GetGenericArguments().Single() : null);

            innerType = interfaceTest(type);

            if (innerType != null)
            {
                return true;
            }

            foreach (var i in type.GetInterfaces())
            {
                innerType = interfaceTest(i);

                if (innerType != null)
                {
                    return true;
                }
            }

            return false;
        }
        public static bool DescendsFrom(this Type type, Type targetType)
        {
            var result = type.IsSubclassOf(targetType);

            if (!result)
            {
                if (targetType == null) throw new ArgumentNullException("targetType");

                if (targetType.IsGenericTypeDefinition)
                {
                    var _type = type;

                    while (_type != TypeHelper.TypeOfObject && _type != null)
                    {
                        if (_type.IsGenericType && _type.GetGenericTypeDefinition() == targetType)
                        {
                            result = true;
                            break;
                        }

                        _type = _type.BaseType;
                    }
                }
            }

            return result;
        }

        public static Dictionary<string, object> ToDictionary(this object x, string excludes = "")
        {
            var result = new Dictionary<string, object>();
            var arrExcludes = new string[] {};

            if (!string.IsNullOrEmpty(excludes))
            {
                excludes.Split(",", MyStringSplitOptions.TrimAndRemoveEmptyEntries);
            }

            foreach (var prop in x.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (prop.CanRead && (arrExcludes.Length == 0 || !arrExcludes.Exists(prop.Name)))
                {
                    result.Add(prop.Name, prop.GetValue(x));
                }
            }

            return result;
        }

        public static bool IsEnumerable(this Type type)
        {
            return type.DescendsFrom(TypeHelper.TypeOfIEnumerable);
        }
        public static bool Implements(this Type type, Type interfaceType)
        {
            if (!interfaceType.IsInterface)
                return false;

            if (interfaceType.IsGenericType)
            {
                return type.GetInterfaces().Any(i => i.IsGenericType && (i.GetGenericTypeDefinition() == interfaceType || i == interfaceType));
            }
            else
            {
                return type.GetInterfaces().Contains(interfaceType);
            }
        }
        public static bool Implements<TInterface>(this Type type)
        {
            return type.Implements(typeof(TInterface));
        }
    }
}
