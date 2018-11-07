using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Locust.Db;
using Locust.Extensions;
using Locust.Tracing;

namespace Locust.ServiceModel
{
    public interface IBaseServiceStrategy
    {
        void Run(IServiceStrategyContext context);
        Task RunAsync(IServiceStrategyContext context);
        BaseServiceStrategyStore Store { get; set; }
        IServiceStrategyContext CreateContext();
        IServiceStrategyContext CreateContext<WRequest>(WRequest request) where WRequest : IBaseServiceRequest, new();
        IServiceStrategyContext CreateContext(object request);
        IServiceStrategyContext CreateContextBy(IServiceStrategyContext context);
        IServiceStrategyContext CreateContextBy<WRequest>(IServiceStrategyContext context, WRequest request) where WRequest : IBaseServiceRequest, new();
        IServiceStrategyContext CreateContextBy(IServiceStrategyContext context, object request);
        string Name { get; }
        string ServiceName { get; }
    }
    public abstract class BaseServiceStrategy<TResponse, UData, VStatus, WRequest, TContext> : IBaseServiceStrategy
        where TResponse : BaseServiceResponse<UData, VStatus>, new()
        where WRequest : class, IBaseServiceRequest, new()
        where TContext : ServiceStrategyContext<TResponse, UData, VStatus, WRequest>, new()
    {
        private string name;
        public virtual string Name
        {
            get
            {
                if (string.IsNullOrEmpty(name))
                {
                    if (Store != null)
                    {
                        if (Store.Service != null)
                        {
                            var category = Store.Service.Name;
                            var n = GetType().Name;

                            if (string.Compare(n.Left(category.Length), category, StringComparison.OrdinalIgnoreCase) ==
                                0)
                            {
                                name = n.Substring(category.Length).Replace("Strategy", "");
                            }
                            else
                            {
                                name = n.Replace("Strategy", "");
                            }
                        }
                    }
                }
                return name;
            }
        }
        public virtual string ServiceName
        {
            get
            {
                if (Store != null)
                {
                    if (Store.Service != null)
                    {
                        return Store.Service.Name;
                    }
                }
                return "";
            }
        }
        private IDbHelper db;
        public IDbHelper Db
        {
            get
            {
                var result = db;

                if (db == null)
                {
                    if (Store != null)
                    {
                        if (Store.Service != null)
                        {
                            result = Store.Service.Db;
                        }
                    }
                }
                
                return result;
                
            }
            set { db = value; }
        }
        private BaseServiceStrategyStore store;
        public BaseServiceStrategyStore Store
        {
            get { return store; }
            set
            {
                if (store == null)
                {
                    store = value;
                }
            }
        }
        protected TContext GetContext()
        {
            return new TContext();
        }

        public TContext CreateContext()
        {
            var result = GetContext();

            result.Strategy = this;

            return result;
        }
        IServiceStrategyContext IBaseServiceStrategy.CreateContext()
        {
            return CreateContext();
        }
        public TContext CreateContextBy(IServiceStrategyContext context)
        {
            var result = CreateContext();

            if (context != null)
            {
                result.Log = context.Log;

                if (result.Strategy != null && result.Strategy.Store != null && result.Strategy.Store.Service != null
                    && context.Strategy != null && context.Strategy.Store != null &&
                    context.Strategy.Store.Service != null)
                {
                    result.Strategy.Store.Service.Db = context.Strategy.Store.Service.Db;
                }

                if (result.Log.DebugMode)
                {
                    result.Parent = context;
                    context.Children.Add(result);
                }
            }

            return result;
        }

        IServiceStrategyContext IBaseServiceStrategy.CreateContextBy(IServiceStrategyContext context)
        {
            return CreateContextBy(context);
        }
        public TContext CreateContext(WRequest request)
        {
            var result = CreateContext();

            result.Request = request;

            return result;
        }

        IServiceStrategyContext IBaseServiceStrategy.CreateContext<TWRequest>(TWRequest request)
        {
            var result = CreateContext();

            result.Request = request as WRequest;

            return result;
        }
        public TContext CreateContextBy(IServiceStrategyContext context, WRequest request)
        {
            var result = CreateContextBy(context);

            result.Request = request;

            return result;
        }
        IServiceStrategyContext IBaseServiceStrategy.CreateContextBy<TWRequest>(IServiceStrategyContext context, TWRequest request)
        {
            var result = CreateContextBy(context);

            result.Request = request as WRequest;

            return result;
        }
        public abstract void Run(TContext context);
        public abstract Task RunAsync(TContext context);
        
        // if we use EntityFramework in our strategy we are better to provide a CheckAccess() method
        // in our BaseStrategyEF by which sub-classes are able to check current user permission regarding
        // a specific action, like posting comments, deleting records, ...
        // 
        // public virtual bool CheckAccess(string code) { ... }
        // 
        // if we use SPROCs in our strageies (like ServiceModel.Babbage strategies) we don't need to provide
        // such a method. we can do this in the SPROCs, especially that we can use ContextInfo in SQL Server
        // and send current user's name, role, IP or other relevent data to the SPROC over the database connection
        // and check user access there.
        void IBaseServiceStrategy.Run(IServiceStrategyContext context)
        {
            if (context != null && context.Ready)
            {
                Run(context as TContext);
            }
        }
        Task IBaseServiceStrategy.RunAsync(IServiceStrategyContext context)
        {
            if (context != null && context.Ready)
            {
                return RunAsync(context as TContext);
            }
            else
            {
                return Task.Run(() => { });
            }
        }

        public TContext Invoke(object args = null)
        {
            var result = CreateContext(args);

            Run(result);

            return result;
        }
        public TContext Invoke(WRequest args)
        {
            var result = CreateContext(args);

            Run(result);

            return result;
        }
        public TContext Invoke(IServiceStrategyContext context, object args = null)
        {
            var result = CreateContextBy(context, args);

            Run(result);

            return result;
        }
        public TContext Invoke(IServiceStrategyContext context, WRequest args = null)
        {
            var result = CreateContextBy(context, args);

            Run(result);

            return result;
        }
        public async Task<TContext> InvokeAsync(object args = null)
        {
            var result = CreateContext(args);

            await RunAsync(result);

            return result;
        }
        public async Task<TContext> InvokeAsync(WRequest args = null)
        {
            var result = CreateContext(args);

            await RunAsync(result);

            return result;
        }
        public async Task<TContext> InvokeAsync(IServiceStrategyContext context, object args = null)
        {
            var result = CreateContextBy(context, args);

            await RunAsync(result);

            return result;
        }
        public async Task<TContext> InvokeAsync(IServiceStrategyContext context, WRequest args = null)
        {
            var result = CreateContextBy(context, args);

            await RunAsync(result);

            return result;
        }
        public TContext CreateContext(object request)
        {
            var result = CreateContext();

            try
            {
                result.Request.Init(request);
            }
            catch (Exception e)
            {
                result.Log.Danger(result.ServiceName, result.Strategy.Name, "req_init_err", e, MessageSource.Framework);
            }

            return result;
        }
        IServiceStrategyContext IBaseServiceStrategy.CreateContext(object request)
        {
            return CreateContext(request);
        }

        public TContext CreateContextBy(IServiceStrategyContext context, object request)
        {
            var result = CreateContextBy(context);

            try
            {
                result.Request.Init(request);
            }
            catch (Exception e)
            {
                result.Log.Danger(result.ServiceName, result.Strategy.Name, "req_init_err", e, MessageSource.Framework);
            }

            return result;
        }
        IServiceStrategyContext IBaseServiceStrategy.CreateContextBy(IServiceStrategyContext context, object request)
        {
            return CreateContextBy(context, request);
        }
        public void Resolve(
                TContext context,
                VStatus status,
                UData data = default(UData),
                Exception ex = null,
                MessageSource source = MessageSource.Application)
        {
            context.Response.Status = status;
            context.Response.Data = data;
            context.Log.Dialog(ServiceName, Name, status.ToString(), ex, source);
        }
        public void Reject(
                TContext context,
                VStatus status,
                UData data = default(UData),
                Exception ex = null,
                MessageSource source = MessageSource.Application)
        {
            context.Response.Status = status;
            context.Response.Data = data;
            context.Log.Danger(ServiceName, Name, status.ToString(), ex, source);
        }
    }
}
