using System;
using System.Collections;
using System.Collections.Generic;


namespace Locust.Collections
{
    public interface ISafeDictionary<TKey, TValue>: IDictionary<TKey, TValue>,
                                                    ICollection<KeyValuePair<TKey, TValue>>,
                                                    IEnumerable<KeyValuePair<TKey, TValue>>,
                                                    IEnumerable,
                                                    IDictionary,
                                                    ICollection,
                                                    IReadOnlyDictionary<TKey, TValue>,
                                                    IReadOnlyCollection<KeyValuePair<TKey, TValue>>
    {
        object SyncPoint { get; set; }
        bool IsEmpty { get; }
        KeyValuePair<TKey, TValue>[] ToArray();
        TValue AddOrUpdate(TKey key, TValue addValue, Func<TKey, TValue, TValue> updateValueFactory);
        TValue AddOrUpdate(TKey key, Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory);
        TValue GetOrAdd(TKey key, TValue value);
        TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory);
        new bool Add(TKey key, TValue item);
        bool TryAdd(TKey key, TValue value);
        bool TryRemove(TKey key, out TValue value);
        new bool Remove(TKey key);
        bool TryUpdate(TKey key, TValue newValue);
        bool TryUpdate(TKey key, TValue newValue, out TValue oldValue);
        bool TryUpdate(TKey key, TValue newValue, TValue comparisonValue);
        new bool TryGetValue(TKey key, out TValue value);
        new bool ContainsKey(TKey key);
        new TValue this[TKey key] { get; set; }
    }
}
