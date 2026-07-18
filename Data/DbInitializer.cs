using LaptopStore.Data;
using LaptopStore.Models;
using Microsoft.EntityFrameworkCore; 

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


               
                if (context.Laptops.Count() < 12)
                {
                    if (context.Laptops.Any())
                    {
                        context.Laptops.RemoveRange(context.Laptops);
                        context.SaveChanges();
                    }

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
                            ImageUrl = "/images/dell-vostro-3520.jpg",
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
                            ImageUrl = "/images/asus-rog-strix-g16.jpg",
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
                            ImageUrl = "/images/macbook-air-m2.jpg",
                            Description = "Thiết kế mỏng nhẹ, thời lượng pin vượt trội, hiệu năng mạnh mẽ."
                        },
                        new Laptop
                        {
                            Name = "Lenovo ThinkPad E14 Gen 5",
                            Brand = "Lenovo",
                            Cpu = "Intel Core i5-1335U",
                            Ram = "16GB",
                            Storage = "512GB SSD",
                            Gpu = "Intel Iris Xe",
                            ScreenSize = "14 inch FHD",
                            Price = 17990000,
                            Stock = 18,
                            CategoryId = vanPhong,
                            ImageUrl = "/images/lenovo-thinkpad-e14.jpg",
                            Description = "Bàn phím gõ êm, độ bền chuẩn quân đội, phù hợp dân văn phòng."
                        },
                        new Laptop
                        {
                            Name = "HP Pavilion 15",
                            Brand = "HP",
                            Cpu = "Intel Core i5-1240P",
                            Ram = "8GB",
                            Storage = "512GB SSD",
                            Gpu = "Intel Iris Xe",
                            ScreenSize = "15.6 inch FHD",
                            Price = 15490000,
                            Stock = 22,
                            CategoryId = vanPhong,
                            ImageUrl = "/images/hp-pavilion-15.jpg",
                            Description = "Thiết kế hiện đại, màn hình viền mỏng, giá tốt cho học tập và làm việc."
                        },
                        new Laptop
                        {
                            Name = "Acer Nitro 5",
                            Brand = "Acer",
                            Cpu = "AMD Ryzen 7 7735HS",
                            Ram = "16GB",
                            Storage = "512GB SSD",
                            Gpu = "RTX 4050 6GB",
                            ScreenSize = "15.6 inch FHD 144Hz",
                            Price = 24990000,
                            Stock = 14,
                            CategoryId = gaming,
                            ImageUrl = "/images/acer-nitro-5.jpg",
                            Description = "Laptop gaming giá tốt, hiệu năng mạnh cho game thủ phổ thông."
                        },
                        new Laptop
                        {
                            Name = "MSI Katana 15",
                            Brand = "MSI",
                            Cpu = "Intel Core i7-13620H",
                            Ram = "16GB",
                            Storage = "1TB SSD",
                            Gpu = "RTX 4060 8GB",
                            ScreenSize = "15.6 inch FHD 144Hz",
                            Price = 29990000,
                            Stock = 12,
                            CategoryId = gaming,
                            ImageUrl = "/images/msi-katana-15.jpg",
                            Description = "Thiết kế đậm chất gaming, hiệu năng đồ họa mạnh mẽ."
                        },
                        new Laptop
                        {
                            Name = "Dell XPS 13",
                            Brand = "Dell",
                            Cpu = "Intel Core i7-1355U",
                            Ram = "16GB",
                            Storage = "512GB SSD",
                            Gpu = "Intel Iris Xe",
                            ScreenSize = "13.4 inch FHD+",
                            Price = 32990000,
                            Stock = 10,
                            CategoryId = mongNhe,
                            ImageUrl = "/images/dell-xps-13.jpg",
                            Description = "Laptop cao cấp, thiết kế viền màn hình siêu mỏng, sang trọng."
                        },
                        new Laptop
                        {
                            Name = "Asus ZenBook 14 OLED",
                            Brand = "Asus",
                            Cpu = "Intel Core i5-1340P",
                            Ram = "16GB",
                            Storage = "512GB SSD",
                            Gpu = "Intel Iris Xe",
                            ScreenSize = "14 inch 2.8K OLED",
                            Price = 22990000,
                            Stock = 16,
                            CategoryId = mongNhe,
                            ImageUrl = "/images/asus-zenbook-14.jpg",
                            Description = "Màn hình OLED sắc nét, thiết kế mỏng nhẹ, màu sắc thời trang."
                        },
                        new Laptop
                        {
                            Name = "Lenovo Legion 5",
                            Brand = "Lenovo",
                            Cpu = "AMD Ryzen 7 7840HS",
                            Ram = "16GB",
                            Storage = "1TB SSD",
                            Gpu = "RTX 4060 8GB",
                            ScreenSize = "16 inch WQXGA 165Hz",
                            Price = 33990000,
                            Stock = 9,
                            CategoryId = gaming,
                            ImageUrl = "/images/lenovo-legion-5.jpg",
                            Description = "Laptop gaming cao cấp, khung máy chắc chắn, hiệu năng vượt trội."
                        },
                        new Laptop
                        {
                            Name = "HP ZBook Firefly 14 G10",
                            Brand = "HP",
                            Cpu = "Intel Core i7-1360P",
                            Ram = "32GB",
                            Storage = "1TB SSD",
                            Gpu = "NVIDIA RTX A500",
                            ScreenSize = "14 inch FHD",
                            Price = 42990000,
                            Stock = 6,
                            CategoryId = doHoa,
                            ImageUrl = "/images/hp-zbook-firefly-14.jpg",
                            Description = "Máy trạm di động cho dân thiết kế, đồ họa và kỹ thuật chuyên nghiệp."
                        },
                        new Laptop
                        {
                            Name = "Dell Precision 5570",
                            Brand = "Dell",
                            Cpu = "Intel Core i7-12800H",
                            Ram = "32GB",
                            Storage = "1TB SSD",
                            Gpu = "RTX A2000 8GB",
                            ScreenSize = "15.6 inch 4K UHD+",
                            Price = 55990000,
                            Stock = 5,
                            CategoryId = doHoa,
                            ImageUrl = "/images/dell-precision-5570.jpg",
                            Description = "Máy trạm mạnh mẽ, màn hình 4K chuẩn màu, dành cho dựng phim và render 3D."
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
