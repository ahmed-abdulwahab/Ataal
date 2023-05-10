using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ataal.DAL.Migrations
{
    /// <inheritdoc />
    public partial class adddingDateofAcceptInOffer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptedDate",
                table: "Problems");

            migrationBuilder.AddColumn<DateTime>(
                name: "AcceptedDate",
                table: "Offers",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcceptedDate",
                table: "Offers");

            migrationBuilder.AddColumn<DateTime>(
                name: "AcceptedDate",
                table: "Problems",
                type: "datetime2",
                nullable: true);
        }
    }
}
