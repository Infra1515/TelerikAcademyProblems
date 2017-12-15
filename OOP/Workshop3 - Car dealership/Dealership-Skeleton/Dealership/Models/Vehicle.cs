using Dealership.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Common.Enums;
using Bytes2you.Validation;


namespace Dealership.Models
{
    public abstract class Vehicle : IVehicle
    {
        private readonly int wheels;
        private VehicleType type;
        private string make;
        private string model;
        private IList<IComment> comments;
        private decimal price;

        public Vehicle(int wheels, VehicleType type, string make, string model, decimal price)
        {
            this.wheels = wheels;
            this.Type = type;
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.Comments = new List<IComment>();
        }

        public int Wheels
        {
            get
            {
                return this.wheels;
            }
        }

        public VehicleType Type { get => type; set => type = value; }

        public string Make
        {
            get
            {
                return this.make;
            }
            set
            {
                Guard.WhenArgument(value, "make").IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, "make out of range")
                    .IsLessThan(2)
                    .IsGreaterThan(15)
                    .Throw();

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
                Guard.WhenArgument(value, "model").IsNullOrEmpty().Throw();
                Guard.WhenArgument(value.Length, "model out of range")
                 .IsLessThan(2)
                 .IsGreaterThan(15)
                 .Throw();
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
                Guard.WhenArgument(value, "price").IsLessThan(0).Throw();
                Guard.WhenArgument(value, "price out of range")
                    .IsLessThan(0)
                    .IsGreaterThan(100000)
                    .Throw();
                this.price = value;
            }
        }
        public IList<IComment> Comments { get => comments; set => comments = value; }

        public override string ToString()
        {
            return $"{ this.Type}:\r\n    Make: {this.Make}\r\n" +
                    $"    Model: { this.Model}\r\n" +
                    $"    Wheels: { this.Wheels}\r\n" +
                    $"    Price: ${ this.Price}\r\n";
        }
    }
}
