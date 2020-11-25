using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorRentCar.Migrations
{
    public partial class MoreSeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Apellidos", "Cedula", "Direccion", "Email", "FechaNacimiento", "FechaRegistro", "Nombres", "Telefono" },
                values: new object[] { 11, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan11", "" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Apellidos", "Cedula", "Direccion", "Email", "FechaNacimiento", "FechaRegistro", "Nombres", "Telefono" },
                values: new object[] { 12, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan12", "" });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Apellidos", "Cedula", "Direccion", "Email", "FechaNacimiento", "FechaRegistro", "Nombres", "Telefono" },
                values: new object[] { 13, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan13", "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
