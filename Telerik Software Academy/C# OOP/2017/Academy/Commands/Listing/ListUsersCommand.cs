using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Models.Users;
using System.Collections.Generic;
using System.Text;

namespace Academy.Commands.Listing
{
    public class ListUsersCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IEngine engine;

        public ListUsersCommand(IAcademyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string ListUser()
        {
            StringBuilder sb = new StringBuilder();
            var students = this.engine.Students;
            var trainers = this.engine.Trainers;

            foreach(Trainer trainer in trainers)
            {
                sb.AppendLine(trainer.ToString());
            }
            foreach(Student student in students)
            {
                sb.Append(student.ToString());
            }
            if (sb.ToString().Equals(""))
            {
                return $"There are no registered users!";
            }
            return sb.ToString().Trim();         
        }
        public string Execute(IList<string> parameters)
        {
            return ListUser();
        }

    }
}
