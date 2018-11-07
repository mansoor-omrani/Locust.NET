using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Collections
{
    public interface IListDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        KeyValuePair<TKey, TValue> this[int index] { get; set; }
    }
}
