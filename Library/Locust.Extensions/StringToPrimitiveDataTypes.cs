

using System;
using Locust.Base;
using Locust.Conversion;

namespace Locust.Extensions
{
	public static partial class StringExtensions
	{
    		public static System.Byte ToByte(this string s, System.Byte @default = default(System.Byte))
		{
			return SafeClrConvert.ToByte(s, @default);
		} 
     		public static System.SByte ToSByte(this string s, System.SByte @default = default(System.SByte))
		{
			return SafeClrConvert.ToSByte(s, @default);
		} 
     		public static System.Int64 ToInt64(this string s, System.Int64 @default = default(System.Int64))
		{
			return SafeClrConvert.ToInt64(s, @default);
		} 
     		public static System.Int32 ToInt32(this string s, System.Int32 @default = default(System.Int32))
		{
			return SafeClrConvert.ToInt32(s, @default);
		} 
     		public static System.Int16 ToInt16(this string s, System.Int16 @default = default(System.Int16))
		{
			return SafeClrConvert.ToInt16(s, @default);
		} 
     		public static System.UInt64 ToUInt64(this string s, System.UInt64 @default = default(System.UInt64))
		{
			return SafeClrConvert.ToUInt64(s, @default);
		} 
     		public static System.UInt32 ToUInt32(this string s, System.UInt32 @default = default(System.UInt32))
		{
			return SafeClrConvert.ToUInt32(s, @default);
		} 
     		public static System.UInt16 ToUInt16(this string s, System.UInt16 @default = default(System.UInt16))
		{
			return SafeClrConvert.ToUInt16(s, @default);
		} 
     		public static short ToShort(this string s, short @default = default(short))
		{
			return SafeClrConvert.ToShort(s, @default);
		} 
     		public static ushort ToUShort(this string s, ushort @default = default(ushort))
		{
			return SafeClrConvert.ToUShort(s, @default);
		} 
     		public static long ToLong(this string s, long @default = default(long))
		{
			return SafeClrConvert.ToLong(s, @default);
		} 
     		public static ulong ToULong(this string s, ulong @default = default(ulong))
		{
			return SafeClrConvert.ToULong(s, @default);
		} 
     		public static int ToInt(this string s, int @default = default(int))
		{
			return SafeClrConvert.ToInt(s, @default);
		} 
     		public static uint ToUInt(this string s, uint @default = default(uint))
		{
			return SafeClrConvert.ToUInt(s, @default);
		} 
     		public static System.Single ToSingle(this string s, System.Single @default = default(System.Single))
		{
			return SafeClrConvert.ToSingle(s, @default);
		} 
     		public static System.Double ToDouble(this string s, System.Double @default = default(System.Double))
		{
			return SafeClrConvert.ToDouble(s, @default);
		} 
     		public static System.DateTime ToDateTime(this string s, System.DateTime @default = default(System.DateTime))
		{
			return SafeClrConvert.ToDateTime(s, @default);
		} 
     		public static System.Boolean ToBoolean(this string s, System.Boolean @default = default(System.Boolean))
		{
			return SafeClrConvert.ToBoolean(s, @default);
		} 
     	}
}