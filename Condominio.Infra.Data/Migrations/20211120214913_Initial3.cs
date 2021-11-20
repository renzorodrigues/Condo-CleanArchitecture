using Microsoft.EntityFrameworkCore.Migrations;

namespace Condominio.Infra.Data.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Credentials");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Credentials",
                type: "TEXT",
                nullable: true);
        }
    }
}
