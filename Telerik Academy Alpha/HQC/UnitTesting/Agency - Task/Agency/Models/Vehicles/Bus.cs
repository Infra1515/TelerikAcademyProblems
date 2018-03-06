using Agency.Models.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.Vehicles
{
    public class Bus : Vehicle, IBus
    {
        public Bus(int passangerCapacity, decimal pricePerKilometer)
            : base(passangerCapacity, pricePerKilometer, VehicleType.Land)
        {
            if(passangerCapacity < 10 || passangerCapacity > 50)
            {
                throw new ArgumentException("A bus cannot have less than 10 passengers" +
                    " or more than 50 passengers.");
            }
        }
    }
}
