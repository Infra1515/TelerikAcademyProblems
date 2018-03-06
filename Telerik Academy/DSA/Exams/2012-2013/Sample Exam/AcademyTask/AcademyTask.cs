using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyTask
{
    public class AcademyTask
    {
        static void Main()
        {
            var problems = Console.ReadLine().Split(',').Select(int.Parse).ToArray();
            var target = int.Parse(Console.ReadLine());
            var minCount = problems.Length;

            for (int i = 0; i < problems.Length; i++)
            {
                for (int j = i + 1; j < problems.Length; j++)
                {
                    if (Math.Abs(problems[i] - problems[j]) >= target)
                    {
                        var count = 1;

                        // from 0 to i
                        for (var start = 0; start < i; start += 2)
                        {
                            count++;
                        }
                        // from i to j
                        for (var start = i+1; start <= j; start += 2)
                        {
                            count++;
                        }
                        minCount = Math.Min(count, minCount);
                    }
                }
            }

            Console.WriteLine(minCount);
        }
    }
}
