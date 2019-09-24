using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Extensions
{
    internal class IdentityFunction<TElement>
    {
        internal static Func<TElement, TElement> Instance
        {
            get
            {
                return (Func<TElement, TElement>)(x => x);
            }
        }
    }
    public static class CollectionExtensions
    {
        public static KeyValuePair<TKey, TValue> ItemAt<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, int index)
        {
            var i = 0;

            foreach (var item in dictionary)
            {
                if (i == index)
                {
                    return item;
                }
            }

            return default(KeyValuePair<TKey, TValue>);
        }
        public static KeyValuePair<TKey, TValue> To<TKey, TValue>(this DictionaryEntry item)
        {
            KeyValuePair<TKey, TValue> result;

            try
            {
                result = new KeyValuePair<TKey, TValue>((TKey) item.Key, (TValue) item.Value);
            }
            catch
            {
                result = new KeyValuePair<TKey, TValue>();
            }

            return result;
        }
        public static IEnumerable<T> GetValues<T>(this Type t) where T : struct, IConvertible
        {
            if (typeof(T).IsEnum)
                return Enum.GetValues(t).Cast<T>();
            else
                throw new ArgumentException("Argument is not an enum");
        }
        public static void ForEach(this IEnumerable list, Action<object> action)
        {
            foreach (var item in list)
            {
                action?.Invoke(item);
            }
        }
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var item in list)
            {
                action?.Invoke(item);
            }
        }
        public static void ForEach(this IEnumerable list, Action<int, object> action)
        {
            var i = 0;

            foreach (var item in list)
            {
                action?.Invoke(i, item);

                i++;
            }
        }
        public static void ForEach<T>(this IEnumerable<T> list, Action<int, T> action)
        {
            var i = 0;

            foreach (var item in list)
            {
                action?.Invoke(i, item);

                i++;
            }
        }
        public static string Join<T>(this IEnumerable<T> list, string separator)
        {
            var sb = new StringBuilder();
            var count = 0;
            foreach (var item in list)
            {
                sb.Append((count == 0) ? item?.ToString() : separator + item?.ToString());
                count++;
            }
            return sb.ToString();
        }
        public static string Join<T>(this IEnumerable<T> list, string first, string separator, string last)
        {
            var sb = new StringBuilder();
            var count = 0;
            var cnt = list.Count();

            foreach (var item in list)
            {
                if (count == 0)
                    sb.Append(first);
                sb.Append((count == 0) ? item?.ToString() : separator + item?.ToString());
                count++;
                if (count == cnt)
                    sb.Append(last);
            }

            return sb.ToString();
        }
        public static string Join<T>(this IEnumerable<T> list, char ch)
        {
            return list.Join(ch.ToString());
        }
        public static string Join<TKey, TValue>(this IDictionary<TKey, TValue> list, char ch)
        {
            var sb = new StringBuilder();
            var i = 0;
            foreach (var item in list)
            {
                sb.Append(((i == 0) ? "" : ch.ToString()) + string.Format("{0}={1}", item.Key, item.Value));
                i++;
            }
            return sb.ToString();
        }
        public static string Join<TKey, TValue>(this IDictionary<TKey, TValue> list, string separator)
        {
            var sb = new StringBuilder();
            var i = 0;
            foreach (var item in list)
            {
                sb.Append(((i == 0) ? "" : separator) + string.Format("{0}={1}", item.Key, item.Value));
                i++;
            }
            return sb.ToString();
        }

        public static int FindIndexOf(this IEnumerable<string> list, string value, StringComparison comparison)
        {
            var result = 0;
            var found = false;

            foreach (var item in list)
            {
                if (string.Compare(item, value, comparison) == 0)
                {
                    found = true;
                    break;
                }

                result++;
            }

            return (found) ? result : -1;
        }
        public static string Join(this NameValueCollection c, string separator = ";", Func<string, object, string> transform = null)
        {
            var sb = new StringBuilder();
            Func<string, object, string> _transform = (key, value) =>
            {
                var _result = transform == null ? $"{key}={value}{separator}" : transform(key, value);

                return _result ?? $"{key}={value}{separator}";
            };

            for (int i = 0; i < c.Count; i++)
            {
                sb.Append(_transform(c.GetKey(i), c.Get(i)));
            }

            return sb.ToString();
        }
        public static string Join(this NameObjectCollectionBase c, string separator = ";", Func<string, object, string> transform = null)
        {
            var sb = new StringBuilder();
            Func<string, object, string> _transform = (key, value) =>
            {
                var _result = transform == null ? $"{key}={value}{separator}" : transform(key, value);

                return _result ?? $"{key}={value}{separator}";
            };
            var i = 0;
            foreach (var obj in c)
            {
                sb.Append(_transform(c.Keys[i++], obj));
            }

            return sb.ToString();
        }
        public static string Join(this NameValueCollection c, List<string> excludeheaders, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            var sb = new StringBuilder();

            for (int i = 0; i < c.Count; i++)
            {
                var key = c.GetKey(i);
                var okToAdd = true;

                if (excludeheaders != null)
                {
                    okToAdd = (excludeheaders.FindIndexOf(key, comparison) == -1);
                }

                if (okToAdd)
                {
                    sb.Append(String.Format("{0}={1};", key, c.Get(i)));
                }
            }

            return sb.ToString();
        }
        public static bool Exists<T>(this IEnumerable<T> list, T value)
        {
            var result = false;

            foreach (var item in list)
            {
                if (item != null && item.Equals(value))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        public static void SafeAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            lock (AppDomain.CurrentDomain)
            {
                if (!dictionary.ContainsKey(key))
                {
                    dictionary.Add(key, value);
                }
                else
                {
                    dictionary[key] = value;
                }
            }
        }
        public static void MergeWith<T>(this T[] array1, T[] array2)
        {
            int array1OriginalLength = array1.Length;
            Array.Resize<T>(ref array1, array1OriginalLength + array2.Length);
            Array.Copy(array2, 0, array1, array1OriginalLength, array2.Length);
        }
        public static IDictionary<TKey, TValue> Merge<TKey, TValue>(this IDictionary<TKey, TValue> to, IDictionary<TKey, TValue> from)
        {
            foreach (var item in from)
            {
                to.Add(item);
            }

            return to;
        }
        public static IList<T> Merge<T>(this IList<T> to, IEnumerable<T> from)
        {
            foreach (var item in from)
            {
                to.Add(item);
            }

            return to;
        }
        public static IList<T> MergeByClone<T>(this IList<T> to, IEnumerable<T> from) where T: class, ICloneable
        {
            foreach (var item in from)
            {
                to.Add(item?.Clone() as T);
            }

            return to;
        }
        public static int IndexOf<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            var i = 0;

            foreach (var item in dictionary)
            {
                var c1 = item.Key as IComparable;

                if (c1 != null)
                {
                    if (c1.CompareTo(key) == 0)
                    {
                        return i;
                    }
                }
                else
                {
                    var c2 = item.Key as IComparable<TKey>;

                    if (c2 != null)
                    {
                        if (c2.CompareTo(key) == 0)
                        {
                            return i;
                        }
                    }
                    else
                    {
                        if (item.Key.Equals(key))
                        {
                            return i;
                        }
                    }
                }

                i++;
            }

            return -1;
        }

        public static void SetByIndex<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, int index, TValue value)
        {
            var item = new KeyValuePair<TKey, TValue>(default(TKey), value);

            dictionary.SetByIndex(index, item);
        }
        public static void SetByIndex<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, int index, KeyValuePair<TKey, TValue> item)
        {
            var _item = dictionary.GetByIndex(index);
            var keyIsChanging = false;
            var keyDefault = default(TKey);
            
            if ((keyDefault != null && !keyDefault.Equals(item.Key)) || (item.Key != null))
            {
                var c1 = item.Key as IComparable;

                if (c1 != null)
                {
                    keyIsChanging = (c1.CompareTo(_item.Key) != 0);
                }
                else
                {
                    var c2 = item.Key as IComparable<TKey>;

                    if (c2 != null)
                    {
                        keyIsChanging = (c2.CompareTo(_item.Key) == 0);
                    }
                    else
                    {
                        keyIsChanging = (item.Key.Equals(_item.Key));
                    }
                }
            }

            if (keyIsChanging)
            {
                lock (AppDomain.CurrentDomain)
                {
                    dictionary.Remove(_item.Key);
                    dictionary.Add(item.Key, item.Value);
                }
            }
            else
            {
                dictionary[_item.Key] = item.Value;
            }
        }

        public static KeyValuePair<TKey, TValue> GetByIndex<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, int index)
        {
            if (index >= 0 && index < dictionary.Count)
            {
                var result = 0;

                foreach (var item in dictionary)
                {
                    if (result == index)
                    {
                        return item;
                    }

                    result++;
                }

                return new KeyValuePair<TKey, TValue>(default(TKey), default(TValue));
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public static IList<T> To<T>(this List<object> list, bool suppressErrors = true)
        {
            var result = new List<T>();

            foreach (var item in list)
            {
                try
                {
                    var _item = (T)item;
                    result.Add(_item);
                }
                catch
                {
                    if (!suppressErrors)
                        throw;
                }
                
            }

            return result;
        }
        //public static IDictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        //{
        //    return source.ToDictionary<TSource, TKey, TElement>(keySelector, elementSelector, (IEqualityComparer<TKey>)null);
        //}
        public static IDictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, IDictionary<TKey, TElement> target, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            return source.ToDictionary<TSource, TKey, TElement>(target, keySelector, elementSelector, (IEqualityComparer<TKey>)null);
        }
        public static IDictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<IEqualityComparer<TKey>, IDictionary<TKey, TElement>> targetFactory, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
        {
            return source.ToDictionary<TSource, TKey, TElement>(targetFactory, keySelector, elementSelector, (IEqualityComparer<TKey>)null);
        }




        public static IDictionary<TKey, TSource> ToDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return source.ToDictionary<TSource, TKey, TSource>(keySelector, IdentityFunction<TSource>.Instance, (IEqualityComparer<TKey>)null);
        }
        public static IDictionary<TKey, TSource> ToDictionary<TSource, TKey>(this IEnumerable<TSource> source, IDictionary<TKey, TSource> target, Func<TSource, TKey> keySelector)
        {
            return source.ToDictionary<TSource, TKey, TSource>(target, keySelector, IdentityFunction<TSource>.Instance, (IEqualityComparer<TKey>)null);
        }
        public static IDictionary<TKey, TSource> ToDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<IEqualityComparer<TKey>, IDictionary<TKey, TSource>> targetFactory, Func<TSource, TKey> keySelector)
        {
            return source.ToDictionary<TSource, TKey, TSource>(targetFactory, keySelector, IdentityFunction<TSource>.Instance, (IEqualityComparer<TKey>)null);
        }



        public static IDictionary<TKey, TSource> ToDictionary<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey> comparer)
        {
            return source.ToDictionary<TSource, TKey, TSource>(keySelector, IdentityFunction<TSource>.Instance, comparer);
        }
        public static IDictionary<TKey, TSource> ToDictionary<TSource, TKey>(
            this IEnumerable<TSource> source,
            IDictionary<TKey, TSource> target,
            Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return source.ToDictionary<TSource, TKey, TSource>(target, keySelector, IdentityFunction<TSource>.Instance, comparer);
        }
        public static IDictionary<TKey, TSource> ToDictionary<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<IEqualityComparer<TKey>, IDictionary<TKey, TSource>> targetFactory,
            Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
        {
            return source.ToDictionary<TSource, TKey, TSource>(targetFactory, keySelector, IdentityFunction<TSource>.Instance, comparer);
        }


        public static IDictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            return ToDictionary(source, (c) => new Dictionary<TKey, TElement>(c), keySelector, elementSelector, comparer);
        }
        public static IDictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
            this IEnumerable<TSource> source, IDictionary<TKey, TElement> target,
            Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            if (target == null)
                throw new ArgumentNullException("target");

            return ToDictionary(source, (c) => target, keySelector, elementSelector, comparer);
        }
        public static IDictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source, IEqualityComparer<TKey> comparer = null)
        {
            return ToDictionary(source, (c) => new Dictionary<TKey, TValue>(c), item => item.Key, item => item.Value);
        }
        public static IDictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(
            this IEnumerable<TSource> source, 
            Func<IEqualityComparer<TKey>, IDictionary<TKey, TElement>> targetFactory,
            Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (keySelector == null)
                throw new ArgumentNullException("keySelector");
            if (elementSelector == null)
                throw new ArgumentNullException("elementSelector");
            if (targetFactory == null)
                throw new ArgumentNullException("targetFactory");

            var target = targetFactory(comparer);

            foreach (TSource item in source)
                target.Add(keySelector(item), elementSelector(item));

            return target;
        }

        //public static string Join(this IDictionary list, char ch)
        //{
        //    var sb = new StringBuilder();
        //    foreach (DictionaryEntry item in list)
        //    {
        //        sb.Append(((sb.Length == 0) ? "" : ch + " ") + string.Format("{0}={1}", item.Key, item.Value));
        //    }
        //    return sb.ToString();
        //}
        //public static string Join(this IDictionary list, string separator)
        //{
        //    var sb = new StringBuilder();
        //    foreach (DictionaryEntry item in list)
        //    {
        //        sb.Append(((sb.Length == 0) ? "" : separator + " ") + string.Format("{0}={1}", item.Key, item.Value));
        //    }
        //    return sb.ToString();
        //}
        public static T Get<T>(this IDictionary<string, object> dictionary, string key)
        {
            object value;

            return dictionary.TryGetValue(key, out value) ? (T)value : default(T);
        }
    }
}
