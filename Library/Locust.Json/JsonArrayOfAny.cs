using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Json
{
    public class JsonArrayOfAny : JsonArray<dynamic>
    {
        private JsonArrayOfAny()
        {
            // implementation of this class is not complete yet
            // so the ctor is private
        }

        //protected override void OnBasicItemDetected(string value, JsonValueType itemType)
        //{
        //    list.Add(value);
        //}
        //protected override bool OnObjectItemDetected(JsonReader reader)
        //{
        //    var emptyreader = new EmptyJson();
        //    emptyreader.Accumulate = true;
        //    emptyreader.ReadJson(reader);

        //    list.Add(x);

        //    return true;
        //}
    }
}
