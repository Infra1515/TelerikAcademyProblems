using ExtMethodsAndOtherHomeWork.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtMethodsAndOtherHomeWork
{
    class Program
    {
        // declartion of a delegate
        //public delegate void SimpleDelagate(string param);
        //public delegate T NewDelagate<T>(T t1, T t2);
        static void Main(string[] args)
        {

            // define an anonymoys type variable
            var anonType = new { X = 5, Y = 3 };
            // array of anon types
            var arr = new[]
            {
                    new {X = 1, Y = 5},
                    new {X = 5, Y = 1},
                    new {X = 10, Y = 20}
            };
            SimpleDelagate exampleDelagate = new SimpleDelagate(TestMethod);
            exampleDelagate("HELLO WORLD!");
        }
        public static void TestMethod(string s)
        {
            Console.WriteLine($"Delagate called me with params {s}");
        }
    }
}
