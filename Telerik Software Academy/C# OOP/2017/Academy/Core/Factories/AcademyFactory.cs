using Academy.Core.Contracts;
using Academy.Core.Providers;
using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.System;
using Academy.Models.System.Resources;
using Academy.Models.Users;
using Academy.Models.Utils.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Core.Factories
{
    public class AcademyFactory : IAcademyFactory
    {
        private static IAcademyFactory instanceHolder = new AcademyFactory();

        // private because of Singleton design pattern
        private AcademyFactory()
        {
        }

        public static IAcademyFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }

        public ISeason CreateSeason(string startingYear, string endingYear, string initiative)
        {
            var parsedStartingYear = int.Parse(startingYear);
            var parsedEngingYear = int.Parse(endingYear);

            Initiative parsedInitiativeAsEnum;
            Enum.TryParse<Initiative>(initiative, out parsedInitiativeAsEnum);

            return new Season(parsedStartingYear, parsedEngingYear, parsedInitiativeAsEnum);
        }

        public IStudent CreateStudent(string username, string track)
        {
            return new Student(username, (Track)Enum.Parse(typeof(Track),track));
        }

        public ITrainer CreateTrainer(string username, string technologies)
        {
            IList<string> stringList = technologies.Split(',').ToList();
            return new Trainer(username, stringList);
        }

        public ICourse CreateCourse(string name, string lecturesPerWeek, string startingDate)
        {
            DateTime myDate = DateTime.ParseExact(startingDate, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            return new Course(name, int.Parse(lecturesPerWeek), myDate);
        }

        public ILecture CreateLecture(string name, string date, ITrainer trainer)
        {
            DateTime myDate = DateTime.ParseExact(date, "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            return new Lecture(name, myDate, trainer);
        }

        public ILectureResource CreateLectureResource(string type, string name, string url)
        {

            switch (type)
            {
                case "video":
                    return new VideoResource(name, url, DateTimeProvider.Now);
                case "presentation":
                    return new PresentationResource(name, url);
                case "demo":
                    return new DemoResource(name, url);
                case "homework":
                    return new HomeworkResource(name, url, DateTimeProvider.Now);
                default:
                    throw new ArgumentException("Invalid lecture resource type");
            }
            
        }

        public ICourseResult CreateCourseResult(ICourse course, string examPoints, string coursePoints)
        {
            return new CourseResult(course, float.Parse(examPoints), float.Parse(coursePoints));
        }
    }
}
