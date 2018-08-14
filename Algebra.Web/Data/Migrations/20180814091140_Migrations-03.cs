using Microsoft.EntityFrameworkCore.Migrations;

namespace Algebra.Web.Data.Migrations
{
    public partial class Migrations03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "MembershipFeeId",
                table: "Payments",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MembershipFeeId",
                table: "Payments");
        }
    }
}
