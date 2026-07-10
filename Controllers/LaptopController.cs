using LaptopStore.Data;
using LaptopStore.Models;
using LaptopStore.Services; // Nhớ thêm dòng này
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaptopStore.Controllers
{
    public class LaptopController : Controller
    {
        private readonly LaptopDbContext _context;
        private readonly CartService _cartService; // Thêm biến này

        // Cập nhật constructor để nhận thêm CartService
        public LaptopController(LaptopDbContext context, CartService cartService)
        {
            _context = context;
            _cartService = cartService;
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
            if (id == null) return NotFound();

            var laptop = await _context.Laptops
                .Include(l => l.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (laptop == null) return NotFound();

            return View(laptop);
        }

        // Hàm xử lý nút "Thêm vào giỏ hàng"
        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var laptop = _context.Laptops.Find(id);
            if (laptop != null)
            {
                _cartService.AddToCart(laptop, 1); // Thêm 1 sản phẩm
            }
            return RedirectToAction("Index");
        }

        // Action Create (giữ nguyên như cũ)
        public IActionResult Create()
        {
            ViewBag.CategoryId = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laptop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CategoryId = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(_context.Categories, "Id", "Name", laptop.CategoryId);
            return View(laptop);
        }
    }
}