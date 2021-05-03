using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkingWithProjects.API.Migrations
{
    public partial class Added_PercentageOfCompletion_for_Progress_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PercentageOfCompletion",
                table: "Progresses",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PercentageOfCompletion",
                table: "Progresses");
        }
    }
}
