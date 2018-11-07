using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Caching
{
    public class AppDomainCacheFactory:ICacheFactory
    {
        private CacheConfig GetDefaultConfig(object arg)
        {
            return new CacheConfig { Name = arg.ToString(), Duration = 100, AutoExpire = true, AutoRemoveDeadItems = true };
        }
        public ICacheManager Get(object arg)
        {
            if (arg != null)
            {
                var cc = arg as CacheConfig;

                if (cc != null)
                {
                    return new AppDomainCacheManager(cc);
                }
                else
                {
                    return new AppDomainCacheManager(GetDefaultConfig(arg));
                }
            }
            else
            {
                return null;
            }
        }

        public List<object> GetNames()
        {
            return new List<object>() { GetDefaultConfig("AppDomainCacheManager") };
        }
    }
}
