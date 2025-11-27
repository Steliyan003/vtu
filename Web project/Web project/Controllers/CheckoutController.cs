using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProject.Data;
using WebProject.Models;
using WebProject.ViewModels;

namespace WebProject.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckoutController(ApplicationDbContext context)
        {
            _context = context;
        }

        private string? GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);

        // GET /Checkout
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var order = await _context.Orders
                .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(o => o.UserId == userId);

            if (order == null || !order.Items.Any())
            {
                // Ако количката е празна -> обратно към количката
                return RedirectToAction("Index", "Cart");
            }

            var model = new CheckoutViewModel
            {
                Items = order.Items.ToList(),
                TotalAmount = order.Items.Sum(i => i.Quantity * i.Product.Price)
            };

            return View(model);  // Това вика Views/Checkout/Index.cshtml
        }

        // POST /Checkout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(CheckoutViewModel model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (!ModelState.IsValid)
            {
                // презареждаме количката за да покажем грешките
                var orderForView = await _context.Orders
                    .Include(o => o.Items)
                        .ThenInclude(i => i.Product)
                    .FirstOrDefaultAsync(o => o.UserId == userId && !o.IsCompleted);

                if (orderForView == null)
                {
                    return RedirectToAction("Index", "Cart");
                }

                model.Items = orderForView.Items.ToList();
                model.TotalAmount = orderForView.Items.Sum(i => i.Quantity * i.Product.Price);

                return View(model);
            }

            var order = await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.UserId == userId && !o.IsCompleted);

            if (order == null)
            {
                return RedirectToAction("Index", "Cart");
            }

            // Записваме данните за доставка
            order.FullName = model.FullName;
            order.PhoneNumber = model.PhoneNumber;
            order.Address = model.Address;
            order.City = model.City;
            order.Notes = model.Notes;

            // ТУК Е ВАЖНОТО:
            order.IsCompleted = true;

            await _context.SaveChangesAsync();

            // Изпращаме Id-то към Completed
            return RedirectToAction("Completed", "Cart", new { orderId = order.Id, area="" });
        }

    }
}
