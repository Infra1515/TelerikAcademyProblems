using Agency.Commands.Contracts;
using Agency.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.Commands.Creating
{
    public abstract class CreateCommand : ICommand
    {
        private readonly IAgencyFactory factory;
        private readonly IEngine engine;

        public CreateCommand(IAgencyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public IAgencyFactory Factory => factory;

        public IEngine Engine => engine;

        public abstract string Execute(IList<string> parameters);
    }
}
