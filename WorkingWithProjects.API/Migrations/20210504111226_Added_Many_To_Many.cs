using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkingWithProjects.API.Migrations
{
    public partial class Added_Many_To_Many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KindOfProjectRole_KindsOfProject_KindOfProjectsKindOfProjectId",
                table: "KindOfProjectRole");

            migrationBuilder.DropForeignKey(
                name: "FK_KindOfProjectRole_Roles_RolesRoleId",
                table: "KindOfProjectRole");

            migrationBuilder.RenameColumn(
                name: "RolesRoleId",
                table: "KindOfProjectRole",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "KindOfProjectsKindOfProjectId",
                table: "KindOfProjectRole",
                newName: "KindId");

            migrationBuilder.RenameIndex(
                name: "IX_KindOfProjectRole_RolesRoleId",
                table: "KindOfProjectRole",
                newName: "IX_KindOfProjectRole_RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_KindOfProjectRole_KindsOfProject_KindId",
                table: "KindOfProjectRole",
                column: "KindId",
                principalTable: "KindsOfProject",
                principalColumn: "KindOfProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KindOfProjectRole_Roles_RoleId",
                table: "KindOfProjectRole",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KindOfProjectRole_KindsOfProject_KindId",
                table: "KindOfProjectRole");

            migrationBuilder.DropForeignKey(
                name: "FK_KindOfProjectRole_Roles_RoleId",
                table: "KindOfProjectRole");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "KindOfProjectRole",
                newName: "RolesRoleId");

            migrationBuilder.RenameColumn(
                name: "KindId",
                table: "KindOfProjectRole",
                newName: "KindOfProjectsKindOfProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_KindOfProjectRole_RoleId",
                table: "KindOfProjectRole",
                newName: "IX_KindOfProjectRole_RolesRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_KindOfProjectRole_KindsOfProject_KindOfProjectsKindOfProjectId",
                table: "KindOfProjectRole",
                column: "KindOfProjectsKindOfProjectId",
                principalTable: "KindsOfProject",
                principalColumn: "KindOfProjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KindOfProjectRole_Roles_RolesRoleId",
                table: "KindOfProjectRole",
                column: "RolesRoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
