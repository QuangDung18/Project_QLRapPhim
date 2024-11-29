using Microsoft.EntityFrameworkCore;

namespace Project_RapPhim.Models
{
  public class QuanLyRapChieuPhimContext : DbContext
  {
    public QuanLyRapChieuPhimContext(DbContextOptions<QuanLyRapChieuPhimContext> options)
    : base(options)
    {
    }

    public DbSet<NguoiDung> NguoiDungs { get; set; }
    public DbSet<Phim> Phims { get; set; }
    public DbSet<RapChieu> RapChieus { get; set; }
    public DbSet<PhongChieu> PhongChieus { get; set; }
    public DbSet<SuatChieu> SuatChieus { get; set; }
    public DbSet<GheNgoi> GheNgois { get; set; }
    public DbSet<Ve> Ves { get; set; }
    public DbSet<KhuyenMai> KhuyenMais { get; set; }
    public DbSet<VeKhuyenMai> VeKhuyenMais { get; set; }
    public DbSet<YeuCauHoTro> YeuCauHoTros { get; set; }
    public DbSet<NhanVien> NhanViens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Thực thể không có khóa chính (chỉ để truy vấn)
      modelBuilder.Entity<GheNgoi>().HasNoKey();
      modelBuilder.Entity<KhuyenMai>().HasNoKey();
      modelBuilder.Entity<VeKhuyenMai>().HasNoKey();
      modelBuilder.Entity<YeuCauHoTro>().HasNoKey();

      // Thực thể có khóa chính (áp dụng cho CRUD)
      modelBuilder.Entity<NguoiDung>().HasKey(n => n.NguoiDungId);
      modelBuilder.Entity<Phim>().HasKey(p => p.PhimId);
      modelBuilder.Entity<RapChieu>().HasKey(r => r.RapChieuId);
      modelBuilder.Entity<PhongChieu>().HasKey(p => p.PhongChieuId);
      modelBuilder.Entity<SuatChieu>().HasKey(s => s.SuatChieuId);
      modelBuilder.Entity<Ve>().HasKey(v => v.VeId);
      modelBuilder.Entity<NhanVien>().HasKey(n => n.NhanVienId);

      // Chỉ định độ chính xác và tỷ lệ cho các thuộc tính decimal
      modelBuilder.Entity<KhuyenMai>()
          .Property(k => k.GiamGia)
          .HasColumnType("decimal(18,2)");

      modelBuilder.Entity<Phim>()
          .Property(p => p.DanhGia)
          .HasColumnType("decimal(18,2)");

      modelBuilder.Entity<SuatChieu>()
          .Property(s => s.GiaVe)
          .HasColumnType("decimal(18,2)");

      modelBuilder.Entity<VeKhuyenMai>()
          .Property(v => v.SoTienGiam)
          .HasColumnType("decimal(18,2)");

      base.OnModelCreating(modelBuilder);
    }
  }
}
