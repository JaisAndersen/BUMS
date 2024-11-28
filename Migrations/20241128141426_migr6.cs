using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BUMS.Migrations
{
    /// <inheritdoc />
    public partial class migr6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_Accesss_AccessID",
                table: "UserGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_Groups_GroupID",
                table: "UserGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_Users_UserID",
                table: "UserGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroup",
                table: "UserGroup");

            migrationBuilder.RenameTable(
                name: "UserGroup",
                newName: "UserGroups");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroup_UserID",
                table: "UserGroups",
                newName: "IX_UserGroups_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroup_GroupID",
                table: "UserGroups",
                newName: "IX_UserGroups_GroupID");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroup_AccessID",
                table: "UserGroups",
                newName: "IX_UserGroups_AccessID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroups",
                table: "UserGroups",
                column: "UserGroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Accesss_AccessID",
                table: "UserGroups",
                column: "AccessID",
                principalTable: "Accesss",
                principalColumn: "AccessID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Groups_GroupID",
                table: "UserGroups",
                column: "GroupID",
                principalTable: "Groups",
                principalColumn: "GroupID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Users_UserID",
                table: "UserGroups",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Accesss_AccessID",
                table: "UserGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Groups_GroupID",
                table: "UserGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Users_UserID",
                table: "UserGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroups",
                table: "UserGroups");

            migrationBuilder.RenameTable(
                name: "UserGroups",
                newName: "UserGroup");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroups_UserID",
                table: "UserGroup",
                newName: "IX_UserGroup_UserID");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroups_GroupID",
                table: "UserGroup",
                newName: "IX_UserGroup_GroupID");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroups_AccessID",
                table: "UserGroup",
                newName: "IX_UserGroup_AccessID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroup",
                table: "UserGroup",
                column: "UserGroupID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_Accesss_AccessID",
                table: "UserGroup",
                column: "AccessID",
                principalTable: "Accesss",
                principalColumn: "AccessID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_Groups_GroupID",
                table: "UserGroup",
                column: "GroupID",
                principalTable: "Groups",
                principalColumn: "GroupID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_Users_UserID",
                table: "UserGroup",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
