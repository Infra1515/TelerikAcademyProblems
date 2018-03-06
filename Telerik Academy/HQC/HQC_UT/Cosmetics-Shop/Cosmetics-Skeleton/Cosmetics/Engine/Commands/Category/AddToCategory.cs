using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Engine.Commands.Category
{
    public class AddToCategory : ICommand
    {
        private readonly IDataStore dataStore;
        public AddToCategory(IDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        public string Execute(IList<string> commandParameters)
        {
            var categoryNameToAdd = commandParameters[0];
            var productToAdd = commandParameters[1];

            if (!this.dataStore.Categories.ContainsKey(categoryNameToAdd))
            {
                return string.Format(Constants.CategoryDoesNotExist, categoryNameToAdd);
            }

            if (!this.dataStore.Products.ContainsKey(productToAdd))
            {
                return string.Format(Constants.ProductDoesNotExist, productToAdd);
            }

            //var category = this.dataStore.AddCategory(category);
            //var product = this.dataStore.AddProduct(product)

            var category = this.dataStore.Categories[categoryNameToAdd];
            var product = this.dataStore.Products[productToAdd];

            category.AddCosmetics(product);

            return string.Format(Constants.ProductAddedToCategory, 
                productToAdd, categoryNameToAdd);
        }
    }
}
