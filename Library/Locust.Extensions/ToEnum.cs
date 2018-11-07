

using System;
using Locust.Base;

namespace Locust.Extensions
{
	public class EnumUndefinedException: Exception
	{
		public EnumUndefinedException(string message): base(message)
		{ }
	}
	public class NotEnumException: Exception
	{
		public NotEnumException(string message): base(message)
		{ }
	}
	public static class ToEnumExtensions
	{
		internal static T CheckType<T>(bool throwOnUndefinedValues, T defaultValue)
		{
			var result = defaultValue;

			if (!typeof(T).IsEnum)
			{
				if (throwOnUndefinedValues)
				{
					throw new NotEnumException($"{typeof(T).Name} is not an Enum type");
				}
			}

			return result;
		}
		internal static object CheckType(Type type, bool throwOnUndefinedValues, object defaultValue)
		{
			var result = defaultValue;

			if (!type.IsEnum)
			{
				if (throwOnUndefinedValues)
				{
					throw new NotEnumException($"{type} is not an Enum type");
				}
			}

			return result;
		}
			public static T ToEnum<T>(this Byte x, bool throwOnUndefinedValues = false) where T : struct
		{
			var type = typeof(T);
			var result = CheckType<T>(throwOnUndefinedValues, default(T));

			try
			{
				result = (T)Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
					{
						var enumDefaultAttribute = (EnumDefaultAttribute)Attribute.GetCustomAttribute(type, typeof(EnumDefaultAttribute));
						var def = default(T);

						if (enumDefaultAttribute != null)
						{
							if (!Enum.TryParse<T>(enumDefaultAttribute.Value, out def))
							{
								def = default(T);
							}
						
						}

						result = def;
					}
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
				{
					throw;
				}
			}

			return result;
		}
		public static T ToEnum<T>(this Byte x, T defaultValue, bool throwOnUndefinedValues = false) where T : struct
		{
			var type = typeof(T);
			var result = CheckType<T>(throwOnUndefinedValues, defaultValue);

			try
			{
				result = (T)Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
						result = defaultValue;
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
					throw;

				result = defaultValue;
			}

			return result;
		}
		public static object ToEnum(this Byte x, Type type, bool throwOnUndefinedValues = false)
		{
			var result = CheckType(type, throwOnUndefinedValues, null);
			
			try
			{
				result = Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
					{
						var enumDefaultAttribute = (EnumDefaultAttribute)Attribute.GetCustomAttribute(type, typeof(EnumDefaultAttribute));

						if (enumDefaultAttribute != null)
						{
							result = Enum.Parse(type, enumDefaultAttribute.Value);
						}
					}
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
				{
					throw;
				}
			}

			return result;
		}
		public static object ToEnum(this Byte x, Type type, object defaultValue, bool throwOnUndefinedValues = false)
		{
			var result = CheckType(type, throwOnUndefinedValues, defaultValue);

			try
			{
				result = Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
						result = defaultValue;
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
					throw;

				result = defaultValue;
			}

			return result;
		}
			public static T ToEnum<T>(this SByte x, bool throwOnUndefinedValues = false) where T : struct
		{
			var type = typeof(T);
			var result = CheckType<T>(throwOnUndefinedValues, default(T));

			try
			{
				result = (T)Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
					{
						var enumDefaultAttribute = (EnumDefaultAttribute)Attribute.GetCustomAttribute(type, typeof(EnumDefaultAttribute));
						var def = default(T);

						if (enumDefaultAttribute != null)
						{
							if (!Enum.TryParse<T>(enumDefaultAttribute.Value, out def))
							{
								def = default(T);
							}
						
						}

						result = def;
					}
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
				{
					throw;
				}
			}

			return result;
		}
		public static T ToEnum<T>(this SByte x, T defaultValue, bool throwOnUndefinedValues = false) where T : struct
		{
			var type = typeof(T);
			var result = CheckType<T>(throwOnUndefinedValues, defaultValue);

			try
			{
				result = (T)Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
						result = defaultValue;
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
					throw;

				result = defaultValue;
			}

			return result;
		}
		public static object ToEnum(this SByte x, Type type, bool throwOnUndefinedValues = false)
		{
			var result = CheckType(type, throwOnUndefinedValues, null);
			
