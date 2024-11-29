using System;
using System.ComponentModel.DataAnnotations;

namespace Project_RapPhim.Models
{
    public class NhanVien
    {
        [Key]
        public int NhanVienId { get; set; } // Tự tăng, không cần nhập
        [Required(ErrorMessage = "Mã Nhân Viên không được để trống")]
        public int MaNhanVien { get; set; }

        [Required(ErrorMessage = "Họ Tên không được để trống")]
        [StringLength(100, ErrorMessage = "Họ Tên không được vượt quá 100 ký tự")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Số Điện Thoại không được để trống")]
        [Phone(ErrorMessage = "Số Điện Thoại không hợp lệ")]
        public string SoDienThoai { get; set; }

        [Required(ErrorMessage = "Vai Trò không được để trống")]
        [StringLength(50, ErrorMessage = "Vai Trò không được vượt quá 50 ký tự")]
        public string VaiTro { get; set; }

        [Required(ErrorMessage = "Trạng Thái không được để trống")]
        [StringLength(50, ErrorMessage = "Trạng Thái không được vượt quá 50 ký tự")]
        public string TrangThai { get; set; }

        public int? MaNguoiDung { get; set; } // Trường không bắt buộc

        // Constructor mặc định
        public NhanVien() { }

        // Constructor có tham số
        public NhanVien(int maNhanVien, string hoTen, string email, string soDienThoai, string vaiTro, string trangThai, int? maNguoiDung = null)
        {
            MaNhanVien = maNhanVien;
            HoTen = hoTen;
            Email = email;
            SoDienThoai = soDienThoai;
            VaiTro = vaiTro;
            TrangThai = trangThai;
            MaNguoiDung = maNguoiDung;
        }
    }
}
