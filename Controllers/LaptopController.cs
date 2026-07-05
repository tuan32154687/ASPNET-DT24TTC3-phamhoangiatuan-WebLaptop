using Microsoft.AspNetCore.Mvc;
using LaptopStore.Data;
using Microsoft.EntityFrameworkCore;

namespace LaptopStore.Controllers
{
    public class LaptopController : Controller
    {
        private readonly LaptopDbContext _context;

        public LaptopController(LaptopDbContext context)
        {
            _context = context;
        }

        // Action hiển thị danh sách
        public async Task<IActionResult> Index()
        {
            var laptops = await _context.Laptops.ToListAsync();
            return View(laptops);
        }

        // Action hiển thị chi tiết sản phẩm
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var laptop = await _context.Laptops
                .Include(l => l.Category) // Lấy thông tin danh mục kèm theo
                .FirstOrDefaultAsync(m => m.Id == id);

            if (laptop == null)
            {
                return NotFound();
            }

            return View(laptop);
        }
    }
}