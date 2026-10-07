BOOK MANAGEMENT MVC - ASP.NET CORE MVC

Công nghệ:
- ASP.NET Core MVC .NET 8
- Entity Framework Core 8
- SQL Server / LocalDB
- Code First

CHẠY BÀI:
1. Mở file BookManagementMVC.csproj bằng Visual Studio 2022.
2. Nếu máy dùng SQL Server LocalDB thì giữ nguyên connection string trong appsettings.json.
3. Mở Package Manager Console và chạy:
   Add-Migration InitialCreate
   Update-Database
4. Nhấn Ctrl + F5 hoặc nút Run.
5. Website mặc định mở vào /Books/Index.

Nếu không muốn dùng Migration:
- Mở SQL Server Management Studio.
- Chạy toàn bộ file database.sql.
- Đảm bảo connection string trỏ đúng SQL Server của máy.

Chức năng:
- Hiển thị danh sách sách
- Tìm kiếm theo tên sách/tác giả
- Thêm sách
- Xem chi tiết
- Sửa sách
- Xóa sách
- Validation dữ liệu

----- BỔ SUNG -----
Middleware (bài Middleware):
- Middlewares/RequestLoggingMiddleware.cs: log request + status code + ms, chặn /Books/Details/{id<=0} trả 400 "Book id không hợp lệ".
- Đăng ký trong Program.cs, đặt trước MapControllerRoute.

Upload ảnh bìa (bổ sung 07/10/2026):
- Thêm/Sửa sách có chọn ảnh (jpg, jpeg, png, gif, webp, tối đa 2MB), lưu vào wwwroot/images/books.
- Cột ImagePath trong bảng Books được tự thêm khi chạy app nếu DB cũ chưa có.
