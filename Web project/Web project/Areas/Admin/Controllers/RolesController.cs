using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebProject.Models;
using WebProject.ViewModels;

namespace WebProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

       
        public async Task<IActionResult> Index()
        {
            
            await EnsureBaseRolesExistAsync();

            var users = _userManager.Users.ToList();

            var model = new List<AdminUserRoleViewModel>();

            foreach (var u in users)
            {
                var roles = await _userManager.GetRolesAsync(u);
                var currentRole = roles.FirstOrDefault() ?? "User";

                model.Add(new AdminUserRoleViewModel
                {
                    Id = u.Id,
                    Email = u.Email ?? "",
                    DisplayName = u.DisplayName,
                    CurrentRole = currentRole
                });
            }

            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetRole(string userId, string roleName)
        {
            if (string.IsNullOrWhiteSpace(userId) ||
                string.IsNullOrWhiteSpace(roleName))
            {
                return RedirectToAction(nameof(Index));
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return RedirectToAction(nameof(Index));
            }

            
            if (roleName != "Admin" && roleName != "User")
            {
                return RedirectToAction(nameof(Index));
            }

            var currentRoles = await _userManager.GetRolesAsync(user);

            
            if (currentRoles.Any())
            {
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
            }

            
            await _userManager.AddToRoleAsync(user, roleName);

            return RedirectToAction(nameof(Index));
        }

        private async Task EnsureBaseRolesExistAsync()
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await _roleManager.RoleExistsAsync("User"))
            {
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }
        }
    }
}
