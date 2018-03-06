using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesInABottle
{
    public class Program
    {
        static void Main(string[] args)
        {
            var message = Console.ReadLine();
            var cipher = Console.ReadLine();
            var cipherDict = SeparateCipher(cipher);
            var results = new List<string>();
            var resultBuilder = new StringBuilder();
            FindAllCombinations(message, cipherDict, results, resultBuilder);
            Console.WriteLine();
        }

        private static void FindAllCombinations(string message, SortedDictionary<char, string> cipherDict,
            List<string> results, StringBuilder resultBuilder)
        {
            if(message.Length == 0)
            {
                results.Add(resultBuilder.ToString());
                return;
            }

            foreach (var pair in cipherDict)
            {
                if (message.StartsWith(pair.Value))
                {
                    resultBuilder.Append(pair.Key);
                    FindAllCombinations(message.Substring(pair.Value.Length), cipherDict,
                        results, resultBuilder);
                    resultBuilder.Remove(resultBuilder.Length - 1, 1);
                }
            }
        }

        private static SortedDictionary<char, string> SeparateCipher(string cipher)
        {
            var cipherDict = new SortedDictionary<char, string>();
            var key = ' ';
            var value = new StringBuilder();


            for(int i = 0; i < cipher.Length; i++)
            {
                key = cipher[i];
                i++;

                while (char.IsDigit(cipher[i]))
                {
                    value.Append(cipher[i]);
                    i++;
                    if(i == cipher.Length)
                    {
                        break;
                    }
                }
                i--;
                cipherDict.Add(key, value.ToString());
                value.Clear();
            }

            return cipherDict;
        }
    }
}
