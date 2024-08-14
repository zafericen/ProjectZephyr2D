using System;
using System.Collections.Generic;

namespace ProjectZephyr
{
    
    public class PriorityList<T>: List<T> where T : IComparable<T>
    {
       public new void Add(T item)
       {
            base.Add(item);
            Sort();
       }
    }

}