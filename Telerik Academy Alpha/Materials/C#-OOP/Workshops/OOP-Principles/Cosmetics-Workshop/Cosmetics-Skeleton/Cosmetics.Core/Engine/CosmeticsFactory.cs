using Cosmetics.Cart;
using Cosmetics.Common;
using Cosmetics.Contracts;
using Cosmetics.Products;
using System;
using System.Collections.Generic;

namespace Cosmetics.Core.Engine
{
    public class CosmeticsFactory : ICosmeticsFactory
    {
        public ICategory CreateCategory(string name)
        {
            return null;
        }

        public Shampoo CreateShampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
        {
            return null;
        }

        public Toothpaste CreateToothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
        {
            return null;
        }

        public ShoppingCart CreateShoppingCart()
        {
            return null;
        }
    }
}
