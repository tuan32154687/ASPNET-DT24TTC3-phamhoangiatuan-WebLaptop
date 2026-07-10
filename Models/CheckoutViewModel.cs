namespace LaptopStore.Models
{
    public class CheckoutViewModel
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public string ShippingAddress { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string ReceiverName { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = "COD";
    }
}