using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ataal.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddingNotificationCounterForCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NotificationCounter",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotificationCounter",
                table: "Customers");
        }
    }
}
