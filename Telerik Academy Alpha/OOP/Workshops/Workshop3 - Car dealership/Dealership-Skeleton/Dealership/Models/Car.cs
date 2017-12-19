using Bytes2you.Validation;
using Dealership.Common.Enums;
using Dealership.Contracts;

namespace Dealership.Models
{
    public class Car : Vehicle, ICar
    {
        private int seats;

        public Car(string mark, string model, decimal price, int seats)
            : base(4, VehicleType.Car, mark, model, price)
        {
            this.Seats = seats;
        }
        public int Seats
        {
            get
            {
                return this.seats;
            }
            set
            {
                Guard.WhenArgument(value, "seats").IsLessThan(0).IsGreaterThan(10).Throw();
                this.seats = value;
            }
        }
        public override string ToString()
        {
            return base.ToString() + $"    Seats: {this.Seats}\r\n";
        }
    }
}
