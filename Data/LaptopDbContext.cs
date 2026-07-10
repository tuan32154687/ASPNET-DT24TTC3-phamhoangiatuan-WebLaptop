using Microsoft.EntityFrameworkCore;
using LaptopStore.Models;

namespace LaptopStore.Data
{
    public class LaptopDbContext : DbContext
    {
        public LaptopDbContext(DbContextOptions<LaptopDbContext> options) : base(options) { }

        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Category> Categories { get; set; }

        // Thêm các DbSet cho Đơn hàng
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình kiểu dữ liệu cho Price
            modelBuilder.Entity<Laptop>().Property(l => l.Price).HasColumnType("decimal(18,2)");

            // Cấu hình kiểu dữ liệu cho TotalAmount và UnitPrice trong Order/OrderItem
            modelBuilder.Entity<Order>().Property(o => o.TotalAmount).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<OrderItem>().Property(oi => oi.UnitPrice).HasColumnType("decimal(18,2)");
        }
    }
}