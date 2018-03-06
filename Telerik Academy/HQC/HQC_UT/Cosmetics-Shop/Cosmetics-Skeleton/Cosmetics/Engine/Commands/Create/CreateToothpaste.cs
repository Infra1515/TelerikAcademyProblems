using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Engine.Commands.Create
{
    public class CreateToothpaste : ICommand
    {
        private readonly IDataStore dataStore;
        private readonly ICosmeticsFactory factory;

        public CreateToothpaste(IDataStore dataStore, ICosmeticsFactory factory)
        {
            this.dataStore = dataStore;
            this.factory = factory;
        }

        public string Execute(IList<string> commandParameters)
        {
            var toothpasteName = commandParameters[0];
            var toothpasteBrand = commandParameters[1];
            var toothpastePrice = decimal.Parse(commandParameters[2]);
            var toothpasteGender = commandParameters[3];
            var toothpasteIngredients = commandParameters[4].Trim().Split(',').ToList();

            if (this.dataStore.Products.ContainsKey(toothpasteName))
            {
                return string.Format(Constants.ToothpasteAlreadyExist, toothpasteName);
            }

            var toothpaste = this.factory.CreateToothpaste(toothpasteName, toothpasteBrand, toothpastePrice, toothpasteGender, toothpasteIngredients);
            this.dataStore.Products.Add(toothpasteName, toothpaste);

            return string.Format(Constants.ToothpasteCreated, toothpasteName);
        }
    }
}
