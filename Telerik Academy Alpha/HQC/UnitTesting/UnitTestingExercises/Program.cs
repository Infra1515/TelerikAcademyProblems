using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingExercises
{
    class Program
    {
        static void Main(string[] args)
        {

            var list = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                list.Add(i);
            }

            var l = Calculator.RecursionSum(list);
            Console.WriteLine(l);
        }
    }
}
