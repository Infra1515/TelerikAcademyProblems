using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DSATasks
{
    public class Program
    {
        static void Main(string[] args)
        {
            var node1 = new LinkedListNode<int>(1);
            var myNode = new Node(1);
        }
    }

    public class Node
    {
        public int val;
        public Node next;

        public Node(int x)
        {
            val = x;
        }
    }
}
