using System;
using System.Collections.Generic;
using Agency.Commands.Contracts;
using Agency.Core.Contracts;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Commands.Creating
{
    public class CreateJourneyCommand : CreateCommand
    {
        public CreateJourneyCommand(IAgencyFactory factory, IEngine engine)
            : base(factory, engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            string startLocation;
            string destination;
            int distance;
            IVehicle vehicle;

            try
            {
                startLocation = parameters[0];
                destination = parameters[1];
                distance = int.Parse(parameters[2]);
                vehicle = this.Engine.Vehicles[int.Parse(parameters[3])];
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateJourney command parameters.");
            }

            var journey = this.Factory.CreateJourney(startLocation, destination, distance, vehicle);
            this.Engine.Journeys.Add(journey);

            return $"Journey with ID {Engine.Journeys.Count - 1} was created.";
        }

    }
}
