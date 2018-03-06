using System;

namespace SortingAlgorithms
{
    public class Quick<T> where T : IComparable<T>
    {
        public static void Sort(T[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        // Think of how to improve it to work on ordered collections
        // https://www.geeksforgeeks.org/3-way-quicksort-dutch-national-flag/
        // https://www.toptal.com/developers/sorting-algorithms/quick-sort-3-way
        private static void Sort(T[] arr, int lo, int hi)
        {
            if (hi <= lo)
            {
                return;
            }

            while (lo < hi)
            {
                int j = Partition(arr, lo, hi);

                if (j - lo < hi - j)
                {
                    Sort(arr, lo, j - 1);
                    lo = j + 1;
                }

                else
                {
                    Sort(arr, j + 1, hi);
                    hi = j - 1;
                }

            }
        }

        private static int Partition(T[] arr, int lo, int hi)
        {
            var i = lo;
            var j = hi + 1;

            var pivot = arr[lo];

            while (true)
            {
                while (arr[++i].CompareTo(pivot) < 0) if (i == hi) break;
                while (pivot.CompareTo(arr[--j]) < 0) if (j == lo) break;
                if (j <= i) break;

                Swap(arr, i, j);
            }

            Swap(arr, lo, j);
            return j;
        }

        private static void Swap(T[] arr, int i, int j)
        {
            var temp = arr[j];
            arr[j] = arr[i];
            arr[i] = temp;
        }
    }
}
