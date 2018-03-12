using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RealEstate.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Area = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AirConditioner = table.Column<bool>(nullable: true),
                    Animals = table.Column<bool>(nullable: true),
                    Apartment = table.Column<int>(nullable: false),
                    Balcony = table.Column<bool>(nullable: false),
                    CeilingHeight = table.Column<double>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ConstructionYear = table.Column<int>(nullable: true),
                    Cost = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Decoration = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    EditDate = table.Column<DateTime>(nullable: false),
                    Elevator = table.Column<bool>(nullable: false),
                    Floor = table.Column<int>(nullable: false),
                    Fridge = table.Column<bool>(nullable: true),
                    Furniture = table.Column<bool>(nullable: true),
                    House = table.Column<int>(nullable: false),
                    Housing = table.Column<string>(nullable: true),
                    Internet = table.Column<bool>(nullable: true),
                    KitchenArea = table.Column<double>(nullable: false),
                    KitchenFurniture = table.Column<bool>(nullable: true),
                    LivingArea = table.Column<double>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true),
                    RoomsNumber = table.Column<int>(nullable: false),
                    Stove = table.Column<bool>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Students = table.Column<bool>(nullable: true),
                    TV = table.Column<bool>(nullable: true),
                    TotalArea = table.Column<double>(nullable: false),
                    TotalFloors = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    WC = table.Column<int>(nullable: true),
                    WallMaterial = table.Column<int>(nullable: true),
                    WashingMachine = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Advertisements_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_UserID",
                table: "Advertisements",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
