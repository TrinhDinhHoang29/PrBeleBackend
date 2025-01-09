using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrBeleBackend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updatesetting : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "mainLogo",
                table: "Setting",
                newName: "MainLogo");

            migrationBuilder.RenameColumn(
                name: "subLogo",
                table: "Setting",
                newName: "SubBanner2");

            migrationBuilder.RenameColumn(
                name: "ZaloLink",
                table: "Setting",
                newName: "SubBanner1");

            migrationBuilder.RenameColumn(
                name: "TiktokLink",
                table: "Setting",
                newName: "SloganLogo");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Setting",
                newName: "SlideshowBanner3");

            migrationBuilder.AddColumn<string>(
                name: "BranchAddress1",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchAddress2",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchName1",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BranchName2",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainBanner",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceInfo1",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceInfo2",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceInfo3",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceInfo4",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceTitle1",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceTitle2",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceTitle3",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceTitle4",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SlideshowBanner1",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SlideshowBanner2",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchAddress1",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "BranchAddress2",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "BranchName1",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "BranchName2",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "MainBanner",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ServiceInfo1",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ServiceInfo2",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ServiceInfo3",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ServiceInfo4",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ServiceTitle1",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ServiceTitle2",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ServiceTitle3",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "ServiceTitle4",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "SlideshowBanner1",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "SlideshowBanner2",
                table: "Setting");

            migrationBuilder.RenameColumn(
                name: "MainLogo",
                table: "Setting",
                newName: "mainLogo");

            migrationBuilder.RenameColumn(
                name: "SubBanner2",
                table: "Setting",
                newName: "subLogo");

            migrationBuilder.RenameColumn(
                name: "SubBanner1",
                table: "Setting",
                newName: "ZaloLink");

            migrationBuilder.RenameColumn(
                name: "SloganLogo",
                table: "Setting",
                newName: "TiktokLink");

            migrationBuilder.RenameColumn(
                name: "SlideshowBanner3",
                table: "Setting",
                newName: "Address");
        }
    }
}
