using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopStore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLaptopFull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cpu",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gpu",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ram",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScreenSize",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Laptops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Storage",
                table: "Laptops",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "Cpu",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "Gpu",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "Ram",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "ScreenSize",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Laptops");

            migrationBuilder.DropColumn(
                name: "Storage",
                table: "Laptops");
        }
    }
}
