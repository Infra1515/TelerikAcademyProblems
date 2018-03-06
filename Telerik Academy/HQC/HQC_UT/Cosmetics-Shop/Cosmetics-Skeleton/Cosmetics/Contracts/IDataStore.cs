using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Contracts
{
    public interface IDataStore
    {
        IDictionary<string, ICategory> Categories { get; }
        IShoppingCart ShoppingCart { get; }
        IDictionary<string, IProduct> Products { get; }

        void AddCategory(ICategory category);
        void AddProduct(IProduct product);


    }
}
