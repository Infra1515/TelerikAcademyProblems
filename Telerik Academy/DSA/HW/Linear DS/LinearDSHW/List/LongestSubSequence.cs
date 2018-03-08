using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public static class LongestSubSequence
    {
        public static List<int> FindLongestSubsequence()
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            var longest = 1;
            var longestMax = 1;

            var element = 0;

            for (int i = 1; i < input.Count; i++)
            {
                if (input[i] == input[i - 1])
                {
                    longest++;
                }
                else
                {
                    if (longest > longestMax)
                    {
                        element = input[i];
                        longestMax = longest;
                    }

                    longest = 1;
                }

                if (longest > longestMax)
                {
                    element = input[i];
                    longestMax = longest;
                }
            }

            var resultList = new List<int>();
            for (int i = 0; i < longestMax; i++)
            {
                resultList.Add(element);
            }

            return resultList;

        }


        // Same with Dictionary
        /// <summary>
        /// Write a method that finds the longest subsequence of equal numbers in given List and returns the result as new List<int>.
        /// Write a program to test whether the method works correctly.
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static List<int> FindLongestEqualNumbersSubsequence(IList<int> sequence)
        {
            var longestSubsequence = new List<int>();

            var distinct = new Dictionary<int, int>();

            foreach (var item in sequence)
            {
                if (distinct.ContainsKey(item))
                {
                    distinct[item]++;
                }
                else
                {
                    distinct.Add(item, 1);
                }
            }

            var longest = new KeyValuePair<int, int>(0, 0);

            foreach (var item in distinct)
            {
                if (item.Value > longest.Value)
                {
                    longest = item;
                }
            }

            var result = new List<int>(longest.Value);

            for (int i = 0; i < result.Capacity; i++)
            {
                result.Add(longest.Key);
            }

            return result;
        }
    }
}
