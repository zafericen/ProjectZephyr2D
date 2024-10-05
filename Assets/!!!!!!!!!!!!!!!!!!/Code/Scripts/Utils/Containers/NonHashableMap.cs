using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProjectZephyr
{
    public class NonHashableMap<TKey, TValue> : ICollection<KeyValuePair<TKey, TValue>> where TKey : IEquatable<TKey>
    {
        List<KeyValuePair<TKey, TValue>> items;

        public NonHashableMap() { items = new List<KeyValuePair<TKey, TValue>>(); }

        public int Count { get { return items.Count; } }

        public bool IsReadOnly { get; }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            items.Add(item);
        }

        public void Add(TKey key, TValue value)
        {
            var pair = new KeyValuePair<TKey, TValue>(key, value);
            items.Add(pair);
        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return items.Exists(x => x.Key.Equals(item.Key));
        }

        public TValue GetValue(TKey key)
        {
            var returnValue = items.Find(x => x.Key.Equals(key)).Value;
            return returnValue;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return items.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
