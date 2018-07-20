using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcMovie.Migrations
{
    public partial class CampusDenovo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Campus",
                table: "Movie",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 5);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Campus",
                table: "Movie",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
