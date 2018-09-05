using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Algebra.Web.Data.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Spouse",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Referrer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Payment",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Mode",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Member",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Location",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Fee",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Dependent",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Cheque",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Category",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Spouse");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Referrer");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Mode");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Member");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Fee");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Dependent");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Cheque");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Category");
        }
    }
}
