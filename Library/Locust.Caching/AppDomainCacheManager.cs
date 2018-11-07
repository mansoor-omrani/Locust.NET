using Locust.Date;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Caching
{
    public class AppDomainCacheManager : BaseCacheManager
    {
        private AppDomain _app;
        public AppDomainCacheManager(CacheConfig config) : this(AppDomain.CurrentDomain, config)
        {
        }
        public AppDomainCacheManager(AppDomain app, CacheConfig config) : base(config)
        {
            _app = app;
        }
        public AppDomainCacheManager(INow now, CacheConfig config) : this(now, AppDomain.CurrentDomain, config)
        {
        }
        public AppDomainCacheManager(INow now, AppDomain app, CacheConfig config) : base(now, config)
        {
            _app = app;
        }
        protected override ConcurrentDictionary<string, CacheItem> GetStore()
        {
            ConcurrentDictionary<string, CacheItem> result = null;

            if (_app != null)
            {
                var x = _app.GetData(_config.Name);

                if (x != null)
                {
                    result = x as ConcurrentDictionary<string, CacheItem>;
                }
            }

            return result;
        }

        protected override bool SetStore(ConcurrentDictionary<string, CacheItem> items)
        {
            var result = false;

            if (_app != null)
            {
                _app.SetData(_config.Name, items);
                result = true;
            }

            return result;
        }
    }
}
