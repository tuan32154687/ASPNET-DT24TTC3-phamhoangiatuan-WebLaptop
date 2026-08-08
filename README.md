# LaptopStore – Website bán laptop trực tuyến

> Đồ án học phần **Chuyên đề ASP.NET** – Trường Kỹ thuật và Công nghệ, Đại học Trà Vinh

Website thương mại điện tử bán laptop, xây dựng trên nền tảng **ASP.NET Core MVC (.NET 8)**, cho phép khách hàng tìm kiếm – lọc – xem chi tiết sản phẩm, quản lý giỏ hàng và đặt hàng trực tuyến; đồng thời cung cấp khu vực quản trị để quản lý đơn hàng và tài khoản người dùng.

---

## Mục lục

- [Thông tin đồ án](#thông-tin-đồ-án)
- [Tính năng chính](#tính-năng-chính)
- [Công nghệ sử dụng](#công-nghệ-sử-dụng)
- [Cấu trúc dự án](#cấu-trúc-dự-án)
- [Yêu cầu môi trường](#yêu-cầu-môi-trường)
- [Hướng dẫn cài đặt và chạy dự án](#hướng-dẫn-cài-đặt-và-chạy-dự-án)
- [Tài khoản demo](#tài-khoản-demo)
- [Một số hình ảnh giao diện](#một-số-hình-ảnh-giao-diện)
- [Hướng phát triển](#hướng-phát-triển)
- [Thông tin liên hệ](#thông-tin-liên-hệ)

---

## Thông tin đồ án

| Thông tin | Nội dung |
|---|---|
| Học phần | Chuyên đề ASP.NET |
| Giảng viên hướng dẫn | TS. Nguyễn Nhứt Lam |
| Họ và tên sinh viên | Phạm Hoàng Gia Tuấn |
| Mã sinh viên | 170124307 |
| Lớp | DT24TTC3 |
| Tài khoản | tuanphg291203 |
| Email | tuanphg291203@tvu-onschool.edu.vn |

---

## Tính năng chính

### Đối với khách hàng

- Xem trang chủ với banner giới thiệu thương hiệu, danh mục nổi bật, sản phẩm nổi bật
- Xem danh sách sản phẩm dạng lưới thẻ (card grid), có phân loại theo 4 danh mục: *Laptop Văn phòng, Laptop Gaming, Laptop Đồ hoạ – Kỹ thuật, Laptop Mỏng nhẹ*
- Tìm kiếm sản phẩm theo tên
- Lọc sản phẩm theo danh mục
- Sắp xếp sản phẩm theo giá (tăng dần / giảm dần)
- Xem chi tiết sản phẩm kèm bảng thông số kỹ thuật đầy đủ (CPU, RAM, ổ cứng, GPU, màn hình...)
- Thêm sản phẩm vào giỏ hàng, xem và xoá sản phẩm khỏi giỏ hàng
- Đăng ký / Đăng nhập / Đăng xuất tài khoản (ASP.NET Core Identity)
- Đặt hàng trực tuyến (thanh toán khi nhận hàng – COD), xem trang xác nhận đơn hàng
- Xem trang **Về chúng tôi** và **Liên hệ**

### Đối với quản trị viên (Admin)

- Xem danh sách toàn bộ đơn hàng, lọc theo trạng thái
- Xem chi tiết đơn hàng và cập nhật trạng thái: `Chờ xử lý → Đang giao → Hoàn thành` (hoặc `Đã huỷ`)
- Xem danh sách tài khoản người dùng đã đăng ký
- Khoá / mở khoá tài khoản người dùng

---

## Công nghệ sử dụng

| Thành phần | Công nghệ |
|---|---|
| Ngôn ngữ | C# (.NET 8) |
| Framework | ASP.NET Core MVC |
| ORM | Entity Framework Core (Code First) |
| Cơ sở dữ liệu | Microsoft SQL Server |
| Xác thực & phân quyền | ASP.NET Core Identity |
| Giao diện | Razor View, Bootstrap 5, CSS tuỳ biến |
| Thư viện hỗ trợ | jQuery, jQuery Validation, SweetAlert2 |
| Quản lý mã nguồn | Git & GitHub |

---

## Cấu trúc dự án

```
LaptopStore/
├── Controllers/            # Xử lý request (Home, Laptop, Cart, Order, Account, AdminOrders, AdminUsers)
├── Models/                 # Các lớp Model & ViewModel (Laptop, Category, Order, OrderItem, ApplicationUser...)
├── Views/                  # Giao diện Razor (.cshtml), tổ chức theo từng Controller
├── ViewComponents/         # CategoryMenuViewComponent, CartSummaryViewComponent
├── Services/                # CartService – xử lý logic giỏ hàng (lưu trong Session)
├── Data/                   # LaptopDbContext, DbInitializer (seed dữ liệu mẫu)
├── Migrations/              # Các file Migration của Entity Framework Core
├── wwwroot/                 # Tài nguyên tĩnh: CSS, hình ảnh, thư viện JS (Bootstrap, jQuery)
├── appsettings.json          # Cấu hình ứng dụng (chuỗi kết nối CSDL...)
└── Program.cs                # Điểm khởi động, cấu hình dịch vụ & middleware pipeline
```

---

## Yêu cầu môi trường

Trước khi chạy dự án, cần cài đặt:

- **.NET 8 SDK** – [tải tại đây](https://dotnet.microsoft.com/download/dotnet/8.0)
- **Visual Studio 2022 / 2026** (kèm workload *ASP.NET and web development*), hoặc VS Code + C# Dev Kit
- **SQL Server** (LocalDB hoặc Developer Edition) + **SQL Server Management Studio (SSMS)** để quản lý CSDL (không bắt buộc nhưng nên có)
- **Git** để clone mã nguồn

---

## Hướng dẫn cài đặt và chạy dự án

### Bước 1 — Clone mã nguồn

```bash
git clone https://github.com/tuan32154687/ASPNET-DT24TTC3-phamhoangiatuan-WebLaptop.git
cd ASPNET-DT24TTC3-phamhoangiatuan-WebLaptop/LaptopStore
```

### Bước 2 — Cấu hình chuỗi kết nối cơ sở dữ liệu

Mở file `appsettings.json`, kiểm tra / chỉnh sửa `ConnectionStrings` cho phù hợp với SQL Server trên máy đang sử dụng:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=LaptopStoreDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

> Nếu dùng SQL Server Express/Developer thay vì LocalDB, đổi `Server=` thành tên instance tương ứng (ví dụ `Server=.\SQLEXPRESS`).

### Bước 3 — Khôi phục package & tạo cơ sở dữ liệu

Mở **Package Manager Console** trong Visual Studio (hoặc dùng .NET CLI), chạy lần lượt:

```powershell
dotnet restore
dotnet ef database update
```

*(Trong Package Manager Console của Visual Studio có thể dùng lệnh `Update-Database` thay cho `dotnet ef database update`.)*

### Bước 4 — Chạy ứng dụng

```bash
dotnet run
```

Hoặc mở file `LaptopStore.sln`/`LaptopStore.csproj` bằng Visual Studio rồi nhấn **F5** (Debug) hoặc **Ctrl+F5** (Run without Debugging).

Khi khởi động lần đầu, hệ thống sẽ **tự động tạo dữ liệu mẫu** (4 danh mục, 12 sản phẩm laptop và 1 tài khoản Admin) thông qua `DbInitializer`, không cần thao tác thêm.

Truy cập ứng dụng tại địa chỉ được hiển thị trên terminal, ví dụ:

```
https://localhost:7008
```

---

## Tài khoản demo

| Vai trò | Email | Mật khẩu |
|---|---|---|
| Quản trị viên (Admin) | `admin@laptopstore.vn` | `Admin@123` |
| Khách hàng | *Tự đăng ký tài khoản mới tại trang Đăng ký* | — |

Sau khi đăng nhập bằng tài khoản Admin, truy cập khu vực quản trị qua đường dẫn `/AdminOrders` (quản lý đơn hàng) hoặc `/AdminUsers` (quản lý tài khoản).

---

## Một số hình ảnh giao diện

> *(Chèn ảnh chụp màn hình thực tế của website vào các mục dưới đây trước ngày báo cáo)*

**Trang chủ**

`[ Chèn ảnh trang chủ tại đây ]`

**Trang danh sách sản phẩm**

`[ Chèn ảnh trang danh sách sản phẩm tại đây ]`

**Trang chi tiết sản phẩm**

`[ Chèn ảnh trang chi tiết sản phẩm tại đây ]`

**Khu vực quản trị**

`[ Chèn ảnh trang quản lý đơn hàng / tài khoản tại đây ]`

---

## Hướng phát triển

- Tích hợp cổng thanh toán trực tuyến (VNPay, Momo)
- Bổ sung chức năng đánh giá – bình luận sản phẩm
- Xây dựng trang "Đơn hàng của tôi" cho khách hàng theo dõi trạng thái đơn hàng
- Xây dựng module quản trị sản phẩm/danh mục (thêm, sửa, xoá) trên giao diện web
- Cải thiện tìm kiếm nâng cao (lọc kết hợp nhiều tiêu chí, gợi ý tìm kiếm)
- Xây dựng trang thống kê doanh thu, sản phẩm bán chạy dành cho Admin
- Triển khai lên môi trường máy chủ thực tế (Azure App Service / VPS)

---

## Thông tin liên hệ

**Sinh viên thực hiện:** Phạm Hoàng Gia Tuấn (MSSV: 170124307 – Lớp DT24TTC3)
**Email:** tuanphg291203@tvu-onschool.edu.vn
**Giảng viên hướng dẫn:** TS. Nguyễn Nhứt Lam
**Học phần:** Chuyên đề ASP.NET – Trường Kỹ thuật và Công nghệ, Đại học Trà Vinh

---

<p align="center"><i>Cảm ơn thầy/cô và các bạn đã quan tâm đến đồ án!</i></p>
