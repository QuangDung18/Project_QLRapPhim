using Microsoft.AspNetCore.Mvc;
using Project_RapPhim.Models;
using System.Linq;

namespace Project_RapPhim.Controllers
{
  public class QuanlynhanvienController : Controller
  {
    private readonly QuanLyRapChieuPhimContext _context;

    public QuanlynhanvienController(QuanLyRapChieuPhimContext context)
    {
      _context = context;
    }

    // GET: Hiển thị danh sách nhân viên
    public IActionResult Index()
    {
      var nhanViens = _context.NhanViens.ToList();
      return View(nhanViens);
    }
  }
}
