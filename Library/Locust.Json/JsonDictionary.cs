using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Base;
using Locust.Extensions;
using Locust.Serialization;

namespace Locust.Json
{
    public class JsonDictionary: JsonModel, IDictionary<string, string>
    {
        protected IDictionary<string, string> dictionary { get; set; }
        public JsonDictionary(): this(false)
        { }
        public JsonDictionary(bool caseInsensitiveKeys)
        {
            if (caseInsensitiveKeys)
            {
                dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            }
            else
            {
                dictionary = new Dictionary<string, string>();
            }
        }
        public override string ToJson(JsonSerializationOptions options = null)
        {
            var _options = new JsonSerializationOptions(options);
            var indent = _options.CurrentIndent + _options.Indent;
            var crlf = Environment.NewLine;
            var currentIndent = _options.CurrentIndent;

            if (!_options.UseIndentation)
            {
                indent = "";
                currentIndent = "";
                crlf = "";
            }
            var result = new StringBuilder();
            var c = 0;

            result.Append("{");

            foreach (var item in dictionary)
            {
				var prefix = ((c++ == 0)?"":", ");

                result.AppendFormat("{0}\"{1}\": \"{2}\"", prefix, item.Key, item.Value);
            }

            result.Append("}");

            return result.ToString();
        }

        protected override void OnBasicPropertyDetected(string propertyName, string propertyValue, JsonValueType itemType)
        {
            Add(propertyName, propertyValue);
        }

        public void Add(string key, string value)
        {
            dictionary.Add(key, value);
        }
        public bool ContainsKey(string key)
        {
            return dictionary.ContainsKey(key);
        }

        public ICollection<string> Keys
        {
            get { return dictionary.Keys; }
        }

        public bool Remove(string key)
        {
            return dictionary.Remove(key);
        }

        public bool TryGestring(string key, out string value)
        {
            return dictionary.TryGetValue(key, out value);
        }

        public ICollection<string> Values
        {
            get { return dictionary.Values; }
        }

        public string this[string key]
        {
            get
            {
                return dictionary[key];
            }
            set { dictionary[key] = value; }
        }
        public KeyValuePair<string, string> this[int index]
        {
            get { return dictionary.GetByIndex(index); }
            set
            {
                dictionary.SetByIndex(index, value);
            }
        }
        public void Add(KeyValuePair<string, string> item)
        {
            dictionary.Add(item.Key, item.Value);
        }

        public void Clear()
        {
            dictionary.Clear();
        }
        public bool Contains(KeyValuePair<string, string> item)
        {
            return dictionary.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            dictionary.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return dictionary.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            return dictionary.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return dictionary.GetEnumerator();
        }


        public bool TryGetValue(string key, out string value)
        {
            return dictionary.TryGetValue(key, out value);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
