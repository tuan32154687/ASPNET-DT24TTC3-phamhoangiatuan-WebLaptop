BÁO CÁO TIẾN ĐỘ - TUẦN 2
1. Công việc đã thực hiện Quản lý dự án

Phát triển Models: Xây dựng cấu trúc dữ liệu cho đơn hàng gồm Order.cs, OrderItem.cs, CartItem.cs và CheckoutViewModel.cs trong thư mục Models/.

Thiết lập Database: Cập nhật LaptopDbContext.cs trong thư mục Data và thực hiện Migration để đồng bộ cơ sở dữ liệu.

Phát triển chức năng Giỏ hàng:

Xây dựng CartService trong thư mục Services để quản lý logic nghiệp vụ giỏ hàng.

Tạo CartController để xử lý các yêu cầu thêm/xóa sản phẩm.

Phát triển chức năng Đặt hàng:

Xây dựng OrderController để quản lý luồng thanh toán và đặt hàng.

Thiết kế giao diện Checkout.cshtml và Confirmation.cshtml trong thư mục Views/Order/.

Nâng cấp giao diện người dùng:

Tích hợp thư viện SweetAlert2 vào _Layout.cshtml để tạo thông báo tương tác.

Xây dựng ViewComponent CartSummary trong thư mục ViewComponents/ để hiển thị số lượng sản phẩm trên thanh menu.

2. Kết quả đạt được

Dự án đã hoàn thiện luồng nghiệp vụ cơ bản từ xem sản phẩm, quản lý giỏ hàng đến thực hiện đặt hàng.

Giao diện người dùng được cải thiện với các thành phần tương tác hiện đại và chuyên nghiệp.

Hệ thống đã được đồng bộ hóa lên GitHub và sẵn sàng cho các giai đoạn kiểm thử tiếp theo.

