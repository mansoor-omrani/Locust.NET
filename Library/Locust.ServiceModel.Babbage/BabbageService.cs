using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Caching;
using Locust.Collections;
using Locust.Db;
using Locust.Logging;

namespace Locust.ServiceModel.Babbage
{
    public abstract class BabbageService:BaseService
    {
        public ICacheManager Cache { get; set; }
        public ICacheFactory CacheFactory { get; set; }
        public BabbageService(BaseServiceStrategyStore store, IExceptionLogger logger, IDbHelper db, ICacheFactory cacheFactory) : base(store, logger)
        {
            if (db == null)
                throw new ArgumentNullException("db");

            CacheFactory = cacheFactory;
            Db = db;
        }
        private IDictionary<string, string> settings;

        public override IDictionary<string, string> Settings
        {
            get
            {
                if (settings == null)
                {
                    FetchSettings();
                }
                return settings;
            }
            set
            {
                settings = value;
                useCache = null;
            }
        }
        private bool? useCache;
        public bool UseCache
        {
            get
            {
                if (!useCache.HasValue)
                    if (Settings != null && Settings.Keys.Count > 0)
                    {
                        var item =
                            Settings.FirstOrDefault(
                                x => string.Compare(x.Key, "UseCache", StringComparison.OrdinalIgnoreCase) == 0);
                        if (!string.IsNullOrEmpty(item.Key))
                        {
                            useCache = string.Compare(item.Value, "true", StringComparison.OrdinalIgnoreCase) == 0;
                        }
                        else
                        {
                            useCache = false;
                        }
                    }
                    else
                    {
                        useCache = false;
                    }

                return useCache.Value;
            }
        }

        public virtual void FetchSettings(IServiceStrategyContext context = null)
        {
            settings = new CaseInsensitiveDictionary<string>();
        }

        public virtual Task FetchSettingsAsync(IServiceStrategyContext context = null)
        {
            settings = new CaseInsensitiveDictionary<string>();

            return Task.FromResult(0);
        }

        protected ConcurrentDictionary<object, bool> ValidRequests
        {
            get
            {
                return Cache.GetOrSet(this.Name + ".VR", () => new ConcurrentDictionary<object, bool>());
            }
        }
        public bool IsValidRequest(object req)
        {
            var vr = ValidRequests;

            if (vr != null)
            {
                return vr.AddOrUpdate(req, x => false, (o, b) => true);
            }

            return false;
        }

        protected void InvalidateRequests()
        {
            var vr = ValidRequests;
            vr.Clear();
        }
    }
}
