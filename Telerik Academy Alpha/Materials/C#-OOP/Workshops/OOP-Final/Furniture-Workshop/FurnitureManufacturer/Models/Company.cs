using Bytes2you.Validation;
using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace FurnitureManufacturer.Models
{
    // Finish the class
    public class Company : ICompany
    {
        private readonly string name;
        private readonly string registrationNumber;
        private readonly ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
        }

        public string Name => this.name;

        public string RegistrationNumber => this.registrationNumber;

        public ICollection<IFurniture> Furnitures => this.furnitures;

        public void Add(IFurniture furniture)
        {
        }

        public string Catalog()
        {
            var strBuilder = new StringBuilder();
            // Finish it

            return strBuilder.ToString().Trim();
        }

        public IFurniture Find(string model)
        {
            return null;
        }

        public void Remove(IFurniture furniture)
        {
        }
    }
}
