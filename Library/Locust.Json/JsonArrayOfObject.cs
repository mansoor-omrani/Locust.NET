using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Json
{
    public class JsonArrayOfObject : JsonArray<object>
    {
        public Type ItemType { get; private set; }
        public JsonArrayOfObject(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            ItemType = type;
        }
        protected override bool OnObjectItemDetected(JsonReader reader)
        {
            var x = Activator.CreateInstance(ItemType);

            var jsonModel = x as JsonModel;

            if (jsonModel != null)
            {
                jsonModel.ReadJson(reader);

                list.Add(x);

                return true;
            }

            return false;
        }
    }
    public class JsonArrayOfObject<T> : JsonArray<T>
    {
        protected override bool OnObjectItemDetected(JsonReader reader)
        {
            var x = Activator.CreateInstance<T>();
            var jsonModel = x as JsonModel;

            if (jsonModel != null)
            {
                jsonModel.ReadJson(reader);

                list.Add(x);

                return true;
            }
            
            return false;
        }
    }
    public class JsonArrayOfObjectOfT<T>: JsonArray<T> where T: JsonModel, new()
    {
        protected override bool OnObjectItemDetected(JsonReader reader)
        {
            var x = new T();

            x.ReadJson(reader);

            list.Add(x);

            return true;
        }
    }
}
