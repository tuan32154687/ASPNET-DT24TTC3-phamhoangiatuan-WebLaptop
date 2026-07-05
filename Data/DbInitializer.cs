using LaptopStore.Data;
using LaptopStore.Models;
using Microsoft.EntityFrameworkCore; // Cần thiết để dùng .Any()

namespace LaptopStore.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
   
            using (var context = new LaptopDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<LaptopDbContext>>()))
            {
             
                context.Database.EnsureCreated();

               
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Category { Name = "Laptop Văn phòng" },
                        new Category { Name = "Laptop Gaming" },
                        new Category { Name = "Laptop Đồ họa - Kỹ thuật" },
                        new Category { Name = "Laptop Mỏng nhẹ" }
                    );
                    context.SaveChanges();
                }

      
                if (!context.Laptops.Any())
                {
                    var categories = context.Categories.ToList();
                    var vanPhong = categories.First(c => c.Name == "Laptop Văn phòng").Id;
                    var gaming = categories.First(c => c.Name == "Laptop Gaming").Id;
                    var doHoa = categories.First(c => c.Name == "Laptop Đồ họa - Kỹ thuật").Id;
                    var mongNhe = categories.First(c => c.Name == "Laptop Mỏng nhẹ").Id;

                    context.Laptops.AddRange(
                        new Laptop
                        {
                            Name = "Dell Vostro 3520",
                            Brand = "Dell",
                            Cpu = "Intel Core i5-1235U",
                            Ram = "16GB",
                            Storage = "512GB SSD",
                            Gpu = "Intel Iris Xe",
                            ScreenSize = "15.6 inch FHD",
                            Price = 14990000,
                            Stock = 20,
                            CategoryId = vanPhong,
                            ImageUrl = "/images/no-image.png",
                            Description = "Laptop văn phòng bền bỉ, hiệu năng ổn định cho công việc hằng ngày."
                        },
                        new Laptop
                        {
                            Name = "Asus ROG Strix G16",
                            Brand = "Asus",
                            Cpu = "Intel Core i7-13650HX",
                            Ram = "16GB",
                            Storage = "1TB SSD",
                            Gpu = "RTX 4060 8GB",
                            ScreenSize = "16 inch QHD 165Hz",
                            Price = 34990000,
                            Stock = 10,
                            CategoryId = gaming,
                            ImageUrl = "/images/no-image.png",
                            Description = "Laptop gaming mạnh mẽ, tản nhiệt tốt, màn hình tần số quét cao."
                        },
                        new Laptop
                        {
                            Name = "MacBook Air M2",
                            Brand = "Apple",
                            Cpu = "Apple M2",
                            Ram = "8GB",
                            Storage = "256GB SSD",
                            Gpu = "8-core GPU",
                            ScreenSize = "13.6 inch Liquid Retina",
                            Price = 26990000,
                            Stock = 15,
                            CategoryId = mongNhe,
                            ImageUrl = "/images/no-image.png",
                            Description = "Thiết kế mỏng nhẹ, thời lượng pin vượt trội, hiệu năng mạnh mẽ."
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}