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
    public class UniversityController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UniversityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: University
        public async Task<IActionResult> Index()
        {
            return View(await _context.Universities.ToListAsync());
        }

        // GET: University/Details/5
        public async Task<IActionResult> Details(Guid? id, Guid? categoryId)
        {
            if (id == null)
            {
                return NotFound();
            }

            var university = await _context.Universities
                .Include(u => u.Faculties)
                .ThenInclude(f => f.Subjects)
                .ThenInclude(s => s.Categories)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (university == null)
            {
                return NotFound();
            }

            // Filter faculties based on category if categoryId is provided
            if (categoryId.HasValue)
            {
                university.Faculties = university.Faculties
                    .Where(f => f.Subjects.Any(s => s.Categories.Any(c => c.Id == categoryId.Value)))
                    .ToList();
            }

            var categories = await _context.Categories.ToListAsync();
            ViewBag.Categories = categories;

            return View(university);
        }

        
        [Authorize(Roles = "Admin")]
        // GET: University/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: University/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] University university)
        {
            if (ModelState.IsValid)
            {
                university.Id = Guid.NewGuid();
                _context.Add(university);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(university);
        }

        [Authorize(Roles = "Admin")]
        // GET: University/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var university = await _context.Universities.FindAsync(id);
            if (university == null)
            {
                return NotFound();
            }

            return View(university);
        }

        // POST: University/Edit/5

    }
}