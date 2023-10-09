using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class te : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tabla_Direcciones_Tabla_Municipios_MunicipioGtId",
                table: "Tabla_Direcciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Tabla_Municipios_Tabla_Departamentos_DepartamentoGtId",
                table: "Tabla_Municipios");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoGtId",
                table: "Tabla_Municipios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MunicipioGtId",
                table: "Tabla_Direcciones",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "idMunicipio",
                table: "Tabla_Direcciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Tabla_Direcciones_Tabla_Municipios_MunicipioGtId",
                table: "Tabla_Direcciones",
                column: "MunicipioGtId",
                principalTable: "Tabla_Municipios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tabla_Municipios_Tabla_Departamentos_DepartamentoGtId",
                table: "Tabla_Municipios",
                column: "DepartamentoGtId",
                principalTable: "Tabla_Departamentos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tabla_Direcciones_Tabla_Municipios_MunicipioGtId",
                table: "Tabla_Direcciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Tabla_Municipios_Tabla_Departamentos_DepartamentoGtId",
                table: "Tabla_Municipios");

            migrationBuilder.DropColumn(
                name: "idMunicipio",
                table: "Tabla_Direcciones");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoGtId",
                table: "Tabla_Municipios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MunicipioGtId",
                table: "Tabla_Direcciones",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tabla_Direcciones_Tabla_Municipios_MunicipioGtId",
                table: "Tabla_Direcciones",
                column: "MunicipioGtId",
                principalTable: "Tabla_Municipios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tabla_Municipios_Tabla_Departamentos_DepartamentoGtId",
                table: "Tabla_Municipios",
                column: "DepartamentoGtId",
                principalTable: "Tabla_Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
