//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace _CokiSkoki
//{
//    class CokiSkokiSolution
//    {
//        static int[] ReadBuildings()
//        {
//            Console.ReadLine();
//            return Console.ReadLine()
//                          .Split(' ')
//                          .Select(int.Parse)
//                          .ToArray();
//        }

//        public static void Main()
//        {
//            var buildings = ReadBuildings();
//            var d = new int[buildings.Length];

//            var s = new Stack<int>();

//            for (var i = buildings.Length - 1; i >= 0; i--)
//            {
//                var current = buildings[i];

//                while (s.Count > 0 && current >= buildings[s.Peek()])
//                {
//                    s.Pop();
//                }

//                if (s.Count > 0)
//                {
//                    d[i] = d[s.Peek()] + 1;
//                }
//                s.Push(i);
//            }

//            Console.WriteLine(d.Max());
//            Console.WriteLine(string.Join(" ", d));
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;

namespace _CokiSkoki
{
    class CokiSkokiSolution
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var path = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var longestJumps = 0;
            var jumps = 0;
            var jumpsPerBuilding = new int[n];

            for (int i = 0; i < n; i++)
            {
                var currentBuilding = path[i];
                for(int j = i + 1; j < n; j++)
                {
                    var nextBuilding = path[j];
                    if(currentBuilding < nextBuilding)
                    {
                        jumps++;
                        currentBuilding = nextBuilding;
                    }
                }
                if(jumps > longestJumps)
                {
                    longestJumps = jumps;
                }
                jumpsPerBuilding[i] = jumps;
                jumps = 0;
            }

            Console.WriteLine(longestJumps);
            Console.WriteLine(string.Join(" ", jumpsPerBuilding));
        }
    }
}



