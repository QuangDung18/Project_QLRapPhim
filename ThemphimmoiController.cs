using Microsoft.AspNetCore.Mvc;
using Project_RapPhim.Models;
using System;

namespace Project_RapPhim.Controllers
{
  public class ThemphimmoiController : Controller
  {
    private readonly QuanLyRapChieuPhimContext _context;

    public ThemphimmoiController(QuanLyRapChieuPhimContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
      return View(); // Hiển thị form thêm phim
    }

    [HttpPost]
    public IActionResult Index(Phim newPhim)
    {
      if (ModelState.IsValid)
      {
        // Đặt ngày tạo và thêm vào database
        newPhim.NgayTao = DateTime.Now;

        _context.Phims.Add(newPhim);
        _context.SaveChanges();

        // Thông báo thành công và làm trống form
        ViewBag.Message = "Thêm phim mới thành công!";
        ModelState.Clear();
        return View();
      }

      ViewBag.Message = "Đã xảy ra lỗi. Vui lòng kiểm tra thông tin nhập!";
      return View(newPhim);
    }
  }
}
