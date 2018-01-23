using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace MessageInABottle
{
    public class Program
    {
        static void Main(string[] args)
        {
            string code = Console.ReadLine();
            string cipher = Console.ReadLine();

            var ciphrerDict = CipherParser(cipher);
            var allCombinations = new List<string>();
            var result = new StringBuilder();
            Decode(ciphrerDict, allCombinations, code, result);
            Console.WriteLine(allCombinations.Count());
            if(allCombinations.Count > 0)
            {
                foreach (var combination in allCombinations.OrderBy(x => x))
                {
                    Console.WriteLine(combination);
                }
            }
      
        }

        static void Decode(Dictionary<string, char> encodingDict, List<string> allCombinations,
            string message, StringBuilder result)
        {
            if(message == string.Empty)
            {
                allCombinations.Add(result.ToString());
                return;
            }

            foreach (var pair in encodingDict)
            {
                var key = pair.Key;
                var value = pair.Value;

                if (message.StartsWith(key))
                {
                    result.Append(value);
                    // when we get to 12:B in original?
                    // does it goes inside here? ASK !
                    var remainingMessage = message.Substring(key.Length);
                    Decode(encodingDict, allCombinations, remainingMessage, result);
                    result.Remove(result.Length - 1, 1);
                }
            }
        }

        static Dictionary<string, char> CipherParser(string cipher)
        {
            var dict = new Dictionary<string, char>();
            var key = new StringBuilder();
            var value = cipher[0];
            for (int i = 1; i < cipher.Length; i++)
            {
                char seed = cipher[i];
                if (char.IsDigit(seed))
                {
                    key.Append(seed);
                }
                else
                {
                    dict.Add(key.ToString(), value);
                    key.Clear();
                    value = seed;
                }

                if (i == cipher.Length - 1)
                {
                    dict.Add(key.ToString(), value);
                }
            }

            return dict;
        }
    }
}



