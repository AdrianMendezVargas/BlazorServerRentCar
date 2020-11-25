using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorRentCar.Migrations
{
    public partial class Seeding30Clientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Apellidos", "Cedula", "Direccion", "Email", "FechaNacimiento", "FechaRegistro", "Nombres", "Telefono" },
                values: new object[,]
                {
                    { 21, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan20", "" },
                    { 22, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan20", "" },
                    { 23, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan20", "" },
                    { 24, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan20", "" },
                    { 25, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan20", "" },
                    { 26, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan20", "" },
                    { 27, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan20", "" },
                    { 28, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan20", "" },
                    { 29, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan20", "" },
                    { 30, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan20", "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