			try
			{
				result = Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
					{
						var enumDefaultAttribute = (EnumDefaultAttribute)Attribute.GetCustomAttribute(type, typeof(EnumDefaultAttribute));

						if (enumDefaultAttribute != null)
						{
							result = Enum.Parse(type, enumDefaultAttribute.Value);
						}
					}
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
				{
					throw;
				}
			}

			return result;
		}
		public static object ToEnum(this SByte x, Type type, object defaultValue, bool throwOnUndefinedValues = false)
		{
			var result = CheckType(type, throwOnUndefinedValues, defaultValue);

			try
			{
				result = Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
						result = defaultValue;
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
					throw;

				result = defaultValue;
			}

			return result;
		}
			public static T ToEnum<T>(this Int64 x, bool throwOnUndefinedValues = false) where T : struct
		{
			var type = typeof(T);
			var result = CheckType<T>(throwOnUndefinedValues, default(T));

			try
			{
				result = (T)Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
					{
						var enumDefaultAttribute = (EnumDefaultAttribute)Attribute.GetCustomAttribute(type, typeof(EnumDefaultAttribute));
						var def = default(T);

						if (enumDefaultAttribute != null)
						{
							if (!Enum.TryParse<T>(enumDefaultAttribute.Value, out def))
							{
								def = default(T);
							}
						
						}

						result = def;
					}
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
				{
					throw;
				}
			}

			return result;
		}
		public static T ToEnum<T>(this Int64 x, T defaultValue, bool throwOnUndefinedValues = false) where T : struct
		{
			var type = typeof(T);
			var result = CheckType<T>(throwOnUndefinedValues, defaultValue);

			try
			{
				result = (T)Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
						result = defaultValue;
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
					throw;

				result = defaultValue;
			}

			return result;
		}
		public static object ToEnum(this Int64 x, Type type, bool throwOnUndefinedValues = false)
		{
			var result = CheckType(type, throwOnUndefinedValues, null);
			
			try
			{
				result = Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
					{
						var enumDefaultAttribute = (EnumDefaultAttribute)Attribute.GetCustomAttribute(type, typeof(EnumDefaultAttribute));

						if (enumDefaultAttribute != null)
						{
							result = Enum.Parse(type, enumDefaultAttribute.Value);
						}
					}
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
				{
					throw;
				}
			}

			return result;
		}
		public static object ToEnum(this Int64 x, Type type, object defaultValue, bool throwOnUndefinedValues = false)
		{
			var result = CheckType(type, throwOnUndefinedValues, defaultValue);

			try
			{
				result = Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
						result = defaultValue;
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
					throw;

				result = defaultValue;
			}

			return result;
		}
			public static T ToEnum<T>(this Int32 x, bool throwOnUndefinedValues = false) where T : struct
		{
			var type = typeof(T);
			var result = CheckType<T>(throwOnUndefinedValues, default(T));

			try
			{
				result = (T)Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
					{
						var enumDefaultAttribute = (EnumDefaultAttribute)Attribute.GetCustomAttribute(type, typeof(EnumDefaultAttribute));
						var def = default(T);

						if (enumDefaultAttribute != null)
						{
							if (!Enum.TryParse<T>(enumDefaultAttribute.Value, out def))
							{
								def = default(T);
							}
						
						}

						result = def;
					}
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
				{
					throw;
				}
			}

			return result;
		}
		public static T ToEnum<T>(this Int32 x, T defaultValue, bool throwOnUndefinedValues = false) where T : struct
		{
			var type = typeof(T);
			var result = CheckType<T>(throwOnUndefinedValues, defaultValue);

			try
			{
				result = (T)Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
						result = defaultValue;
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
					throw;

				result = defaultValue;
			}

			return result;
		}
		public static object ToEnum(this Int32 x, Type type, bool throwOnUndefinedValues = false)
		{
			var result = CheckType(type, throwOnUndefinedValues, null);
			
			try
			{
				result = Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
					{
						var enumDefaultAttribute = (EnumDefaultAttribute)Attribute.GetCustomAttribute(type, typeof(EnumDefaultAttribute));

						if (enumDefaultAttribute != null)
						{
							result = Enum.Parse(type, enumDefaultAttribute.Value);
						}
					}
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
				{
					throw;
				}
			}

