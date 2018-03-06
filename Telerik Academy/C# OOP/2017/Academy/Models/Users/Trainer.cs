using Academy.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.Users
{
    class Trainer : User, ITrainer
    {
        private IList<string> technologies;
        public Trainer(string username, IList<string> technologies ) : base(username)
        {
            this.Technologies = technologies;
        }
        public IList<string> Technologies { get => technologies; set => technologies = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append(" - Technologies: " + string.Join("; ", this.Technologies));
            return sb.ToString();
        }
    }
}
