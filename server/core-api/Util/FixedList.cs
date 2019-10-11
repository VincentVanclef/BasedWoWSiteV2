using System.Collections;
using System.Collections.Generic;

namespace server.Util
{
    public class FixedList<T> : IList<T>
    {
        private readonly int _limit = 200;

        public IList<T> Items { get; set; } = new List<T>();

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            Items.Add(item);
            while (Items.Count > _limit)
            {
                Items.RemoveAt(0);
            }
        }

        public void Clear()
        {
            Items.Clear();
        }

        public bool Contains(T item)
        {
            return Items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Items.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return Items.Remove(item);
        }

        public int Count => Items.Count;

        public bool IsReadOnly { get; set; }

        public int IndexOf(T item)
        {
            return Items.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            Items.Insert(index, item);
            while (Items.Count > _limit)
            {
                Items.RemoveAt(0);
            }
        }

        public void RemoveAt(int index)
        {
            Items.RemoveAt(index);
        }

        public T this[int index]
        {
            get => Items[index];
            set => Items[index] = value;
        }
    }
}
