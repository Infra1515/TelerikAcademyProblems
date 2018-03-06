using FurnitureManufacturer.Engine.Factories;
using FurnitureManufacturer.Commands;
using FurnitureManufacturer.Commands.Create;
using FurnitureManufacturer.Interfaces;
using FurnitureManufacturer.Interfaces.Engine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FurnitureManufacturer.Engine
{
    public sealed class FurnitureManufacturerEngine : IFurnitureManufacturerEngine
    {
        // no need of singleton
        //private static IFurnitureManufacturerEngine instance;

        private readonly ICompanyFactory companyFactory;
        private readonly IFurnitureFactory furnitureFactory;

        // if its from .NET should I inject?
        private readonly IDictionary<string, ICompany> companies;
        private readonly IDictionary<string, IFurniture> furnitures;

        private readonly IRenderer renderer;

        // dependency injection

        public FurnitureManufacturerEngine
            (
            ICompanyFactory companyFactory,
            IFurnitureFactory furnitureFactory,
            IRenderer renderer
            )
        {
            this.companyFactory = companyFactory;
            this.furnitureFactory = furnitureFactory;
            this.renderer = renderer;
            this.companies = new Dictionary<string, ICompany>();
            this.furnitures = new Dictionary<string, IFurniture>();
        }

        
        // separate Read/Write command in a separate module that will be injected
        public void Start()
        {
            var commandResults = new List<string>();

            try
            {
                var commands = this.ReadCommands();
                commandResults = this.ProcessCommands(commands).ToList();
            }
            catch (Exception ex)
            {
                commandResults.Add(ex.Message);
            }

            this.RenderCommandResults(commandResults);

        }

        private ICollection<ICommand> ReadCommands()
        {
            var commands = new List<ICommand>();
            foreach (var currentLine in this.renderer.Input())
            {
                var currentCommand = Command.Parse(currentLine);
                commands.Add(currentCommand);
            }

            return commands;
        }

        private IEnumerable<string> ProcessCommands(ICollection<ICommand> commands)
        {
            var commandResults = new List<string>();

            foreach (var command in commands)
            {
                string commandResult;

                switch (command.Name)
                {
                    case EngineConstants.CreateCompanyCommand:
                        var companyName = command.Parameters[0];
                        var companyRegistrationNumber = command.Parameters[1];
                        commandResult = CreateCompany.CreateCompanyMethod
                            (companyName, companyRegistrationNumber,
                             this.companyFactory, this.companies);
                        commandResults.Add(commandResult);
                        break;
                    case EngineConstants.AddFurnitureToCompanyCommand:
                        var companyToAddTo = command.Parameters[0];
                        var furnitureToBeAdded = command.Parameters[1];
                        commandResult = AddFurnitureToCompany.AddFurnitureToCompanyMethod(
                            companyToAddTo,
                            furnitureToBeAdded,
                            this.companies,
                            this.furnitures
                            );
                        commandResults.Add(commandResult);
                        break;
                    case EngineConstants.RemoveFurnitureFromCompanyCommand:
                        var companyToRemoveFrom = command.Parameters[0];
                        var furnitureToBeRemoved = command.Parameters[1];
                        commandResult = RemoveFurnitureFromCompany.RemoveFurnitureFromCompanyMethod(
                            companyToRemoveFrom,
                            furnitureToBeRemoved,
                            companies, furnitures);
                        commandResults.Add(commandResult);
                        break;
                    case EngineConstants.FindFurnitureFromCompanyCommand:
                        var companyToFindFrom = command.Parameters[0];
                        var furnitureToBeFound = command.Parameters[1];
                        commandResult = this.FindFurnitureFromCompany(companyToFindFrom, furnitureToBeFound);
                        commandResults.Add(commandResult);
                        break;
                    case EngineConstants.ShowCompanyCatalogCommand:
                        var companyToShowCatalog = command.Parameters[0];
                        commandResult = this.ShowCompanyCatalog(companyToShowCatalog);
                        commandResults.Add(commandResult);
                        break;
                    case EngineConstants.CreateTableCommand:
                        var tableModel = command.Parameters[0];
                        var tableMaterial = command.Parameters[1];
                        var tablePrice = decimal.Parse(command.Parameters[2]);
                        var tableHeight = decimal.Parse(command.Parameters[3]);
                        var tableLength = decimal.Parse(command.Parameters[4]);
                        var tableWidth = decimal.Parse(command.Parameters[5]);
                        commandResult = this.CreateTable(tableModel, tableMaterial, tablePrice, tableHeight, tableLength, tableWidth);
                        commandResults.Add(commandResult);
                        break;
                    case EngineConstants.CreateChairCommand:
                        var chairModel = command.Parameters[0];
                        var chairMaterial = command.Parameters[1];
                        var chairPrice = decimal.Parse(command.Parameters[2]);
                        var chairHeight = decimal.Parse(command.Parameters[3]);
                        var chairLegs = int.Parse(command.Parameters[4]);
                        commandResult = this.CreateChair(chairModel, chairMaterial, chairPrice, chairHeight, chairLegs);
                        commandResults.Add(commandResult);
                        break;
                    default:
                        commandResults.Add(string.Format(EngineConstants.InvalidCommandErrorMessage, command.Name));
                        break;
                }
            }

            return commandResults;
        }

        private void RenderCommandResults(IEnumerable<string> output)
        {
            this.renderer.Output(output);
        }

    }
}
