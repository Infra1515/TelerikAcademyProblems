using System;
using System.Collections.Generic;
using System.Linq;
using Agency.Commands.Contracts;
using Agency.Core.Contracts;

namespace Agency.Commands.Creating
{
    public class ListTicketsCommand : CreateCommand
    {
        public ListTicketsCommand(IAgencyFactory factory, IEngine engine) : 
            base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var tickets = this.Engine.Tickets;

            if (tickets.Count == 0)
            {
                return "There are no registered tickets.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, tickets);
        }
    }
}
