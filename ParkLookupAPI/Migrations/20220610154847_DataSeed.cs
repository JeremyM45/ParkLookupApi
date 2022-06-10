using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkLookupAPI.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Jurisdiction", "Location", "Name" },
                values: new object[] { 1, "National", "Califonria", "Yosemite" });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Jurisdiction", "Location", "Name" },
                values: new object[] { 2, "State", "Califonria", "Bidwell" });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Jurisdiction", "Location", "Name" },
                values: new object[] { 3, "National", "Idaho & Wyoming", "YellowStone" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 3);
        }
    }
}
