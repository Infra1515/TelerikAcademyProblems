//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Exam
//{
//    public class SecretMessage
//    {
//        static void Main()
//        {
//            var input = Console.ReadLine();
//            var multList = new List<int>();
//            var strList = new List<string>();

//            var mult = new StringBuilder();
//            var resultToMult = new StringBuilder();

//            for(int i = 0; i < input.Length; i++)
//            {
//                if (i >= input.Length)
//                {
//                    break;
//                }

//                while (char.IsDigit(input[i]))
//                {
//                    mult.Append(input[i]);
//                    i++;
//                    if (i >= input.Length)
//                    {
//                        break;
//                    }
//                }

//                if(mult.Length > 0)
//                {
//                    multList.Add(int.Parse(mult.ToString()));
//                    mult.Clear();
//                }
//                else
//                {
//                    multList.Add(0);
//                }

//                if (i >= input.Length)
//                {
//                    break;
//                }

//                if (input[i] == '{' || input[i] == '}')
//                {
//                    i++;
//                }

//                if (i >= input.Length)
//                {
//                    break;
//                }

//                while (char.IsLetter(input[i]))
//                {
                 
//                    resultToMult.Append(input[i]);
//                    i++;
//                    if (i >= input.Length)
//                    {
//                        break;
//                    }

//                }

//                if (resultToMult.Length > 0)
//                {
//                    strList.Add(resultToMult.ToString());
//                    resultToMult.Clear();
//                }
//                if (i >= input.Length)
//                {
//                    break;
//                }
//                if (char.IsLetter(input[i]) || char.IsDigit(input[i]))
//                {
//                    if (i >= input.Length)
//                    {
//                        break;
//                    }
//                    i--;
//                }

//            }

//            var result = new StringBuilder();
//            //string result = string.Concat(Enumerable.Repeat("aa", 3));
//            //Console.WriteLine(result);

//            for (int i = 0; i < strList.Count; i++)
//            {
//                if(multList[i] == 0)
//                {
//                    result.Append(strList[i]);
//                }
//                else
//                {
//                    result.Append(string.Concat(Enumerable.Repeat(strList[i], multList[i])));
//                }
//            }

//            Console.WriteLine(result.ToString());
//        }
//    }
//}
