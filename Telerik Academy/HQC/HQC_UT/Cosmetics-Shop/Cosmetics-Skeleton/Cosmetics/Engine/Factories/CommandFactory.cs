using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Contracts;
using Autofac;

namespace Cosmetics.Engine.Factories
{
    public class CommandFactory : ICommandsFactory
    {
        private readonly IComponentContext container;

        public CommandFactory(IComponentContext container)
        {
            this.container = container;
        }

        public ICommand GetCommand(string commandName)
        {
            return this.container.ResolveNamed<ICommand>(commandName);
        }
    }
}
