using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class departamentoViewModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idDepartamento",
                table: "Tabla_Municipios",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "idMunicipio",
                table: "Tabla_Direcciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idDepartamento",
                table: "Tabla_Municipios");

            migrationBuilder.AlterColumn<int>(
                name: "idMunicipio",
                table: "Tabla_Direcciones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
