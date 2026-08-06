namespace LaptopStore.Models
{
    public static class OrderStatusExtensions
    {
        public static string ToDisplayName(this OrderStatus status) => status switch
        {
            OrderStatus.ChoXuLy => "Chờ xử lý",
            OrderStatus.DangGiao => "Đang giao",
            OrderStatus.HoanThanh => "Hoàn thành",
            OrderStatus.DaHuy => "Đã huỷ",
            _ => status.ToString()
        };

        public static string ToBadgeClass(this OrderStatus status) => status switch
        {
            OrderStatus.ChoXuLy => "bg-warning text-dark",
            OrderStatus.DangGiao => "bg-info text-dark",
            OrderStatus.HoanThanh => "bg-success",
            OrderStatus.DaHuy => "bg-danger",
            _ => "bg-secondary"
        };
    }
}
