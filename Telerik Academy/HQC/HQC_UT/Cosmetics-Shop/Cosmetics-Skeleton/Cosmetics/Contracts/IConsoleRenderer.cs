using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Contracts
{
    public interface IConsoleRenderer
    {
        IEnumerable<string> Input();

        void Output(IEnumerable<string> reports);
    }
}
