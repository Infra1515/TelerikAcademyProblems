namespace Cosmetics.Engine
{
    using System.Collections.Generic;
    using System.Linq;
    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using Cosmetics.Products;

    public class CosmeticsFactory : ICosmeticsFactory
    {
        public ICategory CreateCategory(string name)
        {
            Category category = new Category(name);
            return category;

        }

        public IProduct CreateShampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
        {
            Shampoo shampoo = new Shampoo(name, brand, price, gender, milliliters, usage);
            return shampoo;
        }

        public IToothpaste CreateToothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
        {
            string ingredientsString = string.Join(", ", ingredients);
            Toothpaste toothpaste = new Toothpaste(name, brand, price, gender, ingredientsString);
            return toothpaste;
        }

        public IShoppingCart ShoppingCart()
        {
            ShoppingCart cart = new ShoppingCart();
            return cart;
        }

    }
}
