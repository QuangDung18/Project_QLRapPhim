using System;
using System.ComponentModel.DataAnnotations;

namespace Project_RapPhim.Models
{
  public class NguoiDung
  {
    [Key]
    public int NguoiDungId { get; set; }

    public int MaNguoiDung { get; set; }

    [Required(ErrorMessage = "Họ tên là bắt buộc.")]
    public string HoTen { get; set; }

    [Required(ErrorMessage = "Email là bắt buộc.")]
    [EmailAddress(ErrorMessage = "Email không hợp lệ.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Số điện thoại là bắt buộc.")]
    public string SoDienThoai { get; set; }

    [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
    public string MatKhau { get; set; }

    [Required(ErrorMessage = "Vai trò là bắt buộc.")]
    public string VaiTro { get; set; }

    public DateTime NgayTao { get; set; }

    public NguoiDung(string hoTen, string email, string soDienThoai, string matKhau, string vaiTro)
    {
      HoTen = hoTen;
      Email = email;
      SoDienThoai = soDienThoai;
      MatKhau = matKhau;
      VaiTro = vaiTro;
    }

    public NguoiDung() { }
  }
}
