using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Test.Benchmark
{
    class benchmark_manual_prop_vs_reflection: BaseBenchmark
    {
        class Foo
        {
            public string Alpha1 { get; set; }
            public string Alpha2 { get; set; }
            public string Alpha3 { get; set; }
            public string Alpha4 { get; set; }
            public string Alpha5 { get; set; }
            public string Alpha6 { get; set; }
            public string Alpha7 { get; set; }
            public string Alpha8 { get; set; }
        }
        private class Test1 : BaseTest
        {
            public override string Title
            {
                get { return "Manual"; }
                set { }
            }

            public override void Test()
            {
                var f = new Foo();

                f.Alpha8 = "sample text";
            }
        }
        private class Test2 : BaseTest
        {
            public override string Title
            {
                get { return "Reflection"; }
                set { }
            }
            public override void Test()
            {
                var prop = typeof(Foo).GetProperty("Alpha8");
                var f = new Foo();

                prop.SetValue(f, "sample text");
            }
        }

        public override void Run()
        {
            const int repeatCount = 10;
            const int stressCount = 99999;

            test1 = new Test1();
            test2 = new Test2();

            base.Run(repeatCount, stressCount);
        }
    }
}
