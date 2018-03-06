using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Common.Enums;

namespace Dealership.Models
{
    public abstract class Vehicle : IVehicle
    {
        private readonly int wheels;
        private readonly VehicleType type;
        private string make;
        private string model;
        private decimal price;
        private IList<IComment> comments;
        public Vehicle(int wheels, VehicleType type, string make, string model, decimal price )
        {
            this.wheels = wheels;
            this.type = type;
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.comments = new List<IComment>();
        }

        public string Make
        {
            get
            {
                return this.make;
            }
            set
            {
                if(value == null)
                {
                    throw new ArgumentNullException();
                }
                else if (value.Length < 2 || value.Length > 15)
                {
                    throw new Exception("Make must be between 2 and 15 characters long!");
                }
                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                else if (value.Length < 2 || value.Length > 15)
                {
                    throw new Exception("Model must be between 2 and 15 characters long!");
                }
                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if(value < 0 || value > 1000000)
                {
                    throw new Exception("Price must be between 0.0 and 1000000.0!");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            return $" {this.Type}:\r\n  Make: {this.Make}\r\n  Model: {this.Model}\r\n  " +
                $"Price: ${this.Price}\r\n  ";
        }
        public int Wheels { get => wheels; }
        public VehicleType Type { get => type;}
        public IList<IComment> Comments { get => comments; set => comments = value; }
    }
}


