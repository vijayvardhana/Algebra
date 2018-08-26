using Microsoft.EntityFrameworkCore.Migrations;

namespace Algebra.Web.Data.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrespondenceAddress",
                table: "Spouse");

            migrationBuilder.RenameColumn(
                name: "CorrespondenceAddress",
                table: "Member",
                newName: "PermanentAddress");

            migrationBuilder.AddColumn<string>(
                name: "Addressed",
                table: "Spouse",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermanentAddress",
                table: "Spouse",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermanentCity",
                table: "Spouse",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermanentPin",
                table: "Spouse",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermanentState",
                table: "Spouse",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PresentCity",
                table: "Spouse",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PresentPin",
                table: "Spouse",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PresentState",
                table: "Spouse",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SponcerId",
                table: "Spouse",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Addressed",
                table: "Member",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermanentCity",
                table: "Member",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermanentPin",
                table: "Member",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermanentState",
                table: "Member",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PresentCity",
                table: "Member",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PresentPin",
                table: "Member",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PresentState",
                table: "Member",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SponcerId",
                table: "Member",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Addressed",
                table: "Spouse");

            migrationBuilder.DropColumn(
                name: "PermanentAddress",
                table: "Spouse");

            migrationBuilder.DropColumn(
                name: "PermanentCity",
                table: "Spouse");

            migrationBuilder.DropColumn(
                name: "PermanentPin",
                table: "Spouse");

            migrationBuilder.DropColumn(
                name: "PermanentState",
                table: "Spouse");

            migrationBuilder.DropColumn(
                name: "PresentCity",
                table: "Spouse");

            migrationBuilder.DropColumn(
                name: "PresentPin",
                table: "Spouse");

            migrationBuilder.DropColumn(
                name: "PresentState",
                table: "Spouse");

            migrationBuilder.DropColumn(
                name: "SponcerId",
                table: "Spouse");

            migrationBuilder.DropColumn(
                name: "Addressed",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "PermanentCity",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "PermanentPin",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "PermanentState",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "PresentCity",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "PresentPin",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "PresentState",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "SponcerId",
                table: "Member");

            migrationBuilder.RenameColumn(
                name: "PermanentAddress",
                table: "Member",
                newName: "CorrespondenceAddress");

            migrationBuilder.AddColumn<string>(
                name: "CorrespondenceAddress",
                table: "Spouse",
                maxLength: 200,
                nullable: true);
        }
    }
}
