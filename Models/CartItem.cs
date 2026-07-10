namespace LaptopStore.Models
{
    public class CartItem
    {
        public int LaptopId { get; set; }
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}