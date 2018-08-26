using Microsoft.EntityFrameworkCore.Migrations;

namespace Algebra.Web.Data.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Spouse",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatus",
                table: "Spouse",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "Spouse",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<short>(
                name: "ReferredBy",
                table: "Member",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Member",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatus",
                table: "Member",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "Member",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Spouse");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "Spouse");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "Spouse");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "Member");

            migrationBuilder.AlterColumn<string>(
                name: "ReferredBy",
                table: "Member",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(short));
        }
    }
}
