using Agency.Models.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Models.Vehicles
{
    public class Train : Vehicle, ITrain
    {
        private readonly int carts;
        public Train(int passangerCapacity, decimal pricePerKilometer, int carts)
            : base(passangerCapacity, pricePerKilometer, VehicleType.Land)
        {
            if(carts < 1 || carts > 15)
            {
                throw new ArgumentException("A train cannot have less than 1 cart or more than 15 carts.");
            }
            if(passangerCapacity < 30 || passangerCapacity > 150)
            {
                throw new ArgumentException("A train cannot have less than 30 passengers" +
                    " or more than 150 passengers.");
            }
            this.carts = carts;
        }

        public int Carts => carts;

        public override string ToString()
        {
            return base.ToString() + $"\r\nCarts amount: {this.Carts}";
        }
    }
}
