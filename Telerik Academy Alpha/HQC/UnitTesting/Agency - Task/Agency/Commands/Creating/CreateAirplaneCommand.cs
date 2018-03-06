using Agency.Commands.Contracts;
using Agency.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Commands.Creating
{
    public class CreateAirplaneCommand : CreateCommand
    {

        public CreateAirplaneCommand(IAgencyFactory factory, IEngine engine)
            : base(factory, engine)
        {

        }

        public override string Execute(IList<string> parameters)
        {
            int passengerCapacity;
            decimal pricePerKilometer;
            bool hasFreeFood;

            try
            {
                passengerCapacity = int.Parse(parameters[0]);
                pricePerKilometer = decimal.Parse(parameters[1]);
                hasFreeFood = bool.Parse(parameters[2]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateAirplane command parameters.");
            }

            var airplane = this.Factory.CreateAirplane(passengerCapacity, pricePerKilometer, hasFreeFood);
            this.Engine.Vehicles.Add(airplane);

            return $"Vehicle with ID {Engine.Vehicles.Count - 1} was created.";
        }
    }
}
