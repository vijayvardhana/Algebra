using Microsoft.EntityFrameworkCore.Migrations;

namespace Algebra.Web.Data.Migrations
{
    public partial class Migrations02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "LocationId",
                table: "Members",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Members");
        }
    }
}
