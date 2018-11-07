using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Locust.Base;
using Locust.Conversion;
using Locust.Db;
using Locust.Extensions;
using Locust.Model;
using Locust.Tracing;
using System.Diagnostics;
using System.Web.Hosting;
using Locust.Collections;
using Locust.Data;
using Locust.ModelField;
using TypeHelper = Locust.Base.TypeHelper;

namespace Locust.ServiceModel.Babbage
{
    public abstract class BabbageStrategy<TResponse, UData, VStatus, WRequest, TContext>: BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>
        where TResponse : BaseServiceResponse<UData, VStatus>, new()
        where WRequest : class, IBaseServiceRequest, new()
        where TContext : BabbageContext<TResponse, UData, VStatus, WRequest>, new()
    {
        protected virtual IDbCommand GetContextCommand(IServiceStrategyContext context)
        {
            var babbageContext = context as BabbageContext<TResponse, UData, VStatus, WRequest>;
            var _cmd = "";

            if (babbageContext != null && !string.IsNullOrEmpty(babbageContext.CommandText))
            {
                _cmd = babbageContext.CommandText;
            }
            else
            {
                _cmd = "usp1_" + context.Strategy.Store.Service.Name + "_" + context.Strategy.Name;
            }

            return Db.GetCommand(_cmd);
        }
        protected void ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(TContext context, IDbCommand cmd, IDictionary<string, object> args)
            where TResponse : BaseServiceResponse<UData, VStatus>, new()
            where WRequest : class, IBaseServiceRequest, new()
            where TContext : BabbageContext<TResponse, UData, VStatus, WRequest>, new()
        {
            Type requestType;
            var babbageRequest = context.Request as BabbageRequest;
            var baseRequest = context.Request as BaseServiceRequest;

            if (context.OverrideRequest != null)
            {
                requestType = context.OverrideRequest.GetType();
            }
            else
            {
                requestType = context.Request.GetType();
            }

            args.Add("Result", CommandParameter.Output(SqlDbType.VarChar, 50));
            args.Add("Args", CommandParameter.Output(SqlDbType.NVarChar, 1000));

            var execMode = 0;
            var ctx = context as BabbageContext<TResponse, UData, VStatus, WRequest>;

            if (ctx != null)
                execMode = ctx.ExecMode;
            else
                if (context.Log.DebugMode)
                    execMode = 1;

            args.Add("ExecMode", execMode);
            
            var reqProps = requestType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var _args = new StringBuilder();
            List<string> overrideList = null;

            if (baseRequest != null)
            {
                overrideList = baseRequest.GetOverrideList();
            }
            //var cnt = 0;

            object value = null;
            Type proptype;

            var babbageContext = context as BabbageContext<TResponse, UData, VStatus, WRequest>;

            if (babbageContext != null)
            {
                foreach (var op in babbageContext.OutputParameters)
                {
                    args.Add(op.Key, op.Value);
                }
            }

            foreach (var prop in reqProps)
            {
                if (prop.CanRead)
                {
                    if (babbageRequest != null && string.Compare(prop.Name, "Hash", StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        continue;
                    }

                    if (overrideList != null && overrideList.Count > 0 && overrideList.Exists(x => string.Compare(x, prop.Name, StringComparison.OrdinalIgnoreCase) == 0))
                    {
                        if (baseRequest.GetValue(prop.Name, out value))
                        {
                            args.Add(prop.Name, value);
                        }

                        continue;
                    }

                    proptype = prop.PropertyType;

                    if (proptype.IsNullableOrBasicType() || proptype.IsModelField() || proptype.IsCommandParameterType())
                    {
                        if (context.OverrideRequest != null)
                        {
                            value = prop.GetValue(context.OverrideRequest);
                        }
                        else
                        {
                            value = prop.GetValue(context.Request);
                        }

                        args.Add(prop.Name, value);

                        if (context.Log.DebugMode)
                        {
                            var _value = "";
                            var cmdIO = value as CommandInputOutputParameter;
                            if (cmdIO != null)
                            {
                                _value = SafeClrConvert.ToString(cmdIO.Value);
                                _args.AppendFormatWithCommaIfNotEmpty("{0}: {1}", prop.Name, _value);
                                //_args.Append((cnt == 0) ? "" : "," + prop.Name + ":" + SafeClrConvert.ToString(cmdIO.Value));
                            }
                            else
                            {
                                var cmdGUId = value as GuidCommandParameter;
                                if (cmdGUId != null)
                                {
                                    _value = SafeClrConvert.ToString(cmdGUId.Value);
                                    _args.AppendFormatWithCommaIfNotEmpty("{0}: {1}", prop.Name, _value);

                                    //_args.Append((cnt == 0)
                                    //    ? ""
                                    //    : "," + prop.Name + ":" + SafeClrConvert.ToString(cmdGUId.Value));
                                }
                                else
                                {
                                    var cmdParam = value as CommandParameter;
                                    if (cmdParam != null)
                                    {
                                        _value = SafeClrConvert.ToString(cmdParam.Value);
                                        _args.AppendFormatWithCommaIfNotEmpty("{0}: {1}", prop.Name, _value);

                                        //_args.Append((cnt == 0)
                                        //    ? ""
                                        //    : "," + prop.Name + ":" + SafeClrConvert.ToString(cmdParam.Value));
                                    }
                                    else
                                    {
                                        _value = SafeClrConvert.ToString(value);
                                        _args.AppendFormatWithCommaIfNotEmpty("{0}: {1}", prop.Name, _value);

                                        //_args.Append((cnt == 0)
                                        //    ? ""
                                        //    : "," + prop.Name + ":" + SafeClrConvert.ToString(value));
                                    }
                                }
                            }
                            //cnt++;
                        }
                    }
                    else
                    {
                        // currently, we don't support non-basic types
                    }
                }
            }

            context.Log.System(context.Strategy.Store.Service.Name, context.Strategy.Name, "sys_db_cmd_exec", () => _args.ToString());
        }
        protected void ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(TContext context,
            IDbCommand cmd, IDictionary<string, object> args, DbResult dbr)
            where TResponse : BaseServiceResponse<UData, VStatus>, new()
            where WRequest : class, IBaseServiceRequest, new()
            where TContext : BabbageContext<TResponse, UData, VStatus, WRequest>, new()
        {
            var responseType = context.Response.GetType();
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
            var strategyName = _strategy.Name;
            var serviceName = _strategy.Store.Service.Name;

            if (dbr.Success)
            {
                var responseInfo = "";
                if (args.Count > 0)
                {
                    var babbageContext = context as BabbageContext<TResponse, UData, VStatus, WRequest>;

                    if (babbageContext != null)
                    {
                        foreach (var item in args.Where(x => x.Key != "Result" && x.Key != "Args" && x.Value != null && x.Value.GetType().IsCommandOutputParameterType()))
                        {
                            var cmdOut = item.Value as CommandOutputParameter;

                            if (!DBNull.Value.Equals(cmdOut.Value) && cmdOut.Value != null && babbageContext.OutputParameters.Count > 0 && babbageContext.OutputParameters.ContainsKey(item.Key))
                            {
                                if (cmdOut.Value.GetType() == TypeHelper.TypeOfGuid)
                                {
                                    babbageContext.OutputParameters[item.Key].Value = cmdOut.Value.ToString();
                                }
                                else
                                {
                                    babbageContext.OutputParameters[item.Key].Value = cmdOut.Value;
                                }
                            }

                            if (context.Log.DebugMode)
                            {
                                responseInfo += (string.IsNullOrEmpty(responseInfo) ? "" : ", ") + item.Key + ": " + SafeClrConvert.ToString(cmdOut.Value);
                            }
                        }
                    }

                    var resProps = responseType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

                    foreach (var prop in resProps)
                    {
                        if (prop.CanWrite && args.ContainsKey(prop.Name))
                        {
                            var value = args[prop.Name];
                            var cmdOut = value as CommandOutputParameter;

                            if (cmdOut != null)
                            {
                                if (!DBNull.Value.Equals(cmdOut.Value) && cmdOut.Value != null)
                                {
                                    if (cmdOut.Value.GetType() == TypeHelper.TypeOfGuid)
                                    {
                                        prop.SetValue(context.Response, cmdOut.Value.ToString());
                                    }
                                    else
                                    {
                                        prop.SetValue(context.Response, cmdOut.Value);
                                    }
                                }

                                if (prop.CanRead && context.Log.DebugMode)
                                {
                                    responseInfo += (string.IsNullOrEmpty(responseInfo) ? "" : ", ") + prop.Name + ": " + SafeClrConvert.ToString(cmdOut.Value);
                                }

                                continue;
                            }

                            var cmdIO = value as CommandInputOutputParameter;
                            if (cmdIO != null)
                            {
                                if (!DBNull.Value.Equals(cmdIO.Value) && cmdIO.Value != null)
                                {
                                    if (cmdIO.Value.GetType() == TypeHelper.TypeOfGuid)
                                    {
                                        prop.SetValue(context.Response, cmdIO.Value.ToString());
                                    }
                                    else
                                    {
                                        prop.SetValue(context.Response, cmdIO.Value);
                                    }
                                }

                                if (prop.CanRead && context.Log.DebugMode)
                                {
                                    responseInfo += (string.IsNullOrEmpty(responseInfo) ? "" : ", ") + prop.Name + ": " + SafeClrConvert.ToString(cmdIO.Value);
                                }

                                continue;
                            }

                            prop.SetValue(context.Response, value);

                            if (prop.CanRead && context.Log.DebugMode)
                            {
                                responseInfo += (string.IsNullOrEmpty(responseInfo) ? "" : ", ") + prop.Name + ": " + SafeClrConvert.ToString(value);
                            }
                        }
                    }

                    var responseData = context.Response.GetData();

                    if (responseData != null)
                    {
                        var resDataType = context.Response.GetDataType();

                        if (resDataType.IsClass ||
                            (resDataType.IsValueType && !resDataType.IsEnum && !resDataType.IsPrimitive))
                        {
                            var resDataProps = responseData.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

                            foreach (var prop in resDataProps)
                            {
                                if (prop.CanWrite && args.ContainsKey(prop.Name))
                                {
                                    var value = args[prop.Name];
                                    var cmdOut = value as CommandOutputParameter;

                                    if (cmdOut != null)
                                    {
                                        if (!DBNull.Value.Equals(cmdOut.Value) && cmdOut.Value != null)
                                        {
                                            if (cmdOut.Value.GetType() == TypeHelper.TypeOfGuid)
                                            {
                                                prop.SetValue(responseData, cmdOut.Value.ToString());
                                            }
                                            else
                                            {
                                                prop.SetValue(responseData, cmdOut.Value);
                                            }
                                        }
                                        continue;
                                    }

                                    var cmdIO = value as CommandInputOutputParameter;
                                    if (cmdIO != null)
                                    {
                                        if (!DBNull.Value.Equals(cmdIO.Value) && cmdIO.Value != null)
                                        {
                                            if (cmdIO.Value.GetType() == TypeHelper.TypeOfGuid)
                                            {
                                                prop.SetValue(responseData, cmdIO.Value.ToString());
                                            }
                                            else
                                            {
                                                prop.SetValue(responseData, cmdIO.Value);
                                            }
                                        }
                                        continue;
                                    }

                                    prop.SetValue(responseData, value);
                                }
                            }
                        }
                    }
                }

                context.Log.Debug(ServiceName, strategyName, "response_filtered", responseInfo);

                var status = SafeClrConvert.ToString((args["Result"] as CommandOutputParameter).Value);
                var _args = SafeClrConvert.ToString((args["Args"] as CommandOutputParameter).Value);

                if (!context.Response.SetStatus(status))
                {
                    context.Log.Debug(ServiceName, strategyName, "InvalidStatus", status);
                }
                
                if (context.Response.IsFailed())
                {
                    try
                    {
                        var sqlError = JsonConvert.DeserializeObject<SqlError>(_args);
                        context.Log.Dialog(serviceName, strategyName, status, sqlError);
                    }
                    catch (Exception e)
                    {
                        context.Log.Danger(serviceName, strategyName, "SqlDeserializationError", e, MessageSource.Library, _args);
                    }
                }
                else
                {
                    CaseInsensitiveStringDictionary mArgs = null;

                    if (!string.IsNullOrEmpty(_args))
                    {
                        try
                        {
                            mArgs = JsonConvert.DeserializeObject<CaseInsensitiveStringDictionary>(_args);
                        }
                        catch (Exception e)
                        {
                            context.Log.Danger(serviceName, strategyName, "ArgsDeserializationError", e, MessageSource.Library, _args);
                        }
                    }
                    if (mArgs == null)
                    {
                        mArgs = new CaseInsensitiveStringDictionary();
                    }

                    context.Log.Dialog(serviceName, strategyName, status, mArgs);

                    if (context.Response.Success)
                    {
                        context.Response.Source = DataSource.Db;
                    }
                }
            }
            else
            {
                context.Response.Errored();
                
                context.Log.Dialog(serviceName, strategyName, context.Response.GetStatus(), dbr.Exception, MessageSource.Application);

                //Store.Service.Logger?.LogException(dbr.Exception, serviceName + "." + strategyName);
            }
        }
    }
}
