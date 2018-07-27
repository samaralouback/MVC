using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcProjetor.Migrations
{
    public partial class incluiCampuseBloco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bloco",
                table: "Auditorio",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Campus",
                table: "Auditorio",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bloco",
                table: "Auditorio");

            migrationBuilder.DropColumn(
                name: "Campus",
                table: "Auditorio");
        }
    }
}
