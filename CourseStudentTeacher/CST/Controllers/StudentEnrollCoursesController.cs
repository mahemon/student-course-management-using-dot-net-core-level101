using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CST.Models;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using CST.ViewModel;

namespace CST.Controllers
{
    public class StudentEnrollCoursesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration Configuration;

        public StudentEnrollCoursesController(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }


        // GET: StudentEnrollCourses
        public ActionResult Index()
        {
            List<SECview> sECviewList = new List<SECview>();

            string cs = Configuration.GetConnectionString("DefaultDBConnection");
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select StudentEnrollCourses.Id,Students.Name,Course.Name from Students join StudentEnrollCourses on Students.Id = StudentEnrollCourses.StudentId join Course on StudentEnrollCourses.CourseId = Course.Id;", con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SECview secview = new SECview();

                        secview.id = Convert.ToInt32(reader[0]);
                        secview.Sname = reader[1].ToString();
                        secview.Cname = reader[2].ToString();

                        sECviewList.Add(secview);
                    }
                }

            }

            //var appDbContext = _context.StudentEnrollCourses.Include(s => s.Course).Include(s => s.Student);
            //return View(await appDbContext.ToListAsync());
            return View(sECviewList);
        }


        // GET: StudentEnrollCourses/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name");
            return View();
        }


        [HttpPost]
        public ActionResult Create([Bind("Id,StudentId,CourseId")] StudentEnrollCourse studentEnrollCourse)
        {
            if (ModelState.IsValid)
            {
                string cs = Configuration.GetConnectionString("DefaultDBConnection");
                using (SqlConnection con = new SqlConnection(cs))
                {

                    SqlCommand cmd = new SqlCommand("sp_addStudentToCourse", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@studentid", studentEnrollCourse.StudentId);
                    cmd.Parameters.AddWithValue("@courseid", studentEnrollCourse.CourseId);

                    con.Open();
                    cmd.ExecuteNonQuery();

                }

                //_context.Add(studentEnrollCourse);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name", studentEnrollCourse.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name", studentEnrollCourse.StudentId);
            return View(studentEnrollCourse);
        }

        // GET: StudentEnrollCourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentEnrollCourse = await _context.StudentEnrollCourses.FindAsync(id);
            if (studentEnrollCourse == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name", studentEnrollCourse.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name", studentEnrollCourse.StudentId);
            return View(studentEnrollCourse);
        }


        [HttpPost]
        public ActionResult Edit(int id, [Bind("Id,StudentId,CourseId")] StudentEnrollCourse studentEnrollCourse)
        {
            if (id != studentEnrollCourse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                string cs = Configuration.GetConnectionString("DefaultDBConnection");
                using (SqlConnection con = new SqlConnection(cs))
                {

                    SqlCommand cmd = new SqlCommand("update StudentEnrollCourses set StudentId = @sid, CourseId = @cid where Id = @id; ", con);

                    cmd.Parameters.AddWithValue("@sid", studentEnrollCourse.StudentId);
                    cmd.Parameters.AddWithValue("@cid", studentEnrollCourse.CourseId);
                    cmd.Parameters.AddWithValue("@id", studentEnrollCourse.Id);
                    con.Open();
                    cmd.ExecuteNonQuery();

                }
                //_context.Update(studentEnrollCourse);
                //await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name", studentEnrollCourse.CourseId);
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Name", studentEnrollCourse.StudentId);
            return View(studentEnrollCourse);
        }

        // GET: StudentEnrollCourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentEnrollCourse = await _context.StudentEnrollCourses
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentEnrollCourse == null)
            {
                return NotFound();
            }

            return View(studentEnrollCourse);
        }

        // POST: StudentEnrollCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            string cs = Configuration.GetConnectionString("DefaultDBConnection");
            using (SqlConnection con = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand("DELETE FROM StudentEnrollCourses WHERE StudentEnrollCourses.Id=@id;", con);

                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            return RedirectToAction(nameof(Index));
        }

    }
}
