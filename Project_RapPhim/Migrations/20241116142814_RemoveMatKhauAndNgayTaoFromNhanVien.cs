using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_RapPhim.Migrations
{
  /// <inheritdoc />
  public partial class RemoveMatKhauAndNgayTaoFromNhanVien : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      // Xóa cột MatKhau và NgayTao khỏi bảng NhanVien
      migrationBuilder.DropColumn(
          name: "MatKhau",
          table: "NhanVien");

      migrationBuilder.DropColumn(
          name: "NgayTao",
          table: "NhanVien");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      // Khôi phục lại cột MatKhau và NgayTao nếu rollback
      migrationBuilder.AddColumn<string>(
          name: "MatKhau",
          table: "NhanVien",
          type: "nvarchar(max)",
          nullable: true);

      migrationBuilder.AddColumn<DateTime>(
          name: "NgayTao",
          table: "NhanVien",
          type: "datetime2",
          nullable: false,
          defaultValue: DateTime.Now);
    }
  }
}
