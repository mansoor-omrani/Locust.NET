using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Base;

namespace Locust.Json
{
    public class JsonArrayOfBasicType : JsonArray<object>
    {
        protected override void OnBasicItemDetected(string value, JsonValueType itemType)
        {
            var x = Convert.ChangeType(value, TypeHelper.TypeOfObject);

            list.Add(x);
        }
    }
    public class JsonArrayOfBasicType<T>: JsonArray<T>
    {
        protected override void OnBasicItemDetected(string value, JsonValueType itemType)
        {
            T x = (T)Convert.ChangeType(value, typeof(T));

            list.Add(x);
        }
    }
    public class JsonArrayOfBasicTypeOfT<T> : JsonArray<T> where T : struct
    {
        protected override void OnBasicItemDetected(string value, JsonValueType itemType)
        {
            T x = (T)Convert.ChangeType(value, typeof(T));

            list.Add(x);
        }
    }
}
