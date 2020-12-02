using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorRentCar.Migrations
{
    public partial class SeedingDataIntoVentas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Vehiculos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Cobros",
                columns: table => new
                {
                    CobroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VentaId = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    Monto = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobros", x => x.CobroId);
                });

            migrationBuilder.CreateTable(
                name: "CobroCuota",
                columns: table => new
                {
                    CobroDetalleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CobroId = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobroCuota", x => x.CobroDetalleId);
                    table.ForeignKey(
                        name: "FK_CobroCuota_Cobros_CobroId",
                        column: x => x.CobroId,
                        principalTable: "Cobros",
                        principalColumn: "CobroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ventas",
                columns: new[] { "VentaId", "Balance", "ClienteId", "Comentarios", "Fecha", "Monto", "UserName", "VehiculoId" },
                values: new object[] { 1, 10000m, 1, "comment", new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Local), 10000m, "styles", 1 });

            migrationBuilder.InsertData(
                table: "Cuota",
                columns: new[] { "CuotaId", "Balance", "Monto", "VentaId" },
                values: new object[,]
                {
                    { 1, 1000m, 1000m, 1 },
                    { 2, 1000m, 1000m, 1 },
                    { 3, 1000m, 1000m, 1 },
                    { 4, 1000m, 1000m, 1 },
                    { 5, 1000m, 1000m, 1 },
                    { 6, 1000m, 1000m, 1 },
                    { 7, 1000m, 1000m, 1 },
                    { 8, 1000m, 1000m, 1 },
                    { 9, 1000m, 1000m, 1 },
                    { 10, 1000m, 1000m, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CobroCuota_CobroId",
                table: "CobroCuota",
                column: "CobroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CobroCuota");

            migrationBuilder.DropTable(
                name: "Cobros");

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

            migrationBuilder.AlterColumn<string>(
                name: "Placa",
                table: "Vehiculos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
