using System;

namespace SortingAlgorithms
{
    // Implementing IComparable to Person
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            return this.Name.CompareTo(other.Name) == 0 ? this.Age.CompareTo(other.Age) : this.Name.CompareTo(other.Name);
        }
    }
}
