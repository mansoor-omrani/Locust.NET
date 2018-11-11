using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Test.Benchmark
{
    public class benchmark_appdomaincachemanager : BaseBenchmark
    {
        private class Test1 : BaseTest
        {
            public override string Title
            {
                get { return "BaseModel"; }
                set { }
            }

            public override void Test()
            {
                
            }
        }
        private class Test2 : BaseTest
        {
            public override string Title
            {
                get { return "EF"; }
                set { }
            }
            public override void Test()
            {

            }
        }

        public override void Run()
        {
            test1 = new Test1();
            test2 = new Test2();

            base.Run();
        }
    }
}
