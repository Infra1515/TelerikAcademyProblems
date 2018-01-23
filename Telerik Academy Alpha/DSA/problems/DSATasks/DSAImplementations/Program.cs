using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DSAImplementations
{
    public class Program
    {
        static void Main(string[] args)
        {
            var microLinked = new System.Collections.Generic.LinkedList<int>();
            var myLL = new LinkedList<int>();
            var myEmptyList = new LinkedList<int>();
            var myNode = new Node<int>(5);
            var myNode2 = new Node<int>(10);
            var myNode3 = new Node<int>(150);
            myLL.AddFirst(myNode);
            myLL.AddFirst(myNode2);
            myLL.AddFirst(myNode3);
            myLL.AddBefore(myNode, 25);
            myLL.AddAfter(myNode, 30);
            var node = myLL.FindLast();
            Console.WriteLine(node.Value);
            
        }
    }
}
