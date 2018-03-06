using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingExercises
{
    public static class Calculator
    {

        public static int Add(int a, int  b)
        {
            return a + b;
        }

        public static int Division(int a, int b)
        {
            if(a < 0 || b < 0)
            {
                throw new DivideByZeroException();
            }

            return a / b;
        }

        public static int SumAllElements(List<int> listToSum)
        {
            var result = 0;
            foreach (var number in listToSum)
            {
                result += number;
            }

            return result;
        }

        public static int RecursionSum(List<int> listToSum)
        {
            if(listToSum.Count == 1)
            {
                return listToSum[0];
            }
            else
            {
                return listToSum[0] + RecursionSum(listToSum.GetRange(1, listToSum.Count - 1));
            }
        }
    }
}
