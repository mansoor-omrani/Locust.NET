using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Language;
using Locust.ServiceModel.Babbage;
using Locust.Tracing;
using Locust.Translation;

namespace Locust.Test.Test
{
    public class test_BabbageMessageProvider:BaseTest
    {
        public override void Test()
        {
            var translator = new TextFileStorageTranslation();
            var mc = new BabbageMessageProvider(translator);
            mc.BasePath = "d:\\1";
            mc.Load();
            mc.Lang = Lang.Fa;
            
            System.Console.WriteLine(mc.GetContentOf(new Message { Category = "order", Operation = "new", Code = "success", Provider = mc }));
            System.Console.WriteLine(mc.GetContentOf(new Message { Category = "Order", Operation = "nEw", Code = "Faulted", Provider = mc }));
            System.Console.WriteLine(mc.GetContentOf(new Message { Category = "MyService", Operation = "SomeStrategy", Code = "faulted", Provider = mc }));
            System.Console.WriteLine(mc.GetContentOf(new Message { Category = "order", Operation = "new", Code = "error", Provider = mc }));
            System.Console.WriteLine(mc.GetContentOf(new Message { Category = "order", Operation = "get", Code = "faulted", Provider = mc }));
        }
    }
}
