using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;
using Cosmetics.Contracts;

namespace Cosmetics.Engine.Commands
{
    public class TotalPrice : ICommand
    {
        private readonly IDataStore dataStore;

        public TotalPrice(IDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        public string Execute(IList<string> commandParameters)
        {
            // if commandParams is null ? So what?
            // they are not called inside 
            return string.Format(Constants.TotalPriceInShoppingCart,
                this.dataStore.ShoppingCart.TotalPrice());

        }
    }
}
