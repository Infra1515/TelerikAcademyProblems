using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            var numList = new List<int>() {1, 3, 5, 7, 4};
            Console.WriteLine(Calculations.CalculteFibonacciRecursively(10));
            
        }
    }
}
