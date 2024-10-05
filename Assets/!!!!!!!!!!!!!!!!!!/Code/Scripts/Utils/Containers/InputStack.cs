using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;


namespace ProjectZephyr
{
    public class InputStack<T> : IEnumerable<T> where T : IEquatable<T>
    {
        List<T> stack;

        public InputStack()
        {
            stack = new List<T>();

        }

        public int Count { get { return stack.Count; } }
        public IEnumerator<T> GetEnumerator()
        {
            return stack.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();

        }

        public bool Exists(Predicate<T> match)
        {
            return stack.Exists(match);
        }

        public void Add(T item)
        {
            stack.Add(item);
        }

        public void AddToStack(T item)
        {
            if (!stack.Exists(x => x.Equals(item)))
            {
                stack.Add(item);
                return;
            }

            for (int i = stack.Count - 1; i > 0; i--)
            {
                if (stack[i].Equals(item))
                {
                    stack[i] = item;
                }
            }
        }

        public T Get(int index)
        {
            return stack[index];
        }

        public void RemoveAt(int index)
        {
            stack.RemoveAt(index);
        }

        public T RemoveFromStack(Predicate<T> predicate)
        {
            var returnItem = Get(0);
            for (int i = stack.Count - 1; i > 0; i--)
            {
                if (predicate(Get(i)))
                {
                    RemoveAt(i);
                }
                else if (returnItem.Equals(stack[0]))
                {
                    returnItem = Get(i);
                }
            }

            return returnItem;
        }
    }
}