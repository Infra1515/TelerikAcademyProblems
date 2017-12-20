using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models.Furnitures
{
    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private bool isConverted = false;
        private decimal normalHeight;
        public ConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs) 
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.normalHeight = height;
        }


        public bool IsConverted { get => isConverted; set => isConverted = value; }
        public decimal NormalHeight { get => normalHeight;}


        public void Convert()
        {
            // always check against a True value;
            if(isConverted)
            {
                this.Height = NormalHeight;
            }
            else
            {
                this.Height = 0.10m;

            }
            // boolean flipping
            this.isConverted = !this.isConverted;
        }

        public override string ToString()
        {
            return base.ToString() + $", State: {(this.IsConverted ? "Converted" : "Normal")}";
            //return base.ToString() + string.Format(" State: {0}", this.IsConverted ? "Converted" : "Normal");
        }
    }
}
