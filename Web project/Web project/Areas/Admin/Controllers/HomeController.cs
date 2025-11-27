using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // когато някой отвори /Admin/Home -> да го прати към Dashboard
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
