using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Caching;
using Locust.Model;
using Locust.Tracing;

namespace Locust.ServiceModel.Babbage
{
    public abstract class BabbageItemFetcherStrategy<TResponse, UData, VStatus, WRequest, TContext> : BabbageStrategy<TResponse, UData, VStatus, WRequest, TContext>
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

        protected void ExecuteSingle(TContext context)
        {
            var responseDataType = context.Response.GetDataType();
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
            var args = new ExpandoObject() as IDictionary<string, object>;
            var cmd = GetContextCommand(context);

            ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

            var dbr = _strategy.Db.ExecuteSingle(cmd, (IDataReader reader) =>
            {
                var result = Activator.CreateInstance(responseDataType);
                var r = result as BaseModel;

                if (r != null)
                {
                    r.Read(reader);
                }

                return result;
            }, args);

            ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

            if (dbr.Success && context.Response.Success)
            {
                context.Response.Data = (UData)dbr.Data;

                if (context.Response.Data == null)
                {
                    context.Response.NotFound();
                }
            }
        }
        protected async Task ExecuteSingleAsync(TContext context)
        {
            var responseDataType = context.Response.GetDataType();
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
            var args = new ExpandoObject() as IDictionary<string, object>;
            var cmd = GetContextCommand(context);

            ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

            var dbr = await _strategy.Db.ExecuteSingleAsync(cmd, (reader) =>
            {
                var result = Activator.CreateInstance(responseDataType);
                var r = result as BaseModel;

                if (r != null)
                {
                    r.Read(reader);
                }

                return result;
            }, args);

            ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

            if (dbr.Success && context.Response.Success)
            {
                context.Response.Data = (UData)dbr.Data;

                if (context.Response.Data == null)
                {
                    context.Response.NotFound();
                }
            }
        }
        protected void ExecuteSingle(TContext context, Func<IDataReader, UData> transform)
        {
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
            var args = new ExpandoObject() as IDictionary<string, object>;
            var cmd = GetContextCommand(context);

            ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

            var dbr = _strategy.Db.ExecuteSingle(cmd, transform, args);

            ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

            if (dbr.Success && context.Response.Success)
            {
                context.Response.Data = dbr.Data;

                if (context.Response.Data == null)
                {
                    context.Response.NotFound();
                }
            }
        }
        protected async Task ExecuteSingleAsync(TContext context, Func<IDataReader, UData> transform)
        {
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
            var args = new ExpandoObject() as IDictionary<string, object>;
            var cmd = GetContextCommand(context);

            ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

            var dbr = await _strategy.Db.ExecuteSingleAsync(cmd, transform, args);

            ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

            if (dbr.Success && context.Response.Success)
            {
                context.Response.Data = dbr.Data;

                if (context.Response.Data == null)
                {
                    context.Response.NotFound();
                }
            }
        }
        protected void ExecuteSingle(TContext context, Func<TContext, string> keySpecifier)
        {
            ExecuteSingle(context, keySpecifier, (r) => 0);
        }
        protected void ExecuteSingle(TContext context, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier)
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

                var dbr = _strategy.Db.ExecuteSingle(cmd, (IDataReader reader) =>
                {
                    var result = Activator.CreateInstance(responseDataType);
                    var r = result as BaseModel;

                    if (r != null)
                    {
                        r.Read(reader);
                    }

                    return result;
                }, args);

                ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    context.Response.Data = (UData)dbr.Data;

