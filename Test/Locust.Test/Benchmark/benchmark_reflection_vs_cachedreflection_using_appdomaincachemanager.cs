using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Locust.Caching;

namespace Locust.Test.Benchmark
{
    public class benchmark_reflection_vs_cachedreflection_using_appdomaincachemanager : BaseBenchmark
    {
        private static MyClass myClass;

        static benchmark_reflection_vs_cachedreflection_using_appdomaincachemanager()
        {
            myClass = new MyClass();
            myClass.Alpha12 = 1234;
        }
        public class MyClass
        {
            public int Alpha1 { get; set; }
            public string Alpha2 { get; set; }
            public double Alpha3 { get; set; }
            public decimal Alpha4 { get; set; }
            public char Alpha5 { get; set; }
            public long Alpha6 { get; set; }
            public DateTime Alpha7 { get; set; }
            public float Alpha8 { get; set; }
            public byte Alpha9 { get; set; }
            public int Alpha10 { get; set; }
            public string Alpha11 { get; set; }
            public short Alpha12 { get; set; }

        }
        private class Test1 : BaseTest
        {
            public override string Title
            {
                get { return "Reflection"; }
                set { }
            }

            public override void Test()
            {
                var prop = myClass.GetType().GetProperty("Alpha12", BindingFlags.Public | BindingFlags.Instance);
                var alpha12 = Convert.ToInt16(prop.GetValue(myClass));
                alpha12++;
            }
        }
        private class Test2 : BaseTest
        {
            public override string Title
            {
                get { return "Cached Reflection"; }
                set { }
            }
            public override void Test()
            {
                var config = new CacheConfig { Name = "Locust.Test__cache" };
                var cache = new AppDomainCacheManager(config);

                var prop = cache.Get("key1", () => myClass.GetType().GetProperty("Alpha12", BindingFlags.Public | BindingFlags.Instance));
                var alpha12 = Convert.ToInt16(prop.GetValue(myClass));
                alpha12++;
            }
        }

        public override void Run()
        {
            test1 = new Test1();
            test2 = new Test2();

            base.Run(10, 99999);
        }
    }
}
