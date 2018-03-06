using Dealership.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public class Truck : Vehicle
    {
        private int weightCapacity;

        public Truck(string make, string model, decimal price, int weightCapacity)
            : base(8, VehicleType.Truck, make, model, price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.WeightCapacity = weightCapacity;

        }

        public int WeightCapacity
        {
            get { return this.weightCapacity; }
            set
            {
                if(value < 1 || value > 100)
                {
                    throw new Exception("Weight capacity must be between 1 and 100!");
                }
                this.weightCapacity = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() + $"Weight capacity {this.WeightCapacity}t\r\n";
        }
    }
}
