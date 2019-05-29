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
    public class TeachersAccountsController : Controller
    {
        private readonly AppDbContext _context;

        public TeachersAccountsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TeachersAccounts
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.TeachersAccount.Include(t => t.Teacher);
            return View(await appDbContext.ToListAsync());
        }

        // GET: TeachersAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachersAccount = await _context.TeachersAccount
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teachersAccount == null)
            {
                return NotFound();
            }

            return View(teachersAccount);
        }

        // GET: TeachersAccounts/Create
        public IActionResult Create()
        {
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id");
            return View();
        }

        // POST: TeachersAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeacherId,accountType,amount")] TeachersAccount teachersAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teachersAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id", teachersAccount.TeacherId);
            return View(teachersAccount);
        }

        // GET: TeachersAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachersAccount = await _context.TeachersAccount.FindAsync(id);
            if (teachersAccount == null)
            {
                return NotFound();
            }
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id", teachersAccount.TeacherId);
            return View(teachersAccount);
        }

        // POST: TeachersAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeacherId,accountType,amount")] TeachersAccount teachersAccount)
        {
            if (id != teachersAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teachersAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeachersAccountExists(teachersAccount.Id))
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
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Id", teachersAccount.TeacherId);
            return View(teachersAccount);
        }

        // GET: TeachersAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teachersAccount = await _context.TeachersAccount
                .Include(t => t.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teachersAccount == null)
            {
                return NotFound();
            }

            return View(teachersAccount);
        }

        // POST: TeachersAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teachersAccount = await _context.TeachersAccount.FindAsync(id);
            _context.TeachersAccount.Remove(teachersAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeachersAccountExists(int id)
        {
            return _context.TeachersAccount.Any(e => e.Id == id);
        }
    }
}
