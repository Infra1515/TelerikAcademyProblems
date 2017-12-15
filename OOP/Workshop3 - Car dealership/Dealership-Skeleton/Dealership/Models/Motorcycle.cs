using Bytes2you.Validation;
using Dealership.Common.Enums;
using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public class Motorcycle : Vehicle, IMotorcycle
    {
        private string category;
        public Motorcycle(string make, string model, decimal price, string category)
            : base(2, VehicleType.Motorcycle, make, model, price)
        {
            this.Category = category; 
        }

        public string Category
        {
            get
            {
                return this.category;
            }
            set
            {
                Guard.WhenArgument(value, "category").IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, "value out of range")
                    .IsLessThan(1)
                    .IsGreaterThan(10)
                    .Throw();
                this.category = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() + $"    Category: {this.Category}\r\n";
        }

    }
}
