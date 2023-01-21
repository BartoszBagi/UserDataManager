using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserDataManager.Server.Migrations
{
    public partial class Attributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAttribute_Users_UserId",
                schema: "UserDataManager",
                table: "UserAttribute");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAttribute",
                schema: "UserDataManager",
                table: "UserAttribute");

            migrationBuilder.RenameTable(
                name: "UserAttribute",
                schema: "UserDataManager",
                newName: "Attributes",
                newSchema: "UserDataManager");

            migrationBuilder.RenameIndex(
                name: "IX_UserAttribute_UserId",
                schema: "UserDataManager",
                table: "Attributes",
                newName: "IX_Attributes_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attributes",
                schema: "UserDataManager",
                table: "Attributes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attributes_Users_UserId",
                schema: "UserDataManager",
                table: "Attributes",
                column: "UserId",
                principalSchema: "UserDataManager",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attributes_Users_UserId",
                schema: "UserDataManager",
                table: "Attributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attributes",
                schema: "UserDataManager",
                table: "Attributes");

            migrationBuilder.RenameTable(
                name: "Attributes",
                schema: "UserDataManager",
                newName: "UserAttribute",
                newSchema: "UserDataManager");

            migrationBuilder.RenameIndex(
                name: "IX_Attributes_UserId",
                schema: "UserDataManager",
                table: "UserAttribute",
                newName: "IX_UserAttribute_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAttribute",
                schema: "UserDataManager",
                table: "UserAttribute",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAttribute_Users_UserId",
                schema: "UserDataManager",
                table: "UserAttribute",
                column: "UserId",
                principalSchema: "UserDataManager",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
