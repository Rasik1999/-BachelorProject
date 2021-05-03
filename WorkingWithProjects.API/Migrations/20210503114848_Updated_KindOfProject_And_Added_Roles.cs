using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkingWithProjects.API.Migrations
{
    public partial class Updated_KindOfProject_And_Added_Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "KindsOfProject",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.InsertData(
                table: "Hashtags",
                columns: new[] { "HashtagId", "Name" },
                values: new object[,]
                {
                    { 1, "HashtagName1" },
                    { 2, "HashtagName2" },
                    { 3, "HashtagName3" }
                });

            migrationBuilder.InsertData(
                table: "Progresses",
                columns: new[] { "ProgressId", "DesiredValue", "PercentageOfCompletion", "ProjectId", "Value" },
                values: new object[,]
                {
                    { 1, 5430m, 0m, 1, 4000m },
                    { 2, 6000m, 0m, 2, 2000m }
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "HashtagIds",
                value: "1,2");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2,
                column: "HashtagIds",
                value: "2,3");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Name" },
                values: new object[,]
                {
                    { 1, "Student" },
                    { 2, "Administrator" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KindsOfProject_Roles_RoleId",
                table: "KindsOfProject");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_KindsOfProject_RoleId",
                table: "KindsOfProject");

            migrationBuilder.DeleteData(
                table: "Hashtags",
                keyColumn: "HashtagId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hashtags",
                keyColumn: "HashtagId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hashtags",
                keyColumn: "HashtagId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Progresses",
                keyColumn: "ProgressId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Progresses",
                keyColumn: "ProgressId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "KindsOfProject");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "HashtagIds",
                value: null);

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2,
                column: "HashtagIds",
                value: null);
        }
    }
}
