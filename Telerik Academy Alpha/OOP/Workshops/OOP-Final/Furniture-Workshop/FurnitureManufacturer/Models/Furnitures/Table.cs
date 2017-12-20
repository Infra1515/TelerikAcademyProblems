using Bytes2you.Validation;
using FurnitureManufacturer.Interfaces;
using System;

namespace FurnitureManufacturer.Models.Furnitures
{
    public class Table : Furniture, ITable
    {
        private decimal length;
        private decimal width;
        private decimal area;
        public Table(string model, string materialType, decimal price, decimal height,
                     decimal length, decimal width) 
                   : base(model, materialType, price, height)
        {
            // Should I do the validation in the constructor if I'm only going to use getter?
            this.Length = length;
            this.Width = width;
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }
            protected set
            {
                Guard.WhenArgument(value, "Table length").IsLessThanOrEqual(0.00m).Throw();
                this.length = value;
            }
        }
        public decimal Width
        {
            get
            {
                return this.width;
            }
            protected set
            {
                Guard.WhenArgument(value, "Table width").IsLessThanOrEqual(0.00m).Throw();
                this.width = value;
            }
        }

        public decimal Area
        {
            get
            {
                // use property or field for calculation?
                return this.Width * this.Height;
            }
        }
    }
}
