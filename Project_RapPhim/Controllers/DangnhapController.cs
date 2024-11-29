using Microsoft.AspNetCore.Mvc;
using Project_RapPhim.Models;
using System.Linq;

namespace Project_RapPhim.Controllers
{
  public class DangnhapController : Controller
  {
    private readonly QuanLyRapChieuPhimContext _context;

    public DangnhapController(QuanLyRapChieuPhimContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Index(string email, string matKhau)
    {
      
      if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(matKhau))
      {
        ModelState.AddModelError("", "Vui lòng điền đầy đủ thông tin đăng nhập.");
        return View();
      }

      
      var nguoiDung = _context.NguoiDungs.FirstOrDefault(nd => nd.Email == email && nd.MatKhau == matKhau);

      if (nguoiDung == null)
      {
        ModelState.AddModelError("", "Email hoặc mật khẩu không chính xác.");
        return View();
      }

      
      return RedirectToAction("Index", "Trangchu");
    }
  }
}
