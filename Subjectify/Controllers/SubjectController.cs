using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.DomainModels;
using Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Repository.Data;
using Service.Interface;

namespace Subjectify.Controllers
{
    [Authorize]
    public class SubjectController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUsersService _usersService;

        public SubjectController(ApplicationDbContext context, IUsersService usersService)
        {
            _context = context;
            _usersService = usersService;
        }

        // GET: Subject
        public async Task<IActionResult> Index(Guid? categoryId)
        {
            var subjectsDb = _context.Subjects
                .Include(s => s.Faculty)
                .Include(s => s.Categories);
            List<Subject> subjects = new List<Subject>();

            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _usersService.GetPlatformUserById(currentUserId);

            // Filter by category if categoryId is provided
            if (categoryId.HasValue)
            {
                subjects = await subjectsDb
                    .Where(s => s.Categories.Any(c => c.Id == categoryId.Value))
                    .ToListAsync();
            }
            else
            {
                if (User.IsInRole("Student"))
                {
                    subjects = await subjectsDb
                        .Where(s => s.FacultyId == user.Student.FacultyId)
                        .ToListAsync();
                }

                if (User.IsInRole("Admin"))
                {
                    subjects = await subjectsDb.ToListAsync();
                }
            }

            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = categories;

            return View(subjects);
        }


        // GET: Subject/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var subject = _context.Subjects
                .Include(s => s.Professors)
                .Include(s => s.Categories)
                .Include(s => s.Reviews)
                .ThenInclude(r => r.Student)  
                .FirstOrDefault(s => s.Id == id);

            if (subject == null)
            {
                return NotFound();
            }

            var approvedReviews = subject.Reviews.Where(r => r.IsApproved).ToList();;
            var reviews = new List<ReviewDTO>();
            double reviewScore = 0;
            if (approvedReviews.Any())
            {
                reviews = subject.Reviews.Where(r => r.IsApproved).Select(r => new ReviewDTO
                {
                    Rating = r.Rating,
                    PositiveComment = r.PositiveComment,
                    NegativeComment = r.NegativeComment
                }).ToList();
                reviewScore=subject.Reviews.Where(r => r.IsApproved).Average(r => r.Rating);
            }
            var subjectDetailsDTO = new SubjectDetailsDTO
            {
                Name = subject.Name,
                Professors = subject.Professors.Select(p => new ProfessorDTO
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName
                }).ToList(),
                Reviews = reviews,
                AverageReviewScore = reviewScore,
                SubjectId = id
            };

           
            return View(subjectDetailsDTO);
        }
        

        // GET: Subject/Create
        public IActionResult Create()
        {
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Name");
            ViewData["ProfessorList"] = new SelectList(_context.Professors, "Id", "FullName");
            ViewData["CategoryList"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }


        // POST: Subject/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,FacultyId")] Subject subject, Guid[] selectedProfessorIds, Guid[] selectedCategoryIds)
        {
            if (ModelState.IsValid)
            {
                subject.Id = Guid.NewGuid();
        
                // Retrieve selected professors
                var professors = await _context.Professors
                    .Where(p => selectedProfessorIds.Contains(p.Id))
                    .ToListAsync();
                var categories = await _context.Categories
                    .Where(p => selectedCategoryIds.Contains(p.Id))
                    .ToListAsync();
        
                subject.Professors = professors;
                subject.Categories = categories;

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
