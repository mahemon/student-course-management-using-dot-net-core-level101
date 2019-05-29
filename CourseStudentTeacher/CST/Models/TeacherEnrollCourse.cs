using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CST.Models
{
    public class TeacherEnrollCourse
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }

        public Teacher Teacher { get; set; }
        public Course Course { get; set; }


    }
}
