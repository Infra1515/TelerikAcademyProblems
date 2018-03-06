using System;

namespace SortingAlgorithms
{
    public class Bubble<T> where T : IComparable<T>
    {
        public static void Sort(T[] arr)
        {
            var isSwapDone = true;

            while (isSwapDone)
            {
                isSwapDone = false;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i + 1].CompareTo(arr[i]) < 0)
                    {
                        Swap(arr, i, i + 1);
                        isSwapDone = true;
                    }
                }
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
