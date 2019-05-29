using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CST.Models
{
    public class Course
    {
        public Course()
        {
            this.StudentEnrollCourses = new HashSet<StudentEnrollCourse>();
            this.TeacherEnrollCourses = new HashSet<TeacherEnrollCourse>();
        }
        public int Id { get; set; }
        public string CourseCode { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StudentEnrollCourse> StudentEnrollCourses { get; set; }
        public virtual ICollection<TeacherEnrollCourse> TeacherEnrollCourses { get; set; }
    }
}
