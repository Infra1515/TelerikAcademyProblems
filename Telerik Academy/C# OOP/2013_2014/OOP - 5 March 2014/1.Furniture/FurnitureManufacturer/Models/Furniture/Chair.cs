using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models.Furniture
{
    public class Chair : Furniture, IChair
    {
        private readonly int numberOfLegs;
        public Chair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height)
        {
            this.numberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs => numberOfLegs;

        public override string ToString()
        {
            return base.ToString() + string.Format(", Legs: {0}", this.numberOfLegs);

        }
    }
}
