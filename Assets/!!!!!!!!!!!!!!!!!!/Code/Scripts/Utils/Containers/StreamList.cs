using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace ProjectZephyr
{
    public class StreamList<T> : IEnumerable<T>, ICollection<T>
    {
        List<T> stream;

        /// <summary>
        /// capacity is the max number of elements the stream can hold. If (for any reason) Count exceeds the capacity,
        /// addition of any element deletes the old excess of elements
        /// </summary>
        readonly int capacity;

        public int Count { get { return stream.Count; } }

        public bool IsReadOnly { get { return false; } }

        public StreamList(int capacity)
        {
            stream = new List<T>(capacity);
            this.capacity = capacity;
        }

        /// <summary>
        /// default constructer. Sets capacity to 20.
        /// </summary>
        public StreamList()
        {
            stream = new List<T>();
            capacity = 20;
        }

        public void Add(T item)
        {
            if (stream.Count >= capacity)
            {
                stream.RemoveRange(0, 1 + Count - capacity);
            }
            stream.Add(item);
        }

        public T Get(int index)
        {
            return stream[index];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return stream.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            stream.Clear();
        }

        public bool Contains(T item)
        {
            return stream.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            stream.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return stream.Remove(item);
        }

        public bool CheckSubStreamExists(ICollection<T> subStream)
        {
            if(subStream.Count > capacity || subStream.Count > Count)
            {
                return false;
            }

            
            int i = 0;

            foreach (var item in subStream)
            {
                if(!stream[Count - subStream.Count + i++].Equals(item))
                {
                    return false;
                }
            }

            return true;
        }
    }
}