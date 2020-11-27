using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorRentCar.Migrations
{
    public partial class AddColumnUserNameToClientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 30);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Clientes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "cuotas",
                columns: table => new
                {
                    CuotaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    Concepto = table.Column<string>(nullable: false),
                    Monto = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cuotas", x => x.CuotaId);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    VentaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    TipoFactura = table.Column<int>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    ITBIS = table.Column<double>(nullable: false),
                    Descuentos = table.Column<double>(nullable: false),
                    TotalGeneral = table.Column<double>(nullable: false),
                    Comentarios = table.Column<string>(nullable: true),
                    CantidadVehiculos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.VentaId);
                });

            migrationBuilder.CreateTable(
                name: "VentasVehiculoDetalle",
                columns: table => new
                {
                    VentasDetalleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VentaId = table.Column<int>(nullable: false),
                    VehiculoId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Precio = table.Column<double>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cuotas");

            migrationBuilder.DropTable(
                name: "VentasVehiculoDetalle");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Clientes");

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Apellidos", "Direccion", "Email", "FechaRegistro", "Nombres", "Telefono" },
                values: new object[,]
                {
                    { 1, "Mendez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Adrian1", "" },
                    { 28, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan20", "" },
                    { 27, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan20", "" },
                    { 26, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan20", "" },
                    { 25, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan20", "" },
                    { 24, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan20", "" },
                    { 23, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan20", "" },
                    { 22, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan20", "" },
                    { 21, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan20", "" },
                    { 20, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan20", "" },
                    { 19, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan19", "" },
                    { 18, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan18", "" },
                    { 17, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan17", "" },
                    { 16, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan16", "" },
                    { 15, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan15", "" },
                    { 14, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan14", "" },
                    { 13, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan13", "" },
                    { 12, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan12", "" },
                    { 11, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan11", "" },
                    { 10, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan10", "" },
                    { 9, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan9", "" },
                    { 8, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan8", "" },
                    { 7, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan7", "" },
                    { 6, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan6", "" },
                    { 5, "Mendez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Adrian5", "" },
                    { 4, "Mendez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Adrian4", "" },
                    { 3, "Mendez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Adrian3", "" },
                    { 2, "Mendez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Adrian2", "" },
                    { 29, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan20", "" },
                    { 30, "Perez", "", "", new DateTime(2020, 11, 25, 0, 0, 0, 0, DateTimeKind.Local), "Juan20", "" }
                });
        }
    }
}
