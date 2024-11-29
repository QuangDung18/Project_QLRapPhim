using Microsoft.EntityFrameworkCore;
using Project_RapPhim.Models;


var builder = WebApplication.CreateBuilder(args);

// Thêm DbContext vào DI container
builder.Services.AddDbContext<QuanLyRapChieuPhimContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Các dịch vụ khác
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Cấu hình các middleware và endpoint
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Trangchu}/{action=Index}/{id?}");

app.Run();
