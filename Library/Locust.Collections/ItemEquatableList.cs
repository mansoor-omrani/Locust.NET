using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Collections
{
    public class ItemEquatableList<T>: IList<T>
    {
        private List<T> list;
        public IEqualityComparer<T> Equatable { get; set; }
        public ItemEquatableList()
        {
            Equatable = EqualityComparer<T>.Default;
            list = new List<T>();
        }
        public ItemEquatableList(int capacity)
        {
            Equatable = EqualityComparer<T>.Default;
            list = new List<T>(capacity);
        }
        public ItemEquatableList(IEqualityComparer<T> equatable)
        {
            Equatable = equatable;
            list = new List<T>();
        }
        public ItemEquatableList(IEqualityComparer<T> equatable, int capacity)
        {
            Equatable = equatable;
            list = new List<T>(capacity);
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
        public int Count
        {
            get
            {
                return list.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            var index = IndexOf(item);

            if (index == -1)
            {
                list.Add(item);
            }
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(T item)
        {
            return list.Contains(item, Equatable);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            var index = 0;

            foreach (var x in list)
            {
                if (Equatable.Equals(item, x))
                {
                    return index;
                }

                index++;
            }

            return -1;
        }
        public int IndexOf(T item, int offset)
        {
            for (var index = 0; index < list.Count; index++)
            {
                if (index < offset)
                    continue;

                if (Equatable.Equals(item, list[index]))
                {
                    return index;
                }
            }

            return -1;
        }
        public int LastIndexOf(T item)
        {
            for (var index = list.Count - 1; index >= 0 ; index--)
            {
                if (Equatable.Equals(item, list[index]))
                {
                    return index;
                }
            }

            return -1;
        }
        public int LastIndexOf(T item, int offset)
        {
            for (var index = list.Count - 1; index >= 0; index--)
            {
                if (index > offset)
                    continue;

                if (Equatable.Equals(item, list[index]))
                {
                    return index;
                }
            }

            return -1;
        }
        public void Insert(int index, T item)
        {
            var i = IndexOf(item);

            if (i == -1)
            {
                list.Insert(index, item);
            }
        }

        public bool Remove(T item)
        {
            var index = IndexOf(item);

            if (index >= 0)
            {
                list.RemoveAt(index);

                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
