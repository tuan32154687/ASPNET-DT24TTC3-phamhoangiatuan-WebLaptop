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

        // Action hiển thị danh sách (có tìm kiếm + sắp xếp theo giá + lọc theo danh mục)
        public async Task<IActionResult> Index(string? searchString, string? sortOrder, int? categoryId)
        {
            var laptops = _context.Laptops.Include(l => l.Category).AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                laptops = laptops.Where(l =>
                    l.Name.Contains(searchString) ||
                    (l.Brand != null && l.Brand.Contains(searchString)));
            }

            if (categoryId.HasValue)
            {
                laptops = laptops.Where(l => l.CategoryId == categoryId.Value);
            }

            laptops = sortOrder switch
            {
                "price_asc" => laptops.OrderBy(l => l.Price),
                "price_desc" => laptops.OrderByDescending(l => l.Price),
                _ => laptops.OrderBy(l => l.Id)
            };

            ViewData["CurrentSearch"] = searchString;
            ViewData["CurrentSort"] = sortOrder;
            ViewData["CurrentCategoryName"] = categoryId.HasValue
                ? (await _context.Categories.FindAsync(categoryId.Value))?.Name
                : null;

            return View(await laptops.ToListAsync());
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

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var laptop = _context.Laptops.Find(id);
            if (laptop != null)
            {
                _cartService.AddToCart(laptop, 1); 
            }
            return RedirectToAction("Index");
        }

        
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