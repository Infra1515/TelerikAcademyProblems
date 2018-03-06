using System;
using System.Collections.Generic;
using Agency.Commands.Creating;
using Agency.Core.Contracts;
using Agency.Models.Vehicles.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
namespace Agency.Tests.Command.Creating.CreateAirplane
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void SaveObjectToEngine_WhenInvoked()
        {
            // arrange
            var factoryMock = new Mock<IAgencyFactory>();
            var engineMock = new Mock<IEngine>();
            var airplaneMock = new Mock<IAirplane>();
            var vehicleList = new List<IVehicle>();

            factoryMock.Setup(x => x.CreateAirplane(250, 1, true)).Returns(airplaneMock.Object);
            engineMock.Setup(x => x.Vehicles).Returns(vehicleList);

            var parameters = new List<string>()
            {
                "250",
                "1",
                "true;"
            };
            var sut = new CreateAirplaneCommand(factoryMock.Object, engineMock.Object);

            // act
            var actualMessage = sut.Execute(parameters);
            // assert
            Assert.IsTrue(vehicleList.Contains(airplaneMock.Object));
        }
    }
}
