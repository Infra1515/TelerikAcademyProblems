using DSAImplementations;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Swappings
{
    public class Program
    {
        static void Main(string[] args)
        {
            var l = new System.Collections.Generic.LinkedList<int>();
            
            var n = int.Parse(Console.ReadLine());
            var numbers = new DSAImplementations.LinkedList<int>();
            numbers.AddFirst(1);
            for (int i = 2; i <= n; i++)
            {
                numbers.AddLast(i);
            }

            var swap = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            // find the separator node and while there put all the elements before it in an array
            for (var i = 0; i < swap.Count; i++)
            {
                // find separator node
                var separatorNode = new Node<int>(default(int));
                var separator = swap[i];
                var current = numbers.Head;
                while (current.Value != separator)
                {
                    current = current.Next;
                }
                separatorNode = current;

                if (separatorNode.Next == null)
                {
                    numbers.AddFirst(separatorNode);
                }
                else if (separatorNode.Prev == null)
                {
                    numbers.AddLast(separatorNode.Value);
                }
                else
                {
                    // set the head to the first number after the separator
                    // it points to all the numbers
                    numbers.Head = separatorNode.Next;
                    var last = numbers.FindLast();
                    var temp = separatorNode.Prev;
                    last.Next = separatorNode;
                    separatorNode.Prev = last;
                    last = temp;
                    while (temp != null)
                    {
                        separatorNode.Next = temp;
                        temp = temp.Prev;
                    }

                    last.Next = null;

                }
            
                Console.WriteLine(numbers.ToString());

            }
        }

    }
}






//while (current.Value!= separator)
//{
//    nodesBeforeSeparator.Add(current);
//    current = current.Next;
//}

//nodesBeforeSeparator.Add(null);

//separatorNode = current;

//while (current.Next != null)
//{
//    separatorNode.Prev = current.Next;
//    current = current.Next;
//}


//for (var j = 0; j < nodesBeforeSeparator.Count; j++)
//{
//    separatorNode.Next = nodesBeforeSeparator[j];
//}



//var separatorFound = false;
//for (var i = 0; i < inputArraySwap.Count; i++)
//{
//    var separator = inputArraySwap[i];
//    for (int j = 0; j < n; j++)
//    {
//        if (numbersArray[j] == separator)
//        {
//            separatorFound = true;
//        }

//        if (separatorFound)
//        {
//            rightSide.Add(numbersArray[j]);
//        }
//        else
//        {
//            leftSide.Add(numbersArray[j]);
//        }
//    }

//    rightSide.AddRange(leftSide);
//    numbersArray =  new List<int>(rightSide);
//    foreach (var num in numbersArray)
//    {
//        Console.Write(num + " ");
//    }

//    Console.WriteLine();
//    rightSide.Clear();
//    leftSide.Clear();
//}


//Console.WriteLine();