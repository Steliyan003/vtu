using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

      
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = GetUserId();
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var order = await _context.Orders
                .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(o => o.UserId == userId &&
                                          !o.IsCompleted &&
                                          !o.IsCanceled &&
                                          string.IsNullOrEmpty(o.FullName)); // активна "празна" поръчка

            if (order == null || !order.Items.Any())
                return View(Enumerable.Empty<OrderProduct>());

            return View(order.Items);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int productId, int quantity)
        {
            var userId = GetUserId();
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                return NotFound();

            var order = await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.UserId == userId &&
                                          !o.IsCompleted &&
                                          !o.IsCanceled &&
                                          string.IsNullOrEmpty(o.FullName));

            if (order == null)
            {
                order = new Order
                {
                    UserId = userId,
                    CreatedOn = DateTime.Now
                };
                _context.Orders.Add(order);
            }

            var item = order.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null)
            {
                order.Items.Add(new OrderProduct
                {
                    ProductId = productId,
                    Quantity = quantity
                });
            }
            else
            {
                item.Quantity += quantity;
            }

            await _context.SaveChangesAsync();

           
            return RedirectToAction("Index", "Cart", new { area = "" });
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Remove(int productId, int quantity)
        {
            var userId = GetUserId();
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var order = await _context.Orders
                .Include(o => o.Items)
                .FirstOrDefaultAsync(o => o.UserId == userId &&
                                          !o.IsCompleted &&
                                          !o.IsCanceled &&
                                          string.IsNullOrEmpty(o.FullName));

            if (order == null)
                return RedirectToAction("Index", "Cart", new { area = "" });

            var item = order.Items.FirstOrDefault(i => i.ProductId == productId);
            if (item != null)
            {
               
                if (quantity <= 0 || quantity >= item.Quantity)
                {
                    order.Items.Remove(item);
                }
                else
                {
                    
                    item.Quantity -= quantity;
                }

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Cart", new { area = "" });
        }

       
        [HttpGet]
        public async Task<IActionResult> Completed(int orderId)
        {
            var userId = GetUserId();
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var order = await _context.Orders
                .Include(o => o.Items)
                    .ThenInclude(i => i.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId && o.UserId == userId);

            if (order == null)
                return RedirectToAction("Index", "Cart", new { area = "" });

            return View(order);
        }
    }
}
