using Microsoft.AspNetCore.Mvc;
using Project_RapPhim.Models;
using System.Linq;

namespace Project_RapPhim.Controllers
{
  public class CapnhatphimController : Controller
  {
    private readonly QuanLyRapChieuPhimContext _context;

    public CapnhatphimController(QuanLyRapChieuPhimContext context)
    {
      _context = context;
    }

    // GET: Hiển thị thông tin phim để cập nhật
    public IActionResult Index(int id)
    {
      var phim = _context.Phims.FirstOrDefault(p => p.PhimId == id);
      if (phim == null)
      {
        return NotFound("Không tìm thấy thông tin phim để cập nhật."); // Trả về lỗi nếu không tìm thấy phim
      }

      return View(phim); // Truyền dữ liệu phim sang View
    }

    // POST: Nhận thông tin chỉnh sửa từ người dùng
    [HttpPost]
    public IActionResult Update(Phim updatedPhim)
    {
      if (!ModelState.IsValid)
      {
        TempData["Error"] = "Thông tin không hợp lệ. Vui lòng kiểm tra lại.";
        return RedirectToAction("Index", new { id = updatedPhim.PhimId });
      }

      var existingPhim = _context.Phims.FirstOrDefault(p => p.PhimId == updatedPhim.PhimId);

      if (existingPhim != null)
      {
        existingPhim.TenPhim = updatedPhim.TenPhim;
        existingPhim.TheLoai = updatedPhim.TheLoai;
        existingPhim.NgayKhoiChieu = updatedPhim.NgayKhoiChieu;
        existingPhim.DaoDien = updatedPhim.DaoDien;
        existingPhim.DienVien = updatedPhim.DienVien;
        existingPhim.MoTa = updatedPhim.MoTa;
        existingPhim.ThoiLuong = updatedPhim.ThoiLuong;
        existingPhim.DanhGia = updatedPhim.DanhGia;
        existingPhim.HinhAnh = updatedPhim.HinhAnh;

        _context.SaveChanges();

        TempData["Success"] = "Cập nhật phim thành công!";
        return RedirectToAction("Index", "Quanlyphim");
      }

      TempData["Error"] = "Phim không tồn tại.";
      return RedirectToAction("Index", new { id = updatedPhim.PhimId });
    }
  }
}
