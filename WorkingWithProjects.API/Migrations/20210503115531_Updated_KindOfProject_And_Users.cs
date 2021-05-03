using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkingWithProjects.API.Migrations
{
    public partial class Updated_KindOfProject_And_Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KindsOfProject_Roles_RoleId",
                table: "KindsOfProject");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_KindsOfProject_RoleId",
                table: "KindsOfProject");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "KindsOfProject");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "RoleId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "RoleId",
                value: 2);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "KindsOfProject",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "KindsOfProject",
                keyColumn: "KindOfProjectId",
                keyValue: 1,
                column: "RoleId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "KindsOfProject",
                keyColumn: "KindOfProjectId",
                keyValue: 2,
                column: "RoleId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "RoleId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "RoleId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_KindsOfProject_RoleId",
                table: "KindsOfProject",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_KindsOfProject_Roles_RoleId",
                table: "KindsOfProject",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
