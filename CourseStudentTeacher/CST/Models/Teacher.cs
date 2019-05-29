using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CST.Models
{
    public class Teacher
    {
        public Teacher()
        {
            TeacherEnrollCourses = new HashSet<TeacherEnrollCourse>();
            TeachersAccount = new HashSet<TeachersAccount>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<TeacherEnrollCourse> TeacherEnrollCourses { get; set; }
        public ICollection<TeachersAccount> TeachersAccount { get; set; }
    }
}
