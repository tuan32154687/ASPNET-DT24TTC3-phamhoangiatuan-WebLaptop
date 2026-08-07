using LaptopStore.Data;
using LaptopStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaptopStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminOrdersController : Controller
    {
        private readonly LaptopDbContext _context;

        public AdminOrdersController(LaptopDbContext context)
        {
            _context = context;
        }

        // Danh sách toàn bộ đơn hàng, có thể lọc theo trạng thái
        public async Task<IActionResult> Index(string? statusFilter)
        {
            var orders = _context.Orders.Include(o => o.OrderItems).AsQueryable();

            if (!string.IsNullOrEmpty(statusFilter) && Enum.TryParse<OrderStatus>(statusFilter, out var status))
            {
                orders = orders.Where(o => o.Status == status);
            }

            orders = orders.OrderByDescending(o => o.OrderDate);

            ViewData["CurrentFilter"] = statusFilter;
            return View(await orders.ToListAsync());
        }

        // Xem chi tiết 1 đơn hàng
        public async Task<IActionResult> Details(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null) return NotFound();

            return View(order);
        }

        // Cập nhật trạng thái đơn hàng
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStatus(int id, OrderStatus newStatus)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();

            order.Status = newStatus;
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = $"Đã cập nhật trạng thái đơn hàng #{id} thành \"{newStatus.ToDisplayName()}\".";
            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
