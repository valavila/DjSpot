using Microsoft.EntityFrameworkCore.Migrations;

namespace DjSpot.Data.Migrations
{
    public partial class addUserType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "userType",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "userType",
                table: "AspNetUsers");
        }
    }
}
