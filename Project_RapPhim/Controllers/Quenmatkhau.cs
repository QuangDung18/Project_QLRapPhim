using Microsoft.AspNetCore.Mvc;
using Project_RapPhim.Models;
using System.Linq;

namespace Project_RapPhim.Controllers
{
  public class QuenmatkhauController : Controller
  {
    private readonly QuanLyRapChieuPhimContext _context;

    public QuenmatkhauController(QuanLyRapChieuPhimContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Index(string email, string soDienThoai, string matKhauMoi)
    {
      
      var nguoiDung = _context.NguoiDungs
          .FirstOrDefault(nd => nd.Email == email && nd.SoDienThoai == soDienThoai);

      if (nguoiDung != null)
      {
        
        nguoiDung.MatKhau = matKhauMoi;
        _context.SaveChanges();

       
        return RedirectToAction("Index", "Dangnhap");
      }
      else
      {
        
        ViewBag.Message = "Thông tin không hợp lệ. Vui lòng kiểm tra lại.";
        return View();
      }
    }
  }
}
