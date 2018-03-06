using System;
using System.Collections.Generic;
using System.Linq;
using DSAImplementations;

namespace VillanConGFG
{
    class Program
    {
        static void Main(string[] args)
        {
            var tests = int.Parse(Console.ReadLine());
            var size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = size[0];
            var m = size[1];
            var visited = new Dictionary<int, bool>();
            var graph = ReadGraph(n, m, visited);

            var result = new Stack<int>();
            foreach (var pair in graph.AdjacencyList)
            {
                var startVertex = pair.Key;
                if(!visited[startVertex])
                {
                    FindLongestChainDFS(graph, visited, startVertex, result);
                }
                Console.WriteLine("sep");
                while (result.Count != 0)
                {
                    Console.WriteLine(result.Pop());
                }
                result.Clear();
            }
        }

        static void FindLongestChainDFS(Graph<int> graph, Dictionary<int,bool> visited, int vertex, 
            Stack<int> result)
        {
            if (!visited[vertex])
            {
                visited[vertex] = true;
                foreach (var child in graph.AdjacencyList[vertex])
                {
                    FindLongestChainDFS(graph, visited, child, result);
                }
                result.Push(vertex);
            }

        }
        static Graph<int> ReadGraph(int totalMinions, int totalRelations, Dictionary<int, bool> visited)
        {
            var graph = new Graph<int>();

            // fill the graph with minions
            for(int i = 1; i <= totalMinions; i++)
            {
                graph.AddVertex(i);
            }

            // connect the minions in the graph
            for(int i = 1; i <= totalRelations; i++)
            {
                var relation = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var parent = relation[0];
                var child = relation[1];
                graph.AddEdge(new Tuple<int, int>(parent, child));
                graph.AdjacencyList[parent].Add(child);

                if (!visited.ContainsKey(parent))
                {
                    visited.Add(parent, false);
                }

                if (!visited.ContainsKey(child))
                {
                    visited.Add(child, false);
                }
            }

            return graph;
        }
    }
}
