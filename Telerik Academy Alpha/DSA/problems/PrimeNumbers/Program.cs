using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeNumbers
{
    public class PrimeNumbers
    {
        static void Main(string[] args)
        {
            var primeNumbers = new List<int>();
            for (int i = 200; i <= 300; i++)
            {
                if (IsPrime(i))
                {
                    primeNumbers.Add(i);
                }
            }

            foreach (var primeNum in primeNumbers)
            {
                Console.WriteLine(primeNum);
            }
        }

        public static bool IsPrime(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0)  return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i+=2)
            {
                if (number % i == 0)  return false;
            }

            return true;        
        }
    }
}
