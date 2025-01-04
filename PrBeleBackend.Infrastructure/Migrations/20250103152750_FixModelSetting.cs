using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrBeleBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixModelSetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainLogoId",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "SubLogoId",
                table: "Setting");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MainLogoId",
                table: "Setting",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubLogoId",
                table: "Setting",
                type: "int",
                nullable: true);
        }
    }
}
