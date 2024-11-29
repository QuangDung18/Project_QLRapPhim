using System;
using System.ComponentModel.DataAnnotations;

namespace Project_RapPhim.Models
{
  public class VeKhuyenMai
  {
    [Key]
    public int VeKhuyenMaiId { get; set; }
    public int MaVe { get; set; }
    public int MaKhuyenMai { get; set; }
    public decimal? SoTienGiam { get; set; }
  }
}
