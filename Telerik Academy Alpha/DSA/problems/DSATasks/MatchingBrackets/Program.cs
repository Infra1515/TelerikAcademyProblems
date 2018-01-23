using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            var ll = new LinkedList<int>();
            //var expression = "1 + (2 - (2+3) * 4 / (3+1)) * 5";
            var expression = Console.ReadLine();
            var stack = new Stack<int>();
            var resultString = string.Empty;
            var resultStringList = new List<string>();

            for (var i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '{')
                {
                    stack.Push(i);
                }
                else if (expression[i] == '}')
                {
                    var startIndex = stack.Pop();
                    var endIndex = i;
                    resultString = expression.Substring(startIndex, endIndex - startIndex+1);
                    resultStringList.Add(resultString);

                }
            }

            foreach (var subexpr in resultStringList)
            {
                Console.WriteLine(subexpr);
            }
        }
    }
}

