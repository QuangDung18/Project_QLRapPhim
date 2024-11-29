using Microsoft.AspNetCore.Mvc;
using Project_RapPhim.Models;
using System.Linq;

namespace Project_RapPhim.Controllers
{
  public class XoaphimController : Controller
  {
    private readonly QuanLyRapChieuPhimContext _context;

    public XoaphimController(QuanLyRapChieuPhimContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult Index(int id)
    {
      // Tìm phim theo ID
      var phim = _context.Phims.FirstOrDefault(p => p.PhimId == id);

      if (phim == null)
      {
        return NotFound("Không tìm thấy phim cần xóa.");
      }

      // Xóa phim
      _context.Phims.Remove(phim);
      _context.SaveChanges();

      // Chuyển hướng về trang Quản lý phim
      return RedirectToAction("Index", "Quanlyphim");
    }
  }
}
