using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class ReverseWithStack
    {
        public static void ReverseStack()
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                var currentNumber = int.Parse(Console.ReadLine());
                stack.Push(currentNumber);
            }

            while (stack.Count > 0)
            {
                var topElement = stack.Pop();
                Console.WriteLine(topElement);
            }
        }
    }
}
