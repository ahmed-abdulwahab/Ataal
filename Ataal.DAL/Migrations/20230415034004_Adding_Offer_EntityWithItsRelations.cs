using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ataal.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Adding_Offer_EntityWithItsRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AcceptedOfferID",
                table: "Problems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    technicalId = table.Column<int>(type: "int", nullable: false),
                    problemId = table.Column<int>(type: "int", nullable: false),
                    OfferSalary = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Offers_Problems_problemId",
                        column: x => x.problemId,
                        principalTable: "Problems",
                        principalColumn: "Problem_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Offers_Technicals_technicalId",
                        column: x => x.technicalId,
                        principalTable: "Technicals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_problemId",
                table: "Offers",
                column: "problemId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_technicalId",
                table: "Offers",
                column: "technicalId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offers");

            migrationBuilder.DropColumn(
                name: "AcceptedOfferID",
                table: "Problems");
        }
    }
}
