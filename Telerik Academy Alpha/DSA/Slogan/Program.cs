    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

namespace Slogan
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; i++)
            {
                var words = Console.ReadLine().Split().ToList();
                var slogan = Console.ReadLine();
                var sb = new StringBuilder();
                var allSlogans = new List<string>();
                //SloganFinder(slogan, words, sb, allSlogans);
                GenerateSlogansSlow(words, slogan, sb, allSlogans);
                if(allSlogans.Count > 0)
                {
                    foreach (var s in allSlogans)
                    {
                        Console.WriteLine(s);
                    }
                }
                else
                {
                    Console.WriteLine("NOT VALID!");
                }
            }
        }

        static void SloganFinder(string slogan, string[] words, StringBuilder sb, List<string> allResults)
        {
            if(slogan == string.Empty)
            {
                allResults.Add(sb.ToString());
                return;
            }

            foreach (var word in words)
            {
                if (slogan.StartsWith(word))
                {
                    sb.Append(word + " ");
                    var restOfSlogan = slogan.Substring(word.Length);
                    SloganFinder(restOfSlogan, words, sb, allResults);
                    sb.Length -= word.Length + 1;
                    //break;
                }
            }

            return;
        }
        /// <summary>
        /// Does not work - the function results in StackOverflow
        /// Ask - is it possible then to find all combinations and if SO happens why?
        /// </summary>
        /// <param name="suggestedWords"></param>
        /// <param name="slogan"></param>
        /// <param name="sloganBuilder"></param>
        /// <param name="originalMessages"></param>
        private static void GenerateSlogansSlow(List<string> suggestedWords, string slogan,
          StringBuilder sloganBuilder, List<string> originalMessages)
        {
            if (slogan == string.Empty)
            {
                originalMessages.Add(sloganBuilder.ToString());
                return;
            }

            foreach (string word in suggestedWords)
            {
                if (slogan.StartsWith(word))
                {
                    string wordToAdd = $"{word} ";
                    sloganBuilder.Append(wordToAdd);

                    string restOfSlogan = slogan.Substring(word.Length);
                    GenerateSlogansSlow(suggestedWords, restOfSlogan, sloganBuilder, originalMessages);

                    sloganBuilder.Length -= wordToAdd.Length;
                   
                }
            }

            return;
        }
        private static bool GenerateSlogansFast(IEnumerable<string> suggestedWords, string slogan,
            List<string> usedWords, HashSet<string> impossibleSlogans)
        {
            if (slogan == string.Empty)
            {
                return true;
            }

            if (impossibleSlogans.Contains(slogan))
            {
                return false;
            }

            foreach (string word in suggestedWords)
            {
                if (slogan.StartsWith(word))
                {
                    string restOfSlogan = slogan.Substring(word.Length);
                    if (GenerateSlogansFast(suggestedWords, restOfSlogan, usedWords, impossibleSlogans))
                    {
                        usedWords.Add(word);
                        return true;
                    }
                }
            }

            impossibleSlogans.Add(slogan);
            return false;
        }
    }
}












            //        if (allSlogans.Count == 0)
            //        {
            //            Console.WriteLine("NOT VALID");
            //        }
            //        else
            //        {
            //            Console.WriteLine(string.Join(" ", allSlogans));
            //        }
            //        allSlogans.Clear();
            //        sb.Clear();
            //    }
            //}
            //static void FindSlogan(string slogan, string[] words, List<string> allSlogans, 
            //    StringBuilder result)
            //{
            //    if(slogan.Length == 0)
            //    {
            //        allSlogans.Add(result.ToString());
            //        return;
            //    }

            //    foreach (var word in words)
            //    {
            //        if (slogan.StartsWith(word))
            //        {
            //            var wordToAdd = $"{word} ";
            //            result.Append(wordToAdd);
            //            var restOfSlogan = slogan.Substring(word.Length);
            //            FindSlogan(restOfSlogan, words, allSlogans, result);
            //            result.Length -= wordToAdd.Length;
            //            break;
            //    }
            //    }
            //}
            ////static void FindSlogan(string slogan, string[] words, List<string> allSlogans)
            ////{
            ////    if(slogan.Length == 0)
            ////    {
            ////        Console.WriteLine(string.Join(" ", allSlogans));
            ////        return;
            ////    }

            ////    foreach (var word in words)
            ////    {
            ////        if (slogan.StartsWith(word))
            ////        {
            ////            allSlogans.Add(word);
            ////            var restOfSlogan = slogan.Substring(word.Length);
            ////            FindSlogan(restOfSlogan, words, allSlogans);
            ////            //allSlogans.RemoveAt(allSlogans.Count - 1);
            ////        }
            ////    }
            ////}
    //    }
    //}
