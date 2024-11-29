using System;
using System.ComponentModel.DataAnnotations;

namespace Project_RapPhim.Models
{
  public class Ve
  {
    [Key]
    public int VeId { get; set; }
    public int MaVe { get; set; }
    public int? MaNguoiDung { get; set; }
    public int? MaSuat { get; set; }
    public int? MaGhe { get; set; }
    public DateTime NgayMua { get; set; }
    public string TrangThai { get; set; }

    public Ve(string trangThai)
    {
      TrangThai = trangThai;
    }
  }
}
