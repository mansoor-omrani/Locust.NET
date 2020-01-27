using System;
using System.Data.SqlTypes;
using Locust.Base;

namespace Locust.Conversion
{
    public static partial class SafeClrConvert
    {
        #region Non-Nullable
        /*
        public static long ToInt64(object x, long @default = default(long))
        {
            Int64 result;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToInt64(x);
                }
                else
                {
                    result = @default;
                }
            }
            catch
            {
                result = @default;
            }

            return result;
        }
        public static Int32 ToInt32(object x, Int32 @default = default(Int32))
        {
            Int32 result;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToInt32(x);
                }
                else
                {
                    result = @default;
                }
            }
            catch
            {
                result = @default;
            }

            return result;
        }
        public static Int16 ToInt16(object x)
        {
            Int16 result = 0;
            try
            {
                if (!(DBNull.Value.Equals(x) || x == null))
                {
                    result = System.Convert.ToInt16(x);
                }
            }
            catch
            { }

            return result;
        }
        public static decimal ToDecimal(object x)
        {
            decimal result = 0;
            try
            {
                if (!(DBNull.Value.Equals(x) || x == null))
                {
                    result = System.Convert.ToDecimal(x);
                }
            }
            catch
            { }

            return result;
        }
        public static double ToDouble(object x)
        {
            double result = 0;

            try
            {
                if (!(DBNull.Value.Equals(x) || x == null))
                {
                    result = System.Convert.ToDouble(x);
                }
            }
            catch
            { }

            return result;
        }
        public static Single ToSingle(object x)
        {
            Single result = 0;

            try
            {
                if (!(DBNull.Value.Equals(x) || x == null))
                {
                    result = System.Convert.ToSingle(x);
                }
            }
            catch
            { }

            return result;
        }
        public static byte ToByte(object x)
        {
            byte result = 0;
            try
            {
                if (!(DBNull.Value.Equals(x) || x == null))
                {
                    result = System.Convert.ToByte(x);
                }
            }
            catch
            { }

            return result;
        }
        public static sbyte ToSByte(object x)
        {
            sbyte result = 0;
            try
            {
                if (!(DBNull.Value.Equals(x) || x == null))
                {
                    result = System.Convert.ToSByte(x);
                }
            }
            catch
            { }

            return result;
        }
        public static DateTime ToDateTime(object x)
        {
            var result = default(DateTime);
            try
            {
                if (!(DBNull.Value.Equals(x) || x == null))
                {
                    result = System.Convert.ToDateTime(x);
                }
            }
            catch
            { }

            return result;
        }
        public static ulong ToUInt64(object x)
        {
            ulong result = 0;
            try
            {
                if (!(DBNull.Value.Equals(x) || x == null))
                {
                    result = System.Convert.ToUInt64(x);
                }
            }
            catch
            { }

            return result;
        }
        public static UInt32 ToUInt32(object x)
        {
            uint result = 0;
            try
            {
                if (!(DBNull.Value.Equals(x) || x == null))
                {
                    result = System.Convert.ToUInt32(x);
                }
            }
            catch
            { }

            return result;
        }
        public static UInt16 ToUInt16(object x)
        {
            UInt16 result = 0;
            try
            {
                if (!(DBNull.Value.Equals(x) || x == null))
                {
                    result = System.Convert.ToUInt16(x);
                }
            }
            catch
            { }

            return result;
        }
        */
        public static string ToString(object x)
        {
            string result = "";
            try
            {
                if (!(DBNull.Value.Equals(x) || x == null))
                {
                    result = System.Convert.ToString(x);
                }
            }
            catch
            { }

            return result;
        }
        public static char ToChar(object x)
        {
            var result = default(Char);
            try
            {
                if (!(DBNull.Value.Equals(x) || x == null))
                {
                    result = System.Convert.ToChar(x);
                }
            }
            catch
            { }

            return result;
        }
        public static bool ToBoolean(object x, bool @default = default(bool))
        {
            bool result;

            try
            {
                for (;;)
                {
                    var s = x as string;
                    
                    if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                    {
                        if (s != null)
                        {
                            if (string.Compare(s, "true", true) == 0 || string.Compare(s, "false", true) == 0)
                            {
                                result = s[0] == 't' || s[0] == 'T';
                                break;
                            }
                            else
                            {
                                ulong a;
                                if (UInt64.TryParse(s, out a))
                                {
                                    result = (a != 0);
                                    break;
                                }

                                double d;
                                if (double.TryParse(s, out d))
                                {
                                    result = (d != 0);
                                    break;
                                }

                                decimal c;
                                if (decimal.TryParse(s, out c))
                                {
                                    result = (c != 0);
                                    break;
                                }

                                result = @default;
                                break;
                            }
                        }
                        if (x is Int64)
                        {
                            result = ((Int64)x) != 0;
                            break;
                        }
                        if (x is Int32)
                        {
                            result = ((Int32)x) != 0;
                            break;
                        }
                        if (x is Int16)
                        {
                            result = ((Int16)x) != 0;
                            break;
                        }
                        if (x is UInt64)
                        {
                            result = ((UInt64)x) != 0;
                            break;
                        }
                        if (x is UInt32)
                        {
                            result = ((UInt32)x) != 0;
                            break;
                        }
                        if (x is UInt16)
                        {
                            result = ((UInt16)x) != 0;
                            break;
                        }
                        if (x is Byte)
                        {
                            result = ((Byte)x) != 0;
                            break;
                        }
                        if (x is SByte)
                        {
                            result = ((SByte)x) != 0;
                            break;
                        }
                        if (x is Decimal)
                        {
                            result = ((Decimal)x) != 0;
                            break;
                        }
                        if (x is Double)
                        {
                            result = ((Double)x) != 0;
                            break;
                        }
                        if (x is Single)
                        {
                            result = ((Single)x) != 0;
                            break;
                        }
                        if (x is Char)
                        {
                            result = ((Char)x) == 'y' || ((Char)x) == 'Y';
                            break;
                        }
                        
                        result = System.Convert.ToBoolean(x);
                    }
                    else
                    {
                        result = @default;
                    }

                    break;
                }
            }
            catch
            {
                result = @default;
            }

            return result;
        }
        public static TimeSpan ToTimeSpan(object x, TimeSpan @default = default(TimeSpan))
        {
            TimeSpan result;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = (TimeSpan)x;
                }
                else
                {
                    result = @default;
                }
            }
            catch
            {
                result = @default;
            }

