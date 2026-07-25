using LaptopStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaptopStore.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly LaptopDbContext _context;

        public CategoryMenuViewComponent(LaptopDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _context.Categories.OrderBy(c => c.Name).ToListAsync();
            return View(categories);
        }
    }
}
