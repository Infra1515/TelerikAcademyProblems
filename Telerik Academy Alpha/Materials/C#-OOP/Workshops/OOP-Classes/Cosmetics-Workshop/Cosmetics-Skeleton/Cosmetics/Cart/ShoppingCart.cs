using Bytes2you.Validation;
using Cosmetics.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmetics.Cart
{
    public class ShoppingCart
    {
        private readonly ICollection<Product> productList;

        public ShoppingCart()
        {
        }

        public ICollection<Product> ProductList
        {
            get { return this.productList; }
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void RemoveProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public bool ContainsProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public decimal TotalPrice()
        {
            throw new NotImplementedException();
        }
    }
}
