using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Caching;
using Locust.Db;
using Locust.Model;
using Locust.Tracing;

namespace Locust.ServiceModel.Babbage
{
    public abstract class BabbageScalerStrategy<TResponse, UData, VStatus, WRequest, TContext> : BabbageStrategy<TResponse, UData, VStatus, WRequest, TContext>
        where TResponse : BaseServiceResponse<UData, VStatus>, new()
        where WRequest : class, IBaseServiceRequest, new()
        where TContext : BabbageContext<TResponse, UData, VStatus, WRequest>, new()
    {
        private BabbageService babbageService;
        private bool _serviceCacheProbed;
        private ICacheManager _serviceCache;
        private ICacheManager _cache;
        public ICacheManager Cache
        {
            get
            {
                if (_cache == null)
                {
                    if (!_serviceCacheProbed)
                    {
                        if (babbageService == null && Store != null && this.Store.Service != null)
                        {
                            babbageService = this.Store.Service as BabbageService;
                        }

                        _serviceCache = babbageService?.Cache;
                        _serviceCacheProbed = true;
                    }

                    return _serviceCache;
                }
                else
                {
                    return _cache;
                }
            }
            set { _cache = value; }
        }

        private bool Finalize(TContext context, DbResult<object> dbr)
        {
            var result = false;
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
            var strategyName = _strategy.Name;
            var serviceName = _strategy.Store.Service.Name;

            if (dbr.Success && context.Response.Success)
            {
                try
                {
                    if (!DBNull.Value.Equals(dbr.Data) && dbr.Data != null)
                    {
                        if (dbr.Data is Guid)
                        {
                            var guid = dbr.Data.ToString();
                            context.Response.Data = (UData)Convert.ChangeType(guid, typeof(UData));
                        }
                        else
                        {
                            context.Response.Data = (UData) Convert.ChangeType(dbr.Data, typeof(UData));
                        }
                    }
                    result = true;
                }
                catch (Exception e)
                {
                    context.Log.Danger(serviceName, strategyName, "TypeCastFailed", e, MessageSource.Library);
                    context.Response.Errored();
                    context.Response.Data = default(UData);
                }
            }

            return result;
        }
        protected void ExecuteScaler(TContext context)
        {
            var responseDataType = context.Response.GetDataType();
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
            var args = new ExpandoObject() as IDictionary<string, object>;
            var cmd = GetContextCommand(context);

            ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

            var dbr = _strategy.Db.ExecuteScaler(cmd, args);

            ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

            Finalize(context, dbr);
        }
        protected async Task ExecuteScalerAsync(TContext context)
        {
            var responseDataType = context.Response.GetDataType();
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
            var args = new ExpandoObject() as IDictionary<string, object>;
            var cmd = GetContextCommand(context);

            ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

            var dbr = await _strategy.Db.ExecuteScalerAsync(cmd, args);

            ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

            Finalize(context, dbr);
        }
        protected void ExecuteScaler(TContext context, Func<TContext, string> keySpecifier)
        {
            ExecuteScaler(context, keySpecifier, (r) => 0);
        }
        protected void ExecuteScaler(TContext context, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier)
        {
            var key = "";
            Tuple<TResponse, Message> responseAndMessage = null;
            if (keySpecifier != null && Cache != null)
            {
                key = keySpecifier(context);
                if (!string.IsNullOrEmpty(key))
                {
                    responseAndMessage = Cache.Get(key) as Tuple<TResponse, Message>;
                }
            }

            if (responseAndMessage == null)
            {
                var responseDataType = context.Response.GetDataType();
                var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = _strategy.Db.ExecuteScaler(cmd, args);

                ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (Finalize(context, dbr))
                {
                    if (!string.IsNullOrEmpty(key) && Cache != null)
                    {
                        var msg = context.Log[context.Log.Count - 1];
                        var lifeLength = 0;
                        if (lifeSpecifier != null)
                        {
                            lifeLength = lifeSpecifier(context);
                        }
                        Cache.Add(key, Tuple.Create(context.Response, msg), lifeLength);
                    }
                }
            }
            else
            {
                context.Response = responseAndMessage.Item1;
                context.Response.Source = DataSource.Cache;
                context.Log.Add(responseAndMessage.Item2);
            }
        }
        protected async Task ExecuteScalerAsync(TContext context, Func<TContext, string> keySpecifier)
        {
            await ExecuteScalerAsync(context, keySpecifier, (r) => 0);
        }
        protected async Task ExecuteScalerAsync(TContext context, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier)
        {
            var key = "";
            Tuple<TResponse, Message> responseAndMessage = null;
            if (keySpecifier != null && Cache != null)
            {
                key = keySpecifier(context);
                if (!string.IsNullOrEmpty(key))
                {
                    responseAndMessage = Cache.Get(key) as Tuple<TResponse, Message>;
                }
            }

            if (responseAndMessage == null)
            {
                var responseDataType = context.Response.GetDataType();
                var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = await _strategy.Db.ExecuteScalerAsync(cmd, args);

                ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (Finalize(context, dbr))
                {
                    if (!string.IsNullOrEmpty(key) && Cache != null)
                    {
                        var msg = context.Log[context.Log.Count - 1];
                        var lifeLength = 0;
                        if (lifeSpecifier != null)
                        {
                            lifeLength = lifeSpecifier(context);
                        }
                        Cache.Add(key, Tuple.Create(context.Response, msg), lifeLength);
                    }
                }
            }
            else
            {
                context.Response = responseAndMessage.Item1;
                context.Response.Source = DataSource.Cache;
                context.Log.Add(responseAndMessage.Item2);
            }
        }
    }
}
