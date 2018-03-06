using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Products
{
    class Category : ICategory
    {
        private string name;
        private List<IProduct> productList;

        public Category(string name)
        {
            this.Name = name;
            this.ProductList = new List<IProduct>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException();
                }
                else if(value.Length < 2 || value.Length > 15)
                {
                    throw new Exception("Category name must be between 2 and 15 symbols long!");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public List<IProduct> ProductList { get => productList; set => productList = value; }
        public object StrigBuilder { get; private set; }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.ProductList.Add(cosmetics);
        }


        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (!this.ProductList.Contains(cosmetics))
            {
                throw new ArgumentNullException(string.Format(
                    "Product {0} does not exist in category {1}!", cosmetics, this.Name));
                    
            }
            this.ProductList.Remove(cosmetics);
        }

        public string Print()
        {
            //List<SomeClass> b = a.OrderBy(x => x.x).ThenBy(x => x.y).ToList();
            this.ProductList = this.ProductList.OrderBy(x => x.Brand).ThenByDescending(x => x.Price).ToList();
            StringBuilder sb = new StringBuilder();
            if(this.ProductList.Count() == 0)
            {
                sb.Append(string.Format("{0} category - {1} products in total",
                    this.Name, this.ProductList.Count()));
            }
            else
            {
                if(this.ProductList.Count() == 1)
                {
                    sb.AppendLine(string.Format("{0} category - {1} product in total",
              this.Name, this.ProductList.Count()));
                }
                else
                {
                    sb.AppendLine(string.Format("{0} category - {1} products in total",
              this.Name, this.ProductList.Count()));
                }
                foreach (Product product in this.ProductList)
                {
                    sb.Append(product.Print());
                    sb.AppendLine();
                }
            }   
            return sb.ToString().TrimEnd('\r', '\n');

        }
    }
}


//{category name} category – {number of products} products/product in total
//- {product brand} – {product name}:
//  * Price: ${product price}
//  * For gender: Men/Women/Unisex
//  * Ingredients: {product ingredients, separated by “, “} (when applicable)
//- {product brand} – {product name}:
//  * Price: ${product price}
//  * For gender: {product gender}
//  * Quantity: {product quantity} ml(when applicable)
//  * Usage: EveryDay/Medical(when applicable)

