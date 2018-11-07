using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Json
{
    public class JsonArrayOfArray<T>: JsonArray<T> where T: JsonArray<T>, new()
    {
        protected override bool OnArrayItemDetected(JsonReader reader)
        {
            var x = new T();

            x.ReadJson(reader);

            list.Add(x);

            return true;
        }
    }
}
