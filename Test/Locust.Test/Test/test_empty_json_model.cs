using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Json;

namespace Locust.Test.Test
{
    public class test_empty_json_model:BaseTest
    {
        class Foo : JsonModel
        {
            public string Alpha { get; set; }
            public string Data { get; set; }
            protected override void OnBasicPropertyDetected(string propertyName, string propertyValue, JsonValueType itemType)
            {
                if (string.Compare(propertyName, "alpha", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    Alpha = propertyValue;
                    return;
                }
                if (string.Compare(propertyName, "data", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    Data = propertyValue;
                    return;
                }
            }
            protected override bool OnObjectPropertyDetected(string propertyName, JsonReader reader)
            {
                if (string.Compare(propertyName, "data1", StringComparison.OrdinalIgnoreCase) == 0)
                {
                    var x = new EmptyJson { Accumulate = true };

                    x.ReadJson(reader);

                    Data = "{" + x.JsonString + "}";

                    return true;
                }

                return false;
            }
        }
        public override void Test()
        {
            var json = "{alpha:'abc',data:\"some data\",data1:{a:1,b:true,x:{},y:[1,2,true,{x:5}],z:\"ALI\"},data2:null}";
            var f = new Foo();
            f.ReadJson(json);
            Console.WriteLine(f.Alpha);
            Console.WriteLine(f.Data);
        }
    }
}
