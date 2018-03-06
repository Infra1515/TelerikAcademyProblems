using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Common.Enums;

namespace Dealership.Models
{
    public class Motorcycle : Vehicle
    {
        private string category;

        public Motorcycle(string make, string model, decimal price, string category)
            : base(2, VehicleType.Motorcycle, make, model, price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.Category = category;

        }

        public string Category
        {
            get { return this.category; }
            set
            {
                if(value.Length < 3 || value.Length > 10)
                {
                    throw new Exception("Category must be between 3 and 10 characters long!");
                }
                this.category = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() + $"Category: {this.Category}\r\n";
        }
    }
}
