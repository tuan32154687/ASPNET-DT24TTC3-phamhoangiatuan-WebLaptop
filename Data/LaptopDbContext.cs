using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LaptopStore.Models;

namespace LaptopStore.Data
{
    // Kế thừa IdentityDbContext để có thêm các bảng quản lý tài khoản
    // (AspNetUsers, AspNetRoles, ...) bên cạnh các bảng dữ liệu sẵn có
    public class LaptopDbContext : IdentityDbContext<ApplicationUser>
    {
        public LaptopDbContext(DbContextOptions<LaptopDbContext> options) : base(options) { }

        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Thêm các DbSet cho Đơn hàng
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Bắt buộc gọi base để Identity cấu hình đúng các bảng tài khoản
            base.OnModelCreating(modelBuilder);

            // Cấu hình kiểu dữ liệu cho Price
            modelBuilder.Entity<Laptop>().Property(l => l.Price).HasColumnType("decimal(18,2)");

            // Cấu hình kiểu dữ liệu cho TotalAmount và UnitPrice trong Order/OrderItem
            modelBuilder.Entity<Order>().Property(o => o.TotalAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<OrderItem>().Property(oi => oi.UnitPrice).HasColumnType("decimal(18,2)");
        }
    }
}
