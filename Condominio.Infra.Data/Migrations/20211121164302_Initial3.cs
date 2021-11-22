using Microsoft.EntityFrameworkCore.Migrations;

namespace Condominio.Infra.Data.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ApplicationUsers_CredentialId",
                table: "ApplicationUsers");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_CredentialId",
                table: "ApplicationUsers",
                column: "CredentialId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ApplicationUsers_CredentialId",
                table: "ApplicationUsers");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_CredentialId",
                table: "ApplicationUsers",
                column: "CredentialId");
        }
    }
}
