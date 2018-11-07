using Locust.Date;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Locust.Caching.Web
{
    public class HttpCacheManager : BaseCacheManager
    {
        private HttpContextBase _context;
        private void Init(HttpContextBase context)
        {
            this._context = context;
        }
        public HttpCacheManager(CacheConfig config) : base(config)
        {
            Init(new HttpContextWrapper(HttpContext.Current));
        }
        public HttpCacheManager(HttpContextBase context, CacheConfig config)
            : base(config)
        {
            Init(context);
        }
        public HttpCacheManager(INow now, HttpContextBase context, CacheConfig config)
            : base(now, config)
        {
            Init(context);
        }
        protected override ConcurrentDictionary<string, CacheItem> GetStore()
        {
            ConcurrentDictionary<string, CacheItem> result = null;

            if (_context != null)
            {
                var x = _context.Cache[_config.Name];

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

            if (_context != null)
            {
                _context.Cache[_config.Name] = items;
                result = true;
            }

            return result;
        }
    }
}
