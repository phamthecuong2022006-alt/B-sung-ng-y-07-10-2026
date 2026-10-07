using BookManagementMVC.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Tự thêm cột ImagePath (bài upload ảnh 07/10) nếu DB cũ chưa có -> chạy là xong
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    try
    {
        db.Database.ExecuteSqlRaw(
            "IF OBJECT_ID(N'dbo.Books', N'U') IS NOT NULL AND COL_LENGTH(N'dbo.Books', N'ImagePath') IS NULL " +
            "ALTER TABLE dbo.Books ADD ImagePath NVARCHAR(300) NULL;");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[Startup] Không thể kiểm tra/thêm cột ImagePath: {ex.Message}");
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Middleware đặt TRƯỚC MapControllerRoute
app.UseMiddleware<BookManagementMVC.Middlewares.RequestLoggingMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Books}/{action=Index}/{id?}");

app.Run();
