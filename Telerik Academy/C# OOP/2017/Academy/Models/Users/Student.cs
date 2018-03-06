using Academy.Models.Contracts;
using System.Collections.Generic;
using Academy.Models.Utils.Contracts;
using Academy.Models.Enums;

namespace Academy.Models.Users
{
    public class Student : User, IStudent
    {
        private Track track;
        private IList<ICourseResult> courseResults;
        public Student(string username, Track track) : base(username)
        {
            this.Track = track;
            this.CourseResults = new List<ICourseResult>();
        }

        public Track Track { get => track; set => track = value; }
        public IList<ICourseResult> CourseResults { get => courseResults; set => courseResults = value; }

        public override string ToString()
        {
            string s = base.ToString() + $" - Track: {this.Track}\r\n - Course results: \r\n";
            if(this.CourseResults.Count == 0)
            {
                s += $"  * User has no course results!\r\n";
            }
            else
            {
                foreach(ICourseResult courseResult in this.CourseResults)
                {
                    s += courseResult.ToString();
                    s += $"\r\n";
                }
            }
            return s;
        }
    }
}
