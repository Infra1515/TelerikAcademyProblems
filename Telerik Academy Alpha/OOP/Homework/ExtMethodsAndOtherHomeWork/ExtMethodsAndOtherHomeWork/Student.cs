using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtMethodsAndOtherHomeWork
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Fn { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public int GroupNumber { get; set; }
        public IList<int> Marks { get; set; }


        public Student(string firstName, string lastName, int age, int fn, string telephone,
            string email, int groupNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Fn = fn;
            Telephone = telephone;
            Email = email;
            GroupNumber = groupNumber;
            Marks = new List<int>();
        }

        public override string ToString()
        {
            return $"First Name: {this.FirstName} Last name: {this.LastName} Age: {this.Age}";
        }
    }
}
