using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Base;
using Locust.Extensions;
using Locust.Serialization;

namespace Locust.Json
{
    public abstract class JsonArray<T>: JsonModel, IList<T>
    {
        protected List<T> list { get; set; }
        public JsonArray()
        {
            list = new List<T>();
        }

        public int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        public T this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            }
        }

        public void Add(T item)
        {
            list.Add(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return list.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(T item)
        {
            return list.Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    //    public override string ToJson(JsonSerializationOptions options = null)
    //    {
    //        var _options = new JsonSerializationOptions(options);
    //        var indent = _options.CurrentIndent + _options.Indent;
    //        var crlf = Environment.NewLine;
    //        var currentIndent = _options.CurrentIndent;

    //        if (!_options.UseIndentation)
    //        {
    //            indent = "";
    //            currentIndent = "";
    //            crlf = "";
    //        }

    //        var result = new StringBuilder();
    //        var c = 0;

    //        result.Append("[");
                
    //        foreach (var value in list)
    //        {
				//var prefix = ((c++ == 0)?"":", ");
    //            if (value == null)
    //            {
    //                result.AppendFormat("{0}{1}", prefix, "null");
    //                continue;
    //            }
    //            var valueType = value.GetType();
    //            if (valueType == TypeHelper.TypeOfBool)
				//{
				//	result.AppendFormat("{0}{1}", prefix, value.ToString().ToLower());
				//	continue;
				//}
				//if (valueType.IsNumeric())
				//{
				//	result.AppendFormat("{0}{1}", prefix, value.ToString());
				//	continue;
				//}
				//if (value is char)
				//{
				//	result.AppendFormat("{0}'{1}'", prefix, value);
				//	continue;
				//}
    //            if (value is Guid)
    //            {
    //                if ((Guid)(object)(value) != Guid.Empty)
    //                {
    //                    result.AppendFormat("{0}\"{1}\"", prefix, value);
    //                    continue;
    //                }
    //                else
    //                {
    //                    result.AppendFormat("{0}\"{1}\"", prefix, "null");
    //                    continue;
    //                }
    //            }
    //            if (value is string)
				//{
				//	result.AppendFormat("{0}\"{1}\"", prefix, value);
				//	continue;
				//}

				//var jm = value as IJsonSerializable;

				//if (jm != null)
				//{
				//	result.AppendFormat("{0}{1}", prefix, jm.ToJson(_options));
				//	continue;
				//}

    //            var e = value as IEnumerable;
    //            if (e != null)
    //            {
    //                result.AppendFormat("{0}", prefix, e.ToJson(_options));
    //                continue;
    //            }
    //            result.AppendFormat("{0}\"{1}\"", prefix, value);

    //            result.AppendFormat("{0}{1}", prefix, value);
    //        }

    //        result.Append("]");

    //        return result.ToString();
    //    }
    }
}
