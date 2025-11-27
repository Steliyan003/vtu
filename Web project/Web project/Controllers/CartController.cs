using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebProject.Data;
using WebProject.Models;

namespace WebProject.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        private string? GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);

        // GET /Cart
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // 🔹 ВЗИМАМЕ САМО НЕЗАВЪРШЕНА ПОРЪЧКА
            var order = await _context.Orders
                .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                .Where(o => o.UserId == userId && !o.IsCompleted)
                .OrderByDescending(o => o.CreatedOn)
                .FirstOrDefaultAsync();

            if (order == null || !order.Items.Any())
            {
                return View(new List<OrderProduct>());
            }

            return View(order.Items.ToList());
        }

        // POST /Cart/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int productId, int quantity = 1)
        {
            var userId = GetUserId();
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // 🔹 ВЗИМАМЕ САМО НЕЗАВЪРШЕНА ПОРЪЧКА
            var order = await _context.Orders
                .Include(o => o.Items)
                .Where(o => o.UserId == userId && !o.IsCompleted)
                .OrderByDescending(o => o.CreatedOn)
                .FirstOrDefaultAsync();

            // ако няма незавършена – създаваме нова
            if (order == null)
            {
                order = new Order
                {
                    UserId = userId,
                    CreatedOn = DateTime.UtcNow,
                    IsCompleted = false,
                    Items = new List<OrderProduct>()
                };

                _context.Orders.Add(order);
            }

            var existingItem = order.Items
                .FirstOrDefault(i => i.ProductId == productId);

            if (existingItem == null)
            {
                order.Items.Add(new OrderProduct
                {
                    ProductId = productId,
                    Quantity = quantity
                });
            }
            else
            {
                existingItem.Quantity += quantity;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Cart", new { area = "" });

        }

        // POST /Cart/Remove
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int productId)
        {
            var userId = GetUserId();
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            // пак търсим само незавършената поръчка
            var order = await _context.Orders
                .Include(o => o.Items)
                .Where(o => o.UserId == userId && !o.IsCompleted)
                .OrderByDescending(o => o.CreatedOn)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                return RedirectToAction("Index");
            }

            var item = order.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
                order.Items.Remove(item);
                _context.OrderProduct.Remove(item);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Cart", new { area = "" });

        }

        // това действие го вика CheckoutController след успешна поръчка
        public IActionResult Completed(int orderId)
        {
            ViewBag.OrderId = orderId;
            return View();
        }
    }
}
