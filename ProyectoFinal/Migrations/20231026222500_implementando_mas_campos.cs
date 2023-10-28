using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class implementando_mas_campos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Nomina",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "Bonificaciones",
                table: "Nomina",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Comisiones",
                table: "Nomina",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Departamento",
                table: "Nomina",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "PrecioHoraExtra",
                table: "Nomina",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Produccion",
                table: "Nomina",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PuestoS",
                table: "Nomina",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "TotalDevengado",
                table: "Nomina",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Ventas",
                table: "Nomina",
                type: "real",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Nomina");

            migrationBuilder.DropColumn(
                name: "Bonificaciones",
                table: "Nomina");

            migrationBuilder.DropColumn(
                name: "Comisiones",
                table: "Nomina");

            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "Nomina");

            migrationBuilder.DropColumn(
                name: "PrecioHoraExtra",
                table: "Nomina");

            migrationBuilder.DropColumn(
                name: "Produccion",
                table: "Nomina");

            migrationBuilder.DropColumn(
                name: "PuestoS",
                table: "Nomina");

            migrationBuilder.DropColumn(
                name: "TotalDevengado",
                table: "Nomina");

            migrationBuilder.DropColumn(
                name: "Ventas",
                table: "Nomina");
        }
    }
}
