using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectZephyr
{
    public class CurcilarLinkedList<T> : LinkedList<T>
    {
        public CurcilarLinkedList(IEnumerable<T> collection) : base(collection)
        {
        }
        public IEnumerable<LinkedListNode<T>> Nodes()
        {
            for (var node = First; node != null; node = node.Next)
            {
                yield return node;
            }
        }

        public LinkedListNode<T> GetNext(LinkedListNode<T> curr)
        {
            if (curr == null)
            {
                return First;
            }
            curr = curr.Next ?? First;
            return curr;
        }

    }
}
