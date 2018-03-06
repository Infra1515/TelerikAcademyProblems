using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Engine.Commands.Create
{
    public class CreateShampoo : ICommand
    {
        private readonly IDataStore dataStore;
        private readonly ICosmeticsFactory factory;

        public CreateShampoo(IDataStore dataStore , ICosmeticsFactory factory)
        {
            this.dataStore = dataStore;
            this.factory = factory;
        }

        public string Execute(IList<string> commandParameters)
        {
            var shampooName = commandParameters[0];
            var shampooBrand = commandParameters[1];
            var shampooPrice = decimal.Parse(commandParameters[2]);
            var shampooGender = commandParameters[3];
            var shampooMilliliters = uint.Parse(commandParameters[4]);
            var shampooUsage = commandParameters[5];

            if (this.dataStore.Products.ContainsKey(shampooName))
            {
                return string.Format(Constants.ShampooAlreadyExist, shampooName);
            }

            var shampoo = this.factory.CreateShampoo(shampooName, shampooBrand, shampooPrice, shampooGender, shampooMilliliters, shampooUsage);
            this.dataStore.AddProduct(shampoo);

            return string.Format(Constants.ShampooCreated, shampooName);

        }
    }
}
