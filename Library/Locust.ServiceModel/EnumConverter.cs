using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Locust.ServiceModel
{
    public class EnumConverter : Newtonsoft.Json.Converters.StringEnumConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value != null && value.GetType().IsEnum)
            {
                writer.WriteValue(value.ToString());// or something else
                return;
            }

            base.WriteJson(writer, value, serializer);
        }
    }
}
