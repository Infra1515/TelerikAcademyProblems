using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;

namespace Cosmetics.Products
{
    public class Product : IProduct
    {
        private string name;
        private string brand;
        private decimal price;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;

        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if(value.Length < 3 || value.Length > 10)
                {
                    throw new Exception("Product name must be between 3 and 10 symbols long!");
                }
                else
                {
                    this.name = value;

                }
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            set
            {
                if (value.Length < 2 || value.Length > 10)
                {
                    throw new Exception("Brand name must be between 3 and 10 symbols long!");
                }
                else
                {
                    this.brand = value;

                }

            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        public GenderType Gender { get; set; }
        public virtual string Print()
        {
            return $"- {this.Brand} - {this.Name}:\r\n * Price: ${this.Price}\r\n * For gender: {this.Gender}\r\n ";
        }
    }
}
