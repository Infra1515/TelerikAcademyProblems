using Agency.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Models
{
    public class Ticket : ITicket
    {
        private readonly IJourney journey;
        private readonly decimal administrativeCosts;
        public Ticket(IJourney journey, decimal administrativeCosts )
        {
            this.journey = journey ?? throw new ArgumentNullException();
            this.administrativeCosts = administrativeCosts;
        }

        public IJourney Journey => journey;

        public decimal AdministrativeCosts => administrativeCosts;

        public decimal CalculatePrice()
        {
            return this.AdministrativeCosts + this.Journey.CalculateTravelCosts(); 
        }

        public override string ToString()
        {
            return $"Ticket ----\r\nDestination: {this.Journey.Destination}\r\nPrice: {this.CalculatePrice()}";
        }

    }
}
