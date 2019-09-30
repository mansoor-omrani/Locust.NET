using Locust.Base;
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
                var type = typeof(T);

                if (value != null)
                {
                    if (type == TypeHelper.TypeOfBool)
                    {
                        bool r;

                        if (bool.TryParse(value, out r))
                        {
                            result = (T)Convert.ChangeType(r, type);
                            goto exit;
                        }
                    }
                    if (type == TypeHelper.TypeOfInt)
                    {
                        int r;

                        if (int.TryParse(value, out r))
                        {
                            result = (T)Convert.ChangeType(r, type);
                            goto exit;
                        }
                    }
                    if (type == TypeHelper.TypeOfShort)
                    {
                        short r;

                        if (short.TryParse(value, out r))
                        {
                            result = (T)Convert.ChangeType(r, type);
                            goto exit;
                        }
                    }
                    if (type == TypeHelper.TypeOfLong)
                    {
                        long r;

                        if (long.TryParse(value, out r))
                        {
                            result = (T)Convert.ChangeType(r, type);
                            goto exit;
                        }
                    }
                    if (type == TypeHelper.TypeOfDecimal)
                    {
                        decimal r;

                        if (decimal.TryParse(value, out r))
                        {
                            result = (T)Convert.ChangeType(r, type);
                            goto exit;
                        }
                    }
                    if (type == TypeHelper.TypeOfDouble)
                    {
                        double r;

                        if (double.TryParse(value, out r))
                        {
                            result = (T)Convert.ChangeType(r, type);
                            goto exit;
                        }
                    }
                    if (type == TypeHelper.TypeOfFloat)
                    {
                        float r;

                        if (float.TryParse(value, out r))
                        {
                            result = (T)Convert.ChangeType(r, type);
                            goto exit;
                        }
                    }
                    if (type == TypeHelper.TypeOfDateTime)
                    {
                        DateTime r;

                        if (DateTime.TryParse(value, out r))
                        {
                            result = (T)Convert.ChangeType(r, type);
                            goto exit;
                        }
                    }
                    if (type == TypeHelper.TypeOfString)
                    {
                        result = (T)Convert.ChangeType(value, type);
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