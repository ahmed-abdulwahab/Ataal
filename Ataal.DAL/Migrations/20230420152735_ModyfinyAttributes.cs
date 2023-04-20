using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ataal.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ModyfinyAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problems_KeyWords_KeyWord_ID",
                table: "Problems");

            migrationBuilder.AlterColumn<int>(
                name: "KeyWord_ID",
                table: "Problems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_KeyWords_KeyWord_ID",
                table: "Problems",
                column: "KeyWord_ID",
                principalTable: "KeyWords",
                principalColumn: "KeyWord_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Problems_KeyWords_KeyWord_ID",
                table: "Problems");

            migrationBuilder.AlterColumn<int>(
                name: "KeyWord_ID",
                table: "Problems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_KeyWords_KeyWord_ID",
                table: "Problems",
                column: "KeyWord_ID",
                principalTable: "KeyWords",
                principalColumn: "KeyWord_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
