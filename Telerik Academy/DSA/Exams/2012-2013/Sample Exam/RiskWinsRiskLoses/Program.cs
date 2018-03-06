//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace RiskWinsRiskLoses
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var startCombination = Console.ReadLine();
//            var endCombination = Console.ReadLine();
//            var visited = new HashSet<string>();
//            var forbiddenCombinationsCount = int.Parse(Console.ReadLine());

//            for(int i = 0; i < forbiddenCombinationsCount; i++)
//            {
//                visited.Add(Console.ReadLine());
//            }

//            var startNode = new Tuple<string, int>(startCombination, 0);
//            var q = new Queue<Tuple<string, int>>();
//            q.Enqueue(startNode);

//            while (q.Count > 0)
//            {
//                var currentNode = q.Dequeue();

//                if (currentNode.Item1 == endCombination)
//                {
//                    Console.WriteLine(currentNode.Item2);
//                    return;
//                }

//                var newNode = new StringBuilder(currentNode.Item1);


//                // moving positions upwards ^
//                for (int i = 0; i < startCombination.Length; i++)
//                {
//                    var digit = (int)Char.GetNumericValue(currentNode.Item1[i]);
//                    digit++;
//                    if (digit == 10)
//                    {
//                        digit = 0;
//                    }

//                    newNode[i] = (char)(digit + '0');

//                    if (!visited.Contains(newNode.ToString()))
//                    {
//                        visited.Add(newNode.ToString());
//                        q.Enqueue(new Tuple<string, int>(newNode.ToString(), currentNode.Item2 + 1));
//                    }


//                    // return to original unchanged state - we avoid creating new sb each iteration
//                    newNode[i] = currentNode.Item1[i];
//                }

//                // moving positions downwards 
//                for (int i = 0; i < startCombination.Length; i++)
//                {
//                    var digit = (int)char.GetNumericValue(newNode[i]);
//                    digit--;
//                    if (digit < 0)
//                    {
//                        digit = 9;
//                    }

//                    newNode[i] = (char)(digit + '0');

//                    if (!visited.Contains(newNode.ToString()))
//                    {
//                        visited.Add(newNode.ToString());
//                        q.Enqueue(new Tuple<string, int>(newNode.ToString(), currentNode.Item2 + 1));
//                    }

//                    newNode[i] = currentNode.Item1[i];

//                }


//            }
//            Console.WriteLine("-1");
            
//        }
//    }
//}


////int count = 0;

////for(int i = 0; i < startCombination.Length; i++)
////{
////    int startDigit = startCombination[i] - '0';
////    int endDigit = endCombination[i] - '0';

////    count += Math.Min(Math.Abs(startDigit - endDigit), 10 - Math.Abs(startDigit - endDigit));

////}

////Console.WriteLine(count);