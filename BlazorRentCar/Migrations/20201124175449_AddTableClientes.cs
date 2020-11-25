using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorRentCar.Migrations
{
    public partial class AddTableClientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Cedula = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Apellidos", "Cedula", "Direccion", "Email", "FechaNacimiento", "FechaRegistro", "Nombres", "Telefono" },
                values: new object[,]
                {
                    { 1, "Mendez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Adrian1", "" },
                    { 2, "Mendez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Adrian2", "" },
                    { 3, "Mendez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Adrian3", "" },
                    { 4, "Mendez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Adrian4", "" },
                    { 5, "Mendez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Adrian5", "" },
                    { 6, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan6", "" },
                    { 7, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan7", "" },
                    { 8, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan8", "" },
                    { 9, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan9", "" },
                    { 10, "Perez", "", "", "", new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2020, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), "Juan10", "" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
