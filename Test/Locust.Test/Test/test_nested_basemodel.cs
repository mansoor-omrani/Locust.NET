using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Locust.Model;

namespace Locust.Test.Test
{
    public class Foo:BaseModel
    {
        public int Data { get; set; }
    }
    public class A : BaseModel
    {
        public string alpha { get; set; }
        public Foo F { get; set; }

        public A()
        {
            F = new Foo();
        }
    }

    public class B : BaseModel
    {
        public A a { get; set; }
        public string Name { get; set; }
        public B()
        {
            a = new A();
        }
    }
    public class test_nested_basemodel:BaseTest
    {
        public override void Test()
        {
            var b = new B();
            var values = new Dictionary<string, object>();
            values.Add("name","Alireza");
            values.Add("a.alpha", "alpha1 data");
            values.Add("a.f.Data", "245");
            b.Read(values);
            var x = JsonConvert.SerializeObject(b, Formatting.Indented);
            System.Console.WriteLine(x);
        }
    }
}
