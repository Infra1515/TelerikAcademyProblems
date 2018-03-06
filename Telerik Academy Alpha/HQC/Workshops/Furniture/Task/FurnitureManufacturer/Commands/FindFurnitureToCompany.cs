using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Commands
{
    class FindFurnitureToCompany
    {
        private string FindFurnitureFromCompany(string companyName, string furnitureName)
        {
            if (!this.companies.ContainsKey(companyName))
            {
                return string.Format(EngineConstants.CompanyNotFoundErrorMessage, companyName);
            }

            var company = this.companies[companyName];
            var furniture = company.Find(furnitureName);
            if (furniture == null)
            {
                return string.Format(EngineConstants.FurnitureNotFoundErrorMessage, furnitureName);
            }

            return furniture.ToString();
        }
    }
}
