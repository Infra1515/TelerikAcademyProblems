using System;
using System.Diagnostics;
using System.Linq;

namespace SortingAlgorithms
{
    public class SortCompare
    {
        public static long TimeFind(int capacity, Action<int[]> action, int repeat = 1, bool sorted = false, bool print = false)
        {
            var rand = new Random();
            var arr = Enumerable.Range(1, capacity).Select(x => rand.Next(0, 1000)).ToArray();


            var sw = new Stopwatch();

            var elapsed = 0L;

            for (int i = 0; i < repeat; i++)
            {

                if (sorted)
                {
                    arr = Enumerable.Range(1, capacity).ToArray();
                }
                else
                {
                    arr = Enumerable.Range(1, capacity).Select(x => rand.Next(0, 1000)).ToArray();
                }

                sw.Restart();

                action(arr);

                elapsed += sw.ElapsedMilliseconds;
            }

            if (print)
            {
                foreach (var item in arr)
                {
                    Console.WriteLine(item);
                }
            }

            return elapsed;
        }
    }
}
