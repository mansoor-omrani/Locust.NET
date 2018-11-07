using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Base;

namespace Locust.Conversion
{
    public class ForceConvert : IConvert
    {
        public long ToInt64(object x)
        {
            long result = 0;

            try
            {
                result = System.Convert.ToInt64((DBNull.Value.Equals(x)) ? 0 : x);
            }
            catch
            { }

            return result;
        }
        public long ToLong(object x)
        {
            return ToInt64(x);
        }
        public Int32 ToInt32(object x)
        {
            int result = 0;

            try
            {
                result = System.Convert.ToInt32((DBNull.Value.Equals(x)) ? 0 : x);
            }
            catch
            { }

            return result;
        }
        public Int16 ToInt16(object x)
        {
            Int16 result = 0;

            try
            {
                result = System.Convert.ToInt16((DBNull.Value.Equals(x)) ? 0 : x);
            }
            catch
            { }

            return result;
        }

        public Int16 ToShort(object x)
        {
            return ToInt16(x);
        }
        public decimal ToDecimal(object x)
        {
            decimal result = 0;

            try
            {
                result = System.Convert.ToDecimal((DBNull.Value.Equals(x)) ? 0 : x);
            }
            catch
            { }

            return result;
        }
        public string ToString(object x)
        {
            var result = "";

            try
            {
                result = System.Convert.ToString((DBNull.Value.Equals(x)) ? "" : ((x == null) ? "" : x));
            }
            catch
            { }

            return result;
        }
        public char ToChar(object x)
        {
            var result = new Char();

            try
            {
                result = System.Convert.ToChar((DBNull.Value.Equals(x)) ? result : ((x == null) ? result : x));
            }
            catch
            { }

            return result;
        }
        public byte ToByte(object x)
        {
            byte result = 0;

            try
            {
                result = System.Convert.ToByte((DBNull.Value.Equals(x)) ? 0 : x);
            }
            catch
            { }

            return result;
        }
        public sbyte ToSByte(object x)
        {
            sbyte result = 0;

            try
            {
                result = System.Convert.ToSByte((DBNull.Value.Equals(x)) ? 0 : x);
            }
            catch
            { }

            return result;
        }
        public bool ToBoolean(object x)
        {
            var result = false;

            try
            {
                if (x != null)
                {
                    if (x.GetType() == TypeHelper.TypeOfString)
                    {
                        var s = ToString(x).Trim();
                        int a;
                        if (Int32.TryParse(s, out a))
                        {
                            if (a != 0)
                                result = true;
                        }
                        else
                        {
                            double d;
                            if (double.TryParse(s, out d))
                            {
                                if (d != 0)
                                    result = true;
                            }
                            else
                            {
                                decimal c;
                                if (decimal.TryParse(s, out c))
                                {
                                    if (c != 0)
                                        result = true;
                                }
                                else
                                {
                                    if (string.Compare(s, "true", true) == 0)
                                        result = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        result = System.Convert.ToBoolean((DBNull.Value.Equals(x)) ? false : x);
                    }
                }
            }
            catch
            { }

            return result;
        }
        public DateTime ToDateTime(object x)
        {
            var result = DateTime.Now;

            try
            {
                result = System.Convert.ToDateTime((DBNull.Value.Equals(x)) ? DateTime.Now : x);
            }
            catch
            { }

            return result;
        }
        public ulong ToUInt64(object x)
        {
            ulong result = 0;

            try
            {
                result = System.Convert.ToUInt64((DBNull.Value.Equals(x)) ? 0 : x);
            }
            catch
            { }

            return result;
        }

        public uint ToUInt32(object x)
        {
            uint result = 0;

            try
            {
                result = System.Convert.ToUInt32((DBNull.Value.Equals(x)) ? 0 : x);
            }
            catch
            { }

            return result;
        }

        public ushort ToUInt16(object x)
        {
            ushort result = 0;

            try
            {
                result = System.Convert.ToUInt16((DBNull.Value.Equals(x)) ? 0 : x);
            }
            catch
            { }

            return result;
        }

        public double ToDouble(object x)
        {
            double result = 0;

            try
            {
                result = System.Convert.ToDouble((DBNull.Value.Equals(x)) ? 0 : x);
            }
            catch
            { }

            return result;
        }

        public float ToSingle(object x)
        {
            Single result = 0;

            try
            {
                result = System.Convert.ToSingle((DBNull.Value.Equals(x)) ? 0 : x);
            }
            catch
            { }

            return result;
        }

        public string ToBase64(object x)
        {
            var result = "";

            try
            {
                result = System.Convert.ToBase64String(ToByteArray(x));
            }
            catch
            { }

            return result;
        }

        public byte[] ToByteArray(object x)
        {
            var result = new byte[0];

            try
            {
                result = (byte[])x;
            }
            catch
            { }

            return result;
        }

        public List<T> ToList<T>(object x)
        {
            var result = new List<T>();

            try
            {
                result = (List<T>)x;
            }
            catch
            { }

            return result;
        }
        public T To<T>(object x) where T : IConvertible
        {
            T result = default(T);

            try
            {
                result = (T)System.Convert.ChangeType(x, typeof(T));
            }
            catch { }

            return result;
        }
        public Guid ToGuid(object x)
        {
            var result = new Guid();
            try
            {
                if (x != null && !DBNull.Value.Equals(x))
                {
                    System.Guid.TryParse(x.ToString(), out result);
                }
            }
            catch
            { }

            return result;
        }
        public long? ToInt64Nullable(object x, bool useDefaultForNull = false)
        {
            long? result = null;
            try
            {
                if (!DBNull.Value.Equals(x))
                {
                    if (x != null)
                    {
                        result = System.Convert.ToInt64(x);
                    }
                    else
                    {
                        if (useDefaultForNull)
                        {
                            result = 0;
                        }
                    }
                }
            }
            catch
            {
                result = 0;
            }
            return result;
        }
        public Int32? ToInt32Nullable(object x, bool useDefaultForNull = false)
        {
            int? result = null;
            try
            {
                if (!DBNull.Value.Equals(x))
                {
                    if (x != null)
                    {
                        result = System.Convert.ToInt32(x);
                    }
                    else
                    {
                        if (useDefaultForNull)
                        {
                            result = 0;
                        }
                    }
                }
            }
            catch
            {
                result = 0;
            }
            return result;
        }
        public Int16? ToInt16Nullable(object x, bool useDefaultForNull = false)
        {
            Int16? result = null;
            try
            {
                if (!DBNull.Value.Equals(x))
                {
                    if (x != null)
                    {
                        result = System.Convert.ToInt16(x);
                    }
                    else
                    {
                        if (useDefaultForNull)
                        {
                            result = 0;
                        }
                    }
                }
            }
            catch
            {
                result = 0;
            }
            return result;
        }
        public decimal? ToDecimalNullable(object x, bool useDefaultForNull = false)
        {
            decimal? result = null;
            try
            {
                if (!DBNull.Value.Equals(x))
                {
                    if (x != null)
                    {
                        result = System.Convert.ToDecimal(x);
                    }
                    else
                    {
                        if (useDefaultForNull)
                        {
                            result = 0;
                        }
                    }
                }
            }
            catch
            {
                result = 0;
            }
            return result;
        }
        public double? ToDoubleNullable(object x, bool useDefaultForNull = false)
        {
            double? result = null;

            try
            {
                if (!DBNull.Value.Equals(x))
                {
                    if (x != null)
                    {
                        result = System.Convert.ToDouble(x);
                    }
                    else
                    {
                        if (useDefaultForNull)
                        {
                            result = 0;
                        }
                    }
                }
            }
            catch
            {
                result = 0;
            }
            return result;
        }
        public Single? ToSingleNullable(object x, bool useDefaultForNull = false)
        {
            Single? result = null;

            try
            {
                if (!DBNull.Value.Equals(x))
                {
                    if (x != null)
                    {
                        result = System.Convert.ToSingle(x);
                    }
                    else
                    {
                        if (useDefaultForNull)
                        {
                            result = 0;
                        }
                    }
                }
            }
            catch
            {
                result = 0;
            }

            return result;
        }
        public char? ToCharNullable(object x, bool useDefaultForNull = false)
        {
            char? result = null;
            try
            {
                if (!DBNull.Value.Equals(x))
                {
                    if (x != null)
                    {
                        result = System.Convert.ToChar(x);
                    }
                    else
                    {
                        if (useDefaultForNull)
                        {
                            result = default(char);
                        }
                    }
                }
            }
            catch
            {
                result = default(char);
            }
            return result;
        }
        public byte? ToByteNullable(object x, bool useDefaultForNull = false)
        {
            byte? result = null;
            try
            {
                if (!DBNull.Value.Equals(x))
                {
                    if (x != null)
                    {
                        result = System.Convert.ToByte(x);
                    }
                    else
                    {
                        if (useDefaultForNull)
                        {
                            result = 0;
                        }
                    }
                }
            }
            catch
            {
                result = 0;
            }
            return result;
        }
        public sbyte? ToSByteNullable(object x, bool useDefaultForNull = false)
        {
            sbyte? result = null;
            try
            {
                if (!DBNull.Value.Equals(x))
                {
                    if (x != null)
                    {
                        result = System.Convert.ToSByte(x);
                    }
                    else
                    {
                        if (useDefaultForNull)
                        {
                            result = 0;
                        }
                    }
                }
            }
            catch
            {
                result = 0;
            }
            return result;
        }
        public bool? ToBooleanNullable(object x, bool useDefaultForNull = false)
        {
            bool? result = null;
            try
            {
                if (x != null)
                {
                    if (x.GetType() == TypeHelper.TypeOfString)
                    {
                        var s = ToString(x).Trim();
                        int a;
                        if (Int32.TryParse(s, out a))
                        {
                            if (a != 0)
                                result = true;
                        }
                        else
                        {
                            double d;
                            if (double.TryParse(s, out d))
                            {
                                if (d != 0)
                                    result = true;
                            }
                            else
                            {
                                decimal c;
                                if (decimal.TryParse(s, out c))
                                {
                                    if (c != 0)
                                        result = true;
                                }
                                else
                                {
                                    if (string.Compare(s, "true", true) == 0)
                                        result = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        result = System.Convert.ToBoolean(x);
                    }
                }
                else
                {
                    if (useDefaultForNull)
                    {
                        result = false;
                    }
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public DateTime? ToDateTimeNullable(object x, bool useDefaultForNull = false)
        {
            DateTime? result = null;
            try
            {
                if (!DBNull.Value.Equals(x))
                {
                    if (x != null)
                    {
                        result = System.Convert.ToDateTime(x);
                    }
                    else
                    {
                        if (useDefaultForNull)
                        {
                            result = default(DateTime);
                        }
                    }
                }
            }
            catch
            {
                result = default(DateTime);
            }
            return result;
        }
        public Guid? ToGuidNullable(object x, bool useDefaultForNull = false)
        {
            Guid? result = null;
            try
            {
                if (!DBNull.Value.Equals(x))
                {
                    if (x != null)
                    {
                        Guid g;
                        if (System.Guid.TryParse(x.ToString(), out g))
                        {
                            result = g;
                        }
                        else
                        {
                            result = default(Guid);
                        }
                    }
                    else
                    {
                        if (useDefaultForNull)
                        {
                            result = default(Guid);
                        }
                    }
                }
            }
            catch
            {
                result = default(Guid);
            }
            return result;
        }


        public long? ToLongNullable(object x, bool useDefaultForNull = false)
        {
            return ToInt64Nullable(x, useDefaultForNull);
        }

        public short? ToShortNullable(object x, bool useDefaultForNull = false)
        {
            return ToInt16Nullable(x, useDefaultForNull);
        }

        public ulong? ToUInt64Nullable(object x, bool useDefaultForNull = false)
        {
            ulong? result = null;
            try
            {
                if (!DBNull.Value.Equals(x))
                {
                    if (x != null)
                    {
                        result = System.Convert.ToUInt64(x);
                    }
                    else
                    {
                        if (useDefaultForNull)
                        {
                            result = 0;
                        }
                    }
                }
            }
            catch
            {
                result = 0;
            }
            return result;
        }

        public uint? ToUInt32Nullable(object x, bool useDefaultForNull = false)
        {
            uint? result = null;
            try
            {
                if (!DBNull.Value.Equals(x))
                {
                    if (x != null)
                    {
                        result = System.Convert.ToUInt32(x);
                    }
                    else
                    {
                        if (useDefaultForNull)
                        {
                            result = 0;
                        }
                    }
                }
            }
            catch
            {
                result = 0;
            }
            return result;
        }

        public ushort? ToUInt16Nullable(object x, bool useDefaultForNull = false)
        {
            ushort? result = null;
            try
            {
                if (!DBNull.Value.Equals(x))
                {
                    if (x != null)
                    {
                        result = System.Convert.ToUInt16(x);
                    }
                    else
                    {
                        if (useDefaultForNull)
                        {
                            result = 0;
                        }
                    }
                }
            }
            catch
            {
                result = 0;
            }
            return result;
        }
    }
}
