using System;
using System.Collections.Generic;

namespace CitiesTemperatures
{
    class StartUp
    {
        static void Main()
        {
            PrintCities();

            PrintMilionCities();

            Console.ReadKey();
        }

        // Illustrates collision -> the key is City which GetHashCode will be the same for every city - all names are of length 5
        private static void PrintCities()
        {
            var cities = new Dictionary<City, int>
            {
                {new City("Sofia", "Bulgaria", 2000000, 6), 10 },
                {new City("Hanoi", "Vietnam", 80000000, 14), 12 },
                {new City("Love4", "Bulgaria", 20000, 10 ), 13},
            };

            foreach (var city in cities)
            {
                Console.WriteLine($"Temperature in " + city.Key.Name + " is " + city.Value);
            }
        }

        // Illustrates how bad is the performance when there are collisions -> the key is City which GetHashCode will be the same for every city.
        // 1. Run the project and wait for the message "All cities are created."
        // 2. Remove the methods Equals and GetHashCode. Run the project and wait for the message "All cities are created."        
        private static void PrintMilionCities()
        {
            var cities = new Dictionary<City, int>();

            for (int i = 1000000; i < 2000000; i++)
            {
                var city = new City(i.ToString(), "Bulgaria", 2000000, 6);
                cities.Add(city, i);
            }

            Console.WriteLine("All cities are created.");
        }
    }
}
