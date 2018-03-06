using Agency.Models.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private readonly int passangerCapacity;
        private readonly VehicleType type;
        private readonly decimal pricePerKilometer;

        public Vehicle(int passangerCapacity, decimal pricePerKilometer, VehicleType type )
        {
            if(passangerCapacity < 1 || passangerCapacity > 800)
            {
                throw new ArgumentException("A vehicle with less than 1 passengers" +
                    " or more than 800 passengers cannot exist!");
            }

            if(pricePerKilometer < 0.10m || pricePerKilometer > 2.50m)
            {
                throw new ArgumentException("A vehicle with a price per kilometer lower than $0.10" +
                    " or higher than $2.50 cannot exist!");
            }
            this.passangerCapacity = passangerCapacity;
            this.pricePerKilometer = pricePerKilometer;
            this.type = type;

        }

        public int PassangerCapacity => passangerCapacity;

        public decimal PricePerKilometer => pricePerKilometer;

        public VehicleType Type { get => type;}

        public override string ToString()
        {
            return $"{this.GetType().Name} ----\r\nPassenger capacity: {this.PassangerCapacity}\r\n" +
                $"Price per kilometer: {this.PricePerKilometer}\r\nVehicle type: {this.Type}";

        }
    }
}




