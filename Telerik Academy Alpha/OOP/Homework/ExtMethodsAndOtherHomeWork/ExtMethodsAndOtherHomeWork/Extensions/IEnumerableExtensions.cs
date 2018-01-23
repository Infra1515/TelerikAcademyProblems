using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtMethodsAndOtherHomeWork.Extensions
{
    public static class EnumerableExtensions
    {
        public static T MySum<T>(this IEnumerable<T> enumerable)
        {
            dynamic sum = 0;
            foreach (T item in enumerable)
            {
                sum += item;
            }
            return sum;
        }

        public static T MyProductExt<T>(this IEnumerable<T> enumerable)
        {
            dynamic product = 1;
            foreach(T item in enumerable)
            {
                product *= item;
            }
            return product;
        }

        public static T MyMinExt<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Min();
        }

        public static T MyMaxExt<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.Max();
        }

        public static T MyAverage<T>(this IEnumerable<T> enumerable)
        {
            dynamic average = 0;

            foreach(T item in enumerable)
            {
                average += item;
            }

            return average / enumerable.Count();
        }


        // extension for interfaces
        public static string ToStringExtensions<T>(
            this IEnumerable<T> enumeration)

        {
            var result = new StringBuilder();

            result.Append("[");

            foreach (var item in enumeration)

            {
                result.Append(item);

                result.Append(", ");
            }

            if (result.Length > 1)

                result.Remove(result.Length - 2, 2);

            result.Append("]");

            return result.ToString();

        }
    }
}


