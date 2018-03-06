//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Wintellect.PowerCollections;

//namespace FriendsInNeed
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            var firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
//            var totalVertices = firstLine[0]; // total points on map
//            var totalEdges = firstLine[1]; // total streets that connect each point
//            var totalHospitals = firstLine[2]; // total hospitals on the map
//            var hospitals = Console.ReadLine().Split().Select(int.Parse).ToArray();

//            var graph = ReadGraph(totalVertices, totalEdges);
//            var resultMin = int.MaxValue;

//            for (int i = 0; i < totalHospitals; i++)
//            {
//                var currentHospital = hospitals[i];
//                var startVertex = graph[currentHospital];
//                var result = FindSmallestDistanceDijkstra(graph, startVertex, hospitals);
//                if(result == 0)
//                {
//                    continue;
//                }
//                Console.WriteLine(result);

//                resultMin = Math.Min(result, resultMin);

//                for(int j = 1; j < graph.Count; j++)
//                  {
//                    graph[j].Visited = false;
//                    graph[j].Cost = 0;
//                    graph[j].Previous = null;
//                }
//            }

//            Console.WriteLine(resultMin);
//        }

//        static int FindSmallestDistanceDijkstra(IList<Vertex> graph, Vertex startVertex,
//            int[] hospitals)
//        {
//            OrderedBag<Vertex> q = new OrderedBag<Vertex>();
//            q.Add(startVertex);
//            var totalCost = 0;

//            while (q.Count > 0)
//            {
//                var current = q.RemoveFirst();
//                current.Visited = true;

//                foreach (var child in current.Children.Keys)
//                {
//                    if (!child.Visited && !hospitals.Contains(child.Name))
//                    {
//                        child.Previous = current;
//                        child.Cost = current.Cost + current.Children[child];
//                        totalCost += child.Cost;
//                        q.Add(child);

//                    }
//                }
//            }

//            return totalCost;
//        }

//        //static int FindSmallestDistanceDFS(IList<Vertex> graph, Vertex startVertex,
//        //    bool[] visited, int[] hospitals)
//        //{
//        //    var result = 1;
//        //    if(!visited[startVertex.Name])
//        //    {
//        //        visited[startVertex.Name] = true;
//        //        foreach (var child in startVertex.Children)
//        //        {
//        //            if (!hospitals.Contains(child.Key))
//        //            {
//        //                result += child.Value;
//        //                FindSmallestDistanceDFS(graph, graph[child.Key], visited, hospitals);
//        //            }
//        //        }
//        //    }
//        //    return result;
//        //}

//        static IList<Vertex> ReadGraph(int totalVertices, int totalEdges)
//        {
//            var graph = new List<Vertex>
//            {
//                new Vertex(-1) // placeholder for 1st slot
//            };
//            graph[0].Visited = true;

//            for (int i = 1; i <= totalVertices; i++)
//            {
//                graph.Add(new Vertex(i));
//            }

//            for (int i = 0; i < totalEdges; i++)
//            {
//                var pointToPointWithDistance = Console.ReadLine().Split().Select(int.Parse).ToArray();

//                var firstPoint = pointToPointWithDistance[0];
//                var secondPoint = pointToPointWithDistance[1];
//                var distance = pointToPointWithDistance[2];

//                graph[firstPoint].Children.Add(graph[secondPoint], distance);
//                graph[secondPoint].Children.Add(graph[firstPoint], distance); // bidirectional graph

//            }

//            return graph;
//        }

//    }
//    class Vertex : IComparable<Vertex>
//    {
//        public int Name { get; set; }
//        public int Cost { get; set; }
//        public Vertex Previous { get; set; }
//        public bool Visited { get; set; }
//        public Dictionary<Vertex, int> Children { get; set; }

//        public Vertex(int name)
//        {
//            this.Name = name;
//            this.Visited = false;
//            this.Previous = null;
//            this.Cost = 0;
//            this.Children = new Dictionary<Vertex, int>();
//        }

