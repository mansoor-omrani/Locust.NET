using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Locust.Collections
{
    public class SafeConcurrentDictionary<TKey, TValue> : ConcurrentDictionary<TKey, TValue>, ISafeDictionary<TKey, TValue>
    {
        private void Init()
        {
            SyncPoint = new object();
        }
        public object SyncPoint { get; set; }
        #region ctor
        public SafeConcurrentDictionary() { Init(); }
        public SafeConcurrentDictionary(IEqualityComparer<TKey> comparer) : base(comparer) { Init(); }
        public SafeConcurrentDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection) : base(collection) { Init(); }
        public SafeConcurrentDictionary(IDictionary<TKey, TValue> dictionary) : base(dictionary) { Init(); }
        public SafeConcurrentDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer) : base(dictionary, comparer) { Init(); }
        public SafeConcurrentDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer) : base(collection, comparer) { Init(); }
        public SafeConcurrentDictionary(int concurrencyLevel, int capacity) : base(concurrencyLevel, capacity) { Init(); }
        public SafeConcurrentDictionary(int concurrencyLevel, int capacity, IEqualityComparer<TKey> comparer) : base(concurrencyLevel, capacity, comparer) { Init(); }
        public SafeConcurrentDictionary(int concurrencyLevel, IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer) : base(concurrencyLevel, collection, comparer) { Init(); }
        #endregion
        public virtual bool Remove(TKey key)
        {
            TValue value;

            return TryRemove(key, out value);
        }
        private bool AddInternal(TKey key, TValue value)
        {
            TValue _value;
            var result = false;

            if (this.TryGetValue(key, out _value))
            {
                return this.TryUpdate(key, value, _value);
            }
            else
            {
                result = this.TryAdd(key, value);
            }

            return result;
        }
        public virtual bool Add(TKey key, TValue value)
        {
            lock (SyncPoint)
            {
                return AddInternal(key, value);
            }
        }
        public new virtual TValue this[TKey key]
        {
            get
            {
                return GetOrAdd(key, default(TValue));
            }
            set
            {
                AddOrUpdate(key, value, (_key, oldValue) => value);
            }
        }
        private bool TryUpdateInternal(TKey key, TValue value)
        {
            TValue _value;
            var result = false;

            if (this.TryGetValue(key, out _value))
            {
                AddOrUpdate(key, value, (_key, oldValue) => value);
                result = true;
            }

            return result;
        }
        public virtual bool TryUpdate(TKey key, TValue value)
        {
            lock (SyncPoint)
            {
                return TryUpdateInternal(key, value);
            }
        }
        private bool TryUpdateInternal(TKey key, TValue value, out TValue oldValue)
        {
            var result = false;

            if (this.TryGetValue(key, out oldValue))
            {
                AddOrUpdate(key, value, (_key, _oldValue) => value);
                result = true;
            }

            return result;
        }
        public virtual bool TryUpdate(TKey key, TValue newValue, out TValue oldValue)
        {
            lock (SyncPoint)
            {
                return TryUpdateInternal(key, newValue, out oldValue);
            }
        }
    }
}
