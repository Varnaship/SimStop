using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimStop.Web.ViewModels.Admin.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimStop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UsersManagementController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersManagementController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            var userRolesViewModel = new List<AllUsersViewModel>();

            foreach (var user in users)
            {
                var thisViewModel = new AllUsersViewModel
                {
                    UserId = user.Id,
                    Email = user.Email,
                    Roles = await GetUserRoles(user)
                };
                userRolesViewModel.Add(thisViewModel);
            }

            ViewBag.Roles = await _roleManager.Roles
                .Where(r => r.Name != "Admin")
                .Select(r => r.Name)
                .ToListAsync();

            return View(userRolesViewModel);
        }

        private async Task<List<string>> GetUserRoles(IdentityUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["ErrorMessage"] = "User not found.";
                return Redirect("/Admin/UsersManagement");
            }

            if (!await _roleManager.RoleExistsAsync(role))
            {
                TempData["ErrorMessage"] = "Role does not exist.";
                return Redirect("/Admin/UsersManagement");
            }

            if (user.Id == _userManager.GetUserId(User))
            {
                TempData["ErrorMessage"] = "You cannot change your own roles.";
                return Redirect("/Admin/UsersManagement");
            }

            var result = await _userManager.AddToRoleAsync(user, role);
            if (!result.Succeeded)
            {
                TempData["ErrorMessage"] = "Failed to assign role.";
            }
            else
            {
                TempData["SuccessMessage"] = "Role assigned successfully.";
            }

            return Redirect("/Admin/UsersManagement");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRole(string userId, string role)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["ErrorMessage"] = "User not found.";
                return Redirect("/Admin/UsersManagement");
            }

            if (!await _roleManager.RoleExistsAsync(role))
            {
                TempData["ErrorMessage"] = "Role does not exist.";
                return Redirect("/Admin/UsersManagement");
            }

            if (user.Id == _userManager.GetUserId(User))
            {
                TempData["ErrorMessage"] = "You cannot change your own roles.";
                return Redirect("/Admin/UsersManagement");
            }

            var result = await _userManager.RemoveFromRoleAsync(user, role);
            if (!result.Succeeded)
            {
                TempData["ErrorMessage"] = "Failed to remove role.";
            }
            else
            {
                TempData["SuccessMessage"] = "Role removed successfully.";
            }

            return Redirect("/Admin/UsersManagement");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["ErrorMessage"] = "User not found.";
                return Redirect("/Admin/UsersManagement");
            }

            if (user.Id == _userManager.GetUserId(User))
            {
                TempData["ErrorMessage"] = "You cannot delete your own account.";
                return Redirect("/Admin/UsersManagement");
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                TempData["ErrorMessage"] = "Failed to delete user.";
            }
            else
            {
                TempData["SuccessMessage"] = "User deleted successfully.";
            }

            return Redirect("/Admin/UsersManagement");
        }
    }
}

