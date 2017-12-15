using Cosmetics.Contracts;
using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Products
{
    class ShoppingCart : IShoppingCart
    {
        public ShoppingCart()
        {
            this.CartList = new List<IProduct>();
        }

        public List<IProduct> CartList { get; set; }

        public void AddProduct(IProduct product)
        {
            this.CartList.Add(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            return this.CartList.Contains(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.CartList.Remove(product);
        }

        public decimal TotalPrice()
        {
            decimal totalSum = 0;
            foreach(IProduct product in this.CartList)
            {
                totalSum += product.Price;         
            }
            return totalSum;
        }
    }
}
