using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorRentCar.Migrations
{
    public partial class SeedingVenta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "VentaId", "Balance", "ClienteId", "Comentarios", "Fecha", "Monto", "UserName", "VehiculoId" },
                values: new object[] { 1, 10000m, 1, "El comentario mas largo del mundoooooooooooooo", new DateTime(2020, 12, 27, 0, 0, 0, 0, DateTimeKind.Local), 10000m, "styles", 1 });

            migrationBuilder.InsertData(
                table: "Cuota",
                columns: new[] { "CuotaId", "Balance", "Monto", "VentaId" },
                values: new object[] { 1, 1000m, 1000m, 1 });

            migrationBuilder.InsertData(
                table: "Cuota",
                columns: new[] { "CuotaId", "Balance", "Monto", "VentaId" },
                values: new object[] { 2, 1000m, 1000m, 1 });

            migrationBuilder.InsertData(
                table: "Cuota",
                columns: new[] { "CuotaId", "Balance", "Monto", "VentaId" },
                values: new object[] { 3, 1000m, 1000m, 1 });

            migrationBuilder.InsertData(
                table: "Cuota",
                columns: new[] { "CuotaId", "Balance", "Monto", "VentaId" },
                values: new object[] { 4, 1000m, 1000m, 1 });

            migrationBuilder.InsertData(
                table: "Cuota",
                columns: new[] { "CuotaId", "Balance", "Monto", "VentaId" },
                values: new object[] { 5, 1000m, 1000m, 1 });

            migrationBuilder.InsertData(
                table: "Cuota",
                columns: new[] { "CuotaId", "Balance", "Monto", "VentaId" },
                values: new object[] { 6, 1000m, 1000m, 1 });

            migrationBuilder.InsertData(
                table: "Cuota",
                columns: new[] { "CuotaId", "Balance", "Monto", "VentaId" },
                values: new object[] { 7, 1000m, 1000m, 1 });

            migrationBuilder.InsertData(
                table: "Cuota",
                columns: new[] { "CuotaId", "Balance", "Monto", "VentaId" },
                values: new object[] { 8, 1000m, 1000m, 1 });

            migrationBuilder.InsertData(
                table: "Cuota",
                columns: new[] { "CuotaId", "Balance", "Monto", "VentaId" },
                values: new object[] { 9, 1000m, 1000m, 1 });

            migrationBuilder.InsertData(
                table: "Cuota",
                columns: new[] { "CuotaId", "Balance", "Monto", "VentaId" },
                values: new object[] { 10, 1000m, 1000m, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cuota",
                keyColumn: "CuotaId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cuota",
                keyColumn: "CuotaId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cuota",
                keyColumn: "CuotaId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cuota",
                keyColumn: "CuotaId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cuota",
                keyColumn: "CuotaId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cuota",
                keyColumn: "CuotaId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cuota",
                keyColumn: "CuotaId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cuota",
                keyColumn: "CuotaId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cuota",
                keyColumn: "CuotaId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cuota",
                keyColumn: "CuotaId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Ventas",
                keyColumn: "VentaId",
                keyValue: 1);
        }
    }
}
