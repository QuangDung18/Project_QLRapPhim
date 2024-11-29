using System;
using System.ComponentModel.DataAnnotations;

namespace Project_RapPhim.Models
{
  public class SuatChieu
  {
    [Key]
    public int SuatChieuId { get; set; }
    public int MaSuat { get; set; }
    public int? MaPhim { get; set; }
    public int? MaPhong { get; set; }
    public DateTime? NgayChieu { get; set; }
    public TimeSpan? GioChieu { get; set; }
    public decimal? GiaVe { get; set; }
  }
}
