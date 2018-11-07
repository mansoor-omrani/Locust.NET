

using System;
using Locust.Base;

namespace Locust.Conversion
{
	public static partial class SafeClrConvert
	{
    		public static System.Byte ToByte(object x, System.Byte @default = default(System.Byte))
        {
            System.Byte result;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToByte(x);
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
		public static System.Byte? ToByteNullable(object x, bool useDefaultForNull = false, System.Byte @default = default(System.Byte))
        {
            System.Byte? result = null;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToByte(x);
                }
            }
            catch
            { }

			if (result == null && useDefaultForNull)
            {
                result = @default;
            }

            return result;
        }
     		public static System.SByte ToSByte(object x, System.SByte @default = default(System.SByte))
        {
            System.SByte result;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToSByte(x);
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
		public static System.SByte? ToSByteNullable(object x, bool useDefaultForNull = false, System.SByte @default = default(System.SByte))
        {
            System.SByte? result = null;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToSByte(x);
                }
            }
            catch
            { }

			if (result == null && useDefaultForNull)
            {
                result = @default;
            }

            return result;
        }
     		public static System.Int64 ToInt64(object x, System.Int64 @default = default(System.Int64))
        {
            System.Int64 result;

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
		public static System.Int64? ToInt64Nullable(object x, bool useDefaultForNull = false, System.Int64 @default = default(System.Int64))
        {
            System.Int64? result = null;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToInt64(x);
                }
            }
            catch
            { }

			if (result == null && useDefaultForNull)
            {
                result = @default;
            }

            return result;
        }
     		public static System.Int32 ToInt32(object x, System.Int32 @default = default(System.Int32))
        {
            System.Int32 result;

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
		public static System.Int32? ToInt32Nullable(object x, bool useDefaultForNull = false, System.Int32 @default = default(System.Int32))
        {
            System.Int32? result = null;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToInt32(x);
                }
            }
            catch
            { }

			if (result == null && useDefaultForNull)
            {
                result = @default;
            }

            return result;
        }
     		public static System.Int16 ToInt16(object x, System.Int16 @default = default(System.Int16))
        {
            System.Int16 result;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToInt16(x);
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
		public static System.Int16? ToInt16Nullable(object x, bool useDefaultForNull = false, System.Int16 @default = default(System.Int16))
        {
            System.Int16? result = null;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToInt16(x);
                }
            }
            catch
            { }

			if (result == null && useDefaultForNull)
            {
                result = @default;
            }

            return result;
        }
     		public static System.UInt64 ToUInt64(object x, System.UInt64 @default = default(System.UInt64))
        {
            System.UInt64 result;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToUInt64(x);
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
		public static System.UInt64? ToUInt64Nullable(object x, bool useDefaultForNull = false, System.UInt64 @default = default(System.UInt64))
        {
            System.UInt64? result = null;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToUInt64(x);
                }
            }
            catch
            { }

			if (result == null && useDefaultForNull)
            {
                result = @default;
            }

            return result;
        }
     		public static System.UInt32 ToUInt32(object x, System.UInt32 @default = default(System.UInt32))
        {
            System.UInt32 result;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToUInt32(x);
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
		public static System.UInt32? ToUInt32Nullable(object x, bool useDefaultForNull = false, System.UInt32 @default = default(System.UInt32))
        {
            System.UInt32? result = null;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToUInt32(x);
                }
            }
            catch
            { }

			if (result == null && useDefaultForNull)
            {
                result = @default;
            }

            return result;
        }
     		public static System.UInt16 ToUInt16(object x, System.UInt16 @default = default(System.UInt16))
        {
            System.UInt16 result;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToUInt16(x);
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
		public static System.UInt16? ToUInt16Nullable(object x, bool useDefaultForNull = false, System.UInt16 @default = default(System.UInt16))
        {
            System.UInt16? result = null;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToUInt16(x);
                }
            }
            catch
            { }

			if (result == null && useDefaultForNull)
            {
                result = @default;
            }

            return result;
        }
     		public static System.Single ToSingle(object x, System.Single @default = default(System.Single))
        {
            System.Single result;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToSingle(x);
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
		public static System.Single? ToSingleNullable(object x, bool useDefaultForNull = false, System.Single @default = default(System.Single))
        {
            System.Single? result = null;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToSingle(x);
                }
            }
            catch
            { }

			if (result == null && useDefaultForNull)
            {
                result = @default;
            }

            return result;
        }
     		public static System.Double ToDouble(object x, System.Double @default = default(System.Double))
        {
            System.Double result;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToDouble(x);
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
		public static System.Double? ToDoubleNullable(object x, bool useDefaultForNull = false, System.Double @default = default(System.Double))
        {
            System.Double? result = null;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToDouble(x);
                }
            }
            catch
            { }

			if (result == null && useDefaultForNull)
            {
                result = @default;
            }

            return result;
        }
     		public static System.Decimal ToDecimal(object x, System.Decimal @default = default(System.Decimal))
        {
            System.Decimal result;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToDecimal(x);
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
		public static System.Decimal? ToDecimalNullable(object x, bool useDefaultForNull = false, System.Decimal @default = default(System.Decimal))
        {
            System.Decimal? result = null;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToDecimal(x);
                }
            }
            catch
            { }

			if (result == null && useDefaultForNull)
            {
                result = @default;
            }

            return result;
        }
     		public static System.DateTime ToDateTime(object x, System.DateTime @default = default(System.DateTime))
        {
            System.DateTime result;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToDateTime(x);
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
		public static System.DateTime? ToDateTimeNullable(object x, bool useDefaultForNull = false, System.DateTime @default = default(System.DateTime))
        {
            System.DateTime? result = null;

            try
            {
                var s = x as string;

                if (!(DBNull.Value.Equals(x) || x == null || (s != null && string.IsNullOrWhiteSpace(s))))
                {
                    result = System.Convert.ToDateTime(x);
                }
            }
            catch
            { }

			if (result == null && useDefaultForNull)
            {
                result = @default;
            }

            return result;
        }
     	}
}