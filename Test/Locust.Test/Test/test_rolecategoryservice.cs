using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Locust.Caching;
using Locust.Db;
using Locust.Logging;
using Locust.Modules.ACL.Service;
using Locust.Modules.ACL.Strategies;
using Locust.ServiceModel.Babbage;

namespace Locust.Test.Test
{
    public class test_rolecategoryservice:BaseTest
    {
        private RoleCategoryService service;
        private ICacheManager cache;

        class MyCacheFactory : ICacheFactory
        {

            public ICacheManager Get(object arg)
            {
                var cacheConfig = new CacheConfig
                {
                    Name = "myCache",
                    AutoExpire = true,
                    AutoRemoveDeadItems = true,
                    Duration = 5
                };
                var cache = new AppDomainCacheManager(cacheConfig);
                return cache;
            }
        }
        private void createCache()
        {
            
        }
        private void createService()
        {
            var gbi = new RoleCategoryGetByIdStrategy(new MyCacheFactory());
            var rcss = new RoleCategoryStrategyStore(gbi);
            var logger = new DebugExceptionLogger(new DefaultMemoryLogger());
            var rcs = new RoleCategoryService(rcss, logger);
            rcs.Db = DA.DefaultDb;

            service = rcs;
        }

        public test_rolecategoryservice()
        {
            createCache();
            createService();
        }
        private void test1()
        {
            var ctx = service.GetById.CreateContext();

            ctx.Request.Id = 1;
            ctx.Log.DebugMode = true;
            ctx.Log.TraceMode = true;
            ctx.Run();

            var x = JsonConvert.SerializeObject(ctx.Response.Data);
            foreach (var msg in ctx.Log)
            {
                System.Console.Write("{0} {1} {2} {3} {4} {5}", msg.Order, msg.Depth, msg.Type, msg.Category, msg.Operation, msg.Date);
                if (msg.Exception != null)
                {
                    System.Console.Write("{0}", msg.Exception.Message);
                }
                System.Console.WriteLine("{0} {1}", msg.Info, msg.Source);
            }
            System.Console.WriteLine(x);
        }

        private void test2()
        {
            var ctx = service.CreateContext("getById");
            System.Console.WriteLine(ctx == null);
        }

        private void test3()
        {
            var ctx = service.GetById.CreateContext();

            ctx.Request.Id = 1;
            ctx.Log.DebugMode = true;
            //ctx.Log.TraceMode = true;
            ctx.Run();
            if (ctx.Response.Status == RoleCategoryGetByIdStatus.Success)
            {
                System.Console.WriteLine(ctx.Response.Data.ToJson());
            }
            else
            {
                var s = JsonConvert.SerializeObject(ctx.Log);
                Debug.WriteLine(s);
                System.Console.WriteLine(s);
            }
            //System.Console.WriteLine(ctx.Response.Source);
            //ctx.Run();
            //System.Console.WriteLine(ctx.Response.Source);
            //ctx.Run();
            //System.Console.WriteLine(ctx.Response.Source);
        }
        public override void Test()
        {
            test3();
        }
    }
}
