using Academy.Models.Contracts;
using Academy.Models.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Models
{
    public class Course : ICourse
    {
        private string name;
        private int lecturesPerWeeek;     
        private DateTime startingDate;
        private DateTime endingDate;
        private readonly IList<IStudent> onSiteStudents;
        private readonly IList<IStudent> onLineStudents;
        private readonly IList<ILecture> lectures;

        public Course(string name, int lecturesPerWeek, DateTime startingDate)
        {
            this.Name = name;
            this.LecturesPerWeek = lecturesPerWeek;
            this.StartingDate = startingDate;
            this.EndingDate = startingDate.AddDays(30);
            this.onSiteStudents = new List<IStudent>();
            this.onLineStudents = new List<IStudent>();
            this.lectures = new List<ILecture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException();
                }
                else if (value.Length < 3 || value.Length > 45)
                {
                    throw new ArgumentException("The name of the course must be between 3 and 45 symbols!");
                }
                this.name = value;
            }
        }

        public int LecturesPerWeek
        {
            get
            {
                return this.lecturesPerWeeek;
            }
            set
            {

                if (value < 1 || value > 7)
                {
                    throw new ArgumentException("The number of lectures per week must be between 1 and 7!");
                }
                this.lecturesPerWeeek = value;
            }

        }

        public DateTime StartingDate { get => startingDate; set => startingDate = value; }

        public DateTime EndingDate { get => endingDate; set => endingDate = value; }

        public IList<IStudent> OnsiteStudents => onSiteStudents;

        public IList<IStudent> OnlineStudents => onLineStudents;

        public IList<ILecture> Lectures => lectures;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"* Course\r\n - Name: {this.Name}\r\n - Lectures per week: {this.LecturesPerWeek}\r\n" +
                $" - Starting date: {Utilities.DateParser(this.StartingDate)}\r\n" +
                $" - Ending date: {Utilities.DateParser(this.EndingDate)}\r\n" + 
                $" - Onsite students: {this.OnsiteStudents.Count}\r\n - Online students: {this.OnlineStudents.Count}\r\n" +
                $" - Lectures: \r\n");

            if(lectures.Count == 0)
            {
                sb.AppendLine("  * There are no lectures in this course!");
            }
            else
            {
                foreach(ILecture lecture in lectures)
                {
                    sb.AppendLine(lecture.ToString());
                }
            }

            return sb.ToString();
        }
    }
}






