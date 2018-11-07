using System;
using System.Configuration;

namespace Locust.Configuration
{
	public partial class AppConfig
	{
		public string Get(string key, string defaultValue = "")
		{
			var result = ConfigurationManager.AppSettings[key] ?? "";

			return result;
		}
		public T Get<T>(string key, T defaultValue = default(T))
		{
			var result = defaultValue;

			try
			{
				var value = ConfigurationManager.AppSettings[key];
				if (value != null)
				{
										if (typeof(T) == typeof(bool))
					{
						bool r;

						if (bool.TryParse(value, out r))
						{
							result = (T)Convert.ChangeType(r, typeof(T));
							goto exit;
						}
					}
										if (typeof(T) == typeof(int))
					{
						int r;

						if (int.TryParse(value, out r))
						{
							result = (T)Convert.ChangeType(r, typeof(T));
							goto exit;
						}
					}
										if (typeof(T) == typeof(short))
					{
						short r;

						if (short.TryParse(value, out r))
						{
							result = (T)Convert.ChangeType(r, typeof(T));
							goto exit;
						}
					}
										if (typeof(T) == typeof(long))
					{
						long r;

						if (long.TryParse(value, out r))
						{
							result = (T)Convert.ChangeType(r, typeof(T));
							goto exit;
						}
					}
										if (typeof(T) == typeof(decimal))
					{
						decimal r;

						if (decimal.TryParse(value, out r))
						{
							result = (T)Convert.ChangeType(r, typeof(T));
							goto exit;
						}
					}
										if (typeof(T) == typeof(double))
					{
						double r;

						if (double.TryParse(value, out r))
						{
							result = (T)Convert.ChangeType(r, typeof(T));
							goto exit;
						}
					}
										if (typeof(T) == typeof(float))
					{
						float r;

						if (float.TryParse(value, out r))
						{
							result = (T)Convert.ChangeType(r, typeof(T));
							goto exit;
						}
					}
										if (typeof(T) == typeof(DateTime))
					{
						DateTime r;

						if (DateTime.TryParse(value, out r))
						{
							result = (T)Convert.ChangeType(r, typeof(T));
							goto exit;
						}
					}
										if (typeof(T) == typeof(string))
					{
						result = (T)Convert.ChangeType(value, typeof(T));
						goto exit;
					}
				}
			}
			catch { }
exit:
			return result;
		}
	}
}