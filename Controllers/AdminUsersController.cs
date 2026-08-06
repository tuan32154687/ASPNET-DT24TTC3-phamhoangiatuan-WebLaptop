using LaptopStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LaptopStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminUsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminUsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        // Danh sách toàn bộ tài khoản đã đăng ký
        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.OrderBy(u => u.Email).ToList();

            // Gắn kèm thông tin khoá/vai trò cho từng user để hiển thị
            var result = new List<(ApplicationUser User, bool IsLocked, IList<string> Roles)>();
            foreach (var user in users)
            {
                var isLocked = await _userManager.IsLockedOutAsync(user);
                var roles = await _userManager.GetRolesAsync(user);
                result.Add((user, isLocked, roles));
            }

            return View(result);
        }

        // Khoá / Mở khoá tài khoản
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleLock(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var isLocked = await _userManager.IsLockedOutAsync(user);

            if (isLocked)
            {
                // Mở khoá: đặt lại thời hạn khoá về null
                await _userManager.SetLockoutEndDateAsync(user, null);
                TempData["SuccessMessage"] = $"Đã mở khoá tài khoản {user.Email}.";
            }
            else
            {
                // Khoá vĩnh viễn (đến năm 9999)
                await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue);
                TempData["SuccessMessage"] = $"Đã khoá tài khoản {user.Email}.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
