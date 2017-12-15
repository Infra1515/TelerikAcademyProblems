using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Bytes2you.Validation;

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
                Guard.WhenArgument(value, "name is null")
                    .IsNull()
                    .Throw();
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
                Guard.WhenArgument(value, "brand is null")
                .IsNull()
                .Throw();
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
                Guard.WhenArgument(Price, "Price is less then 0")
                    .IsLessThan(0)
                    .Throw();
                this.price = value;
            }
        }

        public GenderType Gender { get; set; }
        public virtual string Print()
        {
            //return $" -{this.Name} - {this.Brand}\r\n * Price: ${this.Price}\r\n * Gender: {this.Gender}\r\n ===";
            throw new NotImplementedException();
        }
    }
}
