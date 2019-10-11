using System.Collections.Generic;

namespace server.Util
{
    public class FixedQueue<T>
    {
        public FixedQueue()
        {
        }

        public FixedQueue(int limit)
        {
            Limit = limit;
        }

        public Queue<T> Items { get; set; } = new Queue<T>();

        public int Limit { get; set; }

        public void Enqueue(T item)
        {
            Items.Enqueue(item);
            while (Items.Count > Limit)
            {
                Items.Dequeue();
            }
        }
    }
}
