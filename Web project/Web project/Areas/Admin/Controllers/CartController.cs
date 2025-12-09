using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CartController : Controller
    {
        
        public IActionResult Index()
        {
            return RedirectToAction(
                actionName: "Index",
                controllerName: "Cart",
                routeValues: new { area = "" });
        }
    }
}
