using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Locust.Base;
using Locust.Conversion;
using Locust.Data;
using Locust.Db;
using Locust.Extensions;
using Locust.Json;
using Locust.Serialization;
using Locust.Tracing;

namespace Locust.ServiceModel
{
    public static class ServiceModelExtensions
    {
        public static string ToJson(this IBaseServiceRequest request)
        {
            //var result = "";
            //result = JsonConvert.SerializeObject(request);
            //return result;

            var result = new StringBuilder();
            result.Append("{");
            if (request != null)
            {
                var cnt = 0;
                foreach (var prop in request.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (prop.CanRead)
                    {
                        if (cnt++ > 0)
                            result.Append(", ");
                        var propType = prop.PropertyType;
                        var value = prop.GetValue(request);

                        if (value != null)
                        {
                            var cmdParam = value as CommandParameter;
                            if (cmdParam != null)
                            {
                                var cmdOutput = cmdParam as CommandOutputParameter;

                                if (cmdOutput == null)
                                {
                                    result.AppendFormat("\"{0}\": {1}", prop.Name, cmdParam.ToJson());
                                    continue;
                                }
                            }
                            if (propType.IsEnum)
                            {
                                result.AppendFormat("\"{0}\": \"{1}\"", prop.Name, value.ToString());
                                continue;
                            }
                            if (propType == TypeHelper.TypeOfBool)
                            {
                                result.AppendFormat("\"{0}\": {1}", prop.Name,
                                    SafeClrConvert.ToBoolean(value) ? "true" : "false");
                                continue;
                            }
                            if (propType == TypeHelper.TypeOfString)
                            {
                                result.AppendFormat("\"{0}\": \"{1}\"", prop.Name, HttpUtility.JavaScriptStringEncode(value.ToString()));
                                continue;
                            }
                            if (propType == TypeHelper.TypeOfChar)
                            {
                                result.AppendFormat("\"{0}\": '{1}'", prop.Name, value);
                                continue;
                            }
                            if (propType.IsBasicType())
                            {
                                result.AppendFormat("\"{0}\": {1}", prop.Name, value);
                                continue;
                            }
                            result.AppendFormat("\"{0}\": \"{1}\"", prop.Name, HttpUtility.JavaScriptStringEncode(value.ToString()));
                        }
                        else
                        {
                            result.AppendFormat("\"{0}\": null", prop.Name);
                        }
                    }
                }
            }

            result.Append("}");

            return result.ToString();
        }
        public static string ToJson(this IBaseServiceResponse response, JsonSerializationOptions options = null)
        {
            var _options = new JsonSerializationOptions(options);
            var result = new StringBuilder();
            
            if (response != null)
            {
                foreach (var prop in response.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
                {
                    if (prop.CanRead)
                    {
                        var propType = prop.PropertyType;
                        var value = prop.GetValue(response);

                        if (value != null)
                        {
                            var cmdParam = value as CommandParameter;
                            if (cmdParam != null)
                            {
                                result.AppendFormatWithCommaIfNotEmpty("\"{0}\": {1}", prop.Name, cmdParam.ToJson());
                                continue;
                            }
                            if (propType.IsEnum)
                            {
                                result.AppendFormatWithCommaIfNotEmpty("\"{0}\": \"{1}\"", prop.Name, value.ToString());
                                continue;
                            }
                            if (propType == TypeHelper.TypeOfBool)
                            {
                                result.AppendFormatWithCommaIfNotEmpty("\"{0}\": {1}", prop.Name,
                                    SafeClrConvert.ToBoolean(value) ? "true" : "false");
                                continue;
                            }
                            if (propType == TypeHelper.TypeOfString)
                            {
                                result.AppendFormatWithCommaIfNotEmpty("\"{0}\": \"{1}\"", prop.Name, value);
                                continue;
                            }
                            if (propType == TypeHelper.TypeOfChar)
                            {
                                result.AppendFormatWithCommaIfNotEmpty("\"{0}\": '{1}'", prop.Name, value);
                                continue;
                            }
                            if (propType.IsBasicType())
                            {
                                result.AppendFormatWithCommaIfNotEmpty("\"{0}\": {1}", prop.Name, value);
                                continue;
                            }
                            if (value is Guid)
                            {
                                if ((Guid)value != Guid.Empty)
                                {
                                    result.AppendFormatWithCommaIfNotEmpty("\"{0}\":'{1}'", prop.Name, value);
                                    continue;
                                }
                                else
                                {
                                    result.AppendFormatWithCommaIfNotEmpty("\"{0}\":null", prop.Name);
                                    continue;
                                }
                            }
                            var jm = value as IJsonSerializable;

                            if (jm != null)
                            {
                                result.AppendFormatWithCommaIfNotEmpty("\"{0}\":{1}", prop.Name, jm.ToJson(_options));
                                continue;
                            }

                            var e = value as IEnumerable;
                            if (e != null)
                            {
                                result.AppendFormatWithCommaIfNotEmpty("\"{0}\": ", prop.Name);
                                result.Append(e.ToJson(_options));
                                continue;
                            }
                            result.AppendFormatWithCommaIfNotEmpty("\"{0}\": \"{1}\"", prop.Name, value.ToString());
                        }
                        else
                        {
                            result.AppendFormatWithCommaIfNotEmpty("\"{0}\": null", prop.Name);
                        }
                    }
                }
            }

            return "{" + result + "}";
        }
        //public static void Dialog<UData, VStatus>(this MessageList log, string category, BaseServiceResponse<UData, VStatus> response, string content = "", string info = "")
        //{
        //    log.Dialog(new MessageItem(), response.Status.ToString(), content, info);
        //}

        internal static bool SetProperty(this IBaseServiceRequest serviceRequest, PropertyInfo prop, object value)
        {
            var result = false;

            if (value != null)
            {
                if (prop.PropertyType == typeof(CommandInputOutputParameter))
                {
                    var cmdIO = prop.GetValue(serviceRequest) as CommandInputOutputParameter;
                    if (cmdIO != null)
                    {
                        cmdIO.Value = value;
                        result = true;
                    }
                }
                else
                {
                    if (prop.PropertyType == typeof(GuidCommandParameter))
                    {
                        var cmdGUID = prop.GetValue(serviceRequest) as GuidCommandParameter;
                        if (cmdGUID != null)
                        {
                            cmdGUID.Value = value;
                            result = true;
                        }
                    }
                    else
                    {
                        prop.SetValue(serviceRequest, value);
                        result = true;
                    }
                }
            }
            
            return result;
        }
        public static bool Init(this IBaseServiceRequest serviceRequest, IDictionary<string, object> request)
        {
            var result = false;

            if (request != null)
            {
                foreach (var prop in serviceRequest.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.GetCustomAttribute<IgnoreAttribute>() == null))
                {
                    if (prop.CanRead)
                    {
                        if (request.ContainsKey(prop.Name))
                        {
                            var value = request[prop.Name];

                            result = serviceRequest.SetProperty(prop, value);
                        }
                    }
                }
            }

            return result;
        }
        
