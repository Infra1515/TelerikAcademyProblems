using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Algorithms
{
    class Djeikstra
    {
        public static void ExecuteDijkstra(Vertex start)
        {
            OrderedBag<Vertex> pQueue = new OrderedBag<Vertex>();
            start.Cost = 0;
            pQueue.Add(start);

            while (pQueue.Count > 0)
            {
                Vertex current = pQueue.RemoveFirst();
                current.Visited = true;
                foreach (Vertex child in current.Children.Keys)
                {
                    if (!child.Visited)
                    {
                        if (child.Cost > current.Cost + current.Children[child])
                        {
                            child.Previous = current;
                            child.Cost = current.Cost + current.Children[child];
                            pQueue.Add(child);
                        }
                    }
                }
            }
        }

        public static void PrintPaths(List<Vertex> graph, Vertex start)
        {
            foreach (Vertex vertex in graph)
            {
                if (vertex.Name != start.Name)
                {
                    if (vertex.Cost == int.MaxValue)
                    {
                        Console.WriteLine("No path between "
                            + start.Name + " and " + vertex.Name + ".");
                    }
                    else
                    {
                        Console.Write("The path between "
                            + start.Name + " and " + vertex.Name + " is: ");
                        PrintPath(vertex);
                        Console.WriteLine("and has a length of " +
                            vertex.Cost + ".");
                    }
                }
            }
        }

        static void PrintPath(Vertex v)
        {
            if (v.Previous != null)
            {
                PrintPath(v.Previous);
            }
            Console.Write(v.Name + " ");
        }

        public static void Dijkstra(Vertex start)
        {
            var q = new OrderedBag<Vertex>(); // use priority q
            start.Cost = 0;
            q.Add(start);

            while(q.Count > 0)
            {
                var current = q.RemoveFirst();
                current.Visited = true;

                foreach (var child in current.Children.Keys)
                {
                    if (!child.Visited)
                    {
                        if(child.Cost > current.Cost + current.Children[child])
                        {
                            child.Cost = current.Cost + current.Children[child];
                            child.Previous = current;
                            q.Add(child);
                        }
                    }
                }
            }
        }
    }
    class Vertex : IComparable<Vertex>
    {
        public string Name { get; set; }
        public Vertex Previous { get; set; }
        public uint Cost { get; set; }
        public bool Visited { get; set; }
        public Dictionary<Vertex, uint> Children { get; set; }

        public Vertex(string name)
        {
            this.Name = name;
            this.Previous = null;
            this.Cost = int.MaxValue;
            this.Visited = false;
            this.Children = new Dictionary<Vertex, uint>();
        }

        public override bool Equals(Object obj)
        {
            if (this == obj)
            {
                return true;
            }

            Vertex other = obj as Vertex;

            if (other == null)
            {
                return false;
            }

            if (!this.Name.Equals(other.Name))
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }

        public int CompareTo(Vertex other)
        {
            return this.Cost.CompareTo(other.Cost);
        }
    }
}


//List<Vertex> graph = new List<Vertex>();
//graph.Add(new Vertex("A")); //0            
//    graph.Add(new Vertex("B")); //1
//    graph.Add(new Vertex("C")); //2
//    graph.Add(new Vertex("D")); //3
//    graph.Add(new Vertex("E")); //4
//    graph.Add(new Vertex("F")); //5
//    graph.Add(new Vertex("G")); //6
//    graph.Add(new Vertex("H")); //7
//    graph.Add(new Vertex("I")); //8
//    graph.Add(new Vertex("J")); //9
 
//    graph[0].Children.Add(graph[1], 23);
//    graph[0].Children.Add(graph[7], 8);
 
//    graph[1].Children.Add(graph[0], 23);
//    graph[1].Children.Add(graph[3], 3);
//    graph[1].Children.Add(graph[6], 34);
 
//    graph[2].Children.Add(graph[7], 25);
//    graph[2].Children.Add(graph[3], 6);
//    graph[2].Children.Add(graph[9], 7);
 
//    graph[3].Children.Add(graph[1], 3);
//    graph[3].Children.Add(graph[2], 6);
 
//    graph[4].Children.Add(graph[5], 10);
 
//    graph[5].Children.Add(graph[4], 10);
 
//    graph[6].Children.Add(graph[1], 34);
 
//    graph[7].Children.Add(graph[0], 8);
//    graph[7].Children.Add(graph[9], 30);
//    graph[7].Children.Add(graph[2], 25);
 
//    graph[9].Children.Add(graph[7], 30);
//    graph[9].Children.Add(graph[2], 7);
 
//    Vertex start = graph[0]; //"A"

//ExecuteDijkstra(start);
//PrintPaths(graph, start);