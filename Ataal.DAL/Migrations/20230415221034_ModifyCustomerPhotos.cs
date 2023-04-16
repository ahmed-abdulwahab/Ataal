using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ataal.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ModifyCustomerPhotos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo1",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "Photo2",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "Photo3",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "Photo4",
                table: "Problems");

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath1",
                table: "Problems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath2",
                table: "Problems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath3",
                table: "Problems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoPath4",
                table: "Problems",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoPath1",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "PhotoPath2",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "PhotoPath3",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "PhotoPath4",
                table: "Problems");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo1",
                table: "Problems",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo2",
                table: "Problems",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo3",
                table: "Problems",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo4",
                table: "Problems",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
