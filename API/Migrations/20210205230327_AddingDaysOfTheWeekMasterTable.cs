using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddingDaysOfTheWeekMasterTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DaysOfTheWeek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Weekday = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysOfTheWeek", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "DaysOfTheWeek",
                columns: new[] { "Id", "Weekday" },
                values: new object[,]
                {
                    { 1, "Sunday" },
                    { 2, "Monday" },
                    { 3, "Tuesday" },
                    { 4, "Wednesday" },
                    { 5, "Thursday" },
                    { 6, "Friday" },
                    { 7, "Saturday" }
                });

            migrationBuilder.CreateIndex(
                name: "Idx_Weekday",
                table: "DaysOfTheWeek",
                column: "Weekday",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DaysOfTheWeek");
        }
    }
}
