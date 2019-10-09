using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace Locust.Base
{
    public static class TypeHelper
    {
        public static Type TypeOfInt16 { get; private set; }
        public static Type TypeOfShort { get { return TypeOfInt16; }}
        public static Type TypeOfInt32 { get; private set; }
        public static Type TypeOfInt { get { return TypeOfInt32; } }
        public static Type TypeOfInt64 { get; private set; }
        public static Type TypeOfLong { get { return TypeOfInt64; } }
        public static Type TypeOfUInt16 { get; private set; }
        public static Type TypeOfUShort { get { return TypeOfUInt16; } }
        public static Type TypeOfUInt32 { get; private set; }
        public static Type TypeOfUInt { get { return TypeOfUInt32; } }
        public static Type TypeOfUInt64 { get; private set; }
        public static Type TypeOfULong { get { return TypeOfUInt64; } }
        public static Type TypeOfSingle { get; private set; }
        public static Type TypeOfFloat { get { return TypeOfSingle; } }
        public static Type TypeOfDouble { get; private set; }
        public static Type TypeOfDecimal { get; private set; }
        public static Type TypeOfByte { get; private set; }
        public static Type TypeOfSByte { get; private set; }
        public static Type TypeOfChar { get; private set; }
        public static Type TypeOfString { get; private set; }
        public static Type TypeOfBool { get; private set; }
        public static Type TypeOfGuid { get; private set; }
        public static Type TypeOfDateTime { get; private set; }
        public static Type TypeOfTimeSpan { get; private set; }
        public static Type TypeOfByteArray { get; private set; }
        public static Type TypeOfNullable { get; private set; }
        public static Type TypeOfObject { get; private set; }
        public static Type TypeOfIListOfT { get; private set; }
        public static Type TypeOfIEnumerableOfT { get; private set; }
        public static Type TypeOfIEnumerable { get; private set; }
        public static Type TypeOfException { get; private set; }
        
        public static Type TypeOfNullableInt16 { get; private set; }
        public static Type TypeOfNullableShort { get { return TypeOfNullableInt16; } }
        public static Type TypeOfNullableInt32 { get; private set; }
        public static Type TypeOfNullableInt { get { return TypeOfNullableInt32; } }
        public static Type TypeOfNullableInt64 { get; private set; }
        public static Type TypeOfNullableLong { get { return TypeOfNullableInt64; } }
        public static Type TypeOfNullableUInt16 { get; private set; }
        public static Type TypeOfNullableUShort { get { return TypeOfNullableUInt16; } }
        public static Type TypeOfNullableUInt32 { get; private set; }
        public static Type TypeOfNullableUInt { get { return TypeOfNullableUInt32; } }
        public static Type TypeOfNullableUInt64 { get; private set; }
        public static Type TypeOfNullableULong { get { return TypeOfNullableUInt64; } }
        public static Type TypeOfNullableSingle { get; private set; }
        public static Type TypeOfNullableFloat { get { return TypeOfNullableSingle; } }
        public static Type TypeOfNullableDouble { get; private set; }
        public static Type TypeOfNullableDecimal { get; private set; }
        public static Type TypeOfNullableByte { get; private set; }
        public static Type TypeOfNullableSByte { get; private set; }
        public static Type TypeOfNullableBool { get; private set; }
        public static Type TypeOfNullableDateTime { get; private set; }
        public static Type TypeOfNullableTimeSpan { get; private set; }

        static TypeHelper()
        {
            TypeOfInt16 = typeof(System.Int16);
            TypeOfInt32 = typeof(System.Int32);
            TypeOfInt64 = typeof(System.Int64);
            TypeOfUInt16 = typeof(System.UInt16);
            TypeOfUInt32 = typeof(System.UInt32);
            TypeOfUInt64 = typeof(System.UInt64);

            TypeOfSingle = typeof(System.Single);
            TypeOfDouble = typeof(System.Double);
            TypeOfDecimal = typeof(System.Decimal);
            TypeOfByte = typeof(System.Byte);
            TypeOfSByte = typeof(System.SByte);
            TypeOfBool = typeof(System.Boolean);
            TypeOfChar = typeof(System.Char);
            TypeOfString = typeof(System.String);
            TypeOfGuid = typeof(System.Guid);
            TypeOfDateTime = typeof(System.DateTime);
            TypeOfTimeSpan = typeof(System.TimeSpan);
            TypeOfByteArray = typeof(System.Byte[]);
            TypeOfNullable = typeof(System.Nullable<>);
            TypeOfObject = typeof(object);
            TypeOfIListOfT = typeof(System.Collections.Generic.IList<>);
            TypeOfIEnumerable = typeof(System.Collections.IEnumerable);
            TypeOfIEnumerableOfT = typeof(System.Collections.Generic.IEnumerable<>);
            TypeOfException = typeof(System.Exception);

            TypeOfNullableInt16 = typeof(System.Nullable<System.Int16>);
            TypeOfNullableInt32 = typeof(System.Nullable<System.Int32>);
            TypeOfNullableInt64 = typeof(System.Nullable<System.Int64>);
            TypeOfNullableUInt16 = typeof(System.Nullable<System.UInt16>);
            TypeOfNullableUInt32 = typeof(System.Nullable<System.UInt32>);
            TypeOfNullableUInt64 = typeof(System.Nullable<System.UInt64>);

            TypeOfNullableSingle = typeof(System.Nullable<System.Single>);
            TypeOfNullableDouble = typeof(System.Nullable<System.Double>);
            TypeOfNullableDecimal = typeof(System.Nullable<System.Decimal>);
            TypeOfNullableByte = typeof(System.Nullable<System.Byte>);
            TypeOfNullableSByte = typeof(System.Nullable<System.SByte>);
            TypeOfNullableBool = typeof(System.Nullable<System.Boolean>);
            TypeOfNullableDateTime = typeof(System.Nullable<System.DateTime>);
            TypeOfNullableTimeSpan = typeof(System.Nullable<System.TimeSpan>);
        }

        //public static bool IsNumeric(object x)
        //{
        //    var result = false;

        //    if (x != null)
        //    {
        //        var type = x.GetType();

        //        if (type == TypeOfInt16 ||
        //            type == TypeOfInt32 ||
        //            type == TypeOfInt64 ||
        //            type == TypeOfUInt16 ||
        //            type == TypeOfUInt32 ||
        //            type == TypeOfUInt64 ||
        //            type == TypeOfSingle ||
        //            type == TypeOfDouble ||
        //            type == TypeOfDecimal ||
        //            type == TypeOfByte ||
        //            type == TypeOfSByte)
        //        {
        //            result = true;
        //        }
        //    }

        //    return result;
        //}
        
        public static IEnumerable<T> GetValues<T>() where T : struct, IConvertible
        {
            //return Enum.GetValues(typeof(System.T)).Cast<T>();
            var type = typeof (T);

            if (type.IsEnum)
                return Enum.GetValues(type).Cast<T>();
            else
                throw new ArgumentException(string.Format("{0} is not an enum", type));
        }

        //public static bool IsNamespaceDefined(string nameSpace)
        //{
        //    return
        //        (from assembly in AppDomain.CurrentDomain.GetAssemblies()
        //        from type in assembly.GetTypes()
        //        where type.Namespace == nameSpace
        //        select type).Any();
        //}
        //public static bool IsTypeDefined(string nameSpace, string className)
        //{
        //    return (from assembly in AppDomain.CurrentDomain.GetAssemblies()
        //        from type in assembly.GetTypes()
        //        where type.Name == className && type.GetMethods().Any()
        //        select type).FirstOrDefault() != null;
        //}
        //public static bool DescendsFrom(object obj, Type targetType)
        //{
        //    var result = false;

        //    if (obj == null) throw new ArgumentNullException("obj");
        //    if (targetType == null) throw new ArgumentNullException("targetType");

        //    var type = obj.GetType();
        //    result = type.IsSubclassOf(targetType);

        //    if (!result)
        //    {
        //        if (targetType.IsGenericTypeDefinition)
        //        {
        //            while (type != TypeHelper.TypeOfObject && type != null)
        //            {
        //                if (type.IsGenericType && type.GetGenericTypeDefinition() == targetType)
        //                {
        //                    result = true;
        //                    break;
        //                }

        //                type = type.BaseType;
        //            }
        //        }
        //    }

        //    return result;
        //}

        public static object CreateInstance(Type type)
        {
            object result = null;
            
            if (type.IsClass && !type.IsAbstract)
            {
                var ctor = type.GetConstructor(Type.EmptyTypes);
                var newExp = Expression.New(ctor);
                var lambda = Expression.Lambda<Func<object>>(newExp);

                result = lambda.Compile().Invoke();
            }

            return result;
        }
        public static Type FindType(string typename)
        {
            var result = Type.GetType(typename);

            if (result == null)
            {
                foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
                {
                    result = asm.GetType(typename);

                    if (result != null)
                        break;
                }
            }

            return result;
        }
        public static object FindTypeAndInstantiate(string typename, params object[] args)
        {
            var result = null as object;
            var type = FindType(typename);
            
            if (type != null)
            {
                result = Activator.CreateInstance(type, args);
            }

            return result;
        }
        public static object FindTypeAndTryInstantiate(string typename, params object[] args)
        {
            var result = null as object;

            try
            {
                result = FindTypeAndInstantiate(typename, args);
            }
            catch (Exception)
            {
            }

            return result;
        }
    }
}