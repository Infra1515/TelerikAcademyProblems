using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureManufacturer.Engine;
using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Interfaces.Engine;

namespace FurnitureManufacturer.Commands.Create
{
    internal static class CreateCompany
    {
        internal static string CreateCompanyMethod(string name, string registrationNumber,
            ICompanyFactory companyFactory, IDictionary<string, ICompany> companies)
        {
            if (companies.ContainsKey(name))
            {
                return string.Format(EngineConstants.CompanyExistsErrorMessage, name);
            }

            var company = companyFactory.CreateCompany(name, registrationNumber);
            companies.Add(name, company);

            return string.Format(EngineConstants.CompanyCreatedSuccessMessage, name);
        }
    }
}