			return result;
		}
		public static object ToEnum(this Int32 x, Type type, object defaultValue, bool throwOnUndefinedValues = false)
		{
			var result = CheckType(type, throwOnUndefinedValues, defaultValue);

			try
			{
				result = Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
						result = defaultValue;
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
					throw;

				result = defaultValue;
			}

			return result;
		}
			public static T ToEnum<T>(this Int16 x, bool throwOnUndefinedValues = false) where T : struct
		{
			var type = typeof(T);
			var result = CheckType<T>(throwOnUndefinedValues, default(T));

			try
			{
				result = (T)Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
					{
						var enumDefaultAttribute = (EnumDefaultAttribute)Attribute.GetCustomAttribute(type, typeof(EnumDefaultAttribute));
						var def = default(T);

						if (enumDefaultAttribute != null)
						{
							if (!Enum.TryParse<T>(enumDefaultAttribute.Value, out def))
							{
								def = default(T);
							}
						
						}

						result = def;
					}
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
				{
					throw;
				}
			}

			return result;
		}
		public static T ToEnum<T>(this Int16 x, T defaultValue, bool throwOnUndefinedValues = false) where T : struct
		{
			var type = typeof(T);
			var result = CheckType<T>(throwOnUndefinedValues, defaultValue);

			try
			{
				result = (T)Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
						result = defaultValue;
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
					throw;

				result = defaultValue;
			}

			return result;
		}
		public static object ToEnum(this Int16 x, Type type, bool throwOnUndefinedValues = false)
		{
			var result = CheckType(type, throwOnUndefinedValues, null);
			
			try
			{
				result = Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
					{
						var enumDefaultAttribute = (EnumDefaultAttribute)Attribute.GetCustomAttribute(type, typeof(EnumDefaultAttribute));

						if (enumDefaultAttribute != null)
						{
							result = Enum.Parse(type, enumDefaultAttribute.Value);
						}
					}
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
				{
					throw;
				}
			}

			return result;
		}
		public static object ToEnum(this Int16 x, Type type, object defaultValue, bool throwOnUndefinedValues = false)
		{
			var result = CheckType(type, throwOnUndefinedValues, defaultValue);

			try
			{
				result = Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
						result = defaultValue;
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
					throw;

				result = defaultValue;
			}

			return result;
		}
			public static T ToEnum<T>(this UInt64 x, bool throwOnUndefinedValues = false) where T : struct
		{
			var type = typeof(T);
			var result = CheckType<T>(throwOnUndefinedValues, default(T));

			try
			{
				result = (T)Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
					{
						var enumDefaultAttribute = (EnumDefaultAttribute)Attribute.GetCustomAttribute(type, typeof(EnumDefaultAttribute));
						var def = default(T);

						if (enumDefaultAttribute != null)
						{
							if (!Enum.TryParse<T>(enumDefaultAttribute.Value, out def))
							{
								def = default(T);
							}
						
						}

						result = def;
					}
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
				{
					throw;
				}
			}

			return result;
		}
		public static T ToEnum<T>(this UInt64 x, T defaultValue, bool throwOnUndefinedValues = false) where T : struct
		{
			var type = typeof(T);
			var result = CheckType<T>(throwOnUndefinedValues, defaultValue);

			try
			{
				result = (T)Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
						result = defaultValue;
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
					throw;

				result = defaultValue;
			}

			return result;
		}
		public static object ToEnum(this UInt64 x, Type type, bool throwOnUndefinedValues = false)
		{
			var result = CheckType(type, throwOnUndefinedValues, null);
			
			try
			{
				result = Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
					{
						var enumDefaultAttribute = (EnumDefaultAttribute)Attribute.GetCustomAttribute(type, typeof(EnumDefaultAttribute));

						if (enumDefaultAttribute != null)
						{
							result = Enum.Parse(type, enumDefaultAttribute.Value);
						}
					}
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
				{
					throw;
				}
			}

			return result;
		}
		public static object ToEnum(this UInt64 x, Type type, object defaultValue, bool throwOnUndefinedValues = false)
		{
			var result = CheckType(type, throwOnUndefinedValues, defaultValue);

			try
			{
				result = Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
						result = defaultValue;
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
					throw;

				result = defaultValue;
			}

