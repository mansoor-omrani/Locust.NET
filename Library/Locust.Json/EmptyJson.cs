using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Locust.Base;
using Locust.Collections;

namespace Locust.Json
{
    public class EmptyJson: JsonModel
    {
        private CharBuffer buffer;
        private int count;
        public bool Accumulate { get; set; }
        public string JsonString
        {
            get { return buffer.ToString(); }
        }

        public EmptyJson()
        {
            buffer = new CharBuffer(256);
        }
        protected override bool OnArrayPropertyDetected(string propertyName, JsonReader reader)
        {
            var x = new EmptyJsonArray{ Accumulate = this.Accumulate };

            if (Accumulate)
            {
                if (count > 0)
                    buffer.Append(", ");

                buffer.AppendFormat("\"{0}\": [", propertyName);
            }
            x.ReadJson(reader);

            if (Accumulate)
            {
                buffer.Append(x.JsonString);
                buffer.Append(']');

                count++;
            }

            return true;
        }
        protected override bool OnObjectPropertyDetected(string propertyName, JsonReader reader)
        {
            var x = new EmptyJson { Accumulate = this.Accumulate };

            if (Accumulate)
            {
                if (count > 0)
                    buffer.Append(", ");

                buffer.AppendFormat("\"{0}\": {{", propertyName);
            }

            x.ReadJson(reader);

            if (Accumulate)
            {
                buffer.Append(x.JsonString);
                buffer.Append('}');

                count++;
            }

            return true;
        }

        protected override void OnBasicPropertyDetected(string propertyName, string propertyValue, JsonValueType propertyType)
        {
            if (Accumulate)
            {
                if (count > 0)
                    buffer.Append(", ");

                switch (propertyType)
                {
                    case JsonValueType.String:
                        buffer.AppendFormat("\"{0}\": \"{1}\"", propertyName, HttpUtility.JavaScriptStringEncode(propertyValue));
                        break;
                    case JsonValueType.Char:
                        buffer.AppendFormat("\"{0}\": '{1}'", propertyName, propertyValue);
                        break;
                    case JsonValueType.Null:
                        buffer.AppendFormat("\"{0}\": {1}", propertyName, propertyValue);
                        break;
                    case JsonValueType.Number:
                        buffer.AppendFormat("\"{0}\": {1}", propertyName, propertyValue);
                        break;
                    case JsonValueType.Boolean:
                        buffer.AppendFormat("\"{0}\": {1}", propertyName, propertyValue);
                        break;
                    default:
                        buffer.AppendFormat("\"{0}\": \"{1}\"", propertyName, propertyValue);
                        break;
                }

                count++;
            }
        }
    }
}
