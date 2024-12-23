using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.DomainModels;
using Microsoft.AspNetCore.Authorization;
using Repository.Data;

namespace Subjectify.Controllers
{
    [Authorize]
    public class FacultyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacultyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Faculty
        public async Task<IActionResult> Index(Guid? categoryId)
        {
            var faculties = _context.Faculties
                .Include(f => f.University)
                .Include(f => f.Subjects)
                .ThenInclude(s => s.Categories);

            List<Faculty> facultiesList = await faculties.ToListAsync();
            if (categoryId.HasValue)
            {
                facultiesList = await faculties.Where(f => f.Subjects.Any(s => s.Categories.Select(c => c.Id).ToList().Contains(categoryId.Value))).ToListAsync();
            }

            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = categories;

            return View(facultiesList);
        }


        // GET: Faculty/Details/5
        // GET: Faculty/Details/5
        public async Task<IActionResult> Details(Guid? id, Guid? categoryId)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Fetch the faculty with related data
            var faculty = await _context.Faculties
                .Include(f => f.University)
                .Include(f => f.Subjects)
                .ThenInclude(s => s.Categories)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (faculty == null)
            {
                return NotFound();
            }

            // Filter subjects by category if categoryId is provided
            if (categoryId.HasValue)
            {
                faculty.Subjects = faculty.Subjects
                    .Where(s => s.Categories.Any(c => c.Id == categoryId.Value))
                    .ToList();
            }

            // Fetch all categories for the dropdown
            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = categories;

            return View(faculty);
        }


        // GET: Faculty/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Name");
            return View();
        }

        // POST: Faculty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("UniversityId,Name,Id")] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                faculty.Id = Guid.NewGuid();
                _context.Add(faculty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Name", faculty.UniversityId);
            return View(faculty);
        }

        // GET: Faculty/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = await _context.Faculties.FindAsync(id);
            if (faculty == null)
            {
                return NotFound();
            }
            ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Name", faculty.UniversityId);
            return View(faculty);
        }

        // POST: Faculty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid id, [Bind("UniversityId,Name,Id")] Faculty faculty)
        {
            if (id != faculty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faculty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacultyExists(faculty.Id))
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
            ViewData["UniversityId"] = new SelectList(_context.Universities, "Id", "Name", faculty.UniversityId);
            return View(faculty);
        }

        // GET: Faculty/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faculty = await _context.Faculties
                .Include(f => f.University)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (faculty == null)
            {
                return NotFound();
            }

            return View(faculty);
        }

        // POST: Faculty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var faculty = await _context.Faculties.FindAsync(id);
            if (faculty != null)
            {
                _context.Faculties.Remove(faculty);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacultyExists(Guid id)
        {
            return _context.Faculties.Any(e => e.Id == id);
        }
    }
}
