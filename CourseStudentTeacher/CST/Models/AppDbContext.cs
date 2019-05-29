using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CST.Models;
using CST.ViewModel;

namespace CST.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentEnrollCourse> StudentEnrollCourses { get; set; }
        public DbSet<TeacherEnrollCourse> TeacherEnrollCourses { get; set; }
        public DbSet<CST.Models.Course> Course { get; set; }
        public DbSet<CST.ViewModel.EnrolledInfo> EnrolledInfo { get; set; }
        public DbSet<CST.Models.TeachersAccount> TeachersAccount { get; set; }
    }
}
