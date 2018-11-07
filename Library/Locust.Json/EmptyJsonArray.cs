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
    public class EmptyJsonArray:JsonArray<EmptyJson>
    {
        public bool Accumulate { get; set; }
        
        private CharBuffer buffer;
        private long count;
        public string JsonString
        {
            get { return buffer.ToString(); }
        }

        public EmptyJsonArray()
        {
            buffer = new CharBuffer(256);
        }
        protected override bool OnArrayItemDetected(JsonReader reader)
        {
            var x = new EmptyJsonArray { Accumulate = this.Accumulate };

            x.ReadJson(reader);

            if (Accumulate)
            {
                if (count > 0)
                    buffer.Append(", ");

                buffer.Append("[" + x.JsonString + "]");

                count++;
            }

            return true;
        }
        protected override bool OnObjectItemDetected(JsonReader reader)
        {
            var x = new EmptyJson { Accumulate = this.Accumulate };

            x.ReadJson(reader);

            if (Accumulate)
            {
                if (count > 0)
                    buffer.Append(", ");

                buffer.Append("{" + x.JsonString + "}");

                count++;
            }

            return true;
        }
        protected override void OnBasicItemDetected(string item, JsonValueType itemType)
        {
            if (Accumulate)
            {
                if (count > 0)
                    buffer.Append(", ");

                switch (itemType)
                {
                    case JsonValueType.String:
                        buffer.Append("\"" + HttpUtility.JavaScriptStringEncode(item) + "\"");
                        break;
                    case JsonValueType.Char:
                        buffer.Append("'" + item + "'");
                        break;
                    case JsonValueType.Null:
                        buffer.Append("null");
                        break;
                    case JsonValueType.Number:
                        buffer.Append(item);
                        break;
                    case JsonValueType.Boolean:
                        buffer.Append(item);
                        break;
                    default:
                        buffer.Append("\"" + item + "\"");
                        break;
                }
                
                count++;
            }
        }
    }
}
