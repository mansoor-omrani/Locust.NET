using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Locust.ServiceModel.Babbage;
using Locust.Tracing;

namespace Locust.Test.Test
{
    public class test_newtonsoft_json:BaseTest
    {
        class Foo
        {
            public string Alpha { get; set; }
            public BabbageMessageProvider Provider { get; set; }
            public List<Message> Messages { get; set; }
            public int X { get; set; }
            public string Name { get; set; }
        }
        private void test1()
        {
            var x = new Foo { Name = "ali" };
            var y = JsonConvert.SerializeObject(x, Newtonsoft.Json.Formatting.Indented,
                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });
            System.Console.WriteLine(y);
        }
        public override void Test()
        {
            throw new NotImplementedException();
        }
    }
}
