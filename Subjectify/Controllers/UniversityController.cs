using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain.DomainModels;
using Repository.Data;

namespace Subjectify.Controllers
{
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
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var university = await _context.Universities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (university == null)
            {
                return NotFound();
            }

            return View(university);
        }

        // GET: University/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: University/Create
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