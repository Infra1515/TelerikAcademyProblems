using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class ADT_SinglyLinkedList<T>
    {
        public ADT_SinglyLinkedList()
        {

        }
    }

    public class Node<T>
    {
        public T Previous { get; set; }
        public T Next { get; set; }
        public T Value { get; set; }

        public Node(T value)
        {
            this.Previous = default(T);
            this.Next = default(T);
            this.Value = value;
        }
    }
}
