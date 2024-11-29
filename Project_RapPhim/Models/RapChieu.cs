using System;
using System.ComponentModel.DataAnnotations;

namespace Project_RapPhim.Models
{
  public class RapChieu
  {
    [Key]
    public int RapChieuId { get; set; }
    public int MaRap { get; set; }
    public string TenRap { get; set; }
    public string ViTri { get; set; }
    public int? SoChoNgoi { get; set; }

    public RapChieu(string tenRap, string viTri)
    {
      TenRap = tenRap;
      ViTri = viTri;
    }
  }
}
