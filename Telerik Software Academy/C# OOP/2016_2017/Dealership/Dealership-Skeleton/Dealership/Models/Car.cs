using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Common.Enums;

namespace Dealership.Models
{
    public class Car : Vehicle
    {
        private int seats;

        public Car(string make, string model, decimal price, int seats)
            : base(4, VehicleType.Car, make, model, price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.Seats = seats;
        }
        public int Seats
        {
            get { return seats; }
            set
            {
                if (value < 1 || value > 10)
                {
                    throw new Exception("Seats must be between 1 and 10!");
                }
                this.seats = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() + $"Seats: {this.Seats}\r\n";
        }

    }
}

