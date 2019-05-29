using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CST.Models;

namespace CST.Controllers
{
    public class TeacherEnrollCoursesController : Controller
    {
        private readonly AppDbContext _context;

        public TeacherEnrollCoursesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TeacherEnrollCourses
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.TeacherEnrollCourses.Include(t => t.Course).Include(t => t.Teacher);
            return View(await appDbContext.ToListAsync());
        }


        // GET: TeacherEnrollCourses/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name");
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Name");
            return View();
        }

        // POST: TeacherEnrollCourses/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,TeacherId,CourseId")] TeacherEnrollCourse teacherEnrollCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherEnrollCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name", teacherEnrollCourse.CourseId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Name", teacherEnrollCourse.TeacherId);
            return View(teacherEnrollCourse);
        }

        // GET: TeacherEnrollCourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherEnrollCourse = await _context.TeacherEnrollCourses.FindAsync(id);
            if (teacherEnrollCourse == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name", teacherEnrollCourse.CourseId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Name", teacherEnrollCourse.TeacherId);
            return View(teacherEnrollCourse);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeacherId,CourseId")] TeacherEnrollCourse teacherEnrollCourse)
        {
            if (id != teacherEnrollCourse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherEnrollCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherEnrollCourseExists(teacherEnrollCourse.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Name", teacherEnrollCourse.CourseId);
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Name", teacherEnrollCourse.TeacherId);
            return View(teacherEnrollCourse);
        }

        // GET: TeacherEnrollCourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teacherEnrollCourse = await _context.TeacherEnrollCourses
                .Include(t => t.Course)
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherEnrollCourse == null)
            {
                return NotFound();
            }

            return View(teacherEnrollCourse);
        }

        // POST: TeacherEnrollCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teacherEnrollCourse = await _context.TeacherEnrollCourses.FindAsync(id);
            _context.TeacherEnrollCourses.Remove(teacherEnrollCourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherEnrollCourseExists(int id)
        {
            return _context.TeacherEnrollCourses.Any(e => e.Id == id);
        }
    }
}
