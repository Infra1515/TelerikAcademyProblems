using Agency.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Models
{
    public class Journey : IJourney
    {
        private readonly string startLocation;
        private readonly string destination;
        private readonly int distance;
        private readonly IVehicle vehicle;

        public Journey(string startLocation, string destination, int distance, IVehicle vehicle)
        {
            if (string.IsNullOrEmpty(startLocation))
            {
                throw new ArgumentNullException();
            }
            else if(startLocation.Length < 5 || startLocation.Length > 25)
            {
                throw new ArgumentException("The StartingLocation's length cannot be less than" +
                    " 5 or more than 25 symbols long.");
            }

            if (string.IsNullOrEmpty(destination))
            {
                throw new ArgumentNullException();
            }
            else if (destination.Length < 5 || destination.Length > 25)
            {
                throw new ArgumentException("The Destination's length cannot be less than" +
                    " 5 or more than 25 symbols long.");
            }

            if(distance < 5 || distance > 5000)
            {
                throw new ArgumentException("The Distance cannot be less than 5 or more than 5000 kilometers.");
            }

            this.startLocation = startLocation;
            this.destination = destination;
            this.distance = distance;
            this.vehicle = vehicle ?? throw new ArgumentNullException();

        }

        public string StartLocation => startLocation;

        public string Destination => destination;

        public int Distance => distance;

        public IVehicle Vehicle => vehicle;

        public decimal CalculateTravelCosts()
        {
            return this.Distance * this.Vehicle.PricePerKilometer;
        }

        public override string ToString()
        {
            return $"Journey ----\r\nStart location: {this.StartLocation}\r\nDestination: {this.Destination}\r\n" +
                $"Distance: {this.Distance}\r\n" +
                $"Vehicle type: {this.Vehicle.Type}\r\nTravel costs: {this.CalculateTravelCosts()}";
        }
    }

}
