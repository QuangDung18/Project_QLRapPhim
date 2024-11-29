using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_RapPhim.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDecimalFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GheNgois",
                columns: table => new
                {
                    GheNgoiId = table.Column<int>(type: "int", nullable: false),
                    MaGhe = table.Column<int>(type: "int", nullable: false),
                    MaPhong = table.Column<int>(type: "int", nullable: true),
                    HangGhe = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    SoGhe = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMais",
                columns: table => new
                {
                    KhuyenMaiId = table.Column<int>(type: "int", nullable: false),
                    MaKhuyenMai = table.Column<int>(type: "int", nullable: false),
                    TenKhuyenMai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiamGia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NgayBatDau = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "NguoiDungs",
                columns: table => new
                {
                    NguoiDungId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNguoiDung = table.Column<int>(type: "int", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaiTro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDungs", x => x.NguoiDungId);
                });

            migrationBuilder.CreateTable(
                name: "NhanViens",
                columns: table => new
                {
                    NhanVienId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaNhanVien = table.Column<int>(type: "int", nullable: false),
                    HoTen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VaiTro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaNguoiDung = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanViens", x => x.NhanVienId);
                });

            migrationBuilder.CreateTable(
                name: "Phims",
                columns: table => new
                {
                    PhimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhim = table.Column<int>(type: "int", nullable: false),
                    TenPhim = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TheLoai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayKhoiChieu = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DaoDien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DienVien = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThoiLuong = table.Column<int>(type: "int", nullable: true),
                    DanhGia = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phims", x => x.PhimId);
                });

            migrationBuilder.CreateTable(
                name: "PhongChieus",
                columns: table => new
                {
                    PhongChieuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhong = table.Column<int>(type: "int", nullable: false),
                    MaRap = table.Column<int>(type: "int", nullable: true),
                    TenPhong = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoChoNgoi = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongChieus", x => x.PhongChieuId);
                });

            migrationBuilder.CreateTable(
                name: "RapChieus",
                columns: table => new
                {
                    RapChieuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaRap = table.Column<int>(type: "int", nullable: false),
                    TenRap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViTri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoChoNgoi = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RapChieus", x => x.RapChieuId);
                });

            migrationBuilder.CreateTable(
                name: "SuatChieus",
                columns: table => new
                {
                    SuatChieuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaSuat = table.Column<int>(type: "int", nullable: false),
                    MaPhim = table.Column<int>(type: "int", nullable: true),
                    MaPhong = table.Column<int>(type: "int", nullable: true),
                    NgayChieu = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GioChieu = table.Column<TimeSpan>(type: "time", nullable: true),
                    GiaVe = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuatChieus", x => x.SuatChieuId);
                });

            migrationBuilder.CreateTable(
                name: "VeKhuyenMais",
                columns: table => new
                {
                    VeKhuyenMaiId = table.Column<int>(type: "int", nullable: false),
                    MaVe = table.Column<int>(type: "int", nullable: false),
                    MaKhuyenMai = table.Column<int>(type: "int", nullable: false),
                    SoTienGiam = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Ves",
                columns: table => new
                {
                    VeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaVe = table.Column<int>(type: "int", nullable: false),
                    MaNguoiDung = table.Column<int>(type: "int", nullable: true),
                    MaSuat = table.Column<int>(type: "int", nullable: true),
                    MaGhe = table.Column<int>(type: "int", nullable: true),
                    NgayMua = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ves", x => x.VeId);
                });

            migrationBuilder.CreateTable(
                name: "YeuCauHoTros",
                columns: table => new
                {
                    YeuCauHoTroId = table.Column<int>(type: "int", nullable: false),
                    MaYeuCau = table.Column<int>(type: "int", nullable: false),
                    MaNguoiDung = table.Column<int>(type: "int", nullable: true),
                    LoaiYeuCau = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DanhMuc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayTao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GheNgois");

            migrationBuilder.DropTable(
                name: "KhuyenMais");

            migrationBuilder.DropTable(
                name: "NguoiDungs");

            migrationBuilder.DropTable(
                name: "NhanViens");

            migrationBuilder.DropTable(
                name: "Phims");

            migrationBuilder.DropTable(
                name: "PhongChieus");

            migrationBuilder.DropTable(
                name: "RapChieus");

            migrationBuilder.DropTable(
                name: "SuatChieus");

            migrationBuilder.DropTable(
                name: "VeKhuyenMais");

            migrationBuilder.DropTable(
                name: "Ves");

            migrationBuilder.DropTable(
                name: "YeuCauHoTros");
        }
    }
}
