using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RealEstate.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_Users_UserID",
                table: "Advertisements");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_UserID",
                table: "Advertisements");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_UserID",
                table: "Advertisements",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_Users_UserID",
                table: "Advertisements",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
