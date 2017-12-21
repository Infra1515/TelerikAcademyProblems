using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Enums;
using Academy.Models.Utils;

namespace Academy.Models.System.Resources
{
    public class HomeworkResource : Resource
    {
        private readonly DateTime dueDate;
        public HomeworkResource(string name, string url, DateTime currentDate) 
            : base(ResourceType.HomeworkResource, name, url)
        {
            this.dueDate = currentDate.AddDays(7);
        }

        public DateTime DueDate => dueDate;

        public override string ToString()
        {
            return base.ToString() + $"- Due date: {Utilities.DateParser(this.DueDate)}";
        }

    }
}
