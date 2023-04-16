using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ataal.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddingRateEntity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rate_Customers_Customer_ID",
                table: "Rate");

            migrationBuilder.DropForeignKey(
                name: "FK_Rate_Technicals_Technical_ID",
                table: "Rate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rate",
                table: "Rate");

            migrationBuilder.RenameTable(
                name: "Rate",
                newName: "Rates");

            migrationBuilder.RenameIndex(
                name: "IX_Rate_Technical_ID",
                table: "Rates",
                newName: "IX_Rates_Technical_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Rate_Customer_ID",
                table: "Rates",
                newName: "IX_Rates_Customer_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rates",
                table: "Rates",
                column: "RateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Customers_Customer_ID",
                table: "Rates",
                column: "Customer_ID",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rates_Technicals_Technical_ID",
                table: "Rates",
                column: "Technical_ID",
                principalTable: "Technicals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Customers_Customer_ID",
                table: "Rates");

            migrationBuilder.DropForeignKey(
                name: "FK_Rates_Technicals_Technical_ID",
                table: "Rates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rates",
                table: "Rates");

            migrationBuilder.RenameTable(
                name: "Rates",
                newName: "Rate");

            migrationBuilder.RenameIndex(
                name: "IX_Rates_Technical_ID",
                table: "Rate",
                newName: "IX_Rate_Technical_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Rates_Customer_ID",
                table: "Rate",
                newName: "IX_Rate_Customer_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rate",
                table: "Rate",
                column: "RateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rate_Customers_Customer_ID",
                table: "Rate",
                column: "Customer_ID",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rate_Technicals_Technical_ID",
                table: "Rate",
                column: "Technical_ID",
                principalTable: "Technicals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
