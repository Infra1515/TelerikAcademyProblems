using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtMethodsAndOtherHomeWork.LINQ
{
    public class StudentTest
    {
        public StudentTest()
        {
        }

        public IList<Student> AddStudents()
        {
             var studentList = new List<Student>();

            var student1 = new Student("Atanas", "Qvorov", 28, 2569, "088484848",
                "coolguy@abv.bg", 1);

            var student2 = new Student("Boyko", "Minchev", 22, 2999, "0889239494",
                "mashinata@sofia-university.com",2);
            
            var student3 = new Student("Lubomir", "Atanasov", 23, 2793, "0881236552",
                "trepach@abv.bg", 3);

            studentList.Add((student1));
            studentList.Add((student2));
            studentList.Add((student3));

            return studentList;

        }
    }
}
