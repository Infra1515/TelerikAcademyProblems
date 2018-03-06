using Bytes2you.Validation;
using Cosmetics.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmetics
{
    public class Category
    {
        private readonly string name;
        private readonly List<Product> products;

        public Category(string name)
        {
        }

        public List<Product> Products
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public virtual void AddProduct(Product product)
        {
            throw new NotImplementedException();

        }

        public virtual void RemoveProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public string Print()
        {
            var strBuilder = new StringBuilder();

            foreach (var product in this.products)
            {
                strBuilder.AppendLine(product.Print());
            }

            throw new NotImplementedException();
        }
    }
}