        public static bool Init(this IBaseServiceRequest serviceRequest, JObject request)
        {
            var result = false;

            if (request != null)
            {
                foreach (
                    var prop in
                    serviceRequest.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.GetCustomAttribute<IgnoreAttribute>() == null))
                {
                    if (prop.CanRead)
                    {
                        var token = request.GetValue(prop.Name);
                        if (token != null)
                        {
                            var value = token.Value<object>();

                            result = serviceRequest.SetProperty(prop, value);
                            //if (value != null)
                            //{
                            //    if (prop.PropertyType == typeof(CommandInputOutputParameter))
                            //    {
                            //        var cmdIO = prop.GetValue(serviceRequest) as CommandInputOutputParameter;
                            //        if (cmdIO != null)
                            //        {
                            //            cmdIO.Value = value;
                            //            result = true;
                            //        }
                            //    }
                            //    else
                            //    {
                            //        if (prop.PropertyType == typeof(GuidCommandParameter))
                            //        {
                            //            var cmdGUID = prop.GetValue(serviceRequest) as GuidCommandParameter;
                            //            if (cmdGUID != null)
                            //            {
                            //                cmdGUID.Value = value;
                            //                result = true;
                            //            }
                            //        }
                            //        else
                            //        {
                            //            prop.SetValue(serviceRequest, value);
                            //            result = true;
                            //        }
                            //    }
                            //}
                        }
                    }
                }
            }

            return result;
        }
        
        public static bool Init(this IBaseServiceRequest serviceRequest, object request)
        {
            var result = false;

            if (request != null)
            {
                var d = request as IDictionary<string, object>;
                if (d != null)
                {
                    return serviceRequest.Init(d);
                }
                var jo = request as JObject;
                if (jo != null)
                {
                    return serviceRequest.Init(jo);
                }

                foreach (var prop in serviceRequest.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.GetCustomAttribute<IgnoreAttribute>() == null))
                {
                    if (prop.CanRead)
                    {
                        var xProp = request.GetType()
                            .GetProperty(prop.Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                        if (xProp != null)
                        {
                            var value = xProp.GetValue(request);

                            result = serviceRequest.SetProperty(prop, value);

                            //if (value != null)
                            //{
                            //    if (prop.PropertyType == typeof(CommandInputOutputParameter))
                            //    {
                            //        var cmdIO = prop.GetValue(serviceRequest) as CommandInputOutputParameter;
                            //        if (cmdIO != null)
                            //        {
                            //            cmdIO.Value = value;
                            //            result = true;
                            //        }
                            //    }
                            //    else
                            //    {
                            //        if (prop.PropertyType == typeof(GuidCommandParameter))
                            //        {
                            //            var cmdGUID = prop.GetValue(serviceRequest) as GuidCommandParameter;
                            //            if (cmdGUID != null)
                            //            {
                            //                cmdGUID.Value = value;
                            //                result = true;
                            //            }
                            //        }
                            //        else
                            //        {
                            //            prop.SetValue(serviceRequest, value);
                            //            result = true;
                            //        }
                            //    }
                            //}
                        }
                    }
                }
            }

            return result;
        }
    }
}
