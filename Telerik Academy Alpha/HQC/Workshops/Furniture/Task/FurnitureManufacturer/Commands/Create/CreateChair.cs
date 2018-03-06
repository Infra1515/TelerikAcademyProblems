using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Commands.Create
{
    class CreateChair
    {

        private string CreateChair(string model, string material, decimal price, decimal height, int legs)
        {
            if (this.furnitures.ContainsKey(model))
            {
                return string.Format(EngineConstants.FurnitureExistsErrorMessage, model);
            }

            IFurniture chair = this.furnitureFactory.CreateChair(model, material, price, height, legs);
            this.furnitures.Add(model, chair);

            return string.Format(EngineConstants.ChairCreatedSuccessMessage, model);
        }
    }
}
