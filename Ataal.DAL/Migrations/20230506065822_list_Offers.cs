using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ataal.DAL.Migrations
{
    /// <inheritdoc />
    public partial class list_Offers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Offers_technicalId",
                table: "Offers");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_technicalId",
                table: "Offers",
                column: "technicalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Offers_technicalId",
                table: "Offers");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_technicalId",
                table: "Offers",
                column: "technicalId",
                unique: true);
        }
    }
}
