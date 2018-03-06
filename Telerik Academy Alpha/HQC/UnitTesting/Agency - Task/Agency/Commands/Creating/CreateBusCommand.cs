using System;
using System.Collections.Generic;
using Agency.Commands.Contracts;
using Agency.Core.Contracts;

namespace Agency.Commands.Creating
{
    public class CreateBusCommand : CreateCommand
    {

        public CreateBusCommand(IAgencyFactory factory, IEngine engine)
            : base(factory, engine)
        {
            
        }

        public override string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateBus command parameters.");
            }

            var bus = this.Factory.CreateBus(passengerCapacity, pricePerKilometer);
            this.Engine.Vehicles.Add(bus);

            return $"Vehicle with ID {Engine.Vehicles.Count - 1} was created.";
        }

    }
}
