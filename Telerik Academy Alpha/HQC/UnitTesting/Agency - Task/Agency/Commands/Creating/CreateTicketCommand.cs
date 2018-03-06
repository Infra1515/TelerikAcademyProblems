using Agency.Commands.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Core.Contracts;
using Agency.Models.Contracts;

namespace Agency.Commands.Creating
{
    public class CreateTicketCommand : CreateCommand
    {
        public CreateTicketCommand(IAgencyFactory factory, IEngine engine) : base(factory, engine)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            IJourney journey;
            decimal administrativeCosts;

            try
            {
                journey = this.Engine.Journeys[int.Parse(parameters[0])];
                administrativeCosts = decimal.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTicket command parameters.");
            }

            var ticket = this.Factory.CreateTicket(journey, administrativeCosts);
            this.Engine.Tickets.Add(ticket);

            return $"Ticket with ID {Engine.Tickets.Count - 1} was created.";
        }
    }
}
