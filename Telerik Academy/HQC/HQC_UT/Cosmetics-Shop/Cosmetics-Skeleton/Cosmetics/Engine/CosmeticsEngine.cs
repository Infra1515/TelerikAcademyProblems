namespace Cosmetics.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using Cosmetics.Products;

    public sealed class CosmeticsEngine : IEngine
    {

        private readonly IDataStore dataStore;
        private readonly IConsoleRenderer consoleRenderer;
        private readonly ICommandsFactory commandsFactory;

        public CosmeticsEngine(IDataStore dataStore, IConsoleRenderer consoleRenderer,
            ICommandsFactory commandsFactory)
        {
            this.dataStore = dataStore;
            this.commandsFactory = commandsFactory;
            this.consoleRenderer = consoleRenderer;
        }


        public void Start()
        {
            var commandResults = new List<string>();
            foreach (var currentLine in this.consoleRenderer.Input())
            {
                try
                {
                    commandResults.Add(this.ProcessCommand(currentLine));

                }
                catch(Exception ex)
                {
                    commandResults.Add(ex.Message);
                }
            }
            this.consoleRenderer.Output(commandResults);
        }

        private string ProcessCommand(string commandLine)
        {
            var commandParts = commandLine.Split(' ').ToList();

            var commandName = commandParts[0];
            var commandParameters = commandParts.Skip(1).ToList();

            var command = this.commandsFactory.GetCommand(commandName.ToLower());

            return command.Execute(commandParameters);
        }
    }
}

   

    