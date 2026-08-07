using Microsoft.AspNetCore.Identity;

namespace LaptopStore.Models
{
    // Mở rộng IdentityUser mặc định để lưu thêm thông tin Họ tên
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
    }
}
