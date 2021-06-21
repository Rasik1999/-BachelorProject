using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkingWithProjects.API.Migrations
{
    public partial class Added_AuthorName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AuthorName",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorName",
                table: "Projects");
        }
    }
}
