using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkingWithProjects.API.Migrations
{
    public partial class AddedHashtags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HashtagIds",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Hashtags",
                columns: table => new
                {
                    HashtagId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hashtags", x => x.HashtagId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hashtags");

            migrationBuilder.DropColumn(
                name: "HashtagIds",
                table: "Projects");
        }
    }
}
