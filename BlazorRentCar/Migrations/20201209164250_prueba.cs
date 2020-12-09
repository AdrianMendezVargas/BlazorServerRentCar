using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorRentCar.Migrations
{
    public partial class prueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentaId",
                keyValue: 1,
                columns: new[] { "ClienteId", "Comentarios", "Fecha", "UserName" },
                values: new object[] { 41, "El comentario mas largo del mundoooooooooooooo", new DateTime(2020, 12, 9, 0, 0, 0, 0, DateTimeKind.Local), "niurbis" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentaId",
                keyValue: 1,
                columns: new[] { "ClienteId", "Comentarios", "Fecha", "UserName" },
                values: new object[] { 1, "comment", new DateTime(2020, 12, 2, 0, 0, 0, 0, DateTimeKind.Local), "styles" });
        }
    }
}
