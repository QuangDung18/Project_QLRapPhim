using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; 
using Project_RapPhim.Models;
using System.Linq;
using Project_RapPhim.ViewModels;

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
            // Lấy email người dùng từ session
            var emailNguoiDung = HttpContext.Session.GetString("EmailNguoiDung");

            if (_context.Phims == null)
            {
            return Content("Không có dữ liệu trong bảng Phim.");
            }
            var phimDangChieu = _context.Phims
                .Where(p => p.NgayKhoiChieu.HasValue && p.NgayKhoiChieu.Value.Month == 11)
                .ToList();
            var phimSapChieu = _context.Phims
                .Where(p => p.NgayKhoiChieu.HasValue && p.NgayKhoiChieu.Value.Month == 12)
                .ToList();
            ViewBag.PhimDangChieu = phimDangChieu ?? new List<Phim>();
            ViewBag.PhimSapChieu = phimSapChieu ?? new List<Phim>();
            ViewBag.EmailNguoiDung = emailNguoiDung;

            return View();
        }
        public IActionResult Detail(int id)
        {
			var phim = _context.Phims.FirstOrDefault(p => p.PhimId == id);
			if (phim == null)
			{
				return RedirectToAction("Index", "Trangchu");
			}
            var danhGias = _context.DanhGias
                .Where(d => d.PhimId == id)
                .Select(d => new
                {
                    d.NoiDung,
                    NguoiDung = _context.NguoiDungs.FirstOrDefault(nd => nd.NguoiDungId == d.NguoiDungId).HoTen
                })
                .ToList();
            ViewBag.DanhGias = danhGias;

            // Kiểm tra người dùng có đăng nhập chưa
            var emailNguoiDung = HttpContext.Session.GetString("EmailNguoiDung");
            if (!string.IsNullOrEmpty(emailNguoiDung))
            {
                var nguoiDung = _context.NguoiDungs.FirstOrDefault(nd => nd.Email == emailNguoiDung);
                if (nguoiDung != null)
                {
                    // Lấy thông tin người dùng và hiển thị form đánh giá
                    ViewBag.NguoiDungId = nguoiDung.NguoiDungId;
                }
            }
            return View(phim);
        }
        [HttpPost]
        public IActionResult SubmitReview(int phimId, string noiDung)
        {
            var emailNguoiDung = HttpContext.Session.GetString("EmailNguoiDung");
            if (string.IsNullOrEmpty(emailNguoiDung))
            {
                // Nếu chưa đăng nhập thì yêu cầu đăng nhập
                return RedirectToAction("Index", "Dangnhap");
            }

            var nguoiDung = _context.NguoiDungs.FirstOrDefault(nd => nd.Email == emailNguoiDung);
            if (nguoiDung == null)
            {
                return RedirectToAction("Index", "Trangchu");
            }

            // Lưu đánh giá mới
            var danhGia = new DanhGia
            {
                NguoiDungId = nguoiDung.NguoiDungId,
                PhimId = phimId,
                NoiDung = noiDung
            };

            _context.DanhGias.Add(danhGia);
            _context.SaveChanges();

            TempData["Message"] = "Đánh giá của bạn đã được gửi thành công.";
            return RedirectToAction("Detail", new { id = phimId });
        }
        public IActionResult LichSuDatVe()
		{
            var emailNguoiDung = HttpContext.Session.GetString("EmailNguoiDung");
            if (string.IsNullOrEmpty(emailNguoiDung))
            {
                return RedirectToAction("Index", "Dangnhap");
            }

            // Lấy thông tin người dùng
            var nguoiDung = _context.NguoiDungs.FirstOrDefault(nd => nd.Email == emailNguoiDung);
            if (nguoiDung == null)
            {
                return RedirectToAction("Index", "Trangchu");
            }

            // Truy vấn lịch sử đặt vé
            var lichSuDatVe = _context.Ves
                    .Where(v => v.MaNguoiDung == nguoiDung.NguoiDungId)
                    .Join(_context.SuatChieus, ve => ve.MaSuat, sc => sc.SuatChieuId, (ve, sc) => new { ve, sc })
                    .Join(_context.Phims, combined => combined.sc.MaPhim, phim => phim.PhimId, (combined, phim) => new { combined.ve, combined.sc, phim })
                    .Join(_context.GheNgois, final => final.ve.MaGhe, ghe => ghe.GheNgoiId, (final, ghe) => new LichSuDatVeViewModel
                    {
                        MaVe = final.ve.VeId,
                        TenPhim = final.phim.TenPhim,
                        Ghe = $"{ghe.HangGhe}{ghe.SoGhe}",
                        NgayMua = final.ve.NgayMua,
                        TrangThai = final.ve.TrangThai,
                        NgayChieu = final.sc.NgayChieu.GetValueOrDefault(),
                        GioChieu = final.sc.GioChieu.GetValueOrDefault(),
						TongTien = (decimal)final.sc.GiaVe
					})
                    .ToList();

            if (!lichSuDatVe.Any())
            {
                ViewBag.Message = "Bạn chưa đặt vé nào.";
                return View(new List<LichSuDatVeViewModel>());
            }

            return View(lichSuDatVe);
        }
        [HttpPost]
        public IActionResult ThanhToan(int maVe)
        {
            var ve = _context.Ves.FirstOrDefault(v => v.VeId == maVe);
            if (ve == null)
            {
                return NotFound("Vé không tồn tại.");
            }
            string qrCodeData = $"https://example.com/confirmPayment/{maVe}";
            return View("ConfirmPayment", new { VeId = maVe, QrCodeData = qrCodeData });
        }
        [HttpPost]
        public IActionResult ConfirmPayment(int maVe)
        {
            var ve = _context.Ves.FirstOrDefault(v => v.VeId == maVe);
            if (ve == null)
            {
                return NotFound("Vé không tồn tại.");
            }
            ve.TrangThai = "Đã thanh toán";
            _context.SaveChanges();

            TempData["Message"] = "Thanh toán thành công.";
            return RedirectToAction("LichSuDatVe");
        }
        [HttpPost]
        public IActionResult HuyVe(int maVe)
        {
            var ve = _context.Ves.FirstOrDefault(v => v.VeId == maVe);

            if (ve == null)
            {
                return NotFound("Không tìm thấy vé.");
            }

            // Cập nhật trạng thái vé thành "Đã hủy"
            ve.TrangThai = "Đã hủy";

            // Cập nhật trạng thái ghế là không còn sử dụng
            var ghe = _context.GheNgois.FirstOrDefault(g => g.GheNgoiId == ve.MaGhe);
            if (ghe != null)
            {
                ghe.TrangThai = false;  // ghế trở thành không còn trống
            }

            _context.SaveChanges();

            TempData["Message"] = "Vé đã được hủy thành công.";
            return RedirectToAction("LichSuDatVe");
        }
        [HttpGet]
        public IActionResult YeuCauHoTro()
        {
            var emailNguoiDung = HttpContext.Session.GetString("EmailNguoiDung");
            if (string.IsNullOrEmpty(emailNguoiDung))
            {
                return RedirectToAction("Index", "Dangnhap");
            }

            return View();
        }

        [HttpPost]
        public IActionResult YeuCauHoTro(string loaiYeuCau, string danhMuc, string tieuDe, string noiDung)
        {
            var emailNguoiDung = HttpContext.Session.GetString("EmailNguoiDung");
            if (string.IsNullOrEmpty(emailNguoiDung))
            {
                return RedirectToAction("Index", "Dangnhap");
            }

            // Lấy thông tin người dùng
            var nguoiDung = _context.NguoiDungs.FirstOrDefault(nd => nd.Email == emailNguoiDung);
            if (nguoiDung == null)
            {
                return RedirectToAction("Index", "Trangchu");
            }

            // Tạo mới yêu cầu hỗ trợ
            var yeuCauHoTro = new YeuCauHoTro
            {
                MaYeuCau = 1,
                MaNguoiDung = nguoiDung.NguoiDungId,
                LoaiYeuCau = loaiYeuCau,
                DanhMuc = danhMuc,
                TieuDe = tieuDe,
                NoiDung = noiDung,
                NgayTao = DateTime.Now,
                TrangThai = "Chưa xử lý"
            };

            _context.YeuCauHoTros.Add(yeuCauHoTro);
            _context.SaveChanges();

            TempData["Message"] = "Yêu cầu hỗ trợ của bạn đã được gửi thành công.";
            return RedirectToAction("Index");
        }
    }
}
