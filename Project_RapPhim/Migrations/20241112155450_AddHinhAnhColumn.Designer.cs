﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project_RapPhim.Models;

#nullable disable

namespace Project_RapPhim.Migrations
{
    [DbContext(typeof(QuanLyRapChieuPhimContext))]
    [Migration("20241112155450_AddHinhAnhColumn")]
    partial class AddHinhAnhColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Phim", b =>
                {
                    b.Property<int>("PhimId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhimId"));

                    b.Property<decimal?>("DanhGia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("DaoDien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DienVien")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HinhAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaPhim")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayKhoiChieu")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenPhim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TheLoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ThoiLuong")
                        .HasColumnType("int");

                    b.HasKey("PhimId");

                    b.ToTable("Phims");
                });

            modelBuilder.Entity("Project_RapPhim.Models.GheNgoi", b =>
                {
                    b.Property<int>("GheNgoiId")
                        .HasColumnType("int");

                    b.Property<string>("HangGhe")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<int>("MaGhe")
                        .HasColumnType("int");

                    b.Property<int?>("MaPhong")
                        .HasColumnType("int");

                    b.Property<int>("SoGhe")
                        .HasColumnType("int");

                    b.Property<bool>("TrangThai")
                        .HasColumnType("bit");

                    b.ToTable("GheNgois");
                });

            modelBuilder.Entity("Project_RapPhim.Models.KhuyenMai", b =>
                {
                    b.Property<decimal?>("GiamGia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("KhuyenMaiId")
                        .HasColumnType("int");

                    b.Property<int>("MaKhuyenMai")
                        .HasColumnType("int");

                    b.Property<string>("MoTa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NgayBatDau")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("NgayKetThuc")
                        .HasColumnType("datetime2");

                    b.Property<string>("TenKhuyenMai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("KhuyenMais");
                });

            modelBuilder.Entity("Project_RapPhim.Models.NguoiDung", b =>
                {
                    b.Property<int>("NguoiDungId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NguoiDungId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MaNguoiDung")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VaiTro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NguoiDungId");

                    b.ToTable("NguoiDungs");
                });

            modelBuilder.Entity("Project_RapPhim.Models.NhanVien", b =>
                {
                    b.Property<int>("NhanVienId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NhanVienId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaNguoiDung")
                        .HasColumnType("int");

                    b.Property<int>("MaNhanVien")
                        .HasColumnType("int");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VaiTro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NhanVienId");

                    b.ToTable("NhanViens");
                });

            modelBuilder.Entity("Project_RapPhim.Models.PhongChieu", b =>
                {
                    b.Property<int>("PhongChieuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhongChieuId"));

                    b.Property<int>("MaPhong")
                        .HasColumnType("int");

                    b.Property<int?>("MaRap")
                        .HasColumnType("int");

                    b.Property<int?>("SoChoNgoi")
                        .HasColumnType("int");

                    b.Property<string>("TenPhong")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhongChieuId");

                    b.ToTable("PhongChieus");
                });

            modelBuilder.Entity("Project_RapPhim.Models.RapChieu", b =>
                {
                    b.Property<int>("RapChieuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RapChieuId"));

                    b.Property<int>("MaRap")
                        .HasColumnType("int");

                    b.Property<int?>("SoChoNgoi")
                        .HasColumnType("int");

                    b.Property<string>("TenRap")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ViTri")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RapChieuId");

                    b.ToTable("RapChieus");
                });

            modelBuilder.Entity("Project_RapPhim.Models.SuatChieu", b =>
                {
                    b.Property<int>("SuatChieuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SuatChieuId"));

                    b.Property<decimal?>("GiaVe")
                        .HasColumnType("decimal(18,2)");

                    b.Property<TimeSpan?>("GioChieu")
                        .HasColumnType("time");

                    b.Property<int?>("MaPhim")
                        .HasColumnType("int");

                    b.Property<int?>("MaPhong")
                        .HasColumnType("int");

                    b.Property<int>("MaSuat")
                        .HasColumnType("int");

                    b.Property<DateTime?>("NgayChieu")
                        .HasColumnType("datetime2");

                    b.HasKey("SuatChieuId");

                    b.ToTable("SuatChieus");
                });

            modelBuilder.Entity("Project_RapPhim.Models.Ve", b =>
                {
                    b.Property<int>("VeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VeId"));

                    b.Property<int?>("MaGhe")
                        .HasColumnType("int");

                    b.Property<int?>("MaNguoiDung")
                        .HasColumnType("int");

                    b.Property<int?>("MaSuat")
                        .HasColumnType("int");

                    b.Property<int>("MaVe")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayMua")
                        .HasColumnType("datetime2");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VeId");

                    b.ToTable("Ves");
                });

            modelBuilder.Entity("Project_RapPhim.Models.VeKhuyenMai", b =>
                {
                    b.Property<int>("MaKhuyenMai")
                        .HasColumnType("int");

                    b.Property<int>("MaVe")
                        .HasColumnType("int");

                    b.Property<decimal?>("SoTienGiam")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VeKhuyenMaiId")
                        .HasColumnType("int");

                    b.ToTable("VeKhuyenMais");
                });

            modelBuilder.Entity("Project_RapPhim.Models.YeuCauHoTro", b =>
                {
                    b.Property<string>("DanhMuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoaiYeuCau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaNguoiDung")
                        .HasColumnType("int");

                    b.Property<int>("MaYeuCau")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayTao")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YeuCauHoTroId")
                        .HasColumnType("int");

                    b.ToTable("YeuCauHoTros");
                });
#pragma warning restore 612, 618
        }
    }
}
