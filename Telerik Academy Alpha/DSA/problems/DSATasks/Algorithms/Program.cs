using DSAImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            // Testings GraphEdgeList + BFS
            //var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //var edges = new[]{Tuple.Create(1,2), Tuple.Create(1,3),
            //    Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
            //    Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
            //    Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10)};

            ////var q = new Queue<int>();
            //var graph = new Graph<int>(vertices, edges);
            //Console.WriteLine(graph.HasEdge(2,1));
            //var path = new List<int>();

            //Console.WriteLine(string.Join(", ", GraphBFS.BreadthFirstSearch(graph, 1, v => path.Add(v))));
            //foreach (var item in path)
            //{
            //    Console.WriteLine(item);
            //}

            //var startVertex = 1;
            //var shortestPath = GraphBFS
            //    .ShortestPathFunction(graph, startVertex);
            //foreach (var vertex in vertices)
            //    Console.WriteLine("shortest path to {0,2}: {1}",
            //            vertex, string.Join(", ", shortestPath(vertex)));

            // Testing GraphSuccesorList

            //var graph = new GraphSuccesorList(new List<int>[]
            //{
            //    new List<int>() {3}, // vertex 0 
            //    new List<int>() {4,3}, // 1
            //    new List<int>() {1}, // 2
            //    new List<int>() {}, // 3
            //    new List<int>() {3}, // 4
            //    //new List<int>() {}, // 5
            //    //new List<int>() {}, // 6
            //    //new List<int>() {}, // 7
            //});


            //var visited = new HashSet<int>();
            //var result = new HashSet<int>();
            //for(int v = 0; v < graph.Size(); v++)
            //{
            //    if (!visited.Contains(v))
            //    {
            //        result.Add(TopologicalSortGraphe(graph, visited, v));
            //    }
            //}
            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}
            //var sortedList = TopologicalSortGraphDFS.TopoSort(graph);
            //foreach (var item in sortedList)
            //{
            //    Console.WriteLine(item);
            //}
            List<Vertex> graph = new List<Vertex>();
            graph.Add(new Vertex("A")); //0            
            graph.Add(new Vertex("B")); //1
            graph.Add(new Vertex("C")); //2
            graph.Add(new Vertex("D")); //3
            graph.Add(new Vertex("E")); //4
            graph.Add(new Vertex("F")); //5
            graph.Add(new Vertex("G")); //6
            graph.Add(new Vertex("H")); //7
            graph.Add(new Vertex("I")); //8
            graph.Add(new Vertex("J")); //9

            graph[0].Children.Add(graph[1], 23);
            graph[0].Children.Add(graph[7], 8);

            graph[1].Children.Add(graph[0], 23);
            graph[1].Children.Add(graph[3], 3);
            graph[1].Children.Add(graph[6], 34);

            graph[2].Children.Add(graph[7], 25);
            graph[2].Children.Add(graph[3], 6);
            graph[2].Children.Add(graph[9], 7);

            graph[3].Children.Add(graph[1], 3);
            graph[3].Children.Add(graph[2], 6);

            graph[4].Children.Add(graph[5], 10);

            graph[5].Children.Add(graph[4], 10);

            graph[6].Children.Add(graph[1], 34);

            graph[7].Children.Add(graph[0], 8);
            graph[7].Children.Add(graph[9], 30);
            graph[7].Children.Add(graph[2], 25);

            graph[9].Children.Add(graph[7], 30);
            graph[9].Children.Add(graph[2], 7);

            Vertex start = graph[0]; //"A"

            Djeikstra.ExecuteDijkstra(start);
            Djeikstra.PrintPaths(graph, start);

        }
    }
}




