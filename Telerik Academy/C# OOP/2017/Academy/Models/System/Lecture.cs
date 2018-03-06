using Academy.Models.Contracts;
using Academy.Models.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models.System
{
    public class Lecture : ILecture
    {

        private string name;
        private DateTime date;
        private ITrainer trainer;
        private readonly IList<ILectureResource> resources;


        public Lecture(string name, DateTime date, ITrainer trainer)
        {

            this.Name = name;
            this.Date = date;
            this.Trainer = trainer;
            this.resources = new List<ILectureResource>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length < 5 || value.Length > 30)
                {
                    throw new ArgumentNullException("Lecture's name should be between 5 and 30 symbols long!");
                }
                this.name = value;
            }
        }
        public DateTime Date { get => date; set => date = value; }
        public ITrainer Trainer { get => trainer; set => trainer = value; }
        public IList<ILectureResource> Resources { get => resources; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($" * Lecture:\r\n   - Name: {this.Name}\r\n" +
                $"   - Date: {Utilities.DateParser(this.Date)}\r\n   - Trainer username: {this.Trainer.Username}\r\n" +
                $"   - Resources:");
            if (this.Resources.Count == 0)
            {
                sb.Append("    * There are no resources in this lecture.");

            }
            else
            {
                foreach( ILectureResource rs in this.Resources)
                {
                    sb.Append(rs.ToString());
                }
            }

            return sb.ToString();
        }
    }
}


