using System;
using System.Collections.Concurrent;

namespace server.Util
{
    public class MultiKeyConcurrentDictionary<TKey1, TKey2, TValue> : ConcurrentDictionary<Tuple<TKey1, TKey2>, TValue>
    {
        public bool ContainsKey(TKey1 key1, TKey2 key2)
        {
            return base.ContainsKey(Tuple.Create(key1, key2));
        }

        public bool TryAdd(TKey1 key1, TKey2 key2, TValue value)
        {
            return base.TryAdd(Tuple.Create(key1, key2), value);
        }

        public bool TryRemove(TKey1 key1, TKey2 key2, out TValue value)
        {
            return base.TryRemove(Tuple.Create(key1, key2), out value);
        }

        public bool TryGetValue(TKey1 key1, TKey2 key2, out TValue value)
        {
            return base.TryGetValue(Tuple.Create(key1, key2), out value);
        }
    }
}
