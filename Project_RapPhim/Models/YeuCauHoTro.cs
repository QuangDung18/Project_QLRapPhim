using System;
using System.ComponentModel.DataAnnotations;

namespace Project_RapPhim.Models
{
  public class YeuCauHoTro
  {
    [Key]
    public int YeuCauHoTroId { get; set; }
    public int MaYeuCau { get; set; }
    public int? MaNguoiDung { get; set; }
    public string LoaiYeuCau { get; set; }
    public string DanhMuc { get; set; }
    public string TieuDe { get; set; }
    public string NoiDung { get; set; }
    public string TrangThai { get; set; }
    public DateTime NgayTao { get; set; }

    public YeuCauHoTro(string loaiYeuCau, string danhMuc, string tieuDe, string noiDung, string trangThai)
    {
      LoaiYeuCau = loaiYeuCau;
      DanhMuc = danhMuc;
      TieuDe = tieuDe;
      NoiDung = noiDung;
      TrangThai = trangThai;
    }
  }
}
