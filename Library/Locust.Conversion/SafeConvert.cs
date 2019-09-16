using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#pragma warning disable 219

namespace Locust.Conversion
{
    public static class SafeConvert
    {
        #region Non-Nullable
        public static long ToInt64(object x)
        {
            Int64 result = 0;

            try
            {
                if (!(DBNull.Value.Equals(x) || x == null))
                {
                    if (x is SqlInt64)
                    {
                        result = (Int64)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (Int64)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (Int64)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (Int64)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (Int64)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (Int64)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (Int64)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (Int64)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        Int64.TryParse(((SqlString)x).Value, out result);
                        goto end_conversion;
                    }
                    result = System.Convert.ToInt64(x);
                end_conversion:
                    var nop = 0;
                }
            }
            catch
            { }

            return result;
        }
        public static Int32 ToInt32(object x)
        {
            int result = 0;
            try
            {
                if (!(DBNull.Value.Equals(x) || x == null))
                {
                    if (x is SqlInt64)
                    {
                        result = (Int32)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (Int32)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (Int32)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (Int32)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (Int32)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (Int32)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (Int32)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (Int32)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        Int32.TryParse(((SqlString)x).Value, out result);
                        goto end_conversion;
                    }
                    result = System.Convert.ToInt32(x);
                end_conversion:
                    var nop = 0;
                }
            }
            catch
            { }

            return result;
        }
        public static Int16 ToInt16(object x)
        {
            Int16 result = 0;
            try
            {
                if (!(DBNull.Value.Equals(x) || x == null))
                {
                    if (x is SqlInt64)
                    {
                        result = (Int16)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (Int16)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (Int16)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (Int16)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (Int16)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (Int16)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (Int16)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (Int16)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        Int16.TryParse(((SqlString)x).Value, out result);
                        goto end_conversion;
                    }
                    result = System.Convert.ToInt16(x);
                end_conversion:
                    var nop = 0;
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
                    if (x is SqlInt64)
                    {
                        result = (Decimal)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (Decimal)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (Decimal)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (Decimal)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (Decimal)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (Decimal)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (Decimal)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (Decimal)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        Decimal.TryParse(((SqlString)x).Value, out result);
                        goto end_conversion;
                    }
                    result = System.Convert.ToDecimal(x);
                end_conversion:
                    var nop = 0;
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
                    if (x is SqlInt64)
                    {
                        result = (Double)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (Double)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (Double)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (Double)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (Double)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (Double)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (Double)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (Double)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        Double.TryParse(((SqlString)x).Value, out result);
                        goto end_conversion;
                    }
                    result = System.Convert.ToDouble(x);
                end_conversion:
                    var nop = 0;
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
                    if (x is SqlInt64)
                    {
                        result = (Single)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (Single)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (Single)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (Single)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (Single)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (Single)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (Single)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (Single)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        Single.TryParse(((SqlString)x).Value, out result);
                        goto end_conversion;
                    }
                    result = System.Convert.ToSingle(x);
                end_conversion:
                    var nop = 0;
                }
            }
            catch
            { }

            return result;
        }
        public static string ToString(object x)
        {
            string result = "";

            try
            {
                if (!(DBNull.Value.Equals(x) || x == null))
                {
                    if (x is SqlInt64)
                    {
                        result = ((SqlInt64)x).Value.ToString();
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = ((SqlInt32)x).Value.ToString();
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = ((SqlInt16)x).Value.ToString();
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = ((SqlByte)x).Value.ToString();
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = ((SqlDecimal)x).Value.ToString();
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = ((SqlDouble)x).Value.ToString();
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = ((SqlSingle)x).Value.ToString();
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = ((SqlMoney)x).Value.ToString();
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        result = ((SqlString)x).Value.ToString();
                        goto end_conversion;
                    }
                    if (x is SqlGuid)
                    {
                        result = ((SqlGuid)x).Value.ToString();
                        goto end_conversion;
                    }
                    if (x is SqlBoolean)
                    {
                        result = ((SqlBoolean)x).Value.ToString();
                        goto end_conversion;
                    }
                    if (x is SqlDateTime)
                    {
                        result = ((SqlDateTime)x).Value.ToString();
                        goto end_conversion;
                    }
                    if (x is SqlBinary)
                    {
                        result = System.Text.Encoding.UTF8.GetString(((SqlBinary)x).Value);
                        goto end_conversion;
                    }
                    if (x is SqlBytes)
                    {
                        result = System.Text.Encoding.UTF8.GetString(((SqlBytes)x).Value);
                        goto end_conversion;
                    }
                    if (x is SqlChars)
                    {
                        result = new String(((SqlChars)x).Value);
                        goto end_conversion;
                    }
                    if (x is SqlXml)
                    {
                        result = ((SqlXml)x).Value;
                        goto end_conversion;
                    }
                    result = System.Convert.ToString(x);
                end_conversion:
                    var nop = 0;
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
                    if (x is SqlInt64)
                    {
                        result = (Char)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (Char)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (Char)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (Char)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (Char)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (Char)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (Char)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (Char)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        Char.TryParse(((SqlString)x).Value, out result);
                        goto end_conversion;
                    }
                    result = System.Convert.ToChar(x);
                end_conversion:
                    var nop = 0;
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
                    if (x is SqlInt64)
                    {
                        result = (Byte)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (Byte)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (Byte)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (Byte)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (Byte)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (Byte)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (Byte)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (Byte)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        Byte.TryParse(((SqlString)x).Value, out result);
                        goto end_conversion;
                    }
                    result = System.Convert.ToByte(x);
                end_conversion:
                    var nop = 0;
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
                    if (x is SqlInt64)
                    {
                        result = (SByte)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (SByte)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (SByte)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (SByte)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (SByte)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (SByte)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (SByte)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (SByte)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        SByte.TryParse(((SqlString)x).Value, out result);
                        goto end_conversion;
                    }
                    result = System.Convert.ToSByte(x);
                end_conversion:
                    var nop = 0;
                }
            }
            catch
            { }

            return result;
        }
        public static bool ToBoolean(object x)
        {
            var result = false;

            try
            {
                if (!(DBNull.Value.Equals(x) || x == null))
                {
                    if (x is SqlInt64)
                    {
                        result = ((SqlInt64)x).Value != 0;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = ((SqlInt32)x).Value != 0;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = ((SqlInt16)x).Value != 0;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = ((SqlByte)x).Value != 0;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = ((SqlDecimal)x).Value != 0;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = ((SqlDouble)x).Value != 0;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = ((SqlSingle)x).Value != 0;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = ((SqlMoney)x).Value != 0;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        result = string.Compare(((SqlString)x).Value.Trim(), "true", true) == 0;
                        goto end_conversion;
                    }
                    if (x is Int64)
                    {
                        result = ((Int64)x) != 0;
                        goto end_conversion;
                    }
                    if (x is Int32)
                    {
                        result = ((Int32)x) != 0;
                        goto end_conversion;
                    }
                    if (x is Int16)
                    {
                        result = ((Int16)x) != 0;
                        goto end_conversion;
                    }
                    if (x is UInt64)
                    {
                        result = ((UInt64)x) != 0;
                        goto end_conversion;
                    }
                    if (x is UInt32)
                    {
                        result = ((UInt32)x) != 0;
                        goto end_conversion;
                    }
                    if (x is UInt16)
                    {
                        result = ((UInt16)x) != 0;
                        goto end_conversion;
                    }
                    if (x is Byte)
                    {
                        result = ((Byte)x) != 0;
                        goto end_conversion;
                    }
                    if (x is SByte)
                    {
                        result = ((SByte)x) != 0;
                        goto end_conversion;
                    }
                    if (x is Decimal)
                    {
                        result = ((Decimal)x) != 0;
                        goto end_conversion;
                    }
                    if (x is Double)
                    {
                        result = ((Double)x) != 0;
                        goto end_conversion;
                    }
                    if (x is Single)
                    {
                        result = ((Single)x) != 0;
                        goto end_conversion;
                    }
                    if (x is Char)
                    {
                        result = ((Char)x) == 'y' || ((Char)x) == 'Y';
                        goto end_conversion;
                    }
                    if (x is String)
                    {
                        var s = x.ToString().Trim();
                        int a;
                        if (Int32.TryParse(s, out a))
                        {
                            if (a != 0)
                            {
                                result = true;
                                goto end_conversion;
                            }
                        }
                        else
                        {
                            double d;
                            if (double.TryParse(s, out d))
                            {
                                if (d != 0)
                                {
                                    result = true;
                                    goto end_conversion;
                                }
                            }
                            else
                            {
                                decimal c;
                                if (decimal.TryParse(s, out c))
                                {
                                    if (c != 0)
                                    {
                                        result = true;
                                        goto end_conversion;
                                    }
                                }
                                else
                                {
                                    result = string.Compare(s, "true", true) == 0;
                                    goto end_conversion;
                                }
                            }
                        }
                    }

                    result = System.Convert.ToBoolean(x);
                end_conversion:
                    var nop = 0;
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
                    if (x is SqlDateTime)
                    {
                        result = (DateTime)((SqlDateTime)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        DateTime.TryParse(((SqlString)x).Value, out result);
                        goto end_conversion;
                    }
                    result = System.Convert.ToDateTime(x);
                end_conversion:
                    var nop = 0;
                }
            }
            catch
            { }

            return result;
        }
        public static Guid ToGuid(object x)
        {
            var result = new Guid();
            try
            {
                if (!(DBNull.Value.Equals(x) || x == null))
                {
                    if (x is SqlGuid)
                    {
                        result = (Guid)((SqlGuid)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        Guid.TryParse(((SqlString)x).Value, out result);
                        goto end_conversion;
                    }
                    System.Guid.TryParse(x.ToString(), out result);
                end_conversion:
                    var nop = 0;
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
                    if (x is SqlInt64)
                    {
                        result = (UInt64)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (UInt64)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (UInt64)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (UInt64)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (UInt64)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (UInt64)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (UInt64)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (UInt64)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        UInt64.TryParse(((SqlString)x).Value, out result);
                        goto end_conversion;
                    }
                    result = System.Convert.ToUInt64(x);
                end_conversion:
                    var nop = 0;
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
                    if (x is SqlInt64)
                    {
                        result = (UInt32)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (UInt32)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (UInt32)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (UInt32)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (UInt32)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (UInt32)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (UInt32)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (UInt32)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        UInt32.TryParse(((SqlString)x).Value, out result);
                        goto end_conversion;
                    }
                    result = System.Convert.ToUInt32(x);
                end_conversion:
                    var nop = 0;
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
                    if (x is SqlInt64)
                    {
                        result = (UInt16)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (UInt16)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (UInt16)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (UInt16)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (UInt16)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (UInt16)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (UInt16)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (UInt16)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        UInt16.TryParse(((SqlString)x).Value, out result);
                        goto end_conversion;
                    }
                    result = System.Convert.ToUInt16(x);
                end_conversion:
                    var nop = 0;
                }
            }
            catch
            { }

            return result;
        }

        public static UInt16 ToUShort(object x)
        {
            return ToUInt16(x);
        }
        public static UInt32 ToUInt(object x)
        {
            return ToUInt32(x);
        }
        public static UInt64 ToULong(object x)
        {
            return ToUInt64(x);
        }
        public static Int16 ToShort(object x)
        {
            return ToInt16(x);
        }
        public static Int32 ToInt(object x)
        {
            return ToInt32(x);
        }
        public static Int64 ToLong(object x)
        {
            return ToInt64(x);
        }
        #endregion
        #region Nullable
        public static long? ToInt64Nullable(object x, bool useDefaultForNull = false, Int64 defaultValue = 0)
        {
            long? result = null;
            try
            {
                if (!DBNull.Value.Equals(x) && x != null)
                {
                    if (x is SqlInt64)
                    {
                        result = (Int64)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (Int64)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (Int64)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (Int64)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (Int64)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (Int64)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (Int64)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (Int64)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        Int64 r;
                        if (Int64.TryParse(((SqlString)x).Value, out r))
                        {
                            result = r;
                        }
                        goto end_conversion;
                    }
                    result = System.Convert.ToInt64(x);
                end_conversion:
                    var nop = 0;
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
                    if (x is SqlInt64)
                    {
                        result = (Int32)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (Int32)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (Int32)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (Int32)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (Int32)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (Int32)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (Int32)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (Int32)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        Int32 r;
                        if (Int32.TryParse(((SqlString)x).Value, out r))
                        {
                            result = r;
                        }
                        goto end_conversion;
                    }
                    result = System.Convert.ToInt32(x);
                end_conversion:
                    var nop = 0;
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
                    if (x is SqlInt64)
                    {
                        result = (Int16)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (Int16)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (Int16)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (Int16)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (Int16)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (Int16)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (Int16)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (Int16)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        Int16 r;
                        if (Int16.TryParse(((SqlString)x).Value, out r))
                        {
                            result = r;
                        }
                        goto end_conversion;
                    }
                    result = System.Convert.ToInt16(x);
                end_conversion:
                    var nop = 0;
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
                    if (x is SqlInt64)
                    {
                        result = (Decimal)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (Decimal)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (Decimal)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (Decimal)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (Decimal)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (Decimal)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (Decimal)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (Decimal)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        Decimal r;
                        if (Decimal.TryParse(((SqlString)x).Value, out r))
                        {
                            result = r;
                        }
                        goto end_conversion;
                    }
                    result = System.Convert.ToDecimal(x);
                end_conversion:
                    var nop = 0;
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
                    if (x is SqlInt64)
                    {
                        result = (Double)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (Double)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (Double)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (Double)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (Double)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (Double)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (Double)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (Double)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        Double r;
                        if (Double.TryParse(((SqlString)x).Value, out r))
                        {
                            result = r;
                        }
                        goto end_conversion;
                    }
                    result = System.Convert.ToDouble(x);
                end_conversion:
                    var nop = 0;
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
                    if (x is SqlInt64)
                    {
                        result = (Single)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (Single)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (Single)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (Single)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (Single)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (Single)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (Single)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (Single)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        Single r;
                        if (Single.TryParse(((SqlString)x).Value, out r))
                        {
                            result = r;
                        }
                        goto end_conversion;
                    }
                    result = System.Convert.ToSingle(x);
                end_conversion:
                    var nop = 0;
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
        public static Char? ToCharNullable(object x, bool useDefaultForNull = false, Char defaultValue = default(Char))
        {
            Char? result = null;
            try
            {
                if (!DBNull.Value.Equals(x) && x != null)
                {
                    if (x is SqlInt64)
                    {
                        result = (Char)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (Char)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (Char)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (Char)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (Char)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (Char)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (Char)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (Char)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        Char r;
                        if (Char.TryParse(((SqlString)x).Value, out r))
                        {
                            result = r;
                        }
                        goto end_conversion;
                    }
                    result = System.Convert.ToChar(x);
                end_conversion:
                    var nop = 0;
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
                    if (x is SqlInt64)
                    {
                        result = (Byte)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (Byte)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (Byte)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (Byte)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (Byte)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (Byte)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (Byte)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (Byte)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        Byte r;
                        if (Byte.TryParse(((SqlString)x).Value, out r))
                        {
                            result = r;
                        }
                        goto end_conversion;
                    }
                    result = System.Convert.ToByte(x);
                end_conversion:
                    var nop = 0;
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
                    if (x is SqlInt64)
                    {
                        result = (SByte)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (SByte)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (SByte)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (SByte)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (SByte)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (SByte)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (SByte)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (SByte)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        SByte r;
                        if (SByte.TryParse(((SqlString)x).Value, out r))
                        {
                            result = r;
                        }
                        goto end_conversion;
                    }
                    result = System.Convert.ToSByte(x);
                end_conversion:
                    var nop = 0;
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
                if (!DBNull.Value.Equals(x) && x != null)
                {
                    if (x is SqlInt64)
                    {
                        result = ((SqlInt64)x).Value != 0;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = ((SqlInt32)x).Value != 0;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = ((SqlInt16)x).Value != 0;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = ((SqlByte)x).Value != 0;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = ((SqlDecimal)x).Value != 0;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = ((SqlDouble)x).Value != 0;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = ((SqlSingle)x).Value != 0;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = ((SqlMoney)x).Value != 0;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        result = string.Compare(((SqlString)x).Value.Trim(), "true", true) == 0;
                        goto end_conversion;
                    }
                    if (x is Int64)
                    {
                        result = ((Int64)x) != 0;
                        goto end_conversion;
                    }
                    if (x is Int32)
                    {
                        result = ((Int32)x) != 0;
                        goto end_conversion;
                    }
                    if (x is Int16)
                    {
                        result = ((Int16)x) != 0;
                        goto end_conversion;
                    }
                    if (x is UInt64)
                    {
                        result = ((UInt64)x) != 0;
                        goto end_conversion;
                    }
                    if (x is UInt32)
                    {
                        result = ((UInt32)x) != 0;
                        goto end_conversion;
                    }
                    if (x is UInt16)
                    {
                        result = ((UInt16)x) != 0;
                        goto end_conversion;
                    }
                    if (x is Byte)
                    {
                        result = ((Byte)x) != 0;
                        goto end_conversion;
                    }
                    if (x is SByte)
                    {
                        result = ((SByte)x) != 0;
                        goto end_conversion;
                    }
                    if (x is Decimal)
                    {
                        result = ((Decimal)x) != 0;
                        goto end_conversion;
                    }
                    if (x is Double)
                    {
                        result = ((Double)x) != 0;
                        goto end_conversion;
                    }
                    if (x is Single)
                    {
                        result = ((Single)x) != 0;
                        goto end_conversion;
                    }
                    if (x is Char)
                    {
                        result = ((Char)x) == 'y' || ((Char)x) == 'Y';
                        goto end_conversion;
                    }
                    if (x is String)
                    {
                        var s = x.ToString().Trim();
                        int a;
                        if (Int32.TryParse(s, out a))
                        {
                            if (a != 0)
                            {
                                result = true;
                                goto end_conversion;
                            }
                        }
                        else
                        {
                            double d;
                            if (double.TryParse(s, out d))
                            {
                                if (d != 0)
                                {
                                    result = true;
                                    goto end_conversion;
                                }
                            }
                            else
                            {
                                decimal c;
                                if (decimal.TryParse(s, out c))
                                {
                                    if (c != 0)
                                    {
                                        result = true;
                                        goto end_conversion;
                                    }
                                }
                                else
                                {
                                    result = string.Compare(s, "true", true) == 0;
                                    goto end_conversion;
                                }
                            }
                        }
                    }

                    result = System.Convert.ToBoolean(x);
                end_conversion:
                    var nop = 0;
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
                    if (x is SqlDateTime)
                    {
                        result = (DateTime)((SqlDateTime)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        DateTime r;
                        if (DateTime.TryParse(((SqlString)x).Value, out r))
                        {
                            result = r;
                        }
                        goto end_conversion;
                    }
                    result = System.Convert.ToDateTime(x);
                end_conversion:
                    var nop = 0;
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
                if (!DBNull.Value.Equals(x) && x != null)
                {
                    if (x is SqlGuid)
                    {
                        result = (Guid)((SqlGuid)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        Guid r;
                        if (Guid.TryParse(((SqlString)x).Value, out r))
                        {
                            result = r;
                        }
                        goto end_conversion;
                    }
                    Guid g;
                    if (Guid.TryParse(x.ToString(), out g))
                    {
                        result = g;
                    }
                end_conversion:
                    var nop = 0;
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
                    if (x is SqlInt64)
                    {
                        result = (UInt64)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (UInt64)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (UInt64)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (UInt64)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (UInt64)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (UInt64)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (UInt64)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (UInt64)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        UInt64 r;
                        if (UInt64.TryParse(((SqlString)x).Value, out r))
                        {
                            result = r;
                        }
                        goto end_conversion;
                    }
                    result = System.Convert.ToUInt64(x);
                end_conversion:
                    var nop = 0;
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
                    if (x is SqlInt64)
                    {
                        result = (UInt32)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (UInt32)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (UInt32)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (UInt32)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (UInt32)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (UInt32)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (UInt32)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (UInt32)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        UInt32 r;
                        if (UInt32.TryParse(((SqlString)x).Value, out r))
                        {
                            result = r;
                        }
                        goto end_conversion;
                    }
                    result = System.Convert.ToUInt32(x);
                end_conversion:
                    var nop = 0;
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
                    if (x is SqlInt64)
                    {
                        result = (UInt16)((SqlInt64)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt32)
                    {
                        result = (UInt16)((SqlInt32)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlInt16)
                    {
                        result = (UInt16)((SqlInt16)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlByte)
                    {
                        result = (UInt16)((SqlByte)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDecimal)
                    {
                        result = (UInt16)((SqlDecimal)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlDouble)
                    {
                        result = (UInt16)((SqlDouble)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlSingle)
                    {
                        result = (UInt16)((SqlSingle)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlMoney)
                    {
                        result = (UInt16)((SqlMoney)x).Value;
                        goto end_conversion;
                    }
                    if (x is SqlString)
                    {
                        UInt16 r;
                        if (UInt16.TryParse(((SqlString)x).Value, out r))
                        {
                            result = r;
                        }
                        goto end_conversion;
                    }
                    result = System.Convert.ToUInt16(x);
                end_conversion:
                    var nop = 0;
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
        #endregion
        public static double Rad2Deg(double radians)
        {
            return (180 / Math.PI) * radians;
        }
        public static double Deg2Rad(double degrees)
        {
            return (Math.PI / 180) * degrees;
        }
    }
}

#pragma warning restore 219