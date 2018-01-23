//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Exam
//{
//    public class Expressions
//    {

//        static void Main()
//        {
//            var input = Console.ReadLine();
//            var target = int.Parse(Console.ReadLine());
//            var results = ExpressionFinder(input, target);
//            //foreach (var result in results)
//            //{
//            //    Console.WriteLine(result);
//            //}
//            Console.WriteLine(results.Count());

//        }

//        static void ExpressionHelper(List<string> results, string currentExpression, string input,
//            int target, int pos, int currentVal, int last)
//        {

//            if(pos == input.Length)
//            {
//                if(currentVal == target)
//                {
//                    results.Add(currentExpression);
//                }

//                return;
//            }

//            for(int i = pos; i < input.Length; i++)
//            {
//                if (i != pos && input[pos] == '0')
//                {
//                    break;

//                }
//                string part = input.Substring(pos, i + 1 - pos);

//                int cur = int.Parse(part);

//                if(pos == 0)
//                {
//                    ExpressionHelper(results, currentExpression + part, input, target, i + 1, cur, cur);
//                }
//                else
//                {
//                    ExpressionHelper(results, currentExpression + "+" + part, input, target, i + 1,
//                        currentVal + cur, cur);
//                    ExpressionHelper(results, currentExpression + "-" + part, input, target, i + 1,
//                        currentVal - cur, -cur);
//                    ExpressionHelper(results, currentExpression + "*" + part, input, target, i + 1,
//                        currentVal - last + last * cur, last * cur);
//                }

//            }
//        }
//        static List<string>  ExpressionFinder(string input, int target)
//        {
//            var results = new List<string>();
//            ExpressionHelper(results, "", input, target, 0, 0, 0);
//            return results;
//        }
//    }
//}
