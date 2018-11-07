using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Caching;
using Locust.Data;
using Locust.Extensions;
using Locust.Model;
using Locust.Tracing;

namespace Locust.ServiceModel.Babbage
{
    public abstract class BabbagePageFetcherStrategy<TResponse, VStatus, WRequest, TContext, TDataItem> : BabbageStrategy<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>
        where TResponse : BaseServicePageResponse<TDataItem, VStatus>, new()
        where WRequest : class, IBaseServiceRequest, new()
        where TContext : BabbageContext<TResponse, PageData<TDataItem>, VStatus, WRequest>, new()
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
        private PageData<TDataItem> GetPageData(IDictionary<string, object> args, IList<TDataItem> data)
        {
            var count = 0;
            var argCount = args["Count"];
            if (argCount != null)
            {
                var coCount = argCount as CommandOutputParameter;
                if (coCount != null)
                {
                    count = coCount.Value;
                }
            }
            var result = new PageData<TDataItem> {Items = data, Count = count};
            return result;
        }
        protected void Execute(TContext context)
        {
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>;
            var args = new ExpandoObject() as IDictionary<string, object>;
            var cmd = GetContextCommand(context);

            ContextPreExecute<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

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

            ContextPostExecute<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

            if (dbr.Success && context.Response.Success)
            {
                var data = dbr.Data.To<TDataItem>();
                context.Response.Data = GetPageData(args, data);
            }
        }
        protected async Task ExecuteAsync(TContext context)
        {
            var responseDataType = context.Response.GetDataItemType();
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>;
            var args = new ExpandoObject() as IDictionary<string, object>;
            var cmd = GetContextCommand(context);

            ContextPreExecute<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

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

            ContextPostExecute<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

            if (dbr.Success && context.Response.Success)
            {
                var data = dbr.Data.To<TDataItem>();
                context.Response.Data = GetPageData(args, data);
            }
        }
        protected void Execute(TContext context, Func<IDataReader, TDataItem> transform)
        {
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>;
            var args = new ExpandoObject() as IDictionary<string, object>;
            var cmd = GetContextCommand(context);

            ContextPreExecute<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

            var dbr = _strategy.Db.ExecuteReader(cmd, transform, args);

            ContextPostExecute<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

            if (dbr.Success && context.Response.Success)
            {
                context.Response.Data = GetPageData(args, dbr.Data);
            }
        }
        protected async Task ExecuteAsync(TContext context, Func<IDataReader, TDataItem> transform)
        {
            var _strategy = context.Strategy as BaseServiceStrategy<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>;
            var args = new ExpandoObject() as IDictionary<string, object>;
            var cmd = GetContextCommand(context);

            ContextPreExecute<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

            var dbr = await _strategy.Db.ExecuteReaderAsync(cmd, transform, args);

            ContextPostExecute<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

            if (dbr.Success && context.Response.Success)
            {
                context.Response.Data = GetPageData(args, dbr.Data);
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
                    context.Strategy as BaseServiceStrategy<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

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

                ContextPostExecute<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    var data = dbr.Data.To<TDataItem>();
                    context.Response.Data = GetPageData(args, data);

                    if (!string.IsNullOrEmpty(key) && data != null && Cache != null)
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
                    context.Strategy as BaseServiceStrategy<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

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

                ContextPostExecute<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    var data = dbr.Data.To<TDataItem>();
                    context.Response.Data = GetPageData(args, data);

                    if (!string.IsNullOrEmpty(key) && data != null && Cache != null)
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

        protected void Execute(TContext context, Func<IDataReader, TDataItem> transform,
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
                    context.Strategy as BaseServiceStrategy<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = _strategy.Db.ExecuteReader(cmd, transform, args);

                ContextPostExecute<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    context.Response.Data = GetPageData(args, dbr.Data);

                    if (!string.IsNullOrEmpty(key) && dbr.Data != null && Cache != null)
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
        protected async Task ExecuteAsync(TContext context, Func<IDataReader, TDataItem> transform,
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
                    context.Strategy as BaseServiceStrategy<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>;
                var args = new ExpandoObject() as IDictionary<string, object>;
                var cmd = GetContextCommand(context);

                ContextPreExecute<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args);

                var dbr = await _strategy.Db.ExecuteReaderAsync(cmd, transform, args);

                ContextPostExecute<TResponse, PageData<TDataItem>, VStatus, WRequest, TContext>(context, cmd, args, dbr);

                if (dbr.Success && context.Response.Success)
                {
                    context.Response.Data = GetPageData(args, dbr.Data);

                    if (!string.IsNullOrEmpty(key) && dbr.Data != null && Cache != null)
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
