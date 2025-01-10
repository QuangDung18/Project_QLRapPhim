using Microsoft.AspNetCore.Mvc;
using Project_RapPhim.Models;
using Project_RapPhim.ViewModels;

namespace Project_RapPhim.Controllers
{
  public class DatveController : Controller
  {
        private readonly QuanLyRapChieuPhimContext _context;

        public DatveController(QuanLyRapChieuPhimContext context)
        {
          _context = context;
        }

        public IActionResult Index(int maPhim)
        {
            var phim = _context.Phims.FirstOrDefault(p => p.MaPhim == maPhim);

            if (phim == null)
            {
                return NotFound("Không tìm thấy phim.");
            }
            var currentDateTime = DateTime.ParseExact("20/10/2024", "dd/MM/yyyy", null);
            var suatChieu = _context.SuatChieus
                            .Where(s => s.MaPhim == maPhim &&
                                        (s.NgayChieu > currentDateTime ||
                                         (s.NgayChieu == currentDateTime && s.GioChieu >= currentDateTime.TimeOfDay)))
                            .ToList();

            var viewModel = new PhimSuatChieuViewModel
            {
                Phim = phim,
                SuatChieu = suatChieu
            };

            return View(viewModel);
        }

        public IActionResult ChonGhe(int maSuat)
        {
            var suatChieu = _context.SuatChieus.FirstOrDefault(s => s.SuatChieuId == maSuat);
            if (suatChieu == null)
            {
                return NotFound("Không tìm thấy suất chiếu.");
            }

            var phongChieu = _context.PhongChieus.FirstOrDefault(pc => pc.PhongChieuId == suatChieu.MaPhong);

            // Lấy danh sách ghế và kiểm tra trạng thái
            var gheNgois = _context.GheNgois
                .Where(g => g.MaPhong == suatChieu.MaPhong)
                .Select(g => new GheNgoiViewModel
                {
                    GheNgoiId = g.GheNgoiId,
                    HangGhe = g.HangGhe,
                    SoGhe = g.SoGhe,
                    TrangThai = _context.Ves.Any(v =>
                        v.MaSuat == maSuat &&
                        v.MaGhe == g.GheNgoiId)
                })
                .ToList();

            var viewModel = new SuatChieuGheViewModel
            {
                SuatChieu = suatChieu,
                GheNgois = gheNgois
            };

            return View(viewModel);
        }
        public void EnsureFullSeats(int maPhong, int? soChoNgoi)
        {
            // Lấy danh sách ghế đã có trong phòng
            var existingSeats = _context.GheNgois
                .Where(g => g.MaPhong == maPhong)
                .OrderBy(g => g.GheNgoiId)
                .ToList();

            // Kiểm tra số ghế hiện tại
            if (existingSeats.Count >= soChoNgoi)
            {
                return; // Đã đủ ghế, không cần thêm
            }

            // Thêm ghế còn thiếu
            int gheCanThem = (int)(soChoNgoi - existingSeats.Count);
            char hangHienTai = existingSeats.LastOrDefault()?.HangGhe ?? 'A';
            int soGheHienTai = existingSeats.LastOrDefault()?.SoGhe ?? 0;

            for (int i = 0; i < gheCanThem; i++)
            {
                // Xác định ghế mới
                soGheHienTai++;
                if (soGheHienTai > 10) // Giả sử mỗi hàng có tối đa 10 ghế
                {
                    soGheHienTai = 1;
                    hangHienTai++;
                }

                // Tạo ghế mới
                var newSeat = new GheNgoi
                {
                    MaGhe = existingSeats.Count + i + 1, // Tạo ID ghế
                    MaPhong = maPhong,
                    HangGhe = hangHienTai,
                    SoGhe = soGheHienTai,
                    TrangThai = false // Mặc định ghế trống
                };

                _context.GheNgois.Add(newSeat);
            }

            _context.SaveChanges(); // Lưu thay đổi vào database
        }
        [HttpPost]
        public IActionResult DatGhe(int[] maGhe, int maSuat)
        {
            var maNguoiDung = GetMaNguoiDung();
            if (maNguoiDung == null)
            {
                return RedirectToAction("Index", "Dangnhap");
            }

            // Kiểm tra danh sách ghế
            var gheList = _context.GheNgois
                                  .Where(g => maGhe.Contains(g.GheNgoiId) && !g.TrangThai)
                                  .ToList();

            if (!gheList.Any())
            {
                return BadRequest("Tất cả các ghế được chọn đều đã bị đặt hoặc không hợp lệ.");
            }

            // Danh sách vé vừa tạo
            var veMoi = new List<Ve>();

            foreach (var ghe in gheList)
            {
                ghe.TrangThai = true;

                var ve = new Ve
                {
                    MaGhe = ghe.GheNgoiId,
                    MaSuat = maSuat,
                    MaNguoiDung = maNguoiDung.Value,
                    NgayMua = DateTime.Now,
                    TrangThai = "Đã mua"
                };

                _context.Ves.Add(ve);
                veMoi.Add(ve);
            }

            _context.SaveChanges();

            // Lưu danh sách vé vừa mua vào TempData để hiển thị ở trang DatGheThanhCong
            TempData["VeMoi"] = System.Text.Json.JsonSerializer.Serialize(veMoi);

            return RedirectToAction("DatGheThanhCong");
        }
        public IActionResult DatGheThanhCong()
        {
            // Lấy danh sách vé từ TempData
            var veMoiJson = TempData["VeMoi"] as string;
            var veMoi = string.IsNullOrEmpty(veMoiJson)
                ? new List<Ve>()
                : System.Text.Json.JsonSerializer.Deserialize<List<Ve>>(veMoiJson);

            return View(veMoi);
        }
        private int? GetMaNguoiDung()
        {
            var emailNguoiDung = HttpContext.Session.GetString("EmailNguoiDung");
            if (string.IsNullOrEmpty(emailNguoiDung))
            {
                return null;
            }

            var nguoiDung = _context.NguoiDungs.FirstOrDefault(nd => nd.Email == emailNguoiDung);
            return nguoiDung?.NguoiDungId;
        }
        public IActionResult LichSuDatVe()
        {
            // Lấy MaNguoiDung từ session
            var emailNguoiDung = HttpContext.Session.GetString("EmailNguoiDung");
            if (string.IsNullOrEmpty(emailNguoiDung))
            {
                return RedirectToAction("Index", "Dangnhap");
            }

            var maNguoiDung = _context.NguoiDungs
                .Where(nd => nd.Email == emailNguoiDung)
                .Select(nd => nd.MaNguoiDung)
                .FirstOrDefault();

            if (maNguoiDung == 0)
            {
                return NotFound("Không tìm thấy người dùng.");
            }

            // Lấy danh sách vé của người dùng
            var veList = _context.Ves
                .Where(v => v.MaNguoiDung == maNguoiDung)
                .ToList();

            // Truyền dữ liệu vào ViewBag
            ViewBag.VeList = veList;

            return View();
        }
    }
}
