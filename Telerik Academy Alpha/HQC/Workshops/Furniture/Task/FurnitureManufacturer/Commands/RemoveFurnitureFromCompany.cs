using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Engine;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Commands
{
    internal static class RemoveFurnitureFromCompany
    {

        internal static string RemoveFurnitureFromCompanyMethod(
            string companyName,
            string furnitureName,
            IDictionary<string, ICompany> companies,
            IDictionary<string, IFurniture> furnitures)
        {
            if (!companies.ContainsKey(companyName))
            {
                return string.Format(EngineConstants.CompanyNotFoundErrorMessage, companyName);
            }

            if (!furnitures.ContainsKey(furnitureName))
            {
                return string.Format(EngineConstants.FurnitureNotFoundErrorMessage, furnitureName);
            }

            var company = companies[companyName];
            var furniture = furnitures[furnitureName];
            company.Remove(furniture);

            return string.Format(EngineConstants.FurnitureRemovedSuccessMessage, furnitureName, companyName);
        }

    }
}
