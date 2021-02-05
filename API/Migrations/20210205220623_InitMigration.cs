using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    AddressStreet = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    AddressCity = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    AddressState = table.Column<string>(type: "nvarchar(2)", nullable: false),
                    AddressZip = table.Column<string>(type: "nvarchar(5)", nullable: false),
                    AddressCountry = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BusinessId = table.Column<int>(type: "int", nullable: false),
                    DayOfTheWeek = table.Column<int>(type: "int", nullable: false),
                    OpeningTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    ClosingTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusinessHours_Businesses_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Businesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "Idx_Name",
                table: "Businesses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusinessHours_BusinessId",
                table: "BusinessHours",
                column: "BusinessId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessHours");

            migrationBuilder.DropTable(
                name: "Businesses");
        }
    }
}
