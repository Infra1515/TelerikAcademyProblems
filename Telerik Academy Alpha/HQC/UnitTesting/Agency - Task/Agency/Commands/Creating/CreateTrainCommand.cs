using System;
using System.Collections.Generic;
using Agency.Commands.Contracts;
using Agency.Core.Contracts;

namespace Agency.Commands.Creating
{
    public class CreateTrainCommand : CreateCommand
    {


        public CreateTrainCommand(IAgencyFactory factory, IEngine engine)
            : base(factory, engine)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;
            int cartsCount;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
                cartsCount = int.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTrain command parameters.");
            }

            var train = this.Factory.CreateTrain(passengerCapacity, pricePerKilometer, cartsCount);
            this.Engine.Vehicles.Add(train);

            return $"Vehicle with ID {Engine.Vehicles.Count - 1} was created.";
        }
    }
}
