using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Caching;
using Locust.Extensions;
using Locust.Model;
using Locust.ServiceModel;
using Locust.Tracing;

namespace Locust.ServiceModel.Babbage
{
    public abstract class BabbageListFetcherStrategy<TResponse, VStatus, WRequest, TContext, TDataItem> : BabbageStrategy<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>
        where TResponse : BaseServiceListResponse<TDataItem, VStatus>, new()
        where WRequest : class, IBaseServiceRequest, new()
        where TContext : BabbageContext<TResponse, IList<TDataItem>, VStatus, WRequest>, new()
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
        protected void Execute(TContext context)
        {
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>;
            var args = new ExpandoObject() as IDictionary<string, object>;
            var cmd = GetContextCommand(context);

            ContextPreExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

            var responseDataType = context.Response.GetDataItemType();
            var dbr = _strategy.Db.ExecuteReader(cmd, (reader) =>
            {
                var result = Activator.CreateInstance(responseDataType);
                var r = result as BaseModel;

                if (r != null)
                {
                    r.Read(reader);
                }

                return result;
            }, args);

            ContextPostExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

            if (dbr.Success && context.Response.Success)
            {
                var data = dbr.Data.To<TDataItem>();
                context.Response.Data = data;
            }
        }
        protected async Task ExecuteAsync(TContext context)
        {
            var responseDataType = context.Response.GetDataItemType();
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>;
            var args = new ExpandoObject() as IDictionary<string, object>;
            var cmd = GetContextCommand(context);

            ContextPreExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

            var dbr = await _strategy.Db.ExecuteReaderAsync(cmd, (reader) =>
            {
                var result = Activator.CreateInstance(responseDataType);
                var r = result as BaseModel;

                if (r != null)
                {
                    r.Read(reader);
                }

                return result;
            }, args);

            ContextPostExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

            if (dbr.Success && context.Response.Success)
            {
                var data = dbr.Data.To<TDataItem>();
                context.Response.Data = data;
            }
        }
        protected void Execute(TContext context, Func<IDataReader, TDataItem> transform)
        {
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>;
            var args = new ExpandoObject() as IDictionary<string, object>;
            var cmd = GetContextCommand(context);

            ContextPreExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

            var dbr = _strategy.Db.ExecuteReader(cmd, transform, args);

            ContextPostExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

            if (dbr.Success && context.Response.Success)
            {
                context.Response.Data = dbr.Data;
            }
        }
        protected void Execute(TContext context, Func<IDataReader, TDataItem, TDataItem> transform)
        {
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>;
            var args = new ExpandoObject() as IDictionary<string, object>;
            var cmd = GetContextCommand(context);

            ContextPreExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

            var dbr = _strategy.Db.ExecuteReader(cmd, transform, args);

            ContextPostExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

            if (dbr.Success && context.Response.Success)
            {
                context.Response.Data = dbr.Data;
            }
        }
        protected async Task ExecuteAsync(TContext context, Func<IDataReader, TDataItem> transform)
        {
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>;
            var args = new ExpandoObject() as IDictionary<string, object>;
            var cmd = GetContextCommand(context);

            ContextPreExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

            var dbr = await _strategy.Db.ExecuteReaderAsync(cmd, transform, args);

            ContextPostExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

            if (dbr.Success && context.Response.Success)
            {
                context.Response.Data = dbr.Data;
            }
        }
        protected async Task ExecuteAsync(TContext context, Func<IDataReader, TDataItem, TDataItem> transform)
        {
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>;
            var args = new ExpandoObject() as IDictionary<string, object>;
            var cmd = GetContextCommand(context);

            ContextPreExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

            var dbr = await _strategy.Db.ExecuteReaderAsync(cmd, transform, args);

            ContextPostExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

            if (dbr.Success && context.Response.Success)
            {
                context.Response.Data = dbr.Data;
            }
        }
        protected void Execute(TContext context, Func<TContext, string> keySpecifier)
        {
            Execute(context, keySpecifier, (r) => 0);
        }
        protected void Execute(TContext context, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier)
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
                    context.Strategy as BaseServiceStrategy<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

                var responseDataType = context.Response.GetDataItemType();
                var dbr = _strategy.Db.ExecuteReader(cmd, (reader) =>
                {
                    var result = Activator.CreateInstance(responseDataType);
                    var r = result as BaseModel;

                    if (r != null)
                    {
                        r.Read(reader);
                    }

                    return result;
                }, args);

                ContextPostExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    var data = dbr.Data.To<TDataItem>();
                    context.Response.Data = data;

                    if (!string.IsNullOrEmpty(key) && data != null && Cache != null)
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

        protected async Task ExecuteAsync(TContext context, Func<TContext, string> keySpecifier)
        {
            await ExecuteAsync(context, keySpecifier, (r) => 0);
        }
        protected async Task ExecuteAsync(TContext context, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier)
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
                var responseDataType = context.Response.GetDataItemType();
                var _strategy =
                    context.Strategy as BaseServiceStrategy<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = await _strategy.Db.ExecuteReaderAsync(cmd, (reader) =>
                {
                    var result = Activator.CreateInstance(responseDataType);
                    var r = result as BaseModel;

                    if (r != null)
                    {
                        r.Read(reader);
                    }

                    return result;
                }, args);

                ContextPostExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    var data = dbr.Data.To<TDataItem>();
                    context.Response.Data = data;

                    if (!string.IsNullOrEmpty(key) && data != null && Cache != null)
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

        protected void Execute(TContext context, Func<IDataReader, TDataItem> transform,
            Func<TContext, string> keySpecifier)
        {
            Execute(context, transform, keySpecifier, (r) => 0);
        }
        protected void Execute(TContext context, Func<IDataReader, TDataItem, TDataItem> transform,
            Func<TContext, string> keySpecifier)
        {
            Execute(context, transform, keySpecifier, (r) => 0);
        }
        protected void Execute(TContext context, Func<IDataReader, TDataItem> transform, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier)
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
                    context.Strategy as BaseServiceStrategy<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = _strategy.Db.ExecuteReader(cmd, transform, args);

                ContextPostExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

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
        protected void Execute(TContext context, Func<IDataReader, TDataItem, TDataItem> transform, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier)
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
                    context.Strategy as BaseServiceStrategy<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = _strategy.Db.ExecuteReader(cmd, transform, args);

                ContextPostExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

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
        protected async Task ExecuteAsync(TContext context, Func<IDataReader, TDataItem> transform,
            Func<TContext, string> keySpecifier)
        {
            await ExecuteAsync(context, transform, keySpecifier, (r) => 0);
        }
        protected async Task ExecuteAsync(TContext context, Func<IDataReader, TDataItem, TDataItem> transform,
            Func<TContext, string> keySpecifier)
        {
            await ExecuteAsync(context, transform, keySpecifier, (r) => 0);
        }
        protected async Task ExecuteAsync(TContext context, Func<IDataReader, TDataItem> transform, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier)
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
                    context.Strategy as BaseServiceStrategy<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = await _strategy.Db.ExecuteReaderAsync(cmd, transform, args);

                ContextPostExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

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
        protected async Task ExecuteAsync(TContext context, Func<IDataReader, TDataItem, TDataItem> transform, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier)
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
                    context.Strategy as BaseServiceStrategy<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = await _strategy.Db.ExecuteReaderAsync(cmd, transform, args);

                ContextPostExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

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
        protected void Execute(TContext context, Func<TContext, string> keySpecifier, Func<IList<TDataItem>, bool> cacheGetCondition)
        {
            Execute(context, keySpecifier, (r) => 0, cacheGetCondition);
        }
        protected void Execute(TContext context, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier, Func<IList<TDataItem>, bool> cacheGetCondition)
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
                    context.Strategy as BaseServiceStrategy<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

                var responseDataType = context.Response.GetDataItemType();
                var dbr = _strategy.Db.ExecuteReader(cmd, (reader) =>
                {
                    var result = Activator.CreateInstance(responseDataType);
                    var r = result as BaseModel;

                    if (r != null)
                    {
                        r.Read(reader);
                    }

                    return result;
                }, args);

                ContextPostExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    var data = dbr.Data.To<TDataItem>();
                    context.Response.Data = data;

