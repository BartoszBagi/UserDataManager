using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserDataManager.Server.Migrations
{
    public partial class UserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAttribute_Users_UserId",
                schema: "UserDataManager",
                table: "UserAttribute");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "UserDataManager",
                table: "UserAttribute",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAttribute_Users_UserId",
                schema: "UserDataManager",
                table: "UserAttribute");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "UserDataManager",
                table: "UserAttribute",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAttribute_Users_UserId",
                schema: "UserDataManager",
                table: "UserAttribute",
                column: "UserId",
                principalSchema: "UserDataManager",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
