using Locust.Date;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.Caching
{
    // There is an important difference between Expiration and Life Length for cached items that needed to be noticed carefully.
    // Expiration:
    // 
    // Expiration is determined based on two things for an item in the cache:
    //      1. CacheConfig.Duration
    //      2. The last time the item was cached.
    //
    // For example if CacheConfig.Duration is 30 seconds, it means cached items are available for the recent 30 seconds.
    // Whenever a cached item is accessed, its last access time is updated. Therefore, in a config with 30 seconds duration, if an item
    // is not used for the previous 28 seconds, and in seconds of 29 a Get() is called, its LastAccessed is updated and it can remain
    // in the cache for another 30 seconds.
    // Thus, CacheItem.ExpireSpan for cached items is equal to CacheConfig.Duration (it is set in CacheItem.ctor).
    // This emphasices again that CacheConfig.Duration has a sliding refresh window in practice.
    // So, CacheItem.ExpireSpan and CacheConfig.Duration are always equal.
    // CacheItem.IsExpired works exactly based on LastAccessed and ExpireSpan. This computed property
    // shows effectively if a cached item has expired or not.
    // There is another property CacheItem.Elapsed that shows how many seconds have passed since the last time the item was accessed.
    // It shows how many seconds the item is allowed to remain in the cache. After that, the item will be expired.

    // If CacheConfig.Duration is 0 (which results in cached items with ExpireSpan equal to 0), it means that items can remain infinitely
    // in the cache. This is the default behavior.
    //
    // Life-Time:
    //
    // LifeTime has a different meaning than Expiration. When a life-length is specified for an item, it is allowed to remain in the cache
    // for its exact life-length. This has nothing to do with the expiration effect.
    // We can both set an expiration duration for items and life-length.
    // Suppose the exipration is set for 30 seconds. This means items are allowed to remain in the cache for the recent 30 seconds.
    // If an item is accessed frequently, it will always remain in the cache. Life-length has a different effect.
    // If a 45 seconds life-length is specified for an item, it is allowed to remain only exactly 45 seconds in the cache.
    // It does not matter how many times it is refreshed (was accessed and its LastAccessed was updated). After the 45 second, it will
    // be assumed a dead item (an item whose life-length is passed). So, even if it has not expired yet, it can not stay in the cache
    // and any Get() request for that results in 'null' value.
    // Life-length is determined solely based on the time an item was added in the cache.
    // There is a computed property named CachedItem.IsDead that shows whether an item is dead (its life-length has passed) or not.
    // Also, there is a RemaningLife property that shows how many seconds left of the life of an item.

    // Life-length is usefull when generating tokens in token-based systems.
    // for example, in an API application we can generate tokens for our clients and specify a life-length for them like 2 hours.
    // No matter how frequent the clients uses our API, we are definitely sure, his token will not be usable after 2 hours and
    // he is required to refresh it.
    public abstract class BaseCacheManager : ICacheManager
    {
        protected CacheConfig _config;
        protected ConcurrentDictionary<string, CacheItem> _items;
        protected INow now;
        public INow Now { get { return now; } set { now = value ?? new DateTimeNow(); } }
        public string Name { get; protected set; }
        public BaseCacheManager(INow now, CacheConfig config)
        {
            Init(now, config);
        }
        public BaseCacheManager(CacheConfig config)
        {
            Init(null, config);
        }
        private void Init(INow now, CacheConfig config)
        {
            this.now = now ?? new DateTimeNow();
            this.Name = this.GetType().FullName;

            if (config == null)
                throw new ArgumentNullException("config");

            _config = config;

            if (string.IsNullOrEmpty(_config.Name))
            {
                throw new ArgumentNullException("CacheConfig.Name");
            }
        }
        protected abstract ConcurrentDictionary<string, CacheItem> GetStore();
        protected abstract bool SetStore(ConcurrentDictionary<string, CacheItem> items);
        public CacheConfig Config
        {
            get { return _config; }
        }
        protected ConcurrentDictionary<string, CacheItem> Items
        {
            get
            {
                _items = GetStore();

                if (_items == null)
                {
                    _items = new ConcurrentDictionary<string, CacheItem>();
                    SetStore(_items);
                }

                return _items;
            }
        }

        public int Count
        {
            get
            {
                return Items.Count;
            }
        }

        public object Get(string key)
        {
            object result = null;
            CacheItem ci;

            if (!string.IsNullOrEmpty(key) && Items.TryGetValue(key, out ci))
            {
                if (ci != null)
                {
                    if (ci.IsDead)
                    {
                        if (_config.AutoRemoveDeadItems)
                        {
                            Items.TryRemove(key, out ci);
                        }
                    }
                    else
                    {
                        if (ci.IsExpired)
                        {
                            Items.TryRemove(key, out ci);
                        }
                        else
                        {
                            ci.IncAccess();

                            result = ci.Data;

                            Items.TryUpdate(key, ci, ci);
                        }
                    }
                }
            }

            return result;
        }
        public object GetOrSet(string key, Func<object> initializer, int lifeLength)
        {
            var result = Get(key);

            if (result == null && !string.IsNullOrEmpty(key))
            {
                var ci = new CacheItem(this, _config.Duration, lifeLength) { Data = initializer() };

                var x = Items.AddOrUpdate(key, (k) => ci, (oldKey, oldValue) => ci);

                result = x.Data;
            }

            return result;
        }
        public IEnumerable<KeyValuePair<string, CacheItem>> GetAll()
        {
            foreach (var item in Items)
                yield return item;
        }
        public CacheItem Remove(string key)
        {
            CacheItem c = null;

            if (Contains(key))
            {
                Items.TryRemove(key, out c);
            }

            return c;
        }
        public void Add(string key, object item, int lifeLength)
        {
            var ci = new CacheItem(this, _config.Duration, lifeLength) { Data = item };

            if (!string.IsNullOrEmpty(key))
            {
                Items.AddOrUpdate(key, ci, (oldKey, oldValue) => ci);
            }
        }
        public CacheItem GetItem(string key)
        {
            CacheItem result = null;

            if (!string.IsNullOrEmpty(key))
            {
                Items.TryGetValue(key, out result);
            }

            return result;
        }
        public CacheManagerCleanResult Clean()
        {
            var result = new CacheManagerCleanResult();

            result.TotalItems = Count;
            CacheItem ci;

            foreach (var item in GetAll())
            {
                if (item.Value.IsDead)
                {
                    Items.TryRemove(item.Key, out ci);
                    result.DeadItems++;
                }
                else
                if (item.Value.IsExpired)
                {
                    Items.TryRemove(item.Key, out ci);
                    result.ExpiredItems++;
                }
            }

            return result;
        }
        public object TryGet(string key, Func<object, bool> condition)
        {
            object result = null;
            CacheItem ci;

            if (!string.IsNullOrEmpty(key) && Items.TryGetValue(key, out ci))
            {
                if (ci != null)
                {
                    if (ci.IsDead)
                    {
                        if (_config.AutoRemoveDeadItems)
                        {
                            Items.TryRemove(key, out ci);
                        }
                    }
                    else
                    {
                        if (ci.IsExpired)
                        {
                            Items.TryRemove(key, out ci);
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

                            Items.TryUpdate(key, ci, ci);
                        }
                    }
                }
            }

            return result;
        }
        public async Task<object> TryGetAsync(string key, Func<object, Task<bool>> condition)
        {
            object result = null;
            CacheItem ci;

            if (!string.IsNullOrEmpty(key) && Items.TryGetValue(key, out ci))
            {
                if (ci != null)
                {
                    if (ci.IsDead)
                    {
                        if (_config.AutoRemoveDeadItems)
                        {
                            Items.TryRemove(key, out ci);
                        }
                    }
                    else
                    {
                        if (ci.IsExpired)
                        {
                            Items.TryRemove(key, out ci);
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

                            Items.TryUpdate(key, ci, ci);
                        }
                    }
                }
            }

            return result;
        }

        #region TryGetOrSet


        public object TryGetOrSet(string key, Func<object> initializer, int lifeLength, Func<object, bool> condition)
        {
            var result = TryGet(key, condition);

            if (result == null && !string.IsNullOrEmpty(key))
            {
                var ci = new CacheItem(this, _config.Duration, lifeLength) { Data = initializer() };

                var x = Items.AddOrUpdate(key, (k) => ci, (oldKey, oldValue) => ci);

                result = x.Data;
            }

            return result;
        }

        public async Task<object> TryGetOrSetAsync(string key, Func<object> initializer, int lifeLength, Func<object, Task<bool>> condition)
        {
            var result = await TryGetAsync(key, condition);

            if (result == null && !string.IsNullOrEmpty(key))
            {
                var ci = new CacheItem(this, _config.Duration, lifeLength) { Data = initializer() };

                var x = Items.AddOrUpdate(key, (k) => ci, (oldKey, oldValue) => ci);

                result = x.Data;
            }

            return result;
        }

        #endregion
        public bool Contains(string key)
        {
            var item = Get(key);

            return !string.IsNullOrEmpty(key) && item != null;
        }

        public void Clear()
        {
            Items.Clear();
        }
    }
}
