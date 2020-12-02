using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorRentCar.Migrations
{
    public partial class AddColumnBalanceToClientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Rentas",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "Clientes",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentaId",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2020, 12, 2, 0, 0, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Balance",
                table: "Clientes");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Rentas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Ventas",
                keyColumn: "VentaId",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
