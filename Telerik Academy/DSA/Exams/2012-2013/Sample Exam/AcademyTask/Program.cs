//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AcademyTask
//{
//    public class Program
//    {
//        static void Main(string[] args)
//        {
//            // read input
//            var p = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
//            var target = int.Parse(Console.ReadLine());


//            Console.WriteLine(SolveWithDP(p, target));

//        }

//        private static int SolveWithDP(int[] p, int target)
//        {
//            var minCount = p.Length;
//            for(int i = 0; i < p.Length - 1; i++)
//            {
//                for(int j = i + 1; j < p.Length; j++)
//                {
//                    if(Math.Abs(p[i] - p[j]) >= target)
//                    {
//                        var count = 1;
//                        for(var start = 0; start < i; start += 2)
//                        {
//                            count++;
//                        }
//                        for (var start = i; start < j; start += 2)
//                        {
//                            count++;
//                        }

//                        // formula to find the number of problem without a cycle
//                        //count += (i + 1) / 2; // from 0 to i; 0 inclusive 
//                        //count += (j - i + 1) / 2 + 1; // from i to j;, inclusive i and j 
//                        minCount = Math.Min(count, minCount);

//                    }
//                }
//            }

//            return minCount;
//        }

//        // TO-DO: Solve with recursive method
//    }
//}


////var min = p[0];
////var max = p[0];
////var nextIsBigger = false;
////var totalProblems = 1;
////var broken = false;
////for (int i = 0; i<p.Length - 2; i++)
////{
////    //var current = p[i];

////    if (max - min >= target)
////    {
////        Console.WriteLine(totalProblems);
////        broken = true;
////        break;
////    }

////    if (p[i + 1] >= p[i + 2])
////    {
////        nextIsBigger = true;
////        totalProblems++;
////    }
////    else
////    {
////        totalProblems++;

////    }

////    if (nextIsBigger)
////    {
////        max = Math.Max(max, p[i + 1]);
////        min = Math.Min(min, p[i + 2]);
////        //i++;
////    }
////    else
////    {
////        max = Math.Max(max, p[i + 2]);
////        min = Math.Min(min, p[i + 1]);
////        i++;
////    }
////}
////if (!broken)
////{
////    Console.WriteLine(p.Length);
////}