                    if (!string.IsNullOrEmpty(key) && data != null && Cache != null)
                    {
                        var msg = context.Log[context.Log.Count - 1];
                        var lifeLength = 0;
                        if (lifeSpecifier != null)
                        {
                            lifeLength = lifeSpecifier(context);
                        }
                        var x = Cache.TryGetOrSet(key, () => Tuple.Create(context.Response, msg), lifeLength, (t => cacheGetCondition(t.Item1.Data)));
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

        protected async Task ExecuteAsync(TContext context, Func<TContext, string> keySpecifier, Func<IList<TDataItem>, Task<bool>> cacheGetCondition)
        {
            await ExecuteAsync(context, keySpecifier, (r) => 0, cacheGetCondition);
        }
        protected async Task ExecuteAsync(TContext context, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier, Func<IList<TDataItem>, Task<bool>> cacheGetCondition)
        {
            var key = "";
            Tuple<TResponse, Message> responseAndMessage = null;
            if (keySpecifier != null && Cache != null)
            {
                key = keySpecifier(context);
                if (!string.IsNullOrEmpty(key))
                {
                    responseAndMessage = await Cache.TryGetAsync(key, async(Tuple < TResponse, Message > t) => await cacheGetCondition(t.Item1.Data));
                }
            }

            if (responseAndMessage == null)
            {
                var responseDataType = context.Response.GetDataItemType();
                var _strategy =
                    context.Strategy as BaseServiceStrategy<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = await _strategy.Db.ExecuteReaderAsync(cmd, (reader) =>
                {
                    var result = Activator.CreateInstance(responseDataType);
                    var r = result as BaseModel;

                    if (r != null)
                    {
                        r.Read(reader);
                    }

                    return result;
                }, args);

                ContextPostExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    var data = dbr.Data.To<TDataItem>();
                    context.Response.Data = data;

                    if (!string.IsNullOrEmpty(key) && data != null && Cache != null)
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

        protected void Execute(TContext context, Func<IDataReader, TDataItem> transform,
            Func<TContext, string> keySpecifier, Func<IList<TDataItem>, bool> cacheGetCondition)
        {
            Execute(context, transform, keySpecifier, (r) => 0, cacheGetCondition);
        }
        protected void Execute(TContext context, Func<IDataReader, TDataItem, TDataItem> transform,
            Func<TContext, string> keySpecifier, Func<IList<TDataItem>, bool> cacheGetCondition)
        {
            Execute(context, transform, keySpecifier, (r) => 0, cacheGetCondition);
        }
        protected void Execute(TContext context, Func<IDataReader, TDataItem> transform, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier, Func<IList<TDataItem>, bool> cacheGetCondition)
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
                    context.Strategy as BaseServiceStrategy<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = _strategy.Db.ExecuteReader(cmd, transform, args);

                ContextPostExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

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
        protected void Execute(TContext context, Func<IDataReader, TDataItem, TDataItem> transform, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier, Func<IList<TDataItem>, bool> cacheGetCondition)
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
                    context.Strategy as BaseServiceStrategy<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = _strategy.Db.ExecuteReader(cmd, transform, args);

                ContextPostExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

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
        protected async Task ExecuteAsync(TContext context, Func<IDataReader, TDataItem> transform,
            Func<TContext, string> keySpecifier, Func<IList<TDataItem>, Task<bool>> cacheGetCondition)
        {
            await ExecuteAsync(context, transform, keySpecifier, (r) => 0, cacheGetCondition);
        }
        protected async Task ExecuteAsync(TContext context, Func<IDataReader, TDataItem, TDataItem> transform,
            Func<TContext, string> keySpecifier, Func<IList<TDataItem>, Task<bool>> cacheGetCondition)
        {
            await ExecuteAsync(context, transform, keySpecifier, (r) => 0, cacheGetCondition);
        }
        protected async Task ExecuteAsync(TContext context, Func<IDataReader, TDataItem> transform, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier, Func<IList<TDataItem>, Task<bool>> cacheGetCondition)
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
                    context.Strategy as BaseServiceStrategy<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = await _strategy.Db.ExecuteReaderAsync(cmd, transform, args);

                ContextPostExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

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
        protected async Task ExecuteAsync(TContext context, Func<IDataReader, TDataItem, TDataItem> transform, Func<TContext, string> keySpecifier, Func<TContext, int> lifeSpecifier, Func<IList<TDataItem>, Task<bool>> cacheGetCondition)
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
                    context.Strategy as BaseServiceStrategy<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = await _strategy.Db.ExecuteReaderAsync(cmd, transform, args);

                ContextPostExecute<TResponse, IList<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

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
