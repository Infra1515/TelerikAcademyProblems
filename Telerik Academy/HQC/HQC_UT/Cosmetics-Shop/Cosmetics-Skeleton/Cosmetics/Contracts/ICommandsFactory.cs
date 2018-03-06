using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Contracts
{
    public interface ICommandsFactory
    {
        ICommand GetCommand(string commandName);
    }
}
