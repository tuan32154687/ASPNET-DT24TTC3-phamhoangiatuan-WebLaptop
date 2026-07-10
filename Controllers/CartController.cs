using LaptopStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaptopStore.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        // Hiển thị giỏ hàng
        public IActionResult Index()
        {
            var cart = _cartService.GetCart();
            return View(cart);
        }

        // Xóa sản phẩm
        public IActionResult Remove(int id)
        {
            _cartService.RemoveFromCart(id);
            return RedirectToAction("Index");
        }
    }
}