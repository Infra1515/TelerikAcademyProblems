namespace Cosmetics.Contracts
{
    using System.Collections.Generic;

    using Cosmetics.Common;

    public interface ICosmeticsFactory
    {
        ICategory CreateCategory(string name);

        IProduct CreateShampoo(string name, string brand, decimal price, string gender, uint milliliters, string usage);

        IToothpaste CreateToothpaste(string name, string brand, decimal price, string gender, IList<string> ingredients);

        IShoppingCart ShoppingCart();
    }
}
