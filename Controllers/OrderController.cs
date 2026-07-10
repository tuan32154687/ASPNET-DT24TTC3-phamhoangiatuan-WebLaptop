using LaptopStore.Data;
using LaptopStore.Models;
using LaptopStore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LaptopStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly LaptopDbContext _context;
        private readonly CartService _cartService;

        public OrderController(LaptopDbContext context, CartService cartService)
        {
            _context = context;
            _cartService = cartService;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            var cartItems = _cartService.GetCart();
            if (!cartItems.Any())
            {
                return RedirectToAction("Index", "Cart");
            }
            return View(new CheckoutViewModel { Items = cartItems });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(CheckoutViewModel model)
        {
            var cartItems = _cartService.GetCart();
            if (!cartItems.Any()) return RedirectToAction("Index", "Cart");

            if (!ModelState.IsValid)
            {
                model.Items = cartItems;
                return View(model);
            }

            var order = new Order
            {
                OrderDate = DateTime.Now,
                ShippingAddress = model.ShippingAddress,
                PhoneNumber = model.PhoneNumber,
                ReceiverName = model.ReceiverName,
                PaymentMethod = model.PaymentMethod,
                Status = OrderStatus.ChoXuLy,
                TotalAmount = cartItems.Sum(i => i.Quantity * i.Price)
            };

            foreach (var item in cartItems)
            {
                order.OrderItems.Add(new OrderItem
                {
                    LaptopId = item.LaptopId,
                    LaptopName = item.Name,
                    Quantity = item.Quantity,
                    UnitPrice = item.Price
                });
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            _cartService.ClearCart(); // Xóa giỏ hàng sau khi đặt thành công

            return RedirectToAction(nameof(Confirmation), new { id = order.Id });
        }

        public IActionResult Confirmation(int id)
        {
            var order = _context.Orders
                .Include(o => o.OrderItems)
                .FirstOrDefault(o => o.Id == id);

            if (order == null) return NotFound();
            return View(order);
        }
    }
}