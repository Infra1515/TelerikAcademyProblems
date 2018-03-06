using System;

namespace SortingAlgorithms
{
    public class Shell<T> where T : IComparable<T>
    {
        public static void Sort(T[] arr)
        {
            int h = 1;

            while (h < arr.Length / 3)
            {
                h = 3 * h + 1;
            }

            while (h >= 1)
            {
                for (int i = h; i < arr.Length -1; i++)
                {
                    int j = i;
                    T temp = arr[j];

                    while (j >= h && arr[j - h].CompareTo(temp) > 0)
                    {
                        arr[j] = arr[j - h];

                        j-=h;
                    }

                    arr[j] = temp;
                }

                h = h / 3;

            }
        }
    }
}
