using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models.Furniture
{
    public class ConvertableChair : Chair, IConvertibleChair
    {
        private bool isConverted = false;
        private readonly decimal initialH;
        public ConvertableChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.initialH = height;
        }

        public bool IsConverted => isConverted;

        public void Convert()
        {
            if (isConverted)
            {
                this.Height = initialH;
            }
            else
            {
                this.Height = 0.10m;
            }

            isConverted = !isConverted;

        }

        public override string ToString()
        {
            return base.ToString() + string.Format(", State: {0}", this.IsConverted ? "Converted" : "Normal");
        }
    }

}