using Microsoft.AspNetCore.Mvc;
using Project_RapPhim.Models;
using System.Linq;

namespace Project_RapPhim.Controllers
{
  public class ThemnhanvienController : Controller
  {
    private readonly QuanLyRapChieuPhimContext _context;

    public ThemnhanvienController(QuanLyRapChieuPhimContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
      // Trả về view với model rỗng để nhập dữ liệu
      return View(new NhanVien());
    }

    [HttpPost]
    public IActionResult Index(NhanVien nhanVien)
    {
      if (ModelState.IsValid)
      {
        // Thêm nhân viên vào cơ sở dữ liệu
        _context.NhanViens.Add(nhanVien);
        _context.SaveChanges();

        // Chuyển hướng về trang Quản lý nhân viên
        return RedirectToAction("Index", "Quanlynhanvien");
      }
            ViewBag.Message = "Thông tin không hợp lệ";
      // Nếu có lỗi, hiển thị lại form với dữ liệu đã nhập
      return View(nhanVien);
    }
  }
}
