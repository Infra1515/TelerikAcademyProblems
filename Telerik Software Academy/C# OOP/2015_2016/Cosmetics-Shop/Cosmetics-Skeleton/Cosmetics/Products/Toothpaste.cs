using Cosmetics.Common;
using Cosmetics.Contracts;
using System;

namespace Cosmetics.Products
{
    public class Toothpaste : Product, IToothpaste
    {

        private string ingredients;
        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients) :
            base(name, brand, price, gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
            this.Ingredients = ingredients;
         
        }
        public string Ingredients
        {
            get
            {
                return this.ingredients;
            }
            set
            {
                var ingrList = value.Split(',');
                foreach(string s in ingrList)
                {
                    if (s.Length < 4 || s.Length > 12)
                    {
                        throw new Exception("Each ingredient must be between 4 and 12 symbols long!");
                    }
                }
                this.ingredients = value;
            }
        }

        public override string Print()
        {
            return base.Print() + $"* Ingredients: {this.Ingredients}";
        }
    }
}
