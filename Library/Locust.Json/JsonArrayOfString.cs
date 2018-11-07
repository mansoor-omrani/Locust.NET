using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Json
{
    public class JsonArrayOfString: JsonArray<string>
    {
        protected override void OnBasicItemDetected(string value, JsonValueType itemType)
        {
            var x = (string)Convert.ChangeType(value, typeof(string));

            list.Add(x);
        }
    }
}
