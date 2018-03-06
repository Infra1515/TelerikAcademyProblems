using System;

namespace SortingAlgorithms
{
    public class Merge<T> where T : IComparable<T>
    {
        private static T[] aux;

        public static void Sort(T[] arr)
        {
            aux = new T[arr.Length];
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(T[] arr, int lo, int hi)
        {
            if (hi <= lo)
            {
                return;
            }

            var mid = lo + (hi - lo) / 2;

            Sort(arr, lo, mid);
            Sort(arr, mid + 1, hi);
            MergeIt(arr, lo, mid, hi);
        }

        private static void MergeIt(T[] arr, int lo, int mid, int hi)
        {
            var i = lo;
            var j = mid + 1;

            for (int k = lo; k <= hi; k++)
            {
                aux[k] = arr[k];
            }

            for (int k = lo; k <= hi; k++)
            {
                if (i > mid) arr[k] = aux[j++];
                else if (j > hi) arr[k] = aux[i++];
                else if (aux[i].CompareTo(aux[j]) < 0) arr[k] = aux[i++];
                else arr[k] = aux[j++];
            }
        }
    }
}
