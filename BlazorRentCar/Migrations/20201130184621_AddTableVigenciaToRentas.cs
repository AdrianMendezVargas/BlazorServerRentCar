using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorRentCar.Migrations
{
    public partial class AddTableVigenciaToRentas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cuotas");

            migrationBuilder.DropTable(
                name: "VentasVehiculoDetalle");

            migrationBuilder.CreateTable(
                name: "Vehiculos",
                columns: table => new
                {
                    VehiculoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImportadorId = table.Column<int>(nullable: false),
                    Matricula = table.Column<string>(nullable: false),
                    Placa = table.Column<string>(nullable: false),
                    Marca = table.Column<string>(nullable: false),
                    Modelo = table.Column<string>(nullable: false),
                    AñoFabricacion = table.Column<DateTime>(nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    PrecioDia = table.Column<decimal>(nullable: false),
                    Kilometraje = table.Column<int>(nullable: false),
                    Ano = table.Column<int>(nullable: false),
                    Chassis = table.Column<string>(nullable: false),
                    Pasajeros = table.Column<string>(nullable: false),
                    Puertas = table.Column<string>(nullable: false),
                    Traccion = table.Column<string>(nullable: false),
                    Comentario = table.Column<string>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false),
                    Tipo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculos", x => x.VehiculoId);
                });

            migrationBuilder.CreateTable(
                name: "VentasCuotaDetalle",
                columns: table => new
                {
                    VentasDetalleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VentaId = table.Column<int>(nullable: false),
                    CuotaId = table.Column<int>(nullable: false),
                    VehiculoId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Precio = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentasCuotaDetalle", x => x.VentasDetalleId);
                    table.ForeignKey(
                        name: "FK_VentasCuotaDetalle_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vigencia",
                columns: table => new
                {
                    VigenciaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicial = table.Column<DateTime>(nullable: false),
                    FechaFinal = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vigencia", x => x.VigenciaId);
                });

            migrationBuilder.CreateTable(
                name: "Rentas",
                columns: table => new
                {
                    RentaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    VehiculoId = table.Column<int>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    VigenciaId = table.Column<int>(nullable: false),
                    MontoTotal = table.Column<decimal>(nullable: false),
                    Eliminada = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentas", x => x.RentaId);
                    table.ForeignKey(
                        name: "FK_Rentas_Vigencia_VigenciaId",
                        column: x => x.VigenciaId,
                        principalTable: "Vigencia",
                        principalColumn: "VigenciaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentas_VigenciaId",
                table: "Rentas",
                column: "VigenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_VentasCuotaDetalle_VentaId",
                table: "VentasCuotaDetalle",
                column: "VentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentas");

            migrationBuilder.DropTable(
                name: "Vehiculos");

            migrationBuilder.DropTable(
                name: "VentasCuotaDetalle");

            migrationBuilder.DropTable(
                name: "Vigencia");

            migrationBuilder.CreateTable(
                name: "cuotas",
                columns: table => new
                {
                    CuotaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    Concepto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuotas", x => x.CuotaId);
                });

            migrationBuilder.CreateTable(
                name: "VentasVehiculoDetalle",
                columns: table => new
                {
                    VentasDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    VehiculoId = table.Column<int>(type: "int", nullable: false),
                    VentaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentasVehiculoDetalle", x => x.VentasDetalleId);
                    table.ForeignKey(
                        name: "FK_VentasVehiculoDetalle_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VentasVehiculoDetalle_VentaId",
                table: "VentasVehiculoDetalle",
                column: "VentaId");
        }
    }
}
