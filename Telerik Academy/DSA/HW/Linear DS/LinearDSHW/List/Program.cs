using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            var il = new List<int> { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            var r = FindMajorant.MajorantFinder(il);
            Console.WriteLine();

        }
    }
}
