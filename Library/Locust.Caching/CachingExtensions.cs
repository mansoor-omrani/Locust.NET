using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Caching
{
    public static class CachingExtensions
    {
        public static T Get<T>(this AppDomainCacheManager cache, string key, Func<T> initializer) where T : class
        {
            T result = null;
            var init = true;
            var x = cache.Get(key);

            if (x != null)
            {
                var y = x as T;

                if (y != null)
                {
                    result = y;
                    init = false;
                }
            }

            if (init && initializer != null)
            {
                result = initializer();

                cache.Add(key, result);
            }

            return result;
        }
        public static object GetIfExists(this ICacheManager cache, string key, string dependentKey)
        {
            return cache.TryGet(key, (item) => cache.Contains(dependentKey));
        }
        public static T GetIfExists<T>(this ICacheManager cache, string key, string dependentKey)
        {
            return (T)cache.GetIfExists(key, dependentKey);
        }
        public static async Task<T> TryGetAsync<T>(this ICacheManager cache, string key, Func<T, Task<bool>> condition)
        {
            var result = await cache.TryGetAsync(key, async (x) => await condition((T)x));

            return (T)result;
        }
        public static T TryGet<T>(this ICacheManager cache, string key, Func<T, bool> condition)
        {
            return (T)cache.TryGet(key, (x) => { return condition((T)x); });
        }
        public static T GetOrSet<T>(this ICacheManager cache, string key, Func<T> initializer)
        {
            return cache.GetOrSet(key, initializer, 0);
        }
        public static T GetOrSet<T>(this ICacheManager cache, string key, Func<T> initializer, int lifeLength)
        {
            var result = cache.GetOrSet(key, () => (object)initializer(), lifeLength);

            return (T)result;
        }
        public static object GetOrSet(this ICacheManager cache, string key, Func<object> initializer)
        {
            return cache.GetOrSet(key, initializer, 0);
        }
        public static T Get<T>(this ICacheManager cache, string key)
        {
            return (T)cache.Get(key);
        }
        public static void Add(this ICacheManager cache, string key, object item)
        {
            cache.Add(key, item, 0);
        }
        public static T TryGetOrSet<T>(this ICacheManager cache, string key, Func<T> initializer, Func<T, bool> condition)
        {
            return cache.TryGetOrSet(key, initializer, 0, condition);
        }
        public static T TryGetOrSet<T>(this ICacheManager cache, string key, Func<T> initializer, int lifeLength, Func<T, bool> condition)
        {
            var result = cache.TryGetOrSet(key, () => (object)initializer(), lifeLength, (x) => { return condition((T)x); });

            return (T)result;
        }
        public static Task<T> TryGetOrSet<T>(this ICacheManager cache, string key, Func<T> initializer, Func<T, Task<bool>> condition)
        {
            return cache.TryGetOrSet(key, initializer, 0, condition);
        }
        public static async Task<T> TryGetOrSet<T>(this ICacheManager cache, string key, Func<T> initializer, int lifeLength, Func<T, Task<bool>> condition)
        {
            var result = await cache.TryGetOrSetAsync(key, () => (object)initializer(), lifeLength, async (x) => await condition((T)x));

            return (T)result;
        }
        public static object TryGetOrSet(this ICacheManager cache, string key, Func<object> initializer, Func<object, bool> condition)
        {
            return cache.TryGetOrSet(key, initializer, 0, condition);
        }
        public static Task<object> TryGetOrSet(this ICacheManager cache, string key, Func<object> initializer, Func<object, Task<bool>> condition)
        {
            return cache.TryGetOrSetAsync(key, initializer, 0, condition);
        }
    }
}
