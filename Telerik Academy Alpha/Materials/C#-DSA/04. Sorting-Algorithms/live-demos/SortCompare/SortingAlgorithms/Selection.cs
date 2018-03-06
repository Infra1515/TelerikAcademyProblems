using System;

namespace SortingAlgorithms
{
    public class Selection<T> where T : IComparable<T>
    {
        public static void Sort(T[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                var min = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j].CompareTo(arr[min]) < 0)
                    {
                        min = j;
                    }
                }

                Swap(arr, i, min);
            }
        }

        private static void Swap(T[] arr, int i, int j)
        {
            var temp = arr[j];
            arr[j] = arr[i];
            arr[i] = temp;
        }
    }
}
