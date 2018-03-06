using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models.Furniture
{
    public class Table : Furniture, ITable
    {
        private readonly decimal length;
        private readonly decimal width;
        private readonly decimal area;
        public Table(string model, string materialType, decimal price, decimal height,
                                                        decimal length, decimal width)
            : base(model, materialType, price, height)
        {
           if(length < 0 || width < 0)
            {
                throw new ArgumentException("Length or Width cannot be less 0");
            }
            this.length = length;
            this.width = width;
            this.area = length * width;
        }

        public decimal Length => length;

        public decimal Width => width;

        public decimal Area => area;

        public override string ToString()
        {
            return base.ToString() + string.Format(", Length: {0}, Width: {1}, Area: {2}",
                this.Length, this.Width, this.Area);

        }
    }
}
