using LaptopStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace LaptopStore.ViewComponents
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly CartService _cartService;

        public CartSummaryViewComponent(CartService cartService)
        {
            _cartService = cartService;
        }

        public IViewComponentResult Invoke()
        {
            var cartItems = _cartService.GetCart();
            var totalItems = cartItems.Sum(item => item.Quantity);
            return View(totalItems);
        }
    }
}