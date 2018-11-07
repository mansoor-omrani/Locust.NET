using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Serialization
{
    public class JsonSerializationOptions
    {
        public bool UseIndentation { get; set; }
        public string Indent { get; set; }
        public string CurrentIndent { get; set; }
        public bool IgnoreNullObjects { get; set; }
        public bool IgnoreEmptyStrings { get; set; }
        public bool IgnoreEmptyCollections { get; set; }
        public bool ConvertEnumsToString { get; set; }
        public JsonSerializationOptions()
        {
            Indent = new string(' ', 4);
            IgnoreNullObjects = true;
            ConvertEnumsToString = true;
        }
        public static JsonSerializationOptions From(JsonSerializationOptions options)
        {
            return new JsonSerializationOptions(options);
        }
        public JsonSerializationOptions(JsonSerializationOptions options)
        {
            if (options != null)
            {
                this.IgnoreNullObjects = options.IgnoreNullObjects;
                this.IgnoreEmptyStrings = options.IgnoreEmptyStrings;
                this.ConvertEnumsToString = options.ConvertEnumsToString;
                this.IgnoreEmptyCollections = options.IgnoreEmptyCollections;

                this.UseIndentation = options.UseIndentation;
                this.Indent = options.Indent;
                this.CurrentIndent = options.CurrentIndent + Indent;
            }
        }
    }
    public interface IJsonSerializable
    {
        string ToJson(JsonSerializationOptions options = null);
    }
}
