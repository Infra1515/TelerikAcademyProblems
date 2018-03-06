using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models.Furnitures
{
    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private readonly decimal originalHeight;

        public ConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.originalHeight = height;
        }

        public bool IsConverted { get; private set; }

        public void Convert()
        {
            this.IsConverted = !this.IsConverted;
            this.Height = this.IsConverted ? 0.1m : this.originalHeight;
        }

        protected override string AdditionalInfo()
        {
            return $"{base.AdditionalInfo()}, State: {(this.IsConverted ? "Converted" : "Normal")}";
        }
    }
}
