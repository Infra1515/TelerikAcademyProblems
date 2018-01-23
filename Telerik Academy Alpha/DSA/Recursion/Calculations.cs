using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Recursion
{
    public static class Calculations
    {
        public static int CalculateSumIterative(List<int> numbersList)
        {
            var sum = 0;
            foreach(var num in numbersList)
            {
                sum += num;
            }
            return sum;
        }

        public static int CalculateSumRecursively(List<int> numbersList)
        {
            if(numbersList.Count() == 1)
            {
                return numbersList[0];
            }
            else
            {
                return numbersList[0] + 
                    CalculateSumRecursively(numbersList.GetRange(1, numbersList.Count() -1 ));
            }
        }

        public static int CalculateFactorielIteratively(int n)
        {
            var result = 1;

            for(var i = n; i > 1; i--)
            {
                result *= i;
            }
            
            return result;
        }

        public static int CalculteFactorielRecursively(int n)
        {
            if(n >= 1)
            {
                return n * CalculteFactorielRecursively(n - 1);

            }
            else
            {
                return 1;
            }
        }

        public static int CalculateFibonacciIteratively(int n)
        {
            int x = 0;
            int y = 1;
            int z = 1;
            for (int i = 0; i < n; i++)
            {
                x = y;
                y = z;
                z = x + y;
            }
            return x;
        }

        public static int CalculteFibonacciRecursively(int n)
        {
            if( n <= 1)
            {
                return n;
            }
            else
            {
                return CalculteFibonacciRecursively(n - 1) + CalculteFibonacciRecursively(n - 2);
            }
        }

    }
}
