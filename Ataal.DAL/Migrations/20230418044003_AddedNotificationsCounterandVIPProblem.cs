using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ataal.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedNotificationsCounterandVIPProblem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NotificationCounter",
                table: "Technicals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "VIP",
                table: "Problems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotificationCounter",
                table: "Technicals");

            migrationBuilder.DropColumn(
                name: "VIP",
                table: "Problems");
        }
    }
}
