using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Conversion
{
    public interface IConvert
    {
        long ToInt64(object x);
        long ToLong(object x);
        Int32 ToInt32(object x);
        Int16 ToInt16(object x);
        Int16 ToShort(object x);
        UInt64 ToUInt64(object x);
        UInt32 ToUInt32(object x);
        UInt16 ToUInt16(object x);
        decimal ToDecimal(object x);
        double ToDouble(object x);
        Single ToSingle(object x);
        string ToString(object x);
        char ToChar(object x);
        byte ToByte(object x);
        sbyte ToSByte(object x);
        bool ToBoolean(object x);
        DateTime ToDateTime(object x);
        string ToBase64(object x);
        Guid ToGuid(object x);
        byte[] ToByteArray(object x);
        List<T> ToList<T>(object x);
        T To<T>(object x) where T : IConvertible;
        long? ToInt64Nullable(object x, bool useDefaultForNull = false);
        long? ToLongNullable(object x, bool useDefaultForNull = false);
        Int32? ToInt32Nullable(object x, bool useDefaultForNull = false);
        Int16? ToInt16Nullable(object x, bool useDefaultForNull = false);
        Int16? ToShortNullable(object x, bool useDefaultForNull = false);
        UInt64? ToUInt64Nullable(object x, bool useDefaultForNull = false);
        UInt32? ToUInt32Nullable(object x, bool useDefaultForNull = false);
        UInt16? ToUInt16Nullable(object x, bool useDefaultForNull = false);
        decimal? ToDecimalNullable(object x, bool useDefaultForNull = false);
        double? ToDoubleNullable(object x, bool useDefaultForNull = false);
        Single? ToSingleNullable(object x, bool useDefaultForNull = false);
        char? ToCharNullable(object x, bool useDefaultForNull = false);
        byte? ToByteNullable(object x, bool useDefaultForNull = false);
        sbyte? ToSByteNullable(object x, bool useDefaultForNull = false);
        bool? ToBooleanNullable(object x, bool useDefaultForNull = false);
        DateTime? ToDateTimeNullable(object x, bool useDefaultForNull = false);
        Guid? ToGuidNullable(object x, bool useDefaultForNull = false);
    }
}