                    if (context.Response.Data == null)
                    {
                        context.Response.NotFound();
                    }
                    else
                    {
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
            }
            else
            {
                context.Response = responseAndMessage.Item1;
                context.Response.Source = DataSource.Cache;
                context.Log.Add(responseAndMessage.Item2);
            }
        }
        protected async Task ExecuteSingleAsync(TContext context, Func<TContext, string> keySpecifier)
        {
            await ExecuteSingleAsync(context, keySpecifier, (r) => 0);
        }
        protected async Task ExecuteSingleAsync(TContext context, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier)
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

                var dbr = await _strategy.Db.ExecuteSingleAsync(cmd, (reader) =>
                {
                    var result = Activator.CreateInstance(responseDataType);
                    var r = result as BaseModel;

                    if (r != null)
                    {
                        r.Read(reader);
                    }

                    return result;
                }, args);

                ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    context.Response.Data = (UData)dbr.Data;

                    if (context.Response.Data == null)
                    {
                        context.Response.NotFound();
                    }
                    else
                    {
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
            }
            else
            {
                context.Response = responseAndMessage.Item1;
                context.Response.Source = DataSource.Cache;
                context.Log.Add(responseAndMessage.Item2);
            }
        }
        protected void ExecuteSingle(TContext context, Func<IDataReader, UData> transform, Func<TContext, string> keySpecifier)
        {
            ExecuteSingle(context, transform, keySpecifier, (r) => 0);
        }
        protected void ExecuteSingle(TContext context, Func<IDataReader, UData> transform, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier)
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
                var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = _strategy.Db.ExecuteSingle(cmd, transform, args);

                ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    context.Response.Data = dbr.Data;

                    if (context.Response.Data == null)
                    {
                        context.Response.NotFound();
                    }
                    else
                    {
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
            }
            else
            {
                context.Response = responseAndMessage.Item1;
                context.Response.Source = DataSource.Cache;
                context.Log.Add(responseAndMessage.Item2);
            }
        }
        protected async Task ExecuteSingleAsync(TContext context, Func<IDataReader, UData> transform, Func<TContext, string> keySpecifier)
        {
            await ExecuteSingleAsync(context, transform, keySpecifier, (r) => 0);
        }
        protected async Task ExecuteSingleAsync(TContext context, Func<IDataReader, UData> transform, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier)
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
                var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = await _strategy.Db.ExecuteSingleAsync(cmd, transform, args);

                ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    context.Response.Data = dbr.Data;

                    if (context.Response.Data == null)
                    {
                        context.Response.NotFound();
                    }
                    else
                    {
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
            }
            else
            {
                context.Response = responseAndMessage.Item1;
                context.Response.Source = DataSource.Cache;
                context.Log.Add(responseAndMessage.Item2);
            }
        }
        // -------------------------------
        protected void ExecuteSingle(TContext context, Func<IDataReader, UData, UData> transform)
        {
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
            var args = new ExpandoObject() as IDictionary<string, object>;
            var cmd = GetContextCommand(context);

            ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

            var dbr = _strategy.Db.ExecuteSingle(cmd, transform, args);

            ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

            if (dbr.Success && context.Response.Success)
            {
                context.Response.Data = dbr.Data;
            }
        }
        protected void ExecuteSingle(TContext context, Func<IDataReader, UData, UData> transform,
            Func<TContext, string> keySpecifier)
        {
            ExecuteSingle(context, transform, keySpecifier, (r) => 0);
        }
        protected void ExecuteSingle(TContext context, Func<IDataReader, UData, UData> transform, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier)
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
                var _strategy =
                    context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = _strategy.Db.ExecuteSingle(cmd, transform, args);

                ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    context.Response.Data = (UData)dbr.Data;

                    if (context.Response.Data == null)
                    {
                        context.Response.NotFound();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(key) && dbr.Data != null && Cache != null)
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
            }
            else
            {
                context.Response = responseAndMessage.Item1;
                context.Response.Source = DataSource.Cache;
                context.Log.Add(responseAndMessage.Item2);
            }
        }
        protected async Task ExecuteSingleAsync(TContext context, Func<IDataReader, UData, UData> transform)
        {
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
            var args = new ExpandoObject() as IDictionary<string, object>;
            var cmd = GetContextCommand(context);

            ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

            var dbr = await _strategy.Db.ExecuteSingleAsync(cmd, transform, args);

            ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

            if (dbr.Success && context.Response.Success)
            {
                context.Response.Data = dbr.Data;
            }
        }
        protected async Task ExecuteSingleAsync(TContext context, Func<IDataReader, UData, UData> transform,
            Func<TContext, string> keySpecifier)
        {
            await ExecuteSingleAsync(context, transform, keySpecifier, (r) => 0);
        }
        protected async Task ExecuteSingleAsync(TContext context, Func<IDataReader, UData, UData> transform, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier)
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
                var _strategy =
                    context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = await _strategy.Db.ExecuteSingleAsync(cmd, transform, args);

                ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    context.Response.Data = dbr.Data;

                    if (!string.IsNullOrEmpty(key) && dbr.Data != null && Cache != null)
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

        // ------------------------------------------- methods with Cache Get Condition -------------------------------------
        protected void ExecuteSingle(TContext context, Func<TContext, string> keySpecifier, Func<UData, bool> cacheGetCondition)
        {
            ExecuteSingle(context, keySpecifier, (r) => 0, cacheGetCondition);
        }
        protected void ExecuteSingle(TContext context, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier, Func<UData, bool> cacheGetCondition)
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

                var dbr = _strategy.Db.ExecuteSingle(cmd, (IDataReader reader) =>
                {
                    var result = Activator.CreateInstance(responseDataType);
                    var r = result as BaseModel;

                    if (r != null)
                    {
                        r.Read(reader);
                    }

                    return result;
                }, args);

                ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    context.Response.Data = (UData)dbr.Data;

                    if (context.Response.Data == null)
                    {
                        context.Response.NotFound();
                    }
                    else
                    {
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
            }
            else
            {
                context.Response = responseAndMessage.Item1;
                context.Response.Source = DataSource.Cache;
                context.Log.Add(responseAndMessage.Item2);
            }
        }
        protected async Task ExecuteSingleAsync(TContext context, Func<TContext, string> keySpecifier, Func<UData, Task<bool>> cacheGetCondition)
        {
            await ExecuteSingleAsync(context, keySpecifier, (r) => 0, cacheGetCondition);
        }
        protected async Task ExecuteSingleAsync(TContext context, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier, Func<UData, Task<bool>> cacheGetCondition)
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

                var dbr = await _strategy.Db.ExecuteSingleAsync(cmd, (reader) =>
                {
                    var result = Activator.CreateInstance(responseDataType);
                    var r = result as BaseModel;

                    if (r != null)
                    {
                        r.Read(reader);
                    }

                    return result;
                }, args);

                ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    context.Response.Data = (UData)dbr.Data;

                    if (context.Response.Data == null)
                    {
                        context.Response.NotFound();
                    }
                    else
                    {
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
            }
            else
            {
                context.Response = responseAndMessage.Item1;
                context.Response.Source = DataSource.Cache;
                context.Log.Add(responseAndMessage.Item2);
            }
        }
        protected void ExecuteSingle(TContext context, Func<IDataReader, UData> transform, Func<TContext, string> keySpecifier, Func<UData, bool> cacheGetCondition)
        {
            ExecuteSingle(context, transform, keySpecifier, (r) => 0, cacheGetCondition);
        }
        protected void ExecuteSingle(TContext context, Func<IDataReader, UData> transform, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier, Func<UData, bool> cacheGetCondition)
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
                var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = _strategy.Db.ExecuteSingle(cmd, transform, args);

                ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    context.Response.Data = dbr.Data;

                    if (context.Response.Data == null)
                    {
                        context.Response.NotFound();
                    }
                    else
                    {
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
            }
            else
            {
                context.Response = responseAndMessage.Item1;
                context.Response.Source = DataSource.Cache;
                context.Log.Add(responseAndMessage.Item2);
            }
        }
        protected async Task ExecuteSingleAsync(TContext context, Func<IDataReader, UData> transform, Func<TContext, string> keySpecifier, Func<UData, Task<bool>> cacheGetCondition)
        {
            await ExecuteSingleAsync(context, transform, keySpecifier, (r) => 0, cacheGetCondition);
        }
        protected async Task ExecuteSingleAsync(TContext context, Func<IDataReader, UData> transform, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier, Func<UData, Task<bool>> cacheGetCondition)
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
                var _strategy = context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = await _strategy.Db.ExecuteSingleAsync(cmd, transform, args);

                ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    context.Response.Data = dbr.Data;

                    if (context.Response.Data == null)
                    {
                        context.Response.NotFound();
                    }
                    else
                    {
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
            }
            else
            {
                context.Response = responseAndMessage.Item1;
                context.Response.Source = DataSource.Cache;
                context.Log.Add(responseAndMessage.Item2);
            }
        }
        protected void ExecuteSingle(TContext context, Func<IDataReader, UData, UData> transform,
            Func<TContext, string> keySpecifier, Func<UData, bool> cacheGetCondition)
        {
            ExecuteSingle(context, transform, keySpecifier, (r) => 0, cacheGetCondition);
        }
        protected void ExecuteSingle(TContext context, Func<IDataReader, UData, UData> transform, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier, Func<UData, bool> cacheGetCondition)
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
                var _strategy =
                    context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = _strategy.Db.ExecuteSingle(cmd, transform, args);

                ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    context.Response.Data = (UData)dbr.Data;

                    if (context.Response.Data == null)
                    {
                        context.Response.NotFound();
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(key) && dbr.Data != null && Cache != null)
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
            }
            else
            {
                context.Response = responseAndMessage.Item1;
                context.Response.Source = DataSource.Cache;
                context.Log.Add(responseAndMessage.Item2);
            }
        }
        protected async Task ExecuteSingleAsync(TContext context, Func<IDataReader, UData, UData> transform,
            Func<TContext, string> keySpecifier, Func<UData, Task<bool>> cacheGetCondition)
        {
            await ExecuteSingleAsync(context, transform, keySpecifier, (r) => 0, cacheGetCondition);
        }
        protected async Task ExecuteSingleAsync(TContext context, Func<IDataReader, UData, UData> transform, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier, Func<UData, Task<bool>> cacheGetCondition)
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
                var _strategy =
                    context.Strategy as BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = await _strategy.Db.ExecuteSingleAsync(cmd, transform, args);

                ContextPostExecute<TResponse, UData, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    context.Response.Data = dbr.Data;

                    if (!string.IsNullOrEmpty(key) && dbr.Data != null && Cache != null)
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
    }
}
