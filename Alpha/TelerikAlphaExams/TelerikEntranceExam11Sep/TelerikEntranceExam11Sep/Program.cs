//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Numerics;

//namespace TelerikAcademyFundamentals
//{
//    class TelerikAcademyC_Sharp_Fund_2012_2013
//    {
//        static void Main()
//        {
//            //string input = Console.ReadLine(); ;
//            //var list = input.Split(' ').Select(Int64.Parse).ToList();
//            var list = Console.ReadLine().Split().Select(Int64.Parse).ToArray();
//            BigInteger sum = 0;
//            int index = 1;  
//            while (index < list.Count())
//            {
//                long current = list[index];
//                long previous = list[index - 1];
//                long diff = Math.Abs(current - previous);
//                if (diff % 2 == 0)
//                {
//                    index += 2;
//                    sum += diff;
//                }
//                else
//                {
//                    index += 1;
//                }
//            }
//            Console.WriteLine(sum);
//        }
//    }
//}



using System;
using System.Collections.Generic;
using System.Linq;
namespace TelerikAcademyFundamentals
{
    class TelerikAcademyC_Sharp_Fund_2012_2013
    {
        // problem 1 - Guess the date
        static void Main()
        {
            var carrotsList = Console.ReadLine().Split(',').Select(Int32.Parse).ToArray();
            int directionsCount = int.Parse(Console.ReadLine());
            int sum = 0;
            int sumMax = 0;
            //List<int> carrotsList = carrots.Split(',').Select(Int32.Parse).ToList();

            for (int i = 0; i < directionsCount; i++)
            {
                string directions = Console.ReadLine();
                var directionsList = directions.Split(',').Select(Int32.Parse).ToArray();
                List<int> visitedLocations = new List<int>();
                bool possible = true;
                int index = 0;
                visitedLocations.Add(index);
                sum = carrotsList[index];
                while (possible)
                {
                    for (int j = 0; j < directionsList.Length; j++)
                    {
                        index += directionsList[j];
                        if (index >= carrotsList.Length || index < 0 || visitedLocations.Contains(index))
                        {
                            possible = false;
                            break;
                        }
                        visitedLocations.Add(index);
                        sum += carrotsList[index];
                    }
                }
                if (sum > sumMax)
                {
                    sumMax = sum;
                }
            }
            Console.WriteLine(sumMax);

        }
    }
}