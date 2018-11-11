using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Caching;

namespace Locust.Test.Test
{
    public class test_appdomaincachemanager : BaseTest
    {
        private void test1()
        {
            var config = new CacheConfig { Name = "Locust.Test__cache" };
            var cache = new AppDomainCacheManager(config);

            var x = cache.GetOrSet("key1", ()=> this.GetType());
            System.Console.WriteLine(x);
        }
        private void test2()
        {
            var config = new CacheConfig { Name = "Locust.Test__cache" };
            var cache = new AppDomainCacheManager(config);

            var type = cache.Get("key1");

            System.Console.WriteLine(type != null && (type as Type) == this.GetType());
        }
        public override void Test()
        {
            test1();
            test2();
        }
    }
}
