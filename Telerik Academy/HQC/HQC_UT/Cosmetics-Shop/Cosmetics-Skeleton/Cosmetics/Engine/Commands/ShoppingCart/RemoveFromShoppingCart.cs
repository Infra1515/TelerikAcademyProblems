using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Engine.Commands.ShoppingCart
{
    public class RemoveFromShoppingCart : ICommand
    {
        private readonly IDataStore dataStore;

        public RemoveFromShoppingCart(IDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        public string Execute(IList<string> commandParameters)
        {
            var productToRemoveFromCart = commandParameters[0];
            if (!this.dataStore.Products.ContainsKey(productToRemoveFromCart))
            {
                return string.Format(Constants.ProductDoesNotExist, 
                    productToRemoveFromCart);
            }

            var product = this.dataStore.Products[productToRemoveFromCart];

            if (!this.dataStore.ShoppingCart.ContainsProduct(product))
            {
                return string.Format(Constants.ProductDoesNotExistInShoppingCart,
                    productToRemoveFromCart);
            }

            this.dataStore.ShoppingCart.RemoveProduct(product);

            return string.Format(Constants.ProductRemovedFromShoppingCart,
                productToRemoveFromCart);

        }
    }
}
