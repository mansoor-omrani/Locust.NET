using Locust.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Caching
{
    public class CacheManagerCleanResult
    {
        public int TotalItems { get; set; }
        public int DeadItems { get; set; }
        public int ExpiredItems { get; set; }
    }
    public interface ICacheManager
    {
        string Name { get; }
        int Count { get; }
        INow Now { get; }
        CacheConfig Config { get; }
        CacheItem GetItem(string key);
        IEnumerable<KeyValuePair<string, CacheItem>> GetAll();
        object Get(string key);
        object TryGet(string key, Func<object, bool> condition);
        Task<object> TryGetAsync(string key, Func<object, Task<bool>> condition);
        object GetOrSet(string key, Func<object> initializer, int lifeLength);
        void Add(string key, object item, int lifeLength);
        CacheItem Remove(string key);
        CacheManagerCleanResult Clean();
        void Clear();
        object TryGetOrSet(string key, Func<object> initializer, int lifeLength, Func<object, bool> condition);
        Task<object> TryGetOrSetAsync(string key, Func<object> initializer, int lifeLength, Func<object, Task<bool>> condition);
        bool Contains(string key);
    }
}
