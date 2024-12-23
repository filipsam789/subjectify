using Repository.Data;

using Domain.DomainModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace YourNamespace.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReviewRequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReviewRequest/Index
        public async Task<IActionResult> Index()
        {
            var reviewRequests = await _context.ReviewRequests
                .Include(r => r.Review)
                .ThenInclude(r => r.Student)
                .Include(r => r.Review)
                .ThenInclude(r => r.Subject)
                .ToListAsync();

            return View(reviewRequests);
        }

        // POST: ReviewRequest/Approve/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(Guid id)
        {
            var reviewRequest = await _context.ReviewRequests
                .Include(r => r.Review)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reviewRequest == null)
            {
                return NotFound();
            }

            var review = reviewRequest.Review;
            if (review != null)
            {
                review.IsApproved = true;
                _context.ReviewRequests.Remove(reviewRequest);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: ReviewRequest/Decline/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Decline(Guid id)
        {
            var reviewRequest = await _context.ReviewRequests
                .FirstOrDefaultAsync(r => r.Id == id);

            if (reviewRequest == null)
            {
                return NotFound();
            }

            _context.ReviewRequests.Remove(reviewRequest);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
