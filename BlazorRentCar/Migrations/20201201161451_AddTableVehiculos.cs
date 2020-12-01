using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorRentCar.Migrations
{
    public partial class AddTableVehiculos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Vehiculos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Vehiculos");
        }
    }
}
