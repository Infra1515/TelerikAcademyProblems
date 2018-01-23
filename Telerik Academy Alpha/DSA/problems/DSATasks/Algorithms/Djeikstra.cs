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
