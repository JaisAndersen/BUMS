using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BUMS.Migrations
{
    /// <inheritdoc />
    public partial class Migr2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Groups",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserID",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_CreatedByUserID",
                table: "Groups",
                column: "CreatedByUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_Users_CreatedByUserID",
                table: "Groups",
                column: "CreatedByUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_CreatedByUserID",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_CreatedByUserID",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "CreatedByUserID",
                table: "Groups");
        }
    }
}
