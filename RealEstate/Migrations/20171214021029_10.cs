using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RealEstate.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Advertisements",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Advertisements",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Advertisements");
        }
    }
}
