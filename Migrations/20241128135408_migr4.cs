using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BUMS.Migrations
{
    /// <inheritdoc />
    public partial class migr4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_Users_CreatedByUserID",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_CreatedByUserID",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserID",
                table: "Groups",
                newName: "CreatedBy");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Groups",
                newName: "CreatedByUserID");

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
    }
}
