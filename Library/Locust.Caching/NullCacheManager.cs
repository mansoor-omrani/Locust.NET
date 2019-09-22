using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Date;

namespace Locust.Caching
{
    public class NullCacheManager : ICacheManager
    {
        public string Name => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public INow Now => throw new NotImplementedException();

        public CacheConfig Config => throw new NotImplementedException();

        public void Add(string key, object item, int lifeLength)
        {
        }
        public CacheManagerCleanResult Clean()
        {
            return new CacheManagerCleanResult();
        }
        public void Clear()
        {
        }
        public bool Contains(string key)
        {
            return false;
        }
        public object Get(string key)
        {
            return null;
        }
        public IEnumerable<KeyValuePair<string, CacheItem>> GetAll()
        {
            return new List<KeyValuePair<string, CacheItem>>();
        }
        public CacheItem GetItem(string key)
        {
            return null;
        }
        public object GetOrSet(string key, Func<object> initializer, int lifeLength)
        {
            return null;
        }
        public CacheItem Remove(string key)
        {
            return null;
        }
        public object TryGet(string key, Func<object, bool> condition)
        {
            return null;
        }
        public Task<object> TryGetAsync(string key, Func<object, Task<bool>> condition)
        {
            return Task.FromResult<object>(null);
        }
        public object TryGetOrSet(string key, Func<object> initializer, int lifeLength, Func<object, bool> condition)
        {
            return Task.FromResult<object>(null);
        }
        public Task<object> TryGetOrSetAsync(string key, Func<object> initializer, int lifeLength, Func<object, Task<bool>> condition)
        {
            return Task.FromResult<object>(null);
        }
    }
}
