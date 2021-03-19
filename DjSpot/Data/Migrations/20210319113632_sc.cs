using Microsoft.EntityFrameworkCore.Migrations;

namespace DjSpot.Data.Migrations
{
    public partial class sc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SCUrl",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SCUrl",
                table: "AspNetUsers");
        }
    }
}
