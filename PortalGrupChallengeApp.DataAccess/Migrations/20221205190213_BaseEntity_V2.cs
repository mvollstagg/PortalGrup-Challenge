using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalGrupChallengeApp.DataAccess.Migrations
{
    public partial class BaseEntity_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuId",
                table: "SKUs");

            migrationBuilder.DropColumn(
                name: "GuId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "GuId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "GuId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "GuId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "GuId",
                table: "Addresses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GuId",
                table: "SKUs",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "GuId",
                table: "Orders",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "GuId",
                table: "OrderItems",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "GuId",
                table: "Customers",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "GuId",
                table: "Categories",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "GuId",
                table: "Addresses",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
