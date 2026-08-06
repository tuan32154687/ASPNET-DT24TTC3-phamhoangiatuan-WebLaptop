using LaptopStore.Data;
using LaptopStore.Models;
using LaptopStore.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Cấu hình Database
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LaptopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Thêm các Service cho Giỏ hàng
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();
builder.Services.AddScoped<CartService>();

// 3. Cấu hình Identity cho chức năng Đăng nhập / Đăng ký
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
    {
        // Nới lỏng yêu cầu mật khẩu cho phù hợp đồ án môn học
        options.Password.RequireDigit = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 6;
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<LaptopDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/Login";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 4. Kích hoạt Session
app.UseSession();

// 5. Kích hoạt Xác thực (PHẢI đặt trước UseAuthorization)
app.UseAuthentication();
app.UseAuthorization();
app.MapStaticAssets();

// Sửa dòng này để mặc định vào Laptop/Index thay vì Home/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Seed Database
using (var scope = app.Services.CreateScope())
{
    await DbInitializer.SeedAsync(scope.ServiceProvider);
}

app.Run();
