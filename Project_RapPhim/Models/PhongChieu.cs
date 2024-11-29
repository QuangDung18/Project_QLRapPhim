using System;
using System.ComponentModel.DataAnnotations;

namespace Project_RapPhim.Models
{
  public class PhongChieu
  {
    [Key]
    public int PhongChieuId { get; set; }
    public int MaPhong { get; set; }
    public int? MaRap { get; set; }
    public string TenPhong { get; set; }
    public int? SoChoNgoi { get; set; }

    public PhongChieu(string tenPhong)
    {
      TenPhong = tenPhong;
    }
  }
}
