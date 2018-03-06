using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskWinsRiskLoses
{
    public class RiskWinsRiskLoses
    {
        static void Main()
        {
            var start = Console.ReadLine();
            var target = Console.ReadLine();
            var forbiddenCount = int.Parse(Console.ReadLine());
            var forbidden = new HashSet<string>();

            for(int i = 0; i < forbiddenCount; i++)
            {
                forbidden.Add(Console.ReadLine());
            }

            var result = SolveDP(start, target, forbidden);
            Console.WriteLine(result);

        }

        private static int SolveDP(string start, string target, HashSet<string> forbidden)
        {
            var startNode = new Tuple<string, int>(start, 0);
            var q = new Queue<Tuple<string, int>>();
            q.Enqueue(startNode);

            while(q.Count > 0)
            {
                var current = q.Dequeue();

                if(current.Item1 == target)
                {
                    return current.Item2;
                }

                var sb = new StringBuilder(current.Item1);

                // move upwards ^
                for(int i = 0; i < current.Item1.Length; i++)
                {
                    var digit = char.GetNumericValue(current.Item1[i]);
                    digit++;
                    if(digit == 10)
                    {
                        digit = 0;
                    }

                    sb[i] = (char)(digit + '0');

                    if (!forbidden.Contains(sb.ToString()))
                    {
                        forbidden.Add(sb.ToString());
                        q.Enqueue(new Tuple<string, int>(sb.ToString(), current.Item2 + 1));
                    }

                    sb[i] = current.Item1[i];
                }

                // move downwards V
                for(int i = 0; i < current.Item1.Length; i++)
                {
                    var digit = char.GetNumericValue(current.Item1[i]);
                    digit--;

                    if(digit < 0)
                    {
                        digit = 9;
                    }

                    sb[i] = (char)(digit + '0');
                    // char.Parse is much slower
                    //sb[i] = char.Parse(digit.ToString());

                    if (!forbidden.Contains(sb.ToString()))
                    {
                        forbidden.Add(sb.ToString());
                        q.Enqueue(new Tuple<string, int>(sb.ToString(), current.Item2 + 1));
                    }

                    sb[i] = current.Item1[i];
                }
            }

            return -1;
        }

        private static int SimpleSolution(string start, string target)
        {
            var count = 0;
            for(int i = 0; i < start.Length; i++)
            {
                var startNumber = (int)char.GetNumericValue(start[i]);
                var targetNumber = (int)char.GetNumericValue(target[i]);

                count += Math.Min(Math.Abs(startNumber - targetNumber),
                    10 - Math.Abs(startNumber - targetNumber));
            }

            return count;
        }
    }
}
