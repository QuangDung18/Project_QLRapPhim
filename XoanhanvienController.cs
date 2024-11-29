using Microsoft.AspNetCore.Mvc;
using Project_RapPhim.Models;
using System.Linq;

namespace Project_QuanLyNhanVien.Controllers
{
  public class XoanhanvienController : Controller
  {
    private readonly QuanLyRapChieuPhimContext _context;

    public XoanhanvienController(QuanLyRapChieuPhimContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult Index(int id)
    {
      // Tìm nhân viên theo ID
      var nhanVien = _context.NhanViens.FirstOrDefault(nv => nv.NhanVienId == id);

      if (nhanVien == null)
      {
        return NotFound("Không tìm thấy nhân viên cần xóa.");
      }

      // Hiển thị trang xác nhận xóa
      return View(nhanVien);
    }

    [HttpPost]
    public IActionResult XoaNhanVien(int id)
    {
      // Tìm nhân viên theo ID
      var nhanVien = _context.NhanViens.FirstOrDefault(nv => nv.NhanVienId == id);

      if (nhanVien == null)
      {
        return NotFound("Không tìm thấy nhân viên cần xóa.");
      }

      // Xóa nhân viên
      _context.NhanViens.Remove(nhanVien);
      _context.SaveChanges();

      // Chuyển hướng về trang Quản lý nhân viên
      return RedirectToAction("Index", "Quanlynhanvien");
    }
  }
}
