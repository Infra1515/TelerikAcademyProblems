using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public static class RemoveAllNegativeNumbersFromSequence
    {
        public static IList<int> RemoveAlllNegative()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var result = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] > 0)
                {
                    result.Add(input[i]);
                }
            }
            return result;
        }
    }
}
