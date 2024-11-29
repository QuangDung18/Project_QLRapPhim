using Microsoft.AspNetCore.Mvc;
using Project_RapPhim.Models;
using System.Linq;

namespace Project_RapPhim.Controllers
{
  public class CapnhatnhanvienController : Controller
  {
    private readonly QuanLyRapChieuPhimContext _context;

    public CapnhatnhanvienController(QuanLyRapChieuPhimContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult Index(int id)
    {
      // Tìm nhân viên cần cập nhật theo ID
      var nhanVien = _context.NhanViens.FirstOrDefault(nv => nv.NhanVienId == id);
      if (nhanVien == null)
      {
        return NotFound("Không tìm thấy nhân viên.");
      }

      // Trả về view cùng với thông tin nhân viên
      return View(nhanVien);
    }

    [HttpPost]
    public IActionResult Index(int id, NhanVien updatedNhanVien)
    {
      if (ModelState.IsValid)
      {
        // Tìm nhân viên trong database
        var nhanVien = _context.NhanViens.FirstOrDefault(nv => nv.NhanVienId == id);
        if (nhanVien == null)
        {
          return NotFound("Không tìm thấy nhân viên để cập nhật.");
        }

        // Cập nhật thông tin
        nhanVien.MaNhanVien = updatedNhanVien.MaNhanVien;
        nhanVien.HoTen = updatedNhanVien.HoTen;
        nhanVien.Email = updatedNhanVien.Email;
        nhanVien.SoDienThoai = updatedNhanVien.SoDienThoai;
        nhanVien.VaiTro = updatedNhanVien.VaiTro;
        nhanVien.TrangThai = updatedNhanVien.TrangThai;
        nhanVien.MaNguoiDung = updatedNhanVien.MaNguoiDung;

        // Lưu thay đổi vào database
        _context.SaveChanges();

        // Chuyển hướng về trang Quản lý nhân viên
        return RedirectToAction("Index", "Quanlynhanvien");
      }

      // Nếu có lỗi, trả lại view với dữ liệu đã nhập
      return View(updatedNhanVien);
    }
  }
}
