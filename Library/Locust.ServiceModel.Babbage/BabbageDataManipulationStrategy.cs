using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Caching;
using Locust.Tracing;

namespace Locust.ServiceModel.Babbage
{
    public abstract class BabbageDataManipulationStrategy<TResponse, UData, VStatus, WRequest, TContext> : BabbageStrategy<TResponse, UData, VStatus, WRequest, TContext>
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
        protected void ExecuteNonQuery(TContext context)
        {
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
            var args = new ExpandoObject() as IDictionary<string, object>;
            var cmd = GetContextCommand(context);

            ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

            var dbr = _strategy.Db.ExecuteNonQuery(cmd, args);

            ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);
        }
        protected async Task ExecuteNonQueryAsync(TContext context)
        {
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
            var args = new ExpandoObject() as IDictionary<string, object>;
            var cmd = GetContextCommand(context);

            ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

            var dbr = await _strategy.Db.ExecuteNonQueryAsync(cmd, args);

            ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);
        }
        protected void ExecuteNonQuery(TContext context, Func<TContext, string> cacheRemoverKeySpecifier)
        {
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
            var args = new ExpandoObject() as IDictionary<string, object>;
            var cmd = GetContextCommand(context);

            ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

            var dbr = _strategy.Db.ExecuteNonQuery(cmd, args);
            if (dbr.Success && cacheRemoverKeySpecifier != null)
            {
                var key = cacheRemoverKeySpecifier(context);
                if (!string.IsNullOrEmpty(key) && Cache != null)
                {
                    Cache.Remove(key);
                }
            }

            ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);
        }
        protected async Task ExecuteNonQueryAsync(TContext context, Func<TContext, string> cacheRemoverKeySpecifier)
        {
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
            var args = new ExpandoObject() as IDictionary<string, object>;
            var cmd = GetContextCommand(context);

            ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

            var dbr = await _strategy.Db.ExecuteNonQueryAsync(cmd, args);
            if (dbr.Success && cacheRemoverKeySpecifier != null)
            {
                var key = cacheRemoverKeySpecifier(context);
                if (!string.IsNullOrEmpty(key) && Cache != null)
                {
                    Cache.Remove(key);
                }
            }

            ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);
        }
        protected void ExecuteNonQuery(TContext context, Func<TContext, string> keySpecifier, Func<TContext, UData> valueSpecifier, Func<UData, bool> cacheGetCondition)
        {
            ExecuteNonQuery(context, keySpecifier, valueSpecifier, (r) => 0, cacheGetCondition);
        }
        protected void ExecuteNonQuery(TContext context, Func<TContext, string> keySpecifier, Func<TContext, UData> valueSpecifier, Func<TContext, int> lifeSpecifier, Func<UData, bool> cacheGetCondition)
        {
            var key = "";
            Tuple<TResponse, Message> responseAndMessage = null;
            if (keySpecifier != null && Cache != null)
            {
                key = keySpecifier(context);
                if (!string.IsNullOrEmpty(key))
                {
                    responseAndMessage = Cache.TryGet(key, (Tuple<TResponse, Message> t) => { return cacheGetCondition(t.Item1.Data); });
                }
            }

            if (responseAndMessage == null)
            {
                var responseDataType = context.Response.GetDataType();
                var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = _strategy.Db.ExecuteNonQuery(cmd, args);

                ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    context.Response.Data = valueSpecifier(context);

                    if (!string.IsNullOrEmpty(key) && Cache != null)
                    {
                        var msg = context.Log[context.Log.Count - 1];
                        var lifeLength = 0;
                        if (lifeSpecifier != null)
                        {
                            lifeLength = lifeSpecifier(context);
                        }
                        var x = Cache.TryGetOrSet(key, () => Tuple.Create(context.Response, msg), lifeLength, t => cacheGetCondition(t.Item1.Data));
                        if (x.Item1 != context.Response)
                        {
                            context.Response = x.Item1;
                            context.Response.Source = DataSource.Cache;
                            context.Log.Add(x.Item2);
                        }
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
        protected async Task ExecuteNonQueryAsync(TContext context, Func<TContext, string> keySpecifier, Func<TContext, UData> valueSpecifier, Func<UData, Task<bool>> cacheGetCondition)
        {
            await ExecuteNonQueryAsync(context, keySpecifier, valueSpecifier, (r) => 0, cacheGetCondition);
        }
        protected async Task ExecuteNonQueryAsync(TContext context, Func<TContext, string> keySpecifier, Func<TContext, UData> valueSpecifier, Func<TContext, int> lifeSpecifier, Func<UData, Task<bool>> cacheGetCondition)
        {
            var key = "";
            Tuple<TResponse, Message> responseAndMessage = null;
            if (keySpecifier != null && Cache != null)
            {
                key = keySpecifier(context);
                if (!string.IsNullOrEmpty(key))
                {
                    responseAndMessage = await Cache.TryGetAsync(key, async (Tuple<TResponse, Message> t) => await cacheGetCondition(t.Item1.Data));
                }
            }

            if (responseAndMessage == null)
            {
                var responseDataType = context.Response.GetDataType();
                var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = await _strategy.Db.ExecuteNonQueryAsync(cmd, args);

                ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    context.Response.Data = valueSpecifier(context);

                    if (!string.IsNullOrEmpty(key) && Cache != null)
                    {
                        var msg = context.Log[context.Log.Count - 1];
                        var lifeLength = 0;
                        if (lifeSpecifier != null)
                        {
                            lifeLength = lifeSpecifier(context);
                        }
                        var x = await Cache.TryGetOrSet(key, () => Tuple.Create(context.Response, msg), lifeLength, async t => await cacheGetCondition(t.Item1.Data));
                        if (x.Item1 != context.Response)
                        {
                            context.Response = x.Item1;
                            context.Response.Source = DataSource.Cache;
                            context.Log.Add(x.Item2);
                        }
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
        protected void ExecuteNonQuery(TContext context, Func<TContext, string> keySpecifier, Func<TContext, UData> valueSpecifier)
        {
            ExecuteNonQuery(context, keySpecifier, valueSpecifier, (r) => 0);
        }
        protected void ExecuteNonQuery(TContext context, Func<TContext, string> keySpecifier, Func<TContext, UData> valueSpecifier, Func<TContext, int> lifeSpecifier)
        {
            var key = "";
            Tuple<TResponse, Message> responseAndMessage = null;
            if (keySpecifier != null && Cache != null)
            {
                key = keySpecifier(context);
                if (!string.IsNullOrEmpty(key))
                {
                    responseAndMessage = Cache.Get< Tuple<TResponse, Message>>(key);
                }
            }

            if (responseAndMessage == null)
            {
                var responseDataType = context.Response.GetDataType();
                var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = _strategy.Db.ExecuteNonQuery(cmd, args);

                ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    context.Response.Data = valueSpecifier(context);

                    if (!string.IsNullOrEmpty(key) && Cache != null)
                    {
                        var msg = context.Log[context.Log.Count - 1];
                        var lifeLength = 0;
                        if (lifeSpecifier != null)
                        {
                            lifeLength = lifeSpecifier(context);
                        }
                        var x = Cache.GetOrSet<Tuple<TResponse, Message>>(key, () => Tuple.Create(context.Response, msg), lifeLength);
                        if (x.Item1 != context.Response)
                        {
                            context.Response = x.Item1;
                            context.Response.Source = DataSource.Cache;
                            context.Log.Add(x.Item2);
                        }
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
        protected async Task ExecuteNonQueryAsync(TContext context, Func<TContext, string> keySpecifier, Func<TContext, UData> valueSpecifier)
        {
            await ExecuteNonQueryAsync(context, keySpecifier, valueSpecifier, (r) => 0);
        }
        protected async Task ExecuteNonQueryAsync(TContext context, Func<TContext, string> keySpecifier, Func<TContext, UData> valueSpecifier, Func<TContext, int> lifeSpecifier)
        {
            var key = "";
            Tuple<TResponse, Message> responseAndMessage = null;
            if (keySpecifier != null && Cache != null)
            {
                key = keySpecifier(context);
                if (!string.IsNullOrEmpty(key))
                {
                    responseAndMessage = Cache.Get< Tuple<TResponse, Message>>(key);
                }
            }

            if (responseAndMessage == null)
            {
                var responseDataType = context.Response.GetDataType();
                var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = await _strategy.Db.ExecuteNonQueryAsync(cmd, args);

                ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    context.Response.Data = valueSpecifier(context);

                    if (!string.IsNullOrEmpty(key) && Cache != null)
                    {
                        var msg = context.Log[context.Log.Count - 1];
                        var lifeLength = 0;
                        if (lifeSpecifier != null)
                        {
                            lifeLength = lifeSpecifier(context);
                        }
                        var x = Cache.GetOrSet<Tuple<TResponse, Message>>(key, () => Tuple.Create(context.Response, msg), lifeLength);
                        if (x.Item1 != context.Response)
                        {
                            context.Response = x.Item1;
                            context.Response.Source = DataSource.Cache;
                            context.Log.Add(x.Item2);
                        }
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
