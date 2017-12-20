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
        // Always define the type(collection, other classes etc) that have the highest
        // level of abstraction. You must do for two reasons: 1. In order to work with the
        // greatest number of different types - IE: Look at the methods and lists below - Find, Add, Remove etc
        // they all take IFurniture which is the parent class(highest level of abstraction) 
        // If they did not do so you would have to define different methods for each child class
        // resulting in code duplication and wasting time
        // 2. In order to limit the unexpected behaviour and bugs in our program. Example:
        // We defined the furnitures as ICollection because we only need it's properties: 
        // Add, remove, Find, Indexator. This is all we need. Using a IList would give other people
        // and ourselfs a chance to introduce unexpected behaviour and crash the program;
        private readonly string name;
        private readonly string registrationNumber;
        // We can define it as IList(so only we can internally use its functions) and expose it
        // through the property as ICollection which will limit its behaviour to ICollection externally
        private readonly ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            Guard.WhenArgument(name, "name parameter cannot be null").IsNullOrEmpty().Throw();
            Guard.WhenArgument(name.Length, "name paramater must be < 5").IsLessThan(5).Throw();
            this.name = name;
            this.registrationNumber = registrationNumber;
        // even though its defined a List it only has the functions of the type defined in the field - ICollection
            this.furnitures = new List<IFurniture>();


        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Guard.WhenArgument(registrationNumber, "regNumber parameter cannot be null").IsNullOrEmpty().Throw();
                Guard.WhenArgument(registrationNumber.Length, "name paramater must be < 5").IsNotEqual(10).Throw();
                if (!Regex.IsMatch(registrationNumber, "[0-9]{10}"))
                {
                    throw new ArgumentException("Registration number is not valid");
                }

            }
        }

        public string RegistrationNumber => this.registrationNumber;

        // if Furnitures points directly to the Field we are exposing not our methods
        // but the inbuilt Add/Remove/Find of the ICollection; So instead Furnitures properties
        // must point to a shallow copy of the field; => Best practice;
        public ICollection<IFurniture> Furnitures => new List<IFurniture>(this.furnitures);
        //public ICollection<IFurniture> Furnitures => this.furnitures;

        public void Add(IFurniture furniture)
        {
            Guard.WhenArgument(furniture, "furnite parameter cannot be null").IsNull().Throw();
            // when setting the value you must point to the field, not to the property
            // because the property adds the items to the shallow copy and after and not in the original list
            // and after that it calls the original list which is in the same state;
            this.furnitures.Add(furniture);
        }

        public string Catalog()
        {
            var orderedCatalog = this.Furnitures.OrderBy(x => x.Price).ThenBy(x => x.Model);
            var strBuilder = new StringBuilder();
            string s;
            if(orderedCatalog.Count() == 0)
            {
                s = "no furnitures";
            }
            else if(orderedCatalog.Count() == 1)
            {
                s = "1 furniture";
            }
            else
            {
                s = orderedCatalog.Count().ToString() + " " + "furnitures";
            }

            strBuilder.AppendLine(string.Format("{0} - {1} - {2}", this.Name, this.RegistrationNumber, s));
            foreach (IFurniture furniture in orderedCatalog)
            {
                strBuilder.AppendLine(furniture.ToString());
            }
            return strBuilder.ToString().Trim();
        }
        public IFurniture Find(string model)
        {
            var item = this.furnitures.FirstOrDefault(x => x.Model == model);
            return item;

        }

        public void Remove(IFurniture furniture)
        {
            Guard.WhenArgument(furniture, "furnite parameter cannot be null").IsNull().Throw();
            this.furnitures.Remove(furniture);
        }
    }
}
