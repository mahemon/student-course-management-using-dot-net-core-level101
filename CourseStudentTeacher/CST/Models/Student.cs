using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CST.Models
{
    public class Student
    {
        public Student()
        {
            this.StudentEnrollCourses = new HashSet<StudentEnrollCourse>();
        }
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }

        public ICollection<StudentEnrollCourse> StudentEnrollCourses { get; set; }

    }
}
