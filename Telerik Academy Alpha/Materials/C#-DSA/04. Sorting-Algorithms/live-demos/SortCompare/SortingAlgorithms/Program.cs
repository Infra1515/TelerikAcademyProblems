using System;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var capacity = 10000;
            var repeat = 10;

            Console.WriteLine($"Selection: {SortCompare.TimeFind(capacity, Selection<int>.Sort, repeat)}");
            Console.WriteLine($"Insertion: {SortCompare.TimeFind(capacity, Insertion<int>.Sort, repeat)}");
            Console.WriteLine($"Shell: {SortCompare.TimeFind(capacity, Shell<int>.Sort, repeat)}");
            Console.WriteLine($"Merge: {SortCompare.TimeFind(capacity, Merge<int>.Sort, repeat)}");
            Console.WriteLine($"Quick: {SortCompare.TimeFind(capacity, Quick<int>.Sort, repeat)}");
        }
    }
}
