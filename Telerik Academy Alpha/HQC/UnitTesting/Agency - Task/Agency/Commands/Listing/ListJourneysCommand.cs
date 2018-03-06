using System;
using System.Collections.Generic;
using Agency.Commands.Contracts;
using Agency.Core.Contracts;

namespace Agency.Commands.Creating
{
    public class ListJourneysCommand : CreateCommand
    {
        public ListJourneysCommand(IAgencyFactory factory, IEngine engine)
            : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var journeys = this.Engine.Journeys;

            if (journeys.Count == 0)
            {
                return "There are no registered journeys.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, journeys);
        }
    }
}
