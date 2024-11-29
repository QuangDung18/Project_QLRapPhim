using Microsoft.AspNetCore.Mvc;
using Project_RapPhim.Models;
using System.Linq;

namespace Project_RapPhim.Controllers
{
  public class DangkyController : Controller
  {
    private readonly QuanLyRapChieuPhimContext _context;

    public DangkyController(QuanLyRapChieuPhimContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Index(NguoiDung model)
    {
      
      if (!ModelState.IsValid)
      {
        return View(model);
      }

      
      var emailExists = _context.NguoiDungs.Any(nd => nd.Email == model.Email);
      if (emailExists)
      {
        ModelState.AddModelError("Email", "Email này đã được sử dụng.");
        return View(model);
      }

     
      model.NgayTao = DateTime.Now;
      _context.NguoiDungs.Add(model);
      _context.SaveChanges();

     
      return RedirectToAction("Index", "Dangnhap");
    }
  }
}