//        public override bool Equals(Object obj)
//        {
//            if (this == obj)
//            {
//                return true;
//            }

//            Vertex other = obj as Vertex;

//            if (other == null)
//            {
//                return false;
//            }

//            if (!this.Name.Equals(other.Name))
//            {
//                return false;
//            }
//            return true;
//        }

//        public override int GetHashCode()
//        {
//            return this.Name.GetHashCode();
//        }

//        public int CompareTo(Vertex other)
//        {
//            return this.Cost.CompareTo(other.Cost);
//        }

//    }
//}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace FriendsInNeed
{
    public class Program
    {
        private static IList<KeyValuePair<int, int>>[] graph;
        private static HashSet<int> hospitalIds;
        private static int minimalDistance = int.MaxValue;

        static void Main(string[] args)
        {

            var parameters = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            hospitalIds = new HashSet<int>(Console.ReadLine().Split(' ').Select(int.Parse));

            graph = Enumerable.Range(0, parameters[0] + 1)
                              .Select(i => new List<KeyValuePair<int, int>>())
                              .ToArray();

            graph[0] = null;

            for (int i = 1; i <= parameters[1]; i++)
            {
                var nodesInfo = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                graph[nodesInfo[0]].Add(new KeyValuePair<int, int>(nodesInfo[1], nodesInfo[2]));
                graph[nodesInfo[1]].Add(new KeyValuePair<int, int>(nodesInfo[0], nodesInfo[2]));
            }

            FindMinimalDistance();
            Console.WriteLine(minimalDistance);

        }

        private static void FindMinimalDistance()
        {
            foreach (var hospital in hospitalIds)
            {
                //var dijkstraDistances = FindMinimalDistanceDijkstra(hospital);
                var dijkstraDistances = MinimalDistance(hospital);
                var distance = dijkstraDistances.Where((a, b) => !hospitalIds.Contains(b)).Sum();
                minimalDistance = Math.Min(minimalDistance, distance);
            }
        }

        private static int[] MinimalDistance(int source)
        {
            var q = new Queue<KeyValuePair<int, int>>();
            var start = new KeyValuePair<int, int>(source, 0);
            var distances = Enumerable.Repeat(int.MaxValue, graph.Length).ToArray();
            distances[0] = 0;
            distances[source] = 0;
            q.Enqueue(start);

            while(q.Count > 0)
            {
                var currentVertex = q.Dequeue();

                foreach (var child in graph[currentVertex.Key])
                {
                    var currentDistance = distances[currentVertex.Key] + child.Value;
                    if(currentDistance < distances[child.Key])
                    {
                        distances[child.Key] = currentDistance;
                        q.Enqueue(new KeyValuePair<int, int>(child.Key, currentDistance));
                    }
                }
            }


            return distances;
        }
    }
}















//private static int[] FindMinimalDistanceDijkstra(int sourceId)
//{
//    var queue = new Queue<KeyValuePair<int, int>>();
//    queue.Enqueue(new KeyValuePair<int, int>(sourceId, 0));

//    var dijkstraDistances = Enumerable.Repeat(int.MaxValue, graph.Length).ToArray();
//    dijkstraDistances[0] = 0;
//    dijkstraDistances[sourceId] = 0;

//    while (queue.Count != 0)
//    {
//        var currentNode = queue.Dequeue();
//        foreach (var neighbour in graph[currentNode.Key])
//        {
//            int currentDistance = dijkstraDistances[currentNode.Key] + neighbour.Value;
//            if (currentDistance < dijkstraDistances[neighbour.Key])
//            {
//                dijkstraDistances[neighbour.Key] = currentDistance;
//                queue.Enqueue(new KeyValuePair<int, int>(neighbour.Key, currentDistance));
//            }
//        }
//    }

//    return dijkstraDistances;
//}



