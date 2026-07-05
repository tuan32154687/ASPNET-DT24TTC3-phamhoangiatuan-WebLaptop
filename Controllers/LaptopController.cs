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
    }
}