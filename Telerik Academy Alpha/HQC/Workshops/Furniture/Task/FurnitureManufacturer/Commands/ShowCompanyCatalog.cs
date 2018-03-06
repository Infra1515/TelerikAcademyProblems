using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Commands
{
    class ShowCompanyCatalog
    {

        private string ShowCompanyCatalog(string companyName)
        {
            if (!this.companies.ContainsKey(companyName))
            {
                return string.Format(EngineConstants.CompanyNotFoundErrorMessage, companyName);
            }

            return this.companies[companyName].Catalog();
        }

    }
}
