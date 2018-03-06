using System;
using System.Collections.Generic;

public class SortingArrays
{
    private static void Main()
    {
        int[] numbers = { 1, 2, 5, 10, 11 };

        Array.Sort(numbers, new NumbersComparer());

        Console.WriteLine("Numbers sorted by module 5:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine();

        Array.Sort(numbers, (x, y) => (y % 6).CompareTo(x % 6));

        Console.WriteLine("Numbers sorted by module 6:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine();

        Console.WriteLine("Students sorted by first letter from last name");
        string[] students = { "Doncho Minkov", "Nikolay Kostov", "Ivaylo Kenov", "Evlogi Hristov" };
        Array.Sort(students, new StudentsComparer());
        foreach (string student in students)
        {
            Console.WriteLine(student);
        }
    }

    private class NumbersComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return (x % 5).CompareTo(y % 5);
        }
    }

    private class StudentsComparer : IComparer<string>
    {
        public int Compare(string student1, string student2)
        {
            var lastName1 = student1.Substring(student1.IndexOf(' ') + 1);
            var lastName2 = student2.Substring(student2.IndexOf(' ') + 1);
            return lastName1.CompareTo(lastName2);
        }
    }
}
