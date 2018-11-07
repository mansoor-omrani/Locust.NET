using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Locust.Base;
using Locust.Collections;
using Locust.Db;
using Locust.Extensions;
using Locust.Logging;

namespace Locust.ServiceModel
{
    public abstract class BaseService
    {
        private BaseServiceStrategyStore strategyStore;
        protected IExceptionLogger logger;
        public IDbHelper Db { get; set; }
        private IDictionary<string, string> _settings;

        public virtual IDictionary<string, string> Settings
        {
            get
            {
                if (_settings == null)
                {
                    _settings = new Collections.CaseInsensitiveDictionary<string>();
                }

                return _settings;
            }
            set { _settings = value; }
        }

        public BaseServiceStrategyStore Store
        {
            get { return strategyStore; }
        }
        public BaseService(BaseServiceStrategyStore store, IExceptionLogger logger)
        {
            if(store == null)
                throw new ArgumentNullException("store");
            if (logger == null)
                throw new ArgumentNullException("logger");

            this.strategyStore = store;
            this.logger = logger;
            store.Service = this;
        }
        public IExceptionLogger Logger { get { return logger; } }
        private string name;
        public virtual string Name
        {
            get
            {
                if (string.IsNullOrEmpty(name))
                {
                    var n = GetType().Name;
                    var i = n.LastIndexOf("Service");

                    name = (i > 0)? n.Substring(0, i): n;
                }

                return name;
            }
        }
        public TContext CreateContext<TContext>() where TContext:class
        {
            var strategy = strategyStore.GetStrategy(typeof (TContext));

            if (strategy == null)
                throw new ArgumentException(string.Format("requested context '{0}' does not belong to this service"), typeof(TContext).Name);

            return strategy.CreateContext() as TContext;
        }
        public TContext CreateContextBy<TContext>(IServiceStrategyContext fromContext) where TContext : class
        {
            var strategy = strategyStore.GetStrategy(typeof(TContext));

            if (strategy == null)
                throw new ArgumentException(string.Format("requested context '{0}' does not belong to this service"), typeof(TContext).Name);

            return strategy.CreateContextBy(fromContext) as TContext;
        }
        public TContext CreateContext<WRequest, TContext>(WRequest request)
            where TContext : class
            where WRequest : IBaseServiceRequest, new()
        {
            var strategy = strategyStore.GetStrategy(typeof(TContext));

            if (strategy == null)
                throw new ArgumentException(string.Format("requested context '{0}' does not belong to this service"), typeof(TContext).Name);

            return strategy.CreateContext(request) as TContext;
        }
        public TContext CreateContext<TContext>(object request)
            where TContext : class
        {
            var strategy = strategyStore.GetStrategy(typeof(TContext));

            if (strategy == null)
                throw new ArgumentException(string.Format("requested context '{0}' does not belong to this service"), typeof(TContext).Name);

            return strategy.CreateContext(request) as TContext;
        }
        public TContext CreateContextBy<WRequest, TContext>(IServiceStrategyContext fromContext, WRequest request)
            where TContext : class
            where WRequest : IBaseServiceRequest, new()
        {
            var strategy = strategyStore.GetStrategy(typeof(TContext));

            if (strategy == null)
                throw new ArgumentException(string.Format("requested context '{0}' does not belong to this service"), typeof(TContext).Name);

            return strategy.CreateContextBy(fromContext, request) as TContext;
        }
        public TContext CreateContextBy<TContext>(IServiceStrategyContext fromContext, object request)
            where TContext : class
        {
            var strategy = strategyStore.GetStrategy(typeof(TContext));

            if (strategy == null)
                throw new ArgumentException(string.Format("requested context '{0}' does not belong to this service"), typeof(TContext).Name);

            return strategy.CreateContextBy(fromContext, request) as TContext;
        }

        public IServiceStrategyContext CreateContext(string strategyName)
        {
            var strategy = Store.GetAllStrategies().FirstOrDefault(s => string.Compare(s.Name, strategyName, StringComparison.OrdinalIgnoreCase) == 0);

            if (strategy != null)
            {
                return strategy.CreateContext();
            }
            else
            {
                return null;
            }
        }
        public IServiceStrategyContext CreateContext(string strategyName, object request)
        {
            var strategy = Store.GetAllStrategies().FirstOrDefault(s => string.Compare(s.Name, strategyName, StringComparison.OrdinalIgnoreCase) == 0);

            if (strategy != null)
            {
                return strategy.CreateContext(request);
            }
            else
            {
                return null;
            }
        }
        public IServiceStrategyContext CreateContextBy(IServiceStrategyContext ctx, string strategyName)
        {
            var strategy = Store.GetAllStrategies().FirstOrDefault(s => string.Compare(s.Name, strategyName, StringComparison.OrdinalIgnoreCase) == 0);

            if (strategy != null)
            {
                return strategy.CreateContextBy(ctx);
            }
            else
            {
                return null;
            }
        }
        public IServiceStrategyContext CreateContextBy(IServiceStrategyContext ctx, string strategyName, object request)
        {
            var strategy = Store.GetAllStrategies().FirstOrDefault(s => string.Compare(s.Name, strategyName, StringComparison.OrdinalIgnoreCase) == 0);

            if (strategy != null)
            {
                return strategy.CreateContextBy(ctx, request);
            }
            else
            {
                return null;
            }
        }
    }

}
