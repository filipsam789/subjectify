using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.DomainModels;
using Domain.DTO;
using Repository.Data;

namespace Subjectify.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SubjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Subject
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Subjects.Include(s => s.Faculty);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Subject/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {var subject = _context.Subjects
                .Include(s => s.Professors)
                .Include(s => s.Reviews)
                .ThenInclude(r => r.Student)  
                .FirstOrDefault(s => s.Id == id);

            if (subject == null)
            {
                return NotFound();
            }

            var subjectDetailsDTO = new SubjectDetailsDTO
            {
                Name = subject.Name,
                Professors = subject.Professors.Select(p => new ProfessorDTO
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName
                }).ToList(),
                Reviews = subject.Reviews.Select(r => new ReviewDTO
                {
                    Rating = r.Rating,
                    PositiveComment = r.PositiveComment,
                    NegativeComment = r.NegativeComment
                }).ToList(),
                AverageReviewScore = subject.Reviews.Any() ? subject.Reviews.Average(r => r.Rating) : 0
            };

           
            return View(subjectDetailsDTO);
        }
        

        // GET: Subject/Create
        public IActionResult Create()
        {
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Name");
            ViewData["ProfessorList"] = new SelectList(_context.Professors, "Id", "FullName");
            return View();
        }


        // POST: Subject/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,FacultyId")] Subject subject, Guid[] selectedProfessorIds)
        {
            if (ModelState.IsValid)
            {
                subject.Id = Guid.NewGuid();
        
                // Retrieve selected professors
                var professors = await _context.Professors
                    .Where(p => selectedProfessorIds.Contains(p.Id))
                    .ToListAsync();
        
                subject.Professors = professors;

                _context.Add(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // In case of invalid model state, re-bind data for the dropdowns
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Name", subject.FacultyId);
            ViewData["ProfessorList"] = new SelectList(_context.Professors, "Id", "FullName");
            return View(subject);
        }


        // GET: Subject/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .Include(s => s.Professors) // Include Professors to access the selected ones
                .FirstOrDefaultAsync(m => m.Id == id);

            if (subject == null)
            {
                return NotFound();
            }

            // Pass list of professors for the dropdown
            ViewBag.ProfessorList = new SelectList(_context.Professors, "Id", "FullName");
            ViewBag.FacultyList = new SelectList(_context.Faculties, "Id", "Name");
            return View(subject);
        }



        // POST: Subject/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FacultyId,Name,Id")] Subject subject, List<Guid> selectedProfessorIds)
        {
            if (id != subject.Id)
            {
                return NotFound();
            }
        
            if (ModelState.IsValid)
            {
                try
                {
                    var dbSubject = await _context.Subjects.Include(s => s.Professors).FirstAsync(s => s.Id == subject.Id);
                    dbSubject.Name = subject.Name;
                    // _context.Update(subject);
                        
                    var professors = await _context.Professors
                        .Where(p => selectedProfessorIds.Contains(p.Id))
                        .ToListAsync();

                    foreach (var professor in professors)
                    {
                        if(!dbSubject.Professors.Contains(professor))
                            dbSubject.Professors.Add(professor);
                    }
        
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.Id))
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
        
            ViewBag.ProfessorList = new SelectList(_context.Professors, "Id", "FullName");
            ViewBag.FacultyList = new SelectList(_context.Faculties, "Id", "Name");
        
            return View(subject);
        }


        // GET: Subject/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .Include(s => s.Faculty)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: Subject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(Guid id)
        {
            return _context.Subjects.Any(e => e.Id == id);
        }
    }
}
