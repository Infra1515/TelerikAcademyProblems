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
            var problemSize = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = problemSize[0];
            var m = problemSize[1];
            // if the values are not in a sequence 1,2,3 but are 10,50,70
            // then to hold the parents you must use Dictionary<T, int>()
            // the left side will be the vertex and the right side will be its parentCount
            //var parentCount = new int[n];
            // same for visited - Dictionary<T, bool>(); - constant time lookup;
            // but the best solution would be to use a Node<T> which has isVisited; value; parentsCount; etc;
            //var visited = new bool[n];
            //var visited = new Dictionary<int, bool>();
            //var graph = new Graph<int>();
            //ReadGraph(graph, n, visited);
            //Console.WriteLine(TopologicalSort(graph, visited, parentCount));
            //var result = new Stack<int>();
            //foreach (var pair in graph.AdjacencyList)
            //{
            //    var parent = pair.Key;
            //    if (!visited[parent])
            //    {
            //        DFSGraph(graph, visited, parent, result);
            //    }
            //    while (result.Count != 0)
            //    {
            //        Console.WriteLine(result.Pop());
            //    }
            //}
        }

        static void DFSGraph(Graph<int> graph, Dictionary<int, bool> visited, int vertex, Stack<int> result)
        {
            //visited[vertex] = true;
            //foreach (var child in  graph.AdjacencyList[vertex])
            //{
            //    if (!visited[child])
            //    {
            //        Console.Write(child + " ");
            //        DFSGraph(graph, visited, child);
            //    }
            //}
            if (!visited[vertex])
            {
                visited[vertex] = true;
                foreach (var child in graph.AdjacencyList[vertex])
                {
                    DFSGraph(graph, visited, child, result);
                }
                result.Push(vertex);
            }

        }

        static string TopologicalSort(Graph<int> graph, bool[] visited, int[] parentCount)
        {
            var resultBuilder = new StringBuilder();
            var isAllVisited = false;
            var graphDict = graph.AdjacencyList;
            while (!isAllVisited)
            {
                isAllVisited = true;
                foreach (var pair in graphDict)
                {
                    var parent = pair.Key;
                    var children = pair.Value;
                    if(parentCount[parent] == 0 && !visited[parent])
                    {
                        resultBuilder.AppendLine(parent.ToString());
                        visited[parent] = true;

                        if(children.Count != 0)
                        {
                            foreach (var child in children)
                            {
                                parentCount[child]--;
                            }
                        }
                        isAllVisited = false;
                        break;
                    }
                }
            }

            return resultBuilder.ToString();
        }

        static void ReadGraph(Graph<int> graph, int n, Dictionary<int , bool> visited)
        {
            //for (int i = 0; i < n; i++)
            //{
            //    graph.AddVertex(i);
            //}

            for (int j = 0; j < n; j++)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var parent = input[0];
                var child = input[1];

                graph.AddVertex(parent);
                graph.AddVertex(child);


                graph.AddEdge(new Tuple<int, int>(parent, child));
                //parentCount[child]++;

                if (!visited.ContainsKey(parent))
                {
                    visited.Add(parent, false);
                }

                if (!visited.ContainsKey(child))
                {
                    visited.Add(child, false);
                }
            }
        }

    }
}
