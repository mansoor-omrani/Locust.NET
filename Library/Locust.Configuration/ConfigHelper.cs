using Locust.Base;
using Locust.Conversion;
using Locust.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Configuration
{
    public static class ConfigHelper
    {
        public static T AppSetting<T>(string key, T defaultValue = default(T)) where T : struct
        {
            var result = default(T);
            var type = typeof(T);
            var value = ConfigurationManager.AppSettings[key];

            if (type.IsEnum)
            {
                if (value.IsNumeric())
                {
                    result = SafeClrConvert.ToInt(value).ToEnum(defaultValue);
                }
                else
                {
                    if (!Enum.TryParse(value, out result))
                    {
                        result = defaultValue;
                    }
                }
            }
            else
            {
                if (type.IsBasicType())
                {
                    for (var i = 0; i < 1; i++)
                    {
                        if (type == TypeHelper.TypeOfBool)
                        {
                            result = (T)System.Convert.ChangeType(SafeClrConvert.ToBoolean(value), type);
                            break;
                        }
                        if (type == TypeHelper.TypeOfInt16)
                        {
                            result = (T)System.Convert.ChangeType(SafeClrConvert.ToInt16(value), type);
                            break;
                        }
                        if (type == TypeHelper.TypeOfInt32)
                        {
                            result = (T)System.Convert.ChangeType(SafeClrConvert.ToInt32(value), type);
                            break;
                        }
                        if (type == TypeHelper.TypeOfInt64)
                        {
                            result = (T)System.Convert.ChangeType(SafeClrConvert.ToInt64(value), type);
                            break;
                        }
                        if (type == TypeHelper.TypeOfByte)
                        {
                            result = (T)System.Convert.ChangeType(SafeClrConvert.ToByte(value), type);
                            break;
                        }
                        if (type == TypeHelper.TypeOfSByte)
                        {
                            result = (T)System.Convert.ChangeType(SafeClrConvert.ToSByte(value), type);
                            break;
                        }
                        if (type == TypeHelper.TypeOfUInt16)
                        {
                            result = (T)System.Convert.ChangeType(SafeClrConvert.ToUInt16(value), type);
                            break;
                        }
                        if (type == TypeHelper.TypeOfUInt32)
                        {
                            result = (T)System.Convert.ChangeType(SafeClrConvert.ToUInt32(value), type);
                            break;
                        }
                        if (type == TypeHelper.TypeOfUInt64)
                        {
                            result = (T)System.Convert.ChangeType(SafeClrConvert.ToUInt64(value), type);
                            break;
                        }
                        if (type == TypeHelper.TypeOfChar)
                        {
                            result = (T)System.Convert.ChangeType(SafeClrConvert.ToChar(value), type);
                            break;
                        }
                        if (type == TypeHelper.TypeOfDateTime)
                        {
                            result = (T)System.Convert.ChangeType(SafeClrConvert.ToDateTime(value), type);
                            break;
                        }
                        if (type == TypeHelper.TypeOfDecimal)
                        {
                            result = (T)System.Convert.ChangeType(SafeClrConvert.ToDecimal(value), type);
                            break;
                        }
                        if (type == TypeHelper.TypeOfDouble)
                        {
                            result = (T)System.Convert.ChangeType(SafeClrConvert.ToDouble(value), type);
                            break;
                        }
                        if (type == TypeHelper.TypeOfFloat)
                        {
                            result = (T)System.Convert.ChangeType(SafeClrConvert.ToSingle(value), type);
                            break;
                        }
                        if (type == TypeHelper.TypeOfGuid)
                        {
                            result = (T)System.Convert.ChangeType(SafeClrConvert.ToGuid(value), type);
                            break;
                        }
                        if (type == TypeHelper.TypeOfTimeSpan)
                        {
                            result = (T)System.Convert.ChangeType(SafeClrConvert.ToTimeSpan(value), type);
                            break;
                        }
                        if (type == TypeHelper.TypeOfString)
                        {
                            result = (T)((object)value);
                            break;
                        }
                    }
                }
            }

            return result;
        }
    }
}
