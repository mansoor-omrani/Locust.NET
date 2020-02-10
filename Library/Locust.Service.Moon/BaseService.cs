using Locust.Caching;
using Locust.Collections;
using Locust.Db;
using Locust.Logging;
using Locust.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.Service.Moon
{
    public abstract class BaseConfig
    {
        public ILogger Logger { get; set; }
        public IExceptionLogger ExceptionLogger { get; set; }
        public IDbHelper Db { get; set; }
        public ICacheManager Cache { get; set; }
        public BaseConfig()
        {
        }
        public BaseConfig(ILogger logger, IExceptionLogger exceptionLogger, IDbHelper db, ICacheManager cache)
        {
            Logger = logger;
            ExceptionLogger = exceptionLogger;
            Db = db;
            Cache = cache;
        }
    }
    public abstract class BaseService
    {
        #region Properties
        public virtual string Name { get { return this.GetType().Name; } }
        private ILogger _logger;
        public ILogger Logger
        {
            get
            {
                if (_logger == null)
                    _logger = new NullLogger();

                return _logger;
            }
            set { _logger = value; }
        }
        private IExceptionLogger _exceptionLogger;
        public IExceptionLogger ExceptionLogger
        {
            get
            {
                if (_exceptionLogger == null)
                    _exceptionLogger = new NullExceptionLogger();

                return _exceptionLogger;
            }
            set { _exceptionLogger = value; }
        }
        private IDbHelper _db;
        public IDbHelper Db
        {
            get
            {
                if (_db == null)
                    _db = new FakeDbHelper();

                return _db;
            }
            set { _db = value; }
        }
        private ICacheManager _cache;
        public ICacheManager Cache
        {
            get
            {
                if (_cache == null)
                    _cache = new NullCacheManager();

                return _cache;
            }
            set { _cache = value; }
        }
        #endregion
        #region ctor
        public BaseService()
        { }
        public BaseService(ILogger logger, IExceptionLogger exceptionLogger)
        {
            Init(logger, exceptionLogger, null, null);
        }
        public BaseService(ILogger logger, IExceptionLogger exceptionLogger, IDbHelper db)
        {
            Init(logger, exceptionLogger, db, null);
        }
        public BaseService(ILogger logger, IExceptionLogger exceptionLogger, IDbHelper db, ICacheManager cache)
        {
            Init(logger, exceptionLogger, db, cache);
        }
        private void Init(ILogger logger, IExceptionLogger exceptionLogger, IDbHelper db, ICacheManager cache)
        {
            Logger = logger;
            ExceptionLogger = exceptionLogger;
            Db = db;
            Cache = cache;
        }
        #endregion
    }
    public abstract class BaseActionBasedService<TConfig>: BaseService
        where TConfig: BaseConfig, new()
    {
        private TConfig _config;
        public TConfig Config
        {
            get
            {
                if (_config == null)
                    _config = new TConfig();

                return _config;
            }
            set { _config = value; }
        }
        public IDictionary<string, object> Actions { get; private set; }
        public BaseActionBasedService()
        {
        }
        public BaseActionBasedService(TConfig config)
        {
            Init(config);

            Logger = Config.Logger;
            ExceptionLogger = Config.ExceptionLogger;
            Db = Config.Db;
            Cache = Config.Cache;
        }
        public BaseActionBasedService(TConfig config, ILogger logger, IExceptionLogger exceptionLogger): base(logger, exceptionLogger)
        {
            Init(config);
        }
        public BaseActionBasedService(TConfig config, ILogger logger, IExceptionLogger exceptionLogger, IDbHelper db): base(logger, exceptionLogger, db)
        {
            Init(config);
        }
        public BaseActionBasedService(TConfig config, ILogger logger, IExceptionLogger exceptionLogger, IDbHelper db, ICacheManager cache) : base(logger, exceptionLogger, db, cache)
        {
            Init(config);
        }
        private void Init(TConfig config)
        {
            Config = config ?? throw new ArgumentNullException(nameof(config));
            Actions = new CaseSensitiveDictionary<object>(true);
        }
        public virtual object GetAction(string name)
        {
            return Actions[name];
        }
        public object this[string action]
        {
            get
            {
                return Actions[action];
            }
        }
    }
    public abstract class BaseServiceAction<TBaseService, TRequest, TResponse> : ServiceAction<TBaseService, TRequest, TResponse>
        where TBaseService: BaseService
        where TRequest : ServiceRequest
        where TResponse : ServiceResponse, new()
    {
        #region Props
        private ILogger _logger;
        public ILogger Logger
        {
            get
            {
                if (_logger == null)
                    _logger = new NullLogger();

                return _logger;
            }
            set { _logger = value; }
        }
        private IExceptionLogger _exceptionLogger;
        public IExceptionLogger ExceptionLogger
        {
            get
            {
                if (_exceptionLogger == null)
                    _exceptionLogger = new NullExceptionLogger();

                return _exceptionLogger;
            }
            set { _exceptionLogger = value; }
        }
        private IDbHelper _db;
        public IDbHelper Db
        {
            get
            {
                if (_db == null)
                    _db = new FakeDbHelper();

                return _db;
            }
            set { _db = value; }
        }
        private ICacheManager _cache;
        public ICacheManager Cache
        {
            get
            {
                if (_cache == null)
                    _cache = new NullCacheManager();

                return _cache;
            }
            set { _cache = value; }
        }
        #endregion
        public BaseServiceAction(TBaseService owner): base(owner)
        {
            Logger = owner.Logger;
            ExceptionLogger = owner.ExceptionLogger;
            Db = owner.Db;
            Cache = owner.Cache;
        }
        #region Logging
        protected override void OnError(TRequest request, TResponse response, Exception e)
        {
            Owner.Logger.Sys($"Action execution failed. {e.Message}");

            var info = "";

            Owner.ExceptionLogger.LogException(e, info);
        }
        protected override bool OnBeforeRun(TRequest request, TResponse response)
        {
            Owner.Logger.Sys($"Executing action {Owner.Name}.{Name}");
            Owner.Logger.Sys($"{Owner.Name}.{Name}", request);

            return true;
        }
        protected override void OnAfterRun(TRequest request, TResponse response)
        {
            if (response.IsSucceeded())
            {
                Owner.Logger.Sys($"Action execution succeeded.");
            }
            else
            {
                Owner.Logger.Sys($"Action execution failed.");
            }

            Owner.Logger.Sys($"{Owner.Name}.{Name}", response);
        }
        #endregion
    }
}
