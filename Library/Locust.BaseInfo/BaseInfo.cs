using Locust.Caching;
using Locust.Db;
using System;
using Locust.BaseInfo;

namespace Locust.BaseInfo
{
    public static class BaseInfo
    {
        static BaseInfo()
        {
            var ccfg = new CacheConfig { Name = "BaseInfo", Interval = 3600, Duration = 3600 };
            var cache = new AppDomainCacheManager(ccfg);
            var provider = new SqlBaseInfoProvider(DA.DefaultDb, cache);

            DefaultProvider = provider;
        }
        public static IBaseInfoProvider DefaultProvider { get; set; }
    }
}
