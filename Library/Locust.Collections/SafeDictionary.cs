using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Collections
{
    public class SafeDictionary<TKey, TValue> : ISafeDictionary<TKey, TValue>
    {
        private void Init()
        {
            SyncPoint = new object();
        }
        #region Fields
        protected Dictionary<TKey, TValue> _dictionary;
        #endregion
        #region Properties
        public bool UnsafeMode { get; set; }
        protected int ConcurrencyLevel { get; }
        #endregion
        #region ISafeDictionary<TKey, TValue> implementation
        public object SyncPoint { get; set; }
        public virtual bool IsEmpty
        {
            get
            {
                if (!UnsafeMode)
                    lock (SyncPoint)
                        return this._dictionary.Count == 0;

                return this._dictionary.Count == 0;
            }
        }
        private KeyValuePair<TKey, TValue>[] ToArrayInternal()
        {
            var arr = new KeyValuePair<TKey, TValue>[_dictionary.Count];
            (_dictionary as ICollection<KeyValuePair<TKey, TValue>>).CopyTo(arr, 0);
            return arr;
        }
        public virtual KeyValuePair<TKey, TValue>[] ToArray()
        {
            if (!UnsafeMode)
                lock (SyncPoint)
                {
                    return ToArrayInternal();
                }
            return ToArrayInternal();
        }
        private TValue AddOrUpdateInternal(TKey key, Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory)
        {
            TValue result;

            if (_dictionary.TryGetValue(key, out result))
            {
                result = updateValueFactory(key, result);
                _dictionary[key] = result;
            }
            else
            {
                result = addValueFactory(key);
                _dictionary.Add(key, result);
            }

            return result;
        }
        public virtual TValue AddOrUpdate(TKey key, Func<TKey, TValue> addValueFactory, Func<TKey, TValue, TValue> updateValueFactory)
        {
            if (!UnsafeMode)
                lock (SyncPoint)
                {
                    return AddOrUpdateInternal(key, addValueFactory, updateValueFactory);
                }

            return AddOrUpdateInternal(key, addValueFactory, updateValueFactory);
        }
        private TValue AddOrUpdateInternal(TKey key, TValue addValue, Func<TKey, TValue, TValue> updateValueFactory)
        {
            TValue result;

            if (_dictionary.TryGetValue(key, out result))
            {
                result = updateValueFactory(key, result);
                _dictionary[key] = result;
            }
            else
            {
                result = addValue;
                _dictionary.Add(key, result);
            }

            return result;
        }
        public virtual TValue AddOrUpdate(TKey key, TValue addValue, Func<TKey, TValue, TValue> updateValueFactory)
        {
            if (!UnsafeMode)
                lock (SyncPoint)
                {
                    return AddOrUpdateInternal(key, addValue, updateValueFactory);
                }

            return AddOrUpdateInternal(key, addValue, updateValueFactory);
        }
        private TValue GetOrAddInternal(TKey key, TValue value)
        {
            TValue result;

            if (!_dictionary.TryGetValue(key, out result))
            {
                result = value;
                _dictionary.Add(key, result);
            }

            return result;
        }
        public virtual TValue GetOrAdd(TKey key, TValue value)
        {
            if (!UnsafeMode)
                lock (SyncPoint)
                {
                    return GetOrAddInternal(key, value);
                }

            return GetOrAddInternal(key, value);
        }
        private TValue GetOrAddInternal(TKey key, Func<TKey, TValue> valueFactory)
        {
            TValue result;

            if (!_dictionary.TryGetValue(key, out result))
            {
                result = valueFactory(key);
                _dictionary.Add(key, result);
            }

            return result;
        }
        public virtual TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory)
        {
            if (!UnsafeMode)
                lock (SyncPoint)
                {
                    return GetOrAddInternal(key, valueFactory);
                }

            return GetOrAddInternal(key, valueFactory);
        }
        private bool TryAddInternal(TKey key, TValue value)
        {
            var result = false;

            if (!_dictionary.ContainsKey(key))
            {
                _dictionary.Add(key, value);
                result = true;
            }

            return result;
        }
        public virtual bool TryAdd(TKey key, TValue value)
        {
            if (!UnsafeMode)
                lock (SyncPoint)
                {
                    return TryAddInternal(key, value);
                }

            return TryAddInternal(key, value);
        }
        private bool TryRemoveInternal(TKey key, out TValue value)
        {
            var result = false;

            if (_dictionary.TryGetValue(key, out value))
            {
                _dictionary.Remove(key);
                result = true;
            }

            return result;
        }
        public virtual bool TryRemove(TKey key, out TValue value)
        {
            if (!UnsafeMode)
                lock (SyncPoint)
                {
                    return TryRemoveInternal(key, out value);
                }

            return TryRemoveInternal(key, out value);
        }
        private bool TryUpdateInternal(TKey key, TValue newValue, TValue comparisonValue)
        {
            var result = false;
            TValue oldValue;
            IEqualityComparer<TValue> valueComparer = EqualityComparer<TValue>.Default;

            if (_dictionary.TryGetValue(key, out oldValue))
            {
                if (valueComparer.Equals(oldValue, comparisonValue))
                {
                    _dictionary[key] = newValue;
                    result = true;
                }
            }

            return result;
        }
        public virtual bool TryUpdate(TKey key, TValue newValue, TValue comparisonValue)
        {
            if (!UnsafeMode)
                lock (SyncPoint)
                {
                    return TryUpdateInternal(key, newValue, comparisonValue);
                }

            return TryUpdateInternal(key, newValue, comparisonValue);
        }
        private bool TryUpdateInternal(TKey key, TValue newValue)
        {
            var result = false;
            TValue oldValue;

            if (_dictionary.TryGetValue(key, out oldValue))
            {
                _dictionary[key] = newValue;
                result = true;
            }

            return result;
        }
        public virtual bool TryUpdate(TKey key, TValue newValue)
        {
            if (!UnsafeMode)
                lock (SyncPoint)
                {
                    return TryUpdateInternal(key, newValue);
                }

            return TryUpdateInternal(key, newValue);
        }
        private bool TryUpdateInternal(TKey key, TValue newValue, out TValue oldValue)
        {
            var result = false;

            if (_dictionary.TryGetValue(key, out oldValue))
            {
                _dictionary[key] = newValue;
                result = true;
            }

            return result;
        }
        public virtual bool TryUpdate(TKey key, TValue newValue, out TValue oldValue)
        {
            if (!UnsafeMode)
                lock (SyncPoint)
                {
                    return TryUpdateInternal(key, newValue, out oldValue);
                }

            return TryUpdateInternal(key, newValue, out oldValue);
        }
        private bool AddInternal(TKey key, TValue value)
        {
            TValue _value;
            var result = false;

            if (_dictionary.TryGetValue(key, out _value))
            {
                _dictionary[key] = value;
            }
            else
            {
                _dictionary.Add(key, value);
                result = true;
            }

            return result;
        }
        public bool Add(TKey key, TValue value)
        {
            if (!UnsafeMode)
                lock (SyncPoint)
                    return AddInternal(key, value);
            return AddInternal(key, value);
        }
        #endregion
        #region IReadOnlyDictionary<TKey, TValue> implementation
        IEnumerable<TKey> IReadOnlyDictionary<TKey, TValue>.Keys
        {
            get
            {
                if (!UnsafeMode)
                    lock (SyncPoint)
                        return (_dictionary as IReadOnlyDictionary<TKey, TValue>).Keys;
                return (_dictionary as IReadOnlyDictionary<TKey, TValue>).Keys;
            }
        }
        IEnumerable<TValue> IReadOnlyDictionary<TKey, TValue>.Values
        {
            get
            {
                if (!UnsafeMode)
                    lock (SyncPoint)
                        return (_dictionary as IReadOnlyDictionary<TKey, TValue>).Values;
                return (_dictionary as IReadOnlyDictionary<TKey, TValue>).Values;
            }
        }
        TValue IReadOnlyDictionary<TKey, TValue>.this[TKey key]
        {
            get
            {
                return this[key];
            }
        }
        #endregion
        #region IDictionary<TKey, TValue> implementation
        public virtual ICollection<TKey> Keys
        {
            get
            {
                if (!UnsafeMode)
                    lock (SyncPoint)
                        return _dictionary.Keys;
                return _dictionary.Keys;
            }
        }
        public virtual ICollection<TValue> Values
        {
            get
            {
                if (!UnsafeMode)
                    lock (SyncPoint)
                        return _dictionary.Values;
                return _dictionary.Values;
            }
        }
        void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
        {
            this.Add(key, value);
        }
        public virtual bool Remove(TKey key)
        {
            if (!UnsafeMode)
                lock (SyncPoint)
                    return _dictionary.Remove(key);
            return _dictionary.Remove(key);
        }
        public virtual TValue this[TKey key]
        {
            get
            {
                if (!UnsafeMode)
                    lock (SyncPoint)
                        return GetOrAddInternal(key, default(TValue));
                return GetOrAddInternal(key, default(TValue));
            }

            set
            {
                if (!UnsafeMode)
                    lock (SyncPoint)
                    {
                        AddOrUpdateInternal(key, value, (_key, oldValue) => value);
                        return;
                    }
                AddOrUpdateInternal(key, value, (_key, oldValue) => value);
            }
        }
        #endregion
        #region ICollection implementation
        public virtual int Count
        {
            get
            {
                if (!UnsafeMode)
                    lock (SyncPoint)
                        return _dictionary.Count;

                return _dictionary.Count;
            }
        }
        bool ICollection.IsSynchronized
        {
            get
            {
                return !UnsafeMode;
            }
        }
        object ICollection.SyncRoot
        {
            get
            {
                return SyncPoint;
            }
        }
        void ICollection.CopyTo(Array array, int index)
        {
            if (!UnsafeMode)
                lock (SyncPoint)
                {
                    (_dictionary as ICollection).CopyTo(array, index);
                    return;
                }
            (_dictionary as ICollection).CopyTo(array, index);
        }
        #endregion
        #region ICollection<KeyValuePair<TKey, TValue>>
        bool ICollection<KeyValuePair<TKey, TValue>>.IsReadOnly
        {
            get
            {
                return (_dictionary as ICollection<KeyValuePair<TKey, TValue>>).IsReadOnly;
            }
        }
        void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
        {
            this.Add(item.Key, item.Value);
        }
        bool ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
        {
            if (!UnsafeMode)
                lock (SyncPoint)
                    return (_dictionary as ICollection<KeyValuePair<TKey, TValue>>).Contains(item);
            return (_dictionary as ICollection<KeyValuePair<TKey, TValue>>).Contains(item);
        }
        void ICollection<KeyValuePair<TKey, TValue>>.CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (!UnsafeMode)
                lock (SyncPoint)
                {
                    (_dictionary as ICollection<KeyValuePair<TKey, TValue>>).CopyTo(array, arrayIndex);
                    return;
                }
            (_dictionary as ICollection<KeyValuePair<TKey, TValue>>).CopyTo(array, arrayIndex);
        }
        bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            if (!UnsafeMode)
                lock (SyncPoint)
                    return (_dictionary as ICollection<KeyValuePair<TKey, TValue>>).Remove(item);
            return (_dictionary as ICollection<KeyValuePair<TKey, TValue>>).Remove(item);
        }
        #endregion
        #region public Methods
        public virtual bool ContainsKey(TKey key)
        {
            if (!UnsafeMode)
                lock (SyncPoint)
                    return _dictionary.ContainsKey(key);
            return _dictionary.ContainsKey(key);
        }
        public virtual void Clear()
        {
            if (!UnsafeMode)
                lock (SyncPoint)
                {
                    _dictionary.Clear();
                    return;
                }
            _dictionary.Clear();
        }
        public virtual bool TryGetValue(TKey key, out TValue value)
        {
            if (!UnsafeMode)
                lock (SyncPoint)
                    return _dictionary.TryGetValue(key, out value);
            return _dictionary.TryGetValue(key, out value);
        }
        #endregion
        #region IDictionary implementation
        bool IDictionary.IsReadOnly
        {
            get
            {
                return (_dictionary as IDictionary).IsReadOnly;
            }
        }
        bool IDictionary.IsFixedSize
        {
            get
            {
                return (_dictionary as IDictionary).IsFixedSize;
            }
        }
        bool IDictionary.Contains(object key)
        {
            return this.ContainsKey((TKey)key);
        }
        ICollection IDictionary.Keys
        {
            get
            {
                if (!UnsafeMode)
                    lock (SyncPoint)
                        return _dictionary.Keys;
                return _dictionary.Keys;
            }
        }
        ICollection IDictionary.Values
        {
            get
            {
                if (!UnsafeMode)
                    lock (SyncPoint)
                        return _dictionary.Values;
                return _dictionary.Values;
            }
        }
        void IDictionary.Add(object key, object value)
        {
            this.Add((TKey)key, (TValue)value);
        }
        IDictionaryEnumerator IDictionary.GetEnumerator()
        {
            if (!UnsafeMode)
            {
                lock (SyncPoint)
                {
                    return (_dictionary as IDictionary).GetEnumerator();
                }
            }
            return (_dictionary as IDictionary).GetEnumerator();
        }
        object IDictionary.this[object key]
        {
            get
            {
                return this[(TKey)key];
            }

            set
            {
                this[(TKey)key] = (TValue)value;
            }
        }
        void IDictionary.Remove(object key)
        {
            this.Remove((TKey)key);
        }
        #endregion
        #region IEnumerable<KeyValuePair<TKey, TValue>> implementation
        public virtual IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            if (!UnsafeMode)
            {
                lock (SyncPoint)
                {
                    return (_dictionary as IEnumerable<KeyValuePair<TKey, TValue>>).GetEnumerator();
                }
            }
            return (_dictionary as IEnumerable<KeyValuePair<TKey, TValue>>).GetEnumerator();
        }
        #endregion
        #region IEnumerable implementation
        IEnumerator IEnumerable.GetEnumerator()
        {
            if (!UnsafeMode)
            {
                lock (SyncPoint)
                {
                    return (_dictionary as IEnumerable).GetEnumerator();
                }
            }
            return (_dictionary as IEnumerable).GetEnumerator();
        }
        #endregion
        #region ctor
        public SafeDictionary()
        {
            _dictionary = new Dictionary<TKey, TValue>();

            Init();
        }
        public SafeDictionary(IEqualityComparer<TKey> comparer)
        {
            _dictionary = new Dictionary<TKey, TValue>(comparer);

            Init();
        }
        public SafeDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection)
        {
            _dictionary = new Dictionary<TKey, TValue>();

            Init();

            foreach (var item in collection)
            {
                _dictionary.Add(item.Key, item.Value);
            }
        }
        public SafeDictionary(IDictionary<TKey, TValue> dictionary)
        {
            _dictionary = new Dictionary<TKey, TValue>(dictionary);

            Init();
        }
        public SafeDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
        {
            _dictionary = new Dictionary<TKey, TValue>(dictionary, comparer);

            Init();
        }
        public SafeDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer)
        {
            _dictionary = new Dictionary<TKey, TValue>(comparer);

            Init();

            foreach (var item in collection)
            {
                _dictionary.Add(item.Key, item.Value);
            }
        }
        public SafeDictionary(int concurrencyLevel, int capacity)
        {
            _dictionary = new Dictionary<TKey, TValue>(capacity);

            ConcurrencyLevel = concurrencyLevel;

            Init();
        }
        public SafeDictionary(int concurrencyLevel, int capacity, IEqualityComparer<TKey> comparer)
        {
            _dictionary = new Dictionary<TKey, TValue>(capacity, comparer);

            Init();

            ConcurrencyLevel = concurrencyLevel;
        }
        public SafeDictionary(int concurrencyLevel, IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer) : this(collection, comparer)
        {
            ConcurrencyLevel = concurrencyLevel;
        }
        #endregion
    }
}
