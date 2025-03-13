using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    public partial class NinthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2,
                column: "TruckerId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Truckers",
                keyColumn: "Id",
                keyValue: 2,
                column: "TruckerType",
                value: "Automoviles");

            migrationBuilder.InsertData(
                table: "Truckers",
                columns: new[] { "Id", "CompleteName", "Roles", "TruckerType" },
                values: new object[] { 4, "Benjamin Perez", 3, "Combustibles" });

            migrationBuilder.InsertData(
                table: "Truckers",
                columns: new[] { "Id", "CompleteName", "Roles", "TruckerType" },
                values: new object[] { 5, "Thiago Mendez", 3, "Explosivos" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Truckers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Truckers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2,
                column: "TruckerId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Truckers",
                keyColumn: "Id",
                keyValue: 2,
                column: "TruckerType",
                value: "Autos");
        }
    }
}
