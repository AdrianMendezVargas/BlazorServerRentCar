using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorRentCar.Migrations
{
    public partial class Seeding20Clientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Apellidos", "Cedula", "Direccion", "Email", "FechaNacimiento", "FechaRegistro", "Nombres", "Telefono" },
                values: new object[,]
                {
                    { 14, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan14", "" },
                    { 15, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan15", "" },
                    { 16, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan16", "" },
                    { 17, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan17", "" },
                    { 18, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan18", "" },
                    { 19, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan19", "" },
                    { 20, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan20", "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
