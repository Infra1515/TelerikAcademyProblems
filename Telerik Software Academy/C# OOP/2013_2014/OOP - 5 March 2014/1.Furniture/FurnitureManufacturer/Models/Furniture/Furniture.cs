using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models.Furniture
{
    public class Furniture : IFurniture
    {
        private readonly string model;
        private readonly string material;
        private decimal price;
        private decimal height;

        public Furniture(string model, string materialType, decimal price, decimal height)
        {
            if(string.IsNullOrEmpty(model))
            {
                throw new ArgumentNullException();
            }
            if(price < 0)
            {
                throw new ArgumentException("Price cannot be less than 0");
            }
            this.model = model;
            this.material = materialType;
            this.Price = price;
            this.Height = height;
        }


        public decimal Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Height cannot be less then 0");
                }
                this.height = value;
            }
        }
        public string Model => model;

        public string Material => material;

        public decimal Price { get => price; set => price = value; }

        public override string ToString()
        {
            return string.Format(
                "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4} ",
                 this.GetType().Name, this.Model, this.Material, this.Price, this.Height);
        }
    }
}
