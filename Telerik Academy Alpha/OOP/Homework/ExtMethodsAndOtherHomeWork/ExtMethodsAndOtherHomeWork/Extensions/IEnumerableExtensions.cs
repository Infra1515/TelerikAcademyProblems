using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtMethodsAndOtherHomeWork.Extensions
{
    public static class IEnumerableExtensions
    {
        public static T Sum<T>(this IEnumerable<T> enumerable)
        {
            dynamic sum = 0;
            foreach (T item in enumerable)
            {
                sum += item;
            }
            return sum;
        }

        public static T ProductExt<T>(this IEnumerable<T> enumerable)
        {
            dynamic product = 1;
            foreach(T item in enumerable)
            {
                product *= item;
            }
            return product;
        }

        public static T MinExt<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Min();
        }

        public static T MaxExt<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Max();
        }

        public static T Average<T>(this IEnumerable<T> enumerable)
        {
            dynamic average = 0;

            foreach(T item in enumerable)
            {
                average += item;
            }

            return average / enumerable.Count();
        }
    }
}


