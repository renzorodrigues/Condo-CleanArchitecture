using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Condominio.API.Migrations
{
    public partial class MySecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "Condominiums");

            migrationBuilder.DropColumn(
                name: "Address_Complement",
                table: "Condominiums");

            migrationBuilder.DropColumn(
                name: "Address_District",
                table: "Condominiums");

            migrationBuilder.DropColumn(
                name: "Address_Number",
                table: "Condominiums");

            migrationBuilder.DropColumn(
                name: "Address_PublicPlace",
                table: "Condominiums");

            migrationBuilder.DropColumn(
                name: "Address_State",
                table: "Condominiums");

            migrationBuilder.DropColumn(
                name: "Address_ZipCode",
                table: "Condominiums");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    CondominiumId = table.Column<Guid>(type: "TEXT", nullable: false),
                    PublicPlace = table.Column<string>(type: "TEXT", nullable: true),
                    Number = table.Column<string>(type: "TEXT", nullable: true),
                    Complement = table.Column<string>(type: "TEXT", nullable: true),
                    ZipCode = table.Column<string>(type: "TEXT", nullable: true),
                    District = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.CondominiumId);
                    table.ForeignKey(
                        name: "FK_Addresses_Condominiums_CondominiumId",
                        column: x => x.CondominiumId,
                        principalTable: "Condominiums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "Condominiums",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Complement",
                table: "Condominiums",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_District",
                table: "Condominiums",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Number",
                table: "Condominiums",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_PublicPlace",
                table: "Condominiums",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                table: "Condominiums",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_ZipCode",
                table: "Condominiums",
                type: "TEXT",
                nullable: true);
        }
    }
}