			return result;
		}
			public static T ToEnum<T>(this UInt32 x, bool throwOnUndefinedValues = false) where T : struct
		{
			var type = typeof(T);
			var result = CheckType<T>(throwOnUndefinedValues, default(T));

			try
			{
				result = (T)Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
					{
						var enumDefaultAttribute = (EnumDefaultAttribute)Attribute.GetCustomAttribute(type, typeof(EnumDefaultAttribute));
						var def = default(T);

						if (enumDefaultAttribute != null)
						{
							if (!Enum.TryParse<T>(enumDefaultAttribute.Value, out def))
							{
								def = default(T);
							}
						
						}

						result = def;
					}
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
				{
					throw;
				}
			}

			return result;
		}
		public static T ToEnum<T>(this UInt32 x, T defaultValue, bool throwOnUndefinedValues = false) where T : struct
		{
			var type = typeof(T);
			var result = CheckType<T>(throwOnUndefinedValues, defaultValue);

			try
			{
				result = (T)Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
						result = defaultValue;
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
					throw;

				result = defaultValue;
			}

			return result;
		}
		public static object ToEnum(this UInt32 x, Type type, bool throwOnUndefinedValues = false)
		{
			var result = CheckType(type, throwOnUndefinedValues, null);
			
			try
			{
				result = Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
					{
						var enumDefaultAttribute = (EnumDefaultAttribute)Attribute.GetCustomAttribute(type, typeof(EnumDefaultAttribute));

						if (enumDefaultAttribute != null)
						{
							result = Enum.Parse(type, enumDefaultAttribute.Value);
						}
					}
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
				{
					throw;
				}
			}

			return result;
		}
		public static object ToEnum(this UInt32 x, Type type, object defaultValue, bool throwOnUndefinedValues = false)
		{
			var result = CheckType(type, throwOnUndefinedValues, defaultValue);

			try
			{
				result = Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
						result = defaultValue;
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
					throw;

				result = defaultValue;
			}

			return result;
		}
			public static T ToEnum<T>(this UInt16 x, bool throwOnUndefinedValues = false) where T : struct
		{
			var type = typeof(T);
			var result = CheckType<T>(throwOnUndefinedValues, default(T));

			try
			{
				result = (T)Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
					{
						var enumDefaultAttribute = (EnumDefaultAttribute)Attribute.GetCustomAttribute(type, typeof(EnumDefaultAttribute));
						var def = default(T);

						if (enumDefaultAttribute != null)
						{
							if (!Enum.TryParse<T>(enumDefaultAttribute.Value, out def))
							{
								def = default(T);
							}
						
						}

						result = def;
					}
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
				{
					throw;
				}
			}

			return result;
		}
		public static T ToEnum<T>(this UInt16 x, T defaultValue, bool throwOnUndefinedValues = false) where T : struct
		{
			var type = typeof(T);
			var result = CheckType<T>(throwOnUndefinedValues, defaultValue);

			try
			{
				result = (T)Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
						result = defaultValue;
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
					throw;

				result = defaultValue;
			}

			return result;
		}
		public static object ToEnum(this UInt16 x, Type type, bool throwOnUndefinedValues = false)
		{
			var result = CheckType(type, throwOnUndefinedValues, null);
			
			try
			{
				result = Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
					{
						var enumDefaultAttribute = (EnumDefaultAttribute)Attribute.GetCustomAttribute(type, typeof(EnumDefaultAttribute));

						if (enumDefaultAttribute != null)
						{
							result = Enum.Parse(type, enumDefaultAttribute.Value);
						}
					}
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
				{
					throw;
				}
			}

			return result;
		}
		public static object ToEnum(this UInt16 x, Type type, object defaultValue, bool throwOnUndefinedValues = false)
		{
			var result = CheckType(type, throwOnUndefinedValues, defaultValue);

			try
			{
				result = Enum.ToObject(type, x);

				if (!Enum.IsDefined(type, result))
				{
					if (throwOnUndefinedValues)
						throw new EnumUndefinedException($"{type} enum does not have a {x} value");
					else
						result = defaultValue;
				}
			}
			catch (Exception)
			{
				if (throwOnUndefinedValues)
					throw;

				result = defaultValue;
			}

			return result;
		}
		}
}