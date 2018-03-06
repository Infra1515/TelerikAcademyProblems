using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Commands.Create
{
    class CreateTable
    {
        private string CreateTable(string model, string material, decimal price, decimal height, decimal length, decimal width)
        {
            if (this.furnitures.ContainsKey(model))
            {
                return string.Format(EngineConstants.FurnitureExistsErrorMessage, model);
            }

            var table = (IFurniture)this.furnitureFactory.CreateTable(model, material, price, height, length, width);
            this.furnitures.Add(model, table);

            return string.Format(EngineConstants.TableCreatedSuccessMessage, model);
        }
    }
}
