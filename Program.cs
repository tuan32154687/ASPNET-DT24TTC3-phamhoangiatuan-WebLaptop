using LaptopStore.Data;
using LaptopStore.Services;
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

// 3. Kích hoạt Session
app.UseSession();

app.UseAuthorization();
app.MapStaticAssets();

// Sửa dòng này để mặc định vào Laptop/Index thay vì Home/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Laptop}/{action=Index}/{id?}")
    .WithStaticAssets();

// Seed Database
using (var scope = app.Services.CreateScope())
{
    await DbInitializer.SeedAsync(scope.ServiceProvider);
}

app.Run();