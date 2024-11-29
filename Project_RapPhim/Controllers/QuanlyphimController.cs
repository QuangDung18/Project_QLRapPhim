using Microsoft.AspNetCore.Mvc;
using Project_RapPhim.Models;
using System.Linq;

namespace Project_RapPhim.Controllers
{
  public class QuanlyphimController : Controller
  {
    private readonly QuanLyRapChieuPhimContext _context;

    public QuanlyphimController(QuanLyRapChieuPhimContext context)
    {
      _context = context;
    }

    public IActionResult Index()
    {
      if (_context.Phims == null)
      {
        return Content("Không có dữ liệu trong bảng Phim.");
      }

      // Lấy danh sách phim đang chiếu
      var phimDangChieu = _context.Phims
          .Where(p => p.NgayKhoiChieu.HasValue && p.NgayKhoiChieu.Value.Month == 11)
          .ToList();

      // Lấy danh sách phim sắp chiếu
      var phimSapChieu = _context.Phims
          .Where(p => p.NgayKhoiChieu.HasValue && p.NgayKhoiChieu.Value.Month == 12)
          .ToList();

      ViewBag.PhimDangChieu = phimDangChieu ?? new List<Phim>();
      ViewBag.PhimSapChieu = phimSapChieu ?? new List<Phim>();

      return View("~/Views/Quanlyphim/Index.cshtml");
    }
  }
}
