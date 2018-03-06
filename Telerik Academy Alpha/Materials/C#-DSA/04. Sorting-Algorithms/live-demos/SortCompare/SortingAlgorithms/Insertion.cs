using System;

namespace SortingAlgorithms
{
    public class Insertion<T> where T : IComparable<T>
    {
        public static void Sort(T[] arr)
        {
            for (int i = 1; i < arr.Length - 1; i++)
            {
                int j = i;
                T temp = arr[j];

                while (j > 0 && arr[j - 1].CompareTo(temp) > 0)
                {

                    arr[j] = arr[j - 1];

                    j--;
                }

                arr[j] = temp;
            }
        }
    }
}
