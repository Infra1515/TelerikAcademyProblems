using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam
{
    public class DogLoverPaper
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var graph = ReadGraph(n, n, int.Parse);
            Console.WriteLine(TopologicalSort(graph));
        }

        private static IDictionary<T, Node<T>> ReadGraph<T>(int m, int n, Func<string, T> parse)
        {
            SortedDictionary<T, Node<T>> graph = new SortedDictionary<T, Node<T>>();

            for (int i = 0; i < m; i++)
            {
                var pair = Console.ReadLine().Split().ToList();
                var dependencie = pair[2];
                var firstNumber = parse(pair[0]);
                var secondNumber = parse(pair[3]);
                var parent = default(T);
                var child = default(T);

                if (dependencie == "after")
                {
                    parent = secondNumber;
                    child = firstNumber;
                }
                else
                {
                    parent = firstNumber;
                    child = secondNumber;
                }

                //T parent = parse(pair[0]);
                //T child = parse(pair[1]);

                if (!graph.ContainsKey(parent))
                {
                    graph[parent] = new Node<T>();
                }

                if (!graph.ContainsKey(child))
                {
                    graph[child] = new Node<T>();
                }

                if (graph[parent].Childs == null)
                {
                    graph[parent].Childs = new List<T>();
                }

                graph[parent].Childs.Add(child);
                graph[child].ParentCount++;
            }

            return graph;
        }

        private static void TopologicalSort(Dictionary<int, Node<int>> graph)
        {
            bool areAllVisited = false;
            while (!areAllVisited)
            {
                areAllVisited = true;
                for (int i = 0; i < graph.Keys.Count; i++)
                {
                    Node<int> node = graph[i];
                    if (node.ParentCount == 0 && !node.IsVisited)
                    {
                        Console.WriteLine(i);
                        node.IsVisited = true;
                        if (node.Childs != null)
                        {
                            foreach (int childKey in node.Childs)
                            {
                                graph[childKey].ParentCount--;
                            }
                        }

                        areAllVisited = false;
                        break;
                    }
                }
            }
        }
    }

    public class Node<T>
    {
        public int ParentCount { get; set; }

        public bool IsVisited { get; set; }

        public List<T> Childs { get; set; }
    }
}


//var n = int.Parse(Console.ReadLine());
//var childs = new List<int>[n];
//var parentsCount = new int[n];
//var visited = new bool[n];
//ReadGraph(childs, parentsCount, n);
//Console.WriteLine();