﻿using Bytes2you.Validation;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models.Furnitures
{
    // Finish the class
    public class Furniture : IFurniture
    {
        private readonly string model;
        private readonly string material;
        private readonly decimal price;
        private decimal height;

        public Furniture(string model, string materialType, decimal price, decimal height)
        {
            Guard.WhenArgument(model, "Model").IsNull().Throw();
            Guard.WhenArgument(model.Length, "Model length").IsLessThan(3).Throw();
            Guard.WhenArgument(materialType, "Material type").IsNull().Throw();
            Guard.WhenArgument(price, "Price cannot be less than zero").IsLessThan(0).Throw();
            Guard.WhenArgument(height, "Height cannot be less than zero").IsLessThan(0).Throw();
        }

        public string Model => this.model;

        public string Material => this.material;

        public decimal Price => this.price;

        public decimal Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
                this.height = value;
            }
        }

        // Do we need this? Can I delete it?
        protected virtual string AdditionalInfo()
        {
            return string.Empty;
        }

        public override string ToString()
        {
            return $"Type: {this.GetType().Name}, Model: {this.Model}, Material: {this.Material}, Price: {this.Price}, Height: {this.Height.ToString("0.00")}";
        }
    }
}
