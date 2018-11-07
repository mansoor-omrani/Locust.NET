using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;

namespace Locust.Caching.Web
{
    public class WebCacheManager: ICacheManager
    {
        protected CacheConfig _config;
        protected Cache _cache;
        private void init(CacheConfig config, HttpContext context)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            _config = config;

            if (context != null && context.Cache != null)
            {
                _cache = context.Cache;
            }
        }
        public WebCacheManager(CacheConfig config)
        {
            init(config, HttpContext.Current);
        }
        public WebCacheManager(CacheConfig config, HttpContext context)
        {
            init(config, context);
        }
        public WebCacheManager(CacheConfig config, HttpContextBase context)
        {
            init(config, context.ApplicationInstance.Context);
        }
        public CacheConfig Config
        {
            get { return _config; }
        }

        public object Get(string key)
        {
            object result = null;

            if (_cache != null)
            {
                var ci = _cache[key] as CacheItem;

                if (ci != null)
                {
                    if ((ci.IsDead && _config.AutoRemoveDeadItems) || (ci.IsExpired && _config.AutoExpire))
                    {
                        _cache.Remove(key);
                    }
                    else
                    {
                        ci.IncAccess();

                        result = ci.Data;
                    }
                }
            }

            return result;
        }

        public T Get<T>(string key)
        {
            return (T)Get(key);
        }

        public object GetOrSet(string key, Func<object> initializer)
        {
            return GetOrSet(key, initializer, 0);
        }

        public object GetOrSet(string key, Func<object> initializer, int lifeLength)
        {
            var result = Get(key);

            if (result == null)
            {
                result = initializer();

                var ci = new CacheItem(_config.Duration, lifeLength) { Data = result };

                _cache[key] = ci;
            }

            return result;
        }

        public T GetOrSet<T>(string key, Func<T> initializer)
        {
            return GetOrSet(key, initializer, 0);
        }

        public T GetOrSet<T>(string key, Func<T> initializer, int lifeLength)
        {
            var result = GetOrSet(key, () => (object)initializer(), lifeLength);

            return (T)result;
        }

        public CacheItem Remove(string key)
        {
            var result = _cache.Remove(key);

            return result as CacheItem;
        }

        public void Add(string key, object item)
        {
            Add(key, item, 0);
        }

        public void Add(string key, object item, int lifeLength)
        {
            var result = Get(key);

            if (result == null)
            {
                var ci = new CacheItem(_config.Duration, lifeLength) { Data = item };

                _cache[key] = ci;
            }
        }

        public IEnumerable<KeyValuePair<string, CacheItem>> GetAll()
        {
            foreach (DictionaryEntry item in _cache)
            {
                var ci = item.Value as CacheItem;

                if (ci != null)
                    yield return new KeyValuePair<string, CacheItem>((string)item.Key, ci);
            }
        }


        public CacheItem GetItem(string key)
        {
            if (_cache != null)
            {
                return _cache[key] as CacheItem;
            }
            else
            {
                return null;
            }
        }

        public void Clean()
        {
            if (_cache != null)
            {
                foreach (var item in GetAll())
                {
                    if ((item.Value.IsDead && _config.AutoRemoveDeadItems) || (item.Value.IsExpired && _config.AutoExpire))
                    {
                        _cache.Remove(item.Key);
                    }
                }
            }
        }
        public object TryGet(string key, Func<object, bool> condition)
        {
            object result = null;

            if (_cache != null)
            {
                var ci = _cache[key] as CacheItem;

                if (ci != null)
                {
                    if ((ci.IsDead && _config.AutoRemoveDeadItems) || (ci.IsExpired && _config.AutoExpire))
                    {
                        _cache.Remove(key);
                    }
                    else
                    {
                        if (condition == null || condition(ci.Data))
                        {
                            ci.IncAccess();

                            result = ci.Data;
                        }
                        else
                        {
                            ci.IsDead = true;
                        }
                    }
                }
            }

            return result;

        }
        public T TryGet<T>(string key, Func<T, bool> condition)
        {
            return (T)TryGet(key, (x) => { return condition((T)x); });
        }
        public T TryGetOrSet<T>(string key, Func<T> initializer, Func<T, bool> condition)
        {
            return TryGetOrSet(key, initializer, 0, condition);
        }
        public T TryGetOrSet<T>(string key, Func<T> initializer, int lifeLength, Func<T, bool> condition)
        {
            var result = TryGetOrSet(key, () => (object)initializer(), lifeLength, (x) => { return condition((T)x); });

            return (T)result;
        }

        public async Task<object> TryGet(string key, Func<object, Task<bool>> condition)
        {
            object result = null;

            if (_cache != null)
            {
                var ci = _cache[key] as CacheItem;

                if (ci != null)
                {
                    if ((ci.IsDead && _config.AutoRemoveDeadItems) || (ci.IsExpired && _config.AutoExpire))
                    {
                        _cache.Remove(key);
                    }
                    else
                    {
                        var pass = true;
                        if (condition != null)
                        {
                            pass = await condition(ci.Data);
                        }

                        if (pass)
                        {
                            ci.IncAccess();

                            result = ci.Data;
                        }
                        else
                        {
                            ci.IsDead = true;
                        }
                    }
                }
            }

            return result;
        }

        public async Task<T> TryGet<T>(string key, Func<T, Task<bool>> condition)
        {
            var r = await TryGet(key, async (x) => await condition((T)x));

            return (T)r;
        }

        public Task<object> TryGetOrSet(string key, Func<object> initializer, Func<object, Task<bool>> condition)
        {
            return TryGetOrSet(key, initializer, 0, condition);
        }

        public async Task<object> TryGetOrSet(string key, Func<object> initializer, int lifeLength, Func<object, Task<bool>> condition)
        {
            var result = await TryGet(key, condition);

            if (result == null && !string.IsNullOrEmpty(key))
            {
                result = initializer();

                var ci = new CacheItem(_config.Duration, lifeLength) { Data = result };

                _cache[key] = ci;
            }

            return result;
        }

        public Task<T> TryGetOrSet<T>(string key, Func<T> initializer, Func<T, Task<bool>> condition)
        {
            return TryGetOrSet(key, initializer, 0, condition);
        }

        public async Task<T> TryGetOrSet<T>(string key, Func<T> initializer, int lifeLength, Func<T, Task<bool>> condition)
        {
            var r = await TryGetOrSet(key, initializer, lifeLength, condition);

            return (T) r;
        }

        public bool Contains(string key)
        {
            return !string.IsNullOrEmpty(key) && _cache[key] != null;
        }

        public object TryGetOrSet(string key, Func<object> initializer, Func<object, bool> condition)
        {
            return TryGetOrSet(key, initializer, 0, condition);
        }
        public object TryGetOrSet(string key, Func<object> initializer, int lifeLength, Func<object, bool> condition)
        {
            var result = TryGet(key, condition);

            if (result == null && !string.IsNullOrEmpty(key))
            {
                result = initializer();

                var ci = new CacheItem(_config.Duration, lifeLength) { Data = result };

                _cache[key] = ci;
            }

            return result;
        }
    }
}
