using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Project_RapPhim.Models // Đặt namespace phù hợp với dự án của bạn
{
	public class Phim
	{
		[Key]
		public int PhimId { get; set; } // Khóa chính

		//[Required(ErrorMessage = "Mã phim không được để trống.")]
		//[Range(1, int.MaxValue, ErrorMessage = "Mã phim phải là một giá trị hợp lệ.")]
		public int MaPhim { get; set; }

		[Required(ErrorMessage = "Tên phim không được để trống.")]
		[StringLength(255, ErrorMessage = "Tên phim không được vượt quá 255 ký tự.")]
		public string TenPhim { get; set; }

		[Required(ErrorMessage = "Thể loại không được để trống.")]
		[StringLength(100, ErrorMessage = "Thể loại không được vượt quá 100 ký tự.")]
		public string TheLoai { get; set; }

		[Required(ErrorMessage = "Ngày khởi chiếu không được để trống.")]
		[DataType(DataType.Date, ErrorMessage = "Ngày khởi chiếu phải có định dạng ngày hợp lệ.")]
		public DateTime? NgayKhoiChieu { get; set; }

		[Required(ErrorMessage = "Đạo diễn không được để trống.")]
		[StringLength(200, ErrorMessage = "Tên đạo diễn không được vượt quá 200 ký tự.")]
		public string DaoDien { get; set; }

		[Required(ErrorMessage = "Diễn viên không được để trống.")]
		[StringLength(500, ErrorMessage = "Danh sách diễn viên không được vượt quá 500 ký tự.")]
		public string DienVien { get; set; }

		[StringLength(1000, ErrorMessage = "Mô tả phim không được vượt quá 1000 ký tự.")]
		public string MoTa { get; set; }

		[Range(1, int.MaxValue, ErrorMessage = "Thời lượng phim phải lớn hơn 0.")]
		public int? ThoiLuong { get; set; }

		[Range(0, 10, ErrorMessage = "Đánh giá phải trong khoảng từ 0 đến 10.")]
		public decimal? DanhGia { get; set; }

		[Required(ErrorMessage = "Ngày tạo không được để trống.")]
		public DateTime NgayTao { get; set; }

		[Required(ErrorMessage = "Hình ảnh không được để trống.")]
		[StringLength(255, ErrorMessage = "Tên hình ảnh không được vượt quá 255 ký tự.")]
		public string HinhAnh { get; set; }

		// Constructor không tham số để Entity Framework có thể khởi tạo đối tượng
		public Phim() { }

		// Constructor có tham số để khởi tạo với dữ liệu bắt buộc
		public Phim(string tenPhim, string theLoai, string daoDien, string dienVien, string moTa, string hinhAnh)
		{
			TenPhim = tenPhim;
			TheLoai = theLoai;
			DaoDien = daoDien;
			DienVien = dienVien;
			MoTa = moTa;
			HinhAnh = hinhAnh; // Khởi tạo HinhAnh
			NgayTao = DateTime.Now; // Đặt ngày tạo mặc định
		}
	}
}
