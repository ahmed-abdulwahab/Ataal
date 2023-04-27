using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ataal.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddingDBsetForRecommendation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recommendation_Problems_Problem_ID",
                table: "Recommendation");

            migrationBuilder.DropForeignKey(
                name: "FK_Recommendation_Technicals_Technical_ID",
                table: "Recommendation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recommendation",
                table: "Recommendation");

            migrationBuilder.RenameTable(
                name: "Recommendation",
                newName: "Recommendations");

            migrationBuilder.RenameIndex(
                name: "IX_Recommendation_Technical_ID",
                table: "Recommendations",
                newName: "IX_Recommendations_Technical_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Recommendation_Problem_ID",
                table: "Recommendations",
                newName: "IX_Recommendations_Problem_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recommendations",
                table: "Recommendations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendations_Problems_Problem_ID",
                table: "Recommendations",
                column: "Problem_ID",
                principalTable: "Problems",
                principalColumn: "Problem_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendations_Technicals_Technical_ID",
                table: "Recommendations",
                column: "Technical_ID",
                principalTable: "Technicals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recommendations_Problems_Problem_ID",
                table: "Recommendations");

            migrationBuilder.DropForeignKey(
                name: "FK_Recommendations_Technicals_Technical_ID",
                table: "Recommendations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recommendations",
                table: "Recommendations");

            migrationBuilder.RenameTable(
                name: "Recommendations",
                newName: "Recommendation");

            migrationBuilder.RenameIndex(
                name: "IX_Recommendations_Technical_ID",
                table: "Recommendation",
                newName: "IX_Recommendation_Technical_ID");

            migrationBuilder.RenameIndex(
                name: "IX_Recommendations_Problem_ID",
                table: "Recommendation",
                newName: "IX_Recommendation_Problem_ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recommendation",
                table: "Recommendation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendation_Problems_Problem_ID",
                table: "Recommendation",
                column: "Problem_ID",
                principalTable: "Problems",
                principalColumn: "Problem_ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendation_Technicals_Technical_ID",
                table: "Recommendation",
                column: "Technical_ID",
                principalTable: "Technicals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
