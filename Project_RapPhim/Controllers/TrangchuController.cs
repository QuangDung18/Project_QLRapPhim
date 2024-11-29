using Microsoft.AspNetCore.Mvc;
using Project_RapPhim.Models;
using System.Linq;

namespace Project_RapPhim.Controllers
{
  public class TrangchuController : Controller
  {
    private readonly QuanLyRapChieuPhimContext _context;

    public TrangchuController(QuanLyRapChieuPhimContext context)
    {
      _context = context;
    }

    public IActionResult Index()
    {
      
      if (_context.Phims == null)
      {
        return Content("Không có dữ liệu trong bảng Phim.");
      }

      // Lấy danh sách phim đang chiếu (tháng 11)
      var phimDangChieu = _context.Phims
          .Where(p => p.NgayKhoiChieu.HasValue && p.NgayKhoiChieu.Value.Month == 11)
          .ToList();

      // Lấy danh sách phim sắp chiếu (tháng 12)
      var phimSapChieu = _context.Phims
          .Where(p => p.NgayKhoiChieu.HasValue && p.NgayKhoiChieu.Value.Month == 12)
          .ToList();

      // Truyền dữ liệu vào ViewBag
      ViewBag.PhimDangChieu = phimDangChieu ?? new List<Phim>();
      ViewBag.PhimSapChieu = phimSapChieu ?? new List<Phim>();

      return View("~/Views/Home/Index.cshtml");
    }
  }
}
