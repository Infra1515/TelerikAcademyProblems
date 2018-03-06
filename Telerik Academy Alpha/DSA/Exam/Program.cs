using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exam
{
    public class Program
    {
        static void Main()
        {
            var productsByType = new Dictionary<string, SortedSet<Product>>();
            var productsByPrice = new SortedSet<Product>();
            var totalProducts = new Dictionary<string, Product>();
            var command = string.Empty;
            var resultBuilder = new StringBuilder();


            while ((command = Console.ReadLine()) != "end")
            {
                var commandParams = command.Split().ToArray();
                switch (commandParams[0])
                {
                    case "add":
                        AddProduct(commandParams, productsByType, productsByPrice,
                            totalProducts, resultBuilder);
                        break;
                    case "filter":
                        FilterProduct(commandParams, productsByType, productsByPrice, resultBuilder);
                        break;
                }
            }

            Console.WriteLine(resultBuilder.ToString().TrimEnd());
        }

        private static void FilterProduct(string[] commandParams, Dictionary<string,
            SortedSet<Product>> productsByType, SortedSet<Product> productsByPrice, StringBuilder resultBuilder)
        {
            var filterType = commandParams[2];
            if (filterType == "type")
            {
                var productType = commandParams[3];
                if (productsByType.ContainsKey(productType))
                {
                    resultBuilder.Append("Ok: ");
                    var breaker = 0;
                    foreach (var product in productsByType[productType])
                    {
                        if (breaker == 10)
                        {
                            break;
                        }
                        resultBuilder.Append($"{product.ToString()}, ");
                        breaker++;
                    }
                    resultBuilder.Remove(resultBuilder.Length - 2, 2);
                    resultBuilder.AppendLine();
                }
                else
                {
                    resultBuilder.AppendLine($"Error: Type {productType} does not exists");
                }
            }
            // filter by price 
            else
            {
                if (commandParams[3] == "from")
                {
                    // filter by price from MIN_PRICE to MAX_PRICE 
                    if (commandParams.Length == 7)
                    {
                        var minPrice = double.Parse(commandParams[4]);
                        var maxPrice = double.Parse(commandParams[6]);
                        resultBuilder.AppendLine(string.Format("Ok: {0}",
                            string.Join(", ", productsByPrice.Where(
                            x => x.Price >= minPrice && x.Price <= maxPrice)
                            .Take(10))));
                    }
                    // filter by price from MIN_PRICE
                    else
                    {
                        var minPrice = double.Parse(commandParams[4]);
                        resultBuilder.AppendLine(string.Format("Ok: {0}",
                            string.Join(", ", productsByPrice.Where(x => x.Price >= minPrice)
                            .Take(10))));
                    }
                }
                // filter by price [to] MAX_PRICE
                else
                {
                    var maxPrice = double.Parse(commandParams[4]);
                    resultBuilder.AppendLine(string.Format("Ok: {0}",
                           string.Join(", ", productsByPrice.Where(x => x.Price <= maxPrice)
                           .Take(10))));
                }
            }
        }

        private static void AddProduct(string[] commandParams, Dictionary<string,
            SortedSet<Product>> productsByType, SortedSet<Product> productsByPrice,
            Dictionary<string, Product> totalProducts, StringBuilder resultBuilder)
        {
            var name = commandParams[1];
            var price = double.Parse(commandParams[2]);
            var type = commandParams[3];
            var productToAdd = new Product(name, price, type);

            if (totalProducts.ContainsKey(name))
            {
                resultBuilder.AppendLine($"Error: Product {productToAdd.Name} already exists");
            }
            else
            {

                totalProducts.Add(name, productToAdd);
                productsByPrice.Add(productToAdd);

                if (!productsByType.ContainsKey(type))
                {
                    productsByType.Add(type, new SortedSet<Product>());
                }

                productsByType[type].Add(productToAdd);

                resultBuilder.AppendLine($"Ok: Product { productToAdd.Name} added successfully");

            }
        }
    }

    class Product : IComparable<Product>
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }

        public Product(string name, double price, string type)
        {
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        public int CompareTo(Product other)
        {
            int result = this.Price.CompareTo(other.Price);
            if (result == 0)
            {
                result = this.Name.CompareTo(other.Name);

                if (result == 0)
                {
                    result = this.Type.CompareTo(other.Type);
                }
            }

            return result;
        }

        public override string ToString()
        {
            //return $"{this.Name}({this.Price.ToString("G29")})";
            //return $"{this.Name}({this.Price.ToString("####0.0000")})";
            return $"{this.Name}({this.Price})";

        }
    }
}

//if (productsByType.ContainsKey(type))
//{
//    if(!productsByType[type].Contains(productToAdd))
//    {
//        productsByType[type].Add(productToAdd);
//        productsByPrice.Add(productToAdd);
//    }
//}