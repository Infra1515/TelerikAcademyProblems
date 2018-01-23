using ExtMethodsAndOtherHomeWork.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ExtMethodsAndOtherHomeWork.Delegates;
using ExtMethodsAndOtherHomeWork.LINQ;

namespace ExtMethodsAndOtherHomeWork
{
    public class Program
    {     
        public static void Main(string[] args)
        {
            // ext methods
            //var myEnum = new List<int>();
            //for (int i = 0; i < 30; i++)
            //{
            //    myEnum.Add(i);
            //}

            //var s = myEnum.ToStringExtensions();
            //Console.WriteLine(s);


            // delegates
            //var testString = "test bzzstring";
            //StringDelagate exampleDelagate = new DelagateTest().StringFunction;

            // does not work - cannot pass a function to a function 
            //string z = new DelagateTest().StringFunction(DelagateTest().StringFunction(testString));
            // works - pass a function as delagate to a function
            //string z = new DelagateTest().StringFunction(exampleDelagate(testString));

            // works - use predefined delagate that takes 1-16 TArgs and returns TResult 
            //Func<string,string> predfinedString = new DelagateTest().StringFunction;
            //string z = predfinedString(testString);

            //Console.WriteLine(z);

            var currentStudents = new StudentTest().AddStudents();

            // only students which FirstName is before LastName
            var sortedStudentsByName = currentStudents.Where(student => 
                String.Compare(student.FirstName, student.LastName) < 0);
            //foreach (var student in sortedStudentsByName)
            //{
            //    Console.WriteLine(student);
            //}

            // only students with Age < 25
            var sortedStudentsByAge = currentStudents.Where(student =>
                student.Age < 25);
            //foreach (var student in sortedStudentsByAge)
            //{
            //    Console.WriteLine(student);
            //}

            // sort students by by first name and then by last name in descending order
            var sortedStudentsByNameDescending = currentStudents
                .OrderByDescending(student => student.FirstName)
                .ThenByDescending(student => student.LastName);

            //foreach (var student in sortedStudentsByNameDescending)
            //{
            //    Console.WriteLine(student);
            //}

            // Extract elements from a list only if they are divisible by 7 and 3
            var testList = new List<int>();
            for (int i = 0; i < 2000; i++)
            {
                testList.Add(i);
            }

            var extractedList = testList.Where(i => i % 3 == 0 && i % 7 == 0);

            foreach (var num in extractedList)
            {
                Console.WriteLine(num);
            }
        }
    }
}
