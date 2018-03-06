namespace Cosmetics.Engine.Factories
{
    using System;
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

        public IProduct CreateShampoo(string name, string brand, decimal price, string gender, uint milliliters, string usage)
        {
            Shampoo shampoo = new Shampoo(name, brand, price, this.GetGender(gender),
                milliliters, this.GetUsage(usage));
            return shampoo;
        }

        public IToothpaste CreateToothpaste(string name, string brand, decimal price, string gender, IList<string> ingredients)
        {
            string ingredientsString = string.Join(", ", ingredients);
            Toothpaste toothpaste = new Toothpaste(name, brand, price,
                GetGender(gender), ingredientsString);
            return toothpaste;
        }

        public IShoppingCart ShoppingCart()
        {
            ShoppingCart cart = new ShoppingCart();
            return cart;
        }

        private GenderType GetGender(string genderAsString)
        {
            switch (genderAsString)
            {
                case "men":
                    return GenderType.Men;
                case "women":
                    return GenderType.Women;
                case "unisex":
                    return GenderType.Unisex;
                default:
                    throw new InvalidOperationException(Constants.InvalidGenderType);
            }
        }

        private UsageType GetUsage(string usageAsString)
        {
            switch (usageAsString)
            {
                case "everyday":
                    return UsageType.EveryDay;
                case "medical":
                    return UsageType.Medical;
                default:
                    throw new InvalidOperationException(Constants.InvalidUsageType);
            }
        }

    }
}
