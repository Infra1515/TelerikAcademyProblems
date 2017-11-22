using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace TelerikAcademyFundamentals
{
    class TelerikAcademyC_Sharp_Fund_2012_2013
    {
        static void Main()
        {
            string input = Console.ReadLine(); ;
            var list = input.Split(' ').Select(Int64.Parse).ToList();
            BigInteger sum = 0;
            int index = 1;
            Console.WriteLine("changes");
            while (index < list.Count())
            {
                long current = list[index];
                long previous = list[index - 1];
                long diff = Math.Abs(current - previous);
                if (diff % 2 == 0)
                {
                    index += 2;
                    sum += diff;
                }
                else
                {
                    index += 1;
                }
            }
            Console.WriteLine(sum);
        }
    }
}
