using Bytes2you.Validation;
using Cosmetics.Common;
using System;

namespace Cosmetics.Products
{
    public class Product
    {
        private readonly decimal price;
        private readonly string name;
        private readonly string brand;
        private readonly GenderType gender;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
        }

        public string Print()
        {
            return $" #{this.Name} {this.Brand}\r\n #Price: ${this.Price}\r\n #Gender: {this.Gender}\r\n ===";
        }
    }
}
