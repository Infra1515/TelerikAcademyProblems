using System.Collections.Generic;
using Agency.Core.Contracts;
using System;

namespace Agency.Commands.Creating
{
    public class ListVehiclesCommand : CreateCommand
    {
        public ListVehiclesCommand(IAgencyFactory factory, IEngine engine)
            : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var vehicles = this.Engine.Vehicles;

            if (vehicles.Count == 0)
            {
                return "There are no registered vehicles.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, vehicles);
        }
    }
}
