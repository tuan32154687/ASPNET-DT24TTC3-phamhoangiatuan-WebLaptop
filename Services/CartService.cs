using System.Text.Json;
using LaptopStore.Models;

namespace LaptopStore.Services
{
    public class CartService
    {
        private const string CartSessionKey = "Cart";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private ISession Session => _httpContextAccessor.HttpContext!.Session;

        public List<CartItem> GetCart()
        {
            var json = Session.GetString(CartSessionKey);
            if (string.IsNullOrEmpty(json))
                return new List<CartItem>();

            return JsonSerializer.Deserialize<List<CartItem>>(json) ?? new List<CartItem>();
        }

        private void SaveCart(List<CartItem> cart)
        {
            Session.SetString(CartSessionKey, JsonSerializer.Serialize(cart));
        }

        public void AddToCart(Laptop laptop, int quantity)
        {
            var cart = GetCart();
            var existing = cart.FirstOrDefault(c => c.LaptopId == laptop.Id);

            if (existing != null)
            {
                existing.Quantity += quantity;
            }
            else
            {
                cart.Add(new CartItem
                {
                    LaptopId = laptop.Id,
                    Name = laptop.Name,
                    ImageUrl = laptop.ImageUrl,
                    Price = laptop.Price,
                    Quantity = quantity
                });
            }

            SaveCart(cart);
        }

        public void UpdateQuantity(int laptopId, int quantity)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(c => c.LaptopId == laptopId);
            if (item != null)
            {
                if (quantity <= 0)
                    cart.Remove(item);
                else
                    item.Quantity = quantity;
            }
            SaveCart(cart);
        }

        public void RemoveFromCart(int laptopId)
        {
            var cart = GetCart();
            var item = cart.FirstOrDefault(c => c.LaptopId == laptopId);
            if (item != null)
            {
                cart.Remove(item);
                SaveCart(cart);
            }
        }

        public void ClearCart()
        {
            Session.Remove(CartSessionKey);
        }

        public int GetTotalItems()
        {
            return GetCart().Sum(c => c.Quantity);
        }
    }
}
