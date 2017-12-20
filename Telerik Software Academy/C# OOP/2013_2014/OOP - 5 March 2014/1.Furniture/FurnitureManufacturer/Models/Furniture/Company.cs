using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FurnitureManufacturer.Models.Furniture
{
    public class Company : ICompany
    {
        //    The modifier readonly means that the value cannot be assigned except
        //    in the declaration or constructor.It does not mean that the assigned object becomes immutable.
        private string name;
        private string registrationNumber;
        private readonly ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
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
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                this.name = value;

            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                if (!Regex.IsMatch(value, "[0-9]{10}"))
                {
                    throw new Exception("Company name cannot < || > 10 and can" +
                        "and cannot contain digits");
                }
                this.registrationNumber = value;

            }
        }

        public ICollection<IFurniture> Furnitures => new List<IFurniture>(furnitures);

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public string Catalog()
        {
            var orderedFurnitures = this.furnitures.OrderBy(x => x.Price).ThenBy(x => x.Model);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("{0} - {1} - {2} {3}",
                        this.Name,
                        this.RegistrationNumber,
                        this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                        this.Furnitures.Count != 1 ? "furnitures" : "furniture")); 
            foreach(IFurniture furniture in orderedFurnitures)
            {
                sb.AppendLine(furniture.ToString());
            }

            return sb.ToString().Trim();
        }

        public IFurniture Find(string model)
        {
            var item = this.furnitures.FirstOrDefault(x => x.Model == model);
            return item;
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }
    }
}
