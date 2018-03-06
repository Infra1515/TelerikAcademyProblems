using System;
using System.Collections.Generic;
using System.Linq;
using Cosmetics.Contracts;
using Cosmetics.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Cosmetics.Test.Engine
{
    [TestClass]
    public class Start_Should
    {
        [TestMethod]
        public void CallCreateCommandFactory_WithCorrectCommandParameters()
        {
            // Arrange
            var dataMock = new Mock<IDataStore>();
            var rendererMock = new Mock<IConsoleRenderer>();
            var factoryMock = new Mock<ICommandsFactory>();

            rendererMock.Setup(x => x.Input())
                .Returns(new List<string> { "somecommand some parameters" });
            var commandNameStub = "somecommand";

            // Act
            var sut = new CosmeticsEngine(dataMock.Object,
                rendererMock.Object, factoryMock.Object);
            sut.Start();
            // Assert
            factoryMock.Verify(x => x.GetCommand(commandNameStub), Times.Once);
        }

        [TestMethod]
        public void CallExecuteCommand_WithCorrectParameters()
        {
            // Arrange
            var commandLine = "somecommand some parameters";
            var commandName = commandLine.Split()[0];
            var commandParams = commandLine.Split().Skip(1).ToList();
            var dataMock = new Mock<IDataStore>();
            var rendererMock = new Mock<IConsoleRenderer>();
            var factoryMock = new Mock<ICommandsFactory>();
            var commandMock = new Mock<ICommand>();

            rendererMock.Setup(x => x.Input())
                .Returns(new List<string> { commandLine });

            factoryMock.Setup(x => x.GetCommand(It.IsAny<string>()))
                .Returns(commandMock.Object);

            // act
            var sut = new CosmeticsEngine(dataMock.Object,
                rendererMock.Object, factoryMock.Object);
            sut.Start();

            // assert
            commandMock.Verify(x => x.Execute(commandParams), Times.Once);
        }

        [TestMethod]
        public void ReturnCorrectResultFromExecuteCommand_WithCorrectCommandParameters()
        {
            // Arrange
            var commandLine = "somecommand some parameters";
            var expectedMessage = "Success!";
            var commandName = commandLine.Split()[0];
            var commandParams = commandLine.Split().Skip(1).ToList();
            var dataMock = new Mock<IDataStore>();
            var rendererMock = new Mock<IConsoleRenderer>();
            var factoryMock = new Mock<ICommandsFactory>();
            var commandMock = new Mock<ICommand>();

            rendererMock.Setup(x => x.Input())
                .Returns(new List<string> { commandLine });

            factoryMock.Setup(x => x.GetCommand(It.IsAny<string>()))
                .Returns(commandMock.Object);

            commandMock.Setup(x => x.Execute(commandParams))
                .Returns(expectedMessage);

            // act
            var sut = new CosmeticsEngine(dataMock.Object,
                rendererMock.Object, factoryMock.Object);
            sut.Start();
            var actualMessage = commandMock.Object.Execute(commandParams);

            // Assert
            var outputList = new List<string>() { expectedMessage };


            rendererMock.Verify(x => x.Output(outputList), Times.Once);
        }
    }
}
