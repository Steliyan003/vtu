using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        
        public IActionResult Details(int id)
        {
            return RedirectToAction(
                actionName: "Details",
                controllerName: "Products",
                routeValues: new { area = "", id = id });
        }

        
        public IActionResult Index()
        {
            return RedirectToAction(
                actionName: "Index",
                controllerName: "Products",
                routeValues: new { area = "" });
        }
    }
}
