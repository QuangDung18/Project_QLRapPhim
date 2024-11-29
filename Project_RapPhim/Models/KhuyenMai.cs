using System;
using System.ComponentModel.DataAnnotations;

namespace Project_RapPhim.Models
{
  public class KhuyenMai
  {
    [Key]
    public int KhuyenMaiId { get; set; }
    public int MaKhuyenMai { get; set; }
    public string TenKhuyenMai { get; set; }
    public string MoTa { get; set; }
    public decimal? GiamGia { get; set; }
    public DateTime? NgayBatDau { get; set; }
    public DateTime? NgayKetThuc { get; set; }

    public KhuyenMai(string tenKhuyenMai, string moTa)
    {
      TenKhuyenMai = tenKhuyenMai;
      MoTa = moTa;
    }
  }
}
