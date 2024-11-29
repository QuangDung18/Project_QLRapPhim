using Microsoft.AspNetCore.Mvc;
using Project_RapPhim.Models;
using System;
using System.Linq; // Để sử dụng LINQ

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
				// Kiểm tra xem tên phim đã tồn tại chưa
				bool isExist = _context.Phims
										.AsEnumerable() // Chuyển sang chế độ client-side
										.Any(p => p.TenPhim.Equals(newPhim.TenPhim, StringComparison.OrdinalIgnoreCase));

				if (isExist)
				{
					ViewBag.Message = "Phim đã tồn tại trong cơ sở dữ liệu!";
					return View(newPhim); // Trả lại form với thông báo lỗi
				}

				// Đặt ngày tạo và thêm vào database
				newPhim.NgayTao = DateTime.Now;

				_context.Phims.Add(newPhim);
				_context.SaveChanges();

				// Thông báo thành công và làm trống form
				ViewBag.Message = "Thêm phim mới thành công!";
				ModelState.Clear(); // Làm trống form
				return View();
			}

			ViewBag.Message = "Đã xảy ra lỗi. Vui lòng kiểm tra thông tin nhập!";
			return View(newPhim); // Trả lại form với lỗi
		}
	}
}