            return result;
        }
        public static Guid ToGuid(object x, Guid @default = default(Guid))
        {
            Guid result;
            try
            {
                var s = x as string;
                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    System.Guid.TryParse(x.ToString(), out result);
                }
                else
                {
                    result = @default;
                }
            }
            catch
            {
                result = @default;
            }

            return result;
        }
        public static UInt16 ToUShort(object x, UInt16 @default = default(UInt16))
        {
            return ToUInt16(x, @default);
        }
        public static UInt32 ToUInt(object x, UInt32 @default = default(UInt32))
        {
            return ToUInt32(x, @default);
        }
        public static UInt64 ToULong(object x, UInt64 @default = default(UInt64))
        {
            return ToUInt64(x, @default);
        }
        public static Int16 ToShort(object x, Int16 @default = default(Int16))
        {
            return ToInt16(x, @default);
        }
        public static Int32 ToInt(object x, Int32 @default = default(Int32))
        {
            return ToInt32(x, @default);
        }
        public static Int64 ToLong(object x, Int64 @default = default(Int64))
        {
            return ToInt64(x, @default);
        }
        public static Single ToFloat(object x, Single @default = default(Single))
        {
            return ToSingle(x, @default);
        }
        #endregion
        #region Nullable
        /*
        public static long? ToInt64Nullable(object x, bool useDefaultForNull = false, Int64 defaultValue = 0)
        {
            long? result = null;
            try
            {
                if (!DBNull.Value.Equals(x) && x != null)
                {
                    result = System.Convert.ToInt64(x);
                }
            }
            catch
            { }

            if (result == null && useDefaultForNull)
            {
                result = defaultValue;
            }

            return result;
        }
        public static Int32? ToInt32Nullable(object x, bool useDefaultForNull = false, Int32 defaultValue = 0)
        {
            Int32? result = null;
            try
            {
                if (!DBNull.Value.Equals(x) && x != null)
                {
                    result = System.Convert.ToInt32(x);
                }
            }
            catch
            { }

            if (result == null && useDefaultForNull)
            {
                result = defaultValue;
            }

            return result;
        }
        public static Int16? ToInt16Nullable(object x, bool useDefaultForNull = false, Int16 defaultValue = 0)
        {
            Int16? result = null;
            try
            {
                if (!DBNull.Value.Equals(x) && x != null)
                {
                    result = System.Convert.ToInt16(x);
                }
            }
            catch
            { }

            if (result == null && useDefaultForNull)
            {
                result = defaultValue;
            }

            return result;
        }
        public static Decimal? ToDecimalNullable(object x, bool useDefaultForNull = false, Decimal defaultValue = 0)
        {
            Decimal? result = null;
            try
            {
                if (!DBNull.Value.Equals(x) && x != null)
                {
                    result = System.Convert.ToDecimal(x);
                }
            }
            catch
            { }

            if (result == null && useDefaultForNull)
            {
                result = defaultValue;
            }

            return result;
        }
        public static Double? ToDoubleNullable(object x, bool useDefaultForNull = false, Double defaultValue = 0)
        {
            Double? result = null;
            try
            {
                if (!DBNull.Value.Equals(x) && x != null)
                {
                    result = System.Convert.ToDouble(x);
                }
            }
            catch
            { }

            if (result == null && useDefaultForNull)
            {
                result = defaultValue;
            }

            return result;
        }
        public static Single? ToSingleNullable(object x, bool useDefaultForNull = false, Single defaultValue = 0)
        {
            Single? result = null;
            try
            {
                if (!DBNull.Value.Equals(x) && x != null)
                {
                    result = System.Convert.ToSingle(x);
                }
            }
            catch
            { }

            if (result == null && useDefaultForNull)
            {
                result = defaultValue;
            }

            return result;
        }
        public static Byte? ToByteNullable(object x, bool useDefaultForNull = false, Byte defaultValue = 0)
        {
            Byte? result = null;
            try
            {
                if (!DBNull.Value.Equals(x) && x != null)
                {
                    result = System.Convert.ToByte(x);
                }
            }
            catch
            { }

            if (result == null && useDefaultForNull)
            {
                result = defaultValue;
            }

            return result;
        }
        public static SByte? ToSByteNullable(object x, bool useDefaultForNull = false, SByte defaultValue = 0)
        {
            SByte? result = null;
            try
            {
                if (!DBNull.Value.Equals(x) && x != null)
                {
                    result = System.Convert.ToSByte(x);
                }
            }
            catch
            { }

            if (result == null && useDefaultForNull)
            {
                result = defaultValue;
            }

            return result;
        }
        public static DateTime? ToDateTimeNullable(object x, bool useDefaultForNull = false, DateTime defaultValue = default(DateTime))
        {
            DateTime? result = null;
            try
            {
                if (!DBNull.Value.Equals(x) && x != null)
                {
                    result = System.Convert.ToDateTime(x);
                }
            }
            catch
            { }

            if (result == null && useDefaultForNull)
            {
                result = defaultValue;
            }

            return result;
        }
        public static UInt64? ToUInt64Nullable(object x, bool useDefaultForNull = false, UInt64 defaultValue = 0)
        {
            UInt64? result = null;
            try
            {
                if (!DBNull.Value.Equals(x) && x != null)
                {
                    result = System.Convert.ToUInt64(x);
                }
            }
            catch
            { }

            if (result == null && useDefaultForNull)
            {
                result = defaultValue;
            }

            return result;
        }
        public static UInt32? ToUInt32Nullable(object x, bool useDefaultForNull = false, UInt32 defaultValue = 0)
        {
            UInt32? result = null;
            try
            {
                if (!DBNull.Value.Equals(x) && x != null)
                {
                    result = System.Convert.ToUInt32(x);
                }
            }
            catch
            { }

            if (result == null && useDefaultForNull)
            {
                result = defaultValue;
            }

            return result;
        }
        public static UInt16? ToUInt16Nullable(object x, bool useDefaultForNull = false, UInt16 defaultValue = 0)
        {
            UInt16? result = null;
            try
            {
                if (!DBNull.Value.Equals(x) && x != null)
                {
                    result = System.Convert.ToUInt16(x);
                }
            }
            catch
            { }

            if (result == null && useDefaultForNull)
            {
                result = defaultValue;
            }

            return result;
        }
        */
        public static Char? ToCharNullable(object x, bool useDefaultForNull = false, Char defaultValue = default(Char))
        {
            Char? result = null;
            try
            {
                if (!DBNull.Value.Equals(x) && x != null)
                {
                    result = System.Convert.ToChar(x);
                }
            }
            catch
            { }

            if (result == null && useDefaultForNull)
            {
                result = defaultValue;
            }

            return result;
        }
        public static bool? ToBooleanNullable(object x, bool useDefaultForNull = false, bool defaultValue = false)
        {
            bool? result = null;

            try
            {
                for (;;)
                {
                    var s = x as string;

                    if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                    {
                        if (s != null)
                        {
                            if (string.Compare(s, "true", true) == 0 || string.Compare(s, "false", true) == 0)
                            {
                                result = s[0] == 't' || s[0] == 'T';
                                break;
                            }
                            else
                            {
                                ulong a;
                                if (UInt64.TryParse(s, out a))
                                {
                                    result = (a != 0);
                                    break;
                                }

                                double d;
                                if (double.TryParse(s, out d))
                                {
                                    result = (d != 0);
                                    break;
                                }

                                decimal c;
                                if (decimal.TryParse(s, out c))
                                {
                                    result = (c != 0);
                                    break;
                                }

                                break;
                            }
                        }
                        if (x is Int64)
                        {
                            result = ((Int64)x) != 0;
                            break;
                        }
                        if (x is Int32)
                        {
                            result = ((Int32)x) != 0;
                            break;
                        }
                        if (x is Int16)
                        {
                            result = ((Int16)x) != 0;
                            break;
                        }
                        if (x is UInt64)
                        {
                            result = ((UInt64)x) != 0;
                            break;
                        }
                        if (x is UInt32)
                        {
                            result = ((UInt32)x) != 0;
                            break;
                        }
                        if (x is UInt16)
                        {
                            result = ((UInt16)x) != 0;
                            break;
                        }
                        if (x is Byte)
                        {
                            result = ((Byte)x) != 0;
                            break;
                        }
                        if (x is SByte)
                        {
                            result = ((SByte)x) != 0;
                            break;
                        }
                        if (x is Decimal)
                        {
                            result = ((Decimal)x) != 0;
                            break;
                        }
                        if (x is Double)
                        {
                            result = ((Double)x) != 0;
                            break;
                        }
                        if (x is Single)
                        {
                            result = ((Single)x) != 0;
                            break;
                        }
                        if (x is Char)
                        {
                            result = ((Char)x) == 'y' || ((Char)x) == 'Y';
                            break;
                        }

                        result = System.Convert.ToBoolean(x);
                    }

                    break;
                }
            }
            catch
            { }

            if (result == null && useDefaultForNull)
            {
                result = defaultValue;
            }

            return result;
        }
        public static Guid? ToGuidNullable(object x, bool useDefaultForNull = false, Guid defaultValue = default(Guid))
        {
            Guid? result = null;
            try
            {
                var s = x as string;
                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    Guid g;
                    if (System.Guid.TryParse(x.ToString(), out g))
                    {
                        result = g;
                    }
                }
            }
            catch
            { }
            
            if (result == null && useDefaultForNull)
            {
                result = defaultValue;
            }

            return result;
        }
        public static TimeSpan? ToTimeSpanNullable(object x, bool useDefaultForNull = false, TimeSpan defaultValue = default(TimeSpan))
        {
            TimeSpan? result = null;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = (TimeSpan)x;
                }
            }
            catch
            { }

            if (result == null && useDefaultForNull)
            {
                result = defaultValue;
            }

            return result;
        }
        public static UInt16? ToUShortNullable(object x, bool useDefaultForNull = false, UInt16 defaultValue = default(UInt16))
        {
            return ToUInt16Nullable(x, useDefaultForNull, defaultValue);
        }
        public static UInt32? ToUIntNullable(object x, bool useDefaultForNull = false, UInt32 defaultValue = default(UInt32))
        {
            return ToUInt32Nullable(x, useDefaultForNull, defaultValue);
        }
        public static UInt64? ToULongNullable(object x, bool useDefaultForNull = false, UInt64 defaultValue = default(UInt64))
        {
            return ToUInt64Nullable(x, useDefaultForNull, defaultValue);
        }
        public static Int16? ToShortNullable(object x, bool useDefaultForNull = false, Int16 defaultValue = default(Int16))
        {
            return ToInt16Nullable(x, useDefaultForNull, defaultValue);
        }
        public static Int32? ToIntNullable(object x, bool useDefaultForNull = false, Int32 defaultValue = default(Int32))
        {
            return ToInt32Nullable(x, useDefaultForNull, defaultValue);
        }
        public static Int64? ToLongNullable(object x, bool useDefaultForNull = false, Int64 defaultValue = default(Int64))
        {
            return ToInt64Nullable(x, useDefaultForNull, defaultValue);
        }
        public static Single? ToFloatNullable(object x, bool useDefaultForNull = false, Single defaultValue = default(Single))
        {
            return ToSingleNullable(x, useDefaultForNull, defaultValue);
        }
        #endregion
        public static double Rad2Deg(double radians)
        {
            return (180 / Math.PI) * radians;
        }
        public static double Deg2Rad(double degrees)
        {
            return (Math.PI / 180) * degrees;
        }
        //https://stackoverflow.com/questions/18015425/invalid-cast-from-system-int32-to-system-nullable1system-int32-mscorlib/18015612
        public static T ChangeType<T>(object value)
        {
            var t = typeof(T);

            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return default(T);
                }

                t = Nullable.GetUnderlyingType(t);
            }

            return (T)System.Convert.ChangeType(value, t);
        }
    }
}
