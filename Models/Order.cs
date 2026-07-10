using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaptopStore.Models
{
    public enum OrderStatus
    {
        ChoXuLy, DangGiao, HoanThanh, DaHuy
    }

    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        public string ShippingAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập SĐT")]
        public string PhoneNumber { get; set; } = string.Empty;

        public string ReceiverName { get; set; } = string.Empty;
        public OrderStatus Status { get; set; } = OrderStatus.ChoXuLy;
        public string PaymentMethod { get; set; } = "COD";

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}