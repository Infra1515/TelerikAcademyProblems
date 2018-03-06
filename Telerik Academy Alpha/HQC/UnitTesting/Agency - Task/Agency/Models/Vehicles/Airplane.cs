using Agency.Models.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.Vehicles
{
    public class Airplane : Vehicle, IAirplane
    {
        private readonly bool hasFreeFood;
        public Airplane(int passangerCapacity, decimal pricePerKilometer, bool hasFreeFood)
            : base(passangerCapacity, pricePerKilometer, VehicleType.Air)
        {
            this.hasFreeFood = hasFreeFood;
        }

        public bool HasFreeFood { get => hasFreeFood;}

        public override string ToString()
        {
            return base.ToString() + $"\r\nHas free food: {this.HasFreeFood}";
        }
    }

}
