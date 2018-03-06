using System;

class StringConcatenation
{
    static void Main()
    {
        string firstName = "Telerik";
        string lastName = "Academy";

        string fullName = firstName + " " + lastName;
        Console.WriteLine(fullName);

        int age = 25;

        string nameAndAge =
            "Name: " + fullName +
            "\nAge: " + age;
        Console.WriteLine(nameAndAge);
    }
}
