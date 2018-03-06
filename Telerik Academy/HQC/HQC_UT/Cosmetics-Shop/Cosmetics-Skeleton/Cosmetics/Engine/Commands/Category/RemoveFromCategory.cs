using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Engine.Commands.Category
{
    public class RemoveFromCategory : ICommand
    {
        private readonly IDataStore dataStore;
        public RemoveFromCategory(ICosmeticsFactory factory, IDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        public string Execute(IList<string> commandParameters)
        {
            var categoryNameToRemove = commandParameters[0];
            var productToRemove = commandParameters[1];

            if (!this.dataStore.Categories.ContainsKey(categoryNameToRemove))
            {
                return string.Format(Constants.CategoryDoesNotExist, categoryNameToRemove);
            }

            if (!dataStore.Products.ContainsKey(productToRemove))
            {
                return string.Format(Constants.ProductDoesNotExist, productToRemove);
            }

            var category = this.dataStore.Categories[categoryNameToRemove];
            var product = this.dataStore.Products[productToRemove];

            category.RemoveCosmetics(product);

            return string.Format(Constants.ProductRemovedCategory, productToRemove,
                categoryNameToRemove);
        }
    }
}
