using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Condominio.Infra.Data.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Credentials_ApplicationUsers_Id",
                table: "Credentials");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Credentials");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_CredentialId",
                table: "ApplicationUsers",
                column: "CredentialId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsers_Credentials_CredentialId",
                table: "ApplicationUsers",
                column: "CredentialId",
                principalTable: "Credentials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_Credentials_CredentialId",
                table: "ApplicationUsers");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUsers_CredentialId",
                table: "ApplicationUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Credentials",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Credentials_ApplicationUsers_Id",
                table: "Credentials",
                column: "Id",
                principalTable: "ApplicationUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
