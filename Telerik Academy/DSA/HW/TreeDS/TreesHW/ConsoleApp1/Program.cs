using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new TreeAsDAG<int>();

            for (int i = 0; i < 6; i++)
            {
                var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var parent = input[0];
                var child = input[1];
                tree.AddChild(parent, child);
            }

            var startingPt = tree.Tree.First().Key;
            var root = tree.FindRoot(startingPt);

            Console.WriteLine();
        }
    }
}
