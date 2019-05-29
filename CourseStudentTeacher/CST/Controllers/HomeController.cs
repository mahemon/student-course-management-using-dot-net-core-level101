using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CST.Models;
using CST.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CST.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cst = from s in _context.Students
                      join e in _context.StudentEnrollCourses on s.Id equals e.StudentId
                      join c in _context.Course on e.CourseId equals c.Id
                      join t in _context.TeacherEnrollCourses on c.Id equals t.CourseId
                      join te in _context.Teachers on t.TeacherId equals te.Id
                      select (new EnrolledInfo
                      {
                          StudentName = s.Name,
                          StudentId = s.StudentId,
                          CourseName = c.Name,
                          CourseCode = c.CourseCode,
                          TeacherName = te.Name
                      });


            // _context.TeacherEnrollCourses.Include(t => t.Course).Include(t => t.Teacher);
            return View(cst);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
