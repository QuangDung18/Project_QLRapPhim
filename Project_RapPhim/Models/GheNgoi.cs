using System;
using System.ComponentModel.DataAnnotations;

namespace Project_RapPhim.Models
{
  public class GheNgoi
  {
    [Key]
    public int GheNgoiId { get; set; }
    public int MaGhe { get; set; }
    public int? MaPhong { get; set; }
    public char HangGhe { get; set; }
    public int SoGhe { get; set; }
    public bool TrangThai { get; set; }
  }
}
