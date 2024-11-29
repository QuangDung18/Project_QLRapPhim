using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_RapPhim.Migrations
{
    /// <inheritdoc />
    public partial class AddHinhAnhColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HinhAnh",
                table: "Phims",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HinhAnh",
                table: "Phims");
        }
    }
}
