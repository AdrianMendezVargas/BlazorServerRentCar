using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorRentCar.Migrations
{
    public partial class RemoveTableVigenciaFromRentas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentas_Vigencia_VigenciaId",
                table: "Rentas");

            migrationBuilder.DropTable(
                name: "Vigencia");

            migrationBuilder.DropIndex(
                name: "IX_Rentas_VigenciaId",
                table: "Rentas");

            migrationBuilder.DropColumn(
                name: "VigenciaId",
                table: "Rentas");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFinal",
                table: "Rentas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaInicial",
                table: "Rentas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaFinal",
                table: "Rentas");

            migrationBuilder.DropColumn(
                name: "FechaInicial",
                table: "Rentas");

            migrationBuilder.AddColumn<int>(
                name: "VigenciaId",
                table: "Rentas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Vigencia",
                columns: table => new
                {
                    VigenciaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaInicial = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vigencia", x => x.VigenciaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rentas_VigenciaId",
                table: "Rentas",
                column: "VigenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rentas_Vigencia_VigenciaId",
                table: "Rentas",
                column: "VigenciaId",
                principalTable: "Vigencia",
                principalColumn: "VigenciaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
