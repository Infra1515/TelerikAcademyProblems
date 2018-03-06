using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Contracts;
using Cosmetics.Products;

namespace Cosmetics.Engine
{
    public class DataStore : IDataStore
    {
        private readonly IDictionary<string, ICategory> categories;
        private readonly IDictionary<string, IProduct> products;
        private readonly IShoppingCart shoppingCart;

        public DataStore()
        {
            this.categories = new Dictionary<string, ICategory>();
            this.products = new Dictionary<string, IProduct>();
            this.shoppingCart = new ShoppingCart();

        }

        public IDictionary<string, ICategory> Categories => 
            new Dictionary<string, ICategory> (categories);

        public IDictionary<string, IProduct> Products =>
           new Dictionary<string, IProduct>(products);

        public IShoppingCart ShoppingCart =>
            this.shoppingCart;

        public void AddCategory(ICategory category)
        {
            if(string.IsNullOrEmpty(category.Name))
            {
                throw new ArgumentNullException("Category cannot be null!");
            }
            this.categories.Add(category.Name, category);
        }

        public void AddProduct(IProduct product)
        {
            if (string.IsNullOrEmpty(product.Name))
            {
                throw new ArgumentNullException("Product cannot be null!");
            }

            this.products.Add(product.Name, product);
        }
    }
}
