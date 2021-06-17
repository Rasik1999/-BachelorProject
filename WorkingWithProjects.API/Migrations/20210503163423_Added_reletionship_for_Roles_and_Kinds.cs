using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkingWithProjects.API.Migrations
{
    public partial class Added_reletionship_for_Roles_and_Kinds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Roles",
                newName: "RoleId");

            migrationBuilder.CreateTable(
                name: "KindOfProjectRole",
                columns: table => new
                {
                    KindOfProjectId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KindOfProjectRole", x => new { x.KindOfProjectId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_KindOfProjectRole_KindsOfProject_KindOfProjectsKindOfProjectId",
                        column: x => x.KindOfProjectId,
                        principalTable: "KindsOfProject",
                        principalColumn: "KindOfProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KindOfProjectRole_Roles_RolesRoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KindOfProjectRole_RolesRoleId",
                table: "KindOfProjectRole",
                column: "RolesRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KindOfProjectRole");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Roles",
                newName: "Id");
        }
    }
}
