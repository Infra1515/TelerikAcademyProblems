using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAImplementations
{
    public class LinkedList<T>
    {
        public NodeLL<T> Head { get; set; }
        public NodeLL<T> Current { get; set; }
        public int Size { get; private set; }

        public LinkedList()
        {
            this.Head = default(NodeLL<T>);
            this.Size = 0;
        }

        public void AddFirst(T val)
        {
            var node = new NodeLL<T>(val);
            node.Next = this.Head;
            node.Prev = null;
            if (this.Head != null)
            {
                this.Head.Prev = node;
            }
            this.Head = node;
            Size++;
        }

        /// <summary>
        /// overloaded method taking a whole node
        /// </summary>
        /// <param name="node"></param>
        public void AddFirst(NodeLL<T> node)
        {
            node.Next = this.Head;
            node.Prev = null;
            if (this.Head != null)
            {
                this.Head.Prev = node;
            }
            this.Head = node;
            Size++;

        }

        public void AddLast(T val)
        {
            // AddLast in Constant time with Last variable
            // Is it possible?
            var node = new NodeLL<T>(val);

            if (this.Head == null)
            {
                node.Prev = null;
                Head = node;
            }
            else
            {
                
                var temp = this.Head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = node;
                node.Prev = temp;
                node.Next = null;
            }
            Size++;
        }

        public NodeLL<T> FindLast()
        {
            var current = this.Head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            return current;
        }

        public void AddBefore(NodeLL<T> node, T Val)
        {
            if (node == null)
            {
                Console.WriteLine("NodeLL cannot be null!");
            }
            else
            {
                var newNodeLL = new NodeLL<T>(Val);

                newNodeLL.Next = node;
                newNodeLL.Prev = node.Prev;
                node.Prev = newNodeLL;
                if (newNodeLL.Prev != null)
                {
                    newNodeLL.Prev.Next = newNodeLL;  
                }
            }
        }

        public void AddAfter(NodeLL<T> node, T val)
        {
            if (node == null)
            {
                Console.WriteLine("NodeLL cannot be null!");
            }
            else
            {
                var newNodeLL = new NodeLL<T>(val);

                newNodeLL.Next = node.Next;
                node.Next = newNodeLL;

                newNodeLL.Prev = node;
                if (newNodeLL.Next != null)
                {
                    newNodeLL.Next.Prev = newNodeLL; 
                }
            }
        }

        public void DeleteByValue(T value)
        {
            var temp = this.Head;
            var isFound = false;
            var nodeToRemove = new NodeLL<T>(default(T));
            while (temp != null)
            {
                if (temp.Value.Equals(value))
                {
                    nodeToRemove = temp;
                    isFound = true;
                    break;
                }

                temp = temp.Next;
            }

            if (isFound)
            {
                if (nodeToRemove.Prev == null)
                {
                    this.Head = nodeToRemove.Next;
                    this.Head.Prev = null;
                }
                else if (nodeToRemove.Next == null)
                {
                    nodeToRemove.Prev.Next = null;
                }
                else
                {
                    nodeToRemove.Prev.Next = nodeToRemove.Next;
                    nodeToRemove.Next.Prev = nodeToRemove.Prev;

                }
            }
            else
            {
                Console.WriteLine("No node with such value!");
            }
        }

        public void RemoveByNodeLL(NodeLL<T> node)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns a new instance with the list reversed;
        /// </summary>
        public LinkedList<T> ReverseList()
        {
            var current = new NodeLL<T>(this.Head);
            NodeLL<T> temp = null;
            var reversedList = new LinkedList<T>();
            while (true)
            {
                temp = new NodeLL<T>(current);
                reversedList.AddFirst(current);
                if (temp.Next == null)
                {
                    break;
                }
                // 
                current = new NodeLL<T>(temp.Next);
            }

            return reversedList;
        }

        /// <summary>
        /// Returns the list reversed in place
        /// </summary>
        public void Reverse()
        {
            // does not work - when start is called in AddFirst - its next value is reseted to null
            // and so it loses further reference
            //var start = this.Head;
            //var reversedList = new LinkedList<T>();
            //while (start != null)
            //{
            //    reversedList.AddFirst(start);
            //    start = start.Next;
            //}

            //return reversedList;
            if (this.Head == null)
            {
                Console.WriteLine("List is empty!");
            }
            else
            {
                var current = this.Head;
                NodeLL<T> temp = null;
                while (current != null)
                {
                    temp = current.Next;
                    current.Next = current.Prev;
                    current.Prev = current;
                    // if this is outside of loop => current.prev is null
                    this.Head = current.Prev;
                    current = temp;
                }
            }
        }

        public override string ToString()
        {

            if (this.Head == null)
            {
                return string.Empty;
            }
            else
            {
                var sb = new StringBuilder();
                var temp = this.Head;
                while (temp != null)
                {
                    sb.AppendLine($"{temp.Value.ToString()} ");
                    temp = temp.Next;
                }

                return sb.ToString();
            }
        }

        // HackerRank Print();
        public static void Print(NodeLL<T> head)
        {
            if (head == null)
            {
                return;
            }
            else
            {
                var temp = head;
                while (temp != null)
                {
                    Console.WriteLine(temp.Value);
                    temp = temp.Next;
                }
            }
        }

        // Insert at the end - HackerRank
        public static NodeLL<T> Insert(NodeLL<T> head, T x)
        {
            if (head == null)
            {
                Console.WriteLine("List is empty! Add something first!");
                return default(NodeLL<T>);
            }

            var newNodeLL = new NodeLL<T>(x);
            var current = head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = newNodeLL;
            newNodeLL.Prev = current;
            newNodeLL.Next = null;

            return head;
        }

    }

    public class NodeLL<T>
    {
        public NodeLL<T> Prev { get; set; }
        public NodeLL<T> Next { get; set;  }
        public T Value { get; set; }

        public NodeLL(T value)
        {
            this.Value = value;
        }

        // copy constructor
        public NodeLL(NodeLL<T> node)
        {
            this.Next = node.Next;
            this.Prev = node.Prev;
            this.Value = node.Value;
        }
    }
}
