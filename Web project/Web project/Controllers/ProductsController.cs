using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using WebProject.Data;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductsController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .ToListAsync();

            return View(products);
        }

        
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products
                .Include(p => p.Reviews)
                    .ThenInclude(r => r.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

       
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReview(int productId, string content, int rating)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }

            if (rating < 1 || rating > 5 || string.IsNullOrWhiteSpace(content))
            {
                TempData["ReviewError"] = "Моля, въведи текст на ревюто и оценка между 1 и 5.";
                return RedirectToAction("Details", new { id = productId });
            }

            var userId = _userManager.GetUserId(User);

            var review = new Review
            {   
                ProductId = productId,
                Content = content.Trim(),
                Rating = rating,
                UserId = userId!
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            TempData["ReviewSuccess"] = "Благодарим за ревюто!";
            return RedirectToAction("Details", new { id = productId });
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteReview(int reviewId, int productId)
        {
            var review = await _context.Reviews
                .FirstOrDefaultAsync(r => r.Id == reviewId);

            if (review == null)
            {
                TempData["ReviewError"] = "Ревюто не беше намерено.";
                return RedirectToAction("Details", new { id = productId });
            }

            var userId = _userManager.GetUserId(User);

            
            if (review.UserId != userId)
            {
                TempData["ReviewError"] = "Нямате права да изтриете това ревю.";
                return RedirectToAction("Details", new { id = productId });
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            TempData["ReviewSuccess"] = "Ревюто беше изтрито успешно.";
            return RedirectToAction("Details", new { id = productId });
        }

    }
}
