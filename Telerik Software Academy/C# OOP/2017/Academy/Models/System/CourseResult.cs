using Academy.Models.Contracts;
using Academy.Models.Utils.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Models.Enums;

namespace Academy.Models.System
{
    public class CourseResult : ICourseResult
    {
        private readonly ICourse course;
        private readonly float examPoints;
        private readonly float coursePoints;
        private readonly Grade grade;

        public CourseResult(ICourse course, float examPoints, float coursePoints)
        {
            if (examPoints < 0 || examPoints > 1000)
            {
                throw new ArgumentException("Course result's exam points should be between 0 and 1000!");
            }

            if (coursePoints < 0 || coursePoints > 125)
            {
                throw new ArgumentNullException("Course result's course points should be between 0 and 125!");
            }

            if (examPoints >= 65 || coursePoints >= 75)
            {
                this.grade = Grade.Excellent;
            }
            else if (examPoints < 60 && examPoints >= 30 || coursePoints < 75 && coursePoints >= 45)
            {
                this.grade = Grade.Passed;
            }
            else
            {
                this.grade = Grade.Failed;
            }

            this.course = course;
            this.examPoints = examPoints;
            this.coursePoints = coursePoints;
        }

        public ICourse Course => course;

        public float ExamPoints => examPoints;

        public float CoursePoints { get => coursePoints; }

        public Grade Grade => grade;

        public override string ToString()
        {
            return $"*  {this.Course.Name}: Points - {this.CoursePoints}, Grade - {this.Grade}";
        }
    }
}


