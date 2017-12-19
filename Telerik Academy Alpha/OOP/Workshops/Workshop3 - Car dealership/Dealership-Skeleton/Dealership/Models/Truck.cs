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
    public class Truck : Vehicle, ITruck
    {
        private int weightCapacity;
        public Truck(string make, string model, decimal price, int weightCapacity)
            : base(8, VehicleType.Truck, make, model, price)
        {
            this.WeightCapacity = weightCapacity;
        }
        public int WeightCapacity
        {
            get
            {
                return weightCapacity;
            }
            set
            {
                Guard.WhenArgument(value, "weight capacity").IsLessThan(0).IsGreaterThan(100).Throw();
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"    Weight capacity: {this.WeightCapacity}\r\n";
        }

    }
}
