using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class nueva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tabla_Municipios_DepartamentoGtId",
                table: "Tabla_Municipios");

            migrationBuilder.DropIndex(
                name: "IX_Tabla_Direcciones_MunicipioGtId",
                table: "Tabla_Direcciones");

            migrationBuilder.DropColumn(
                name: "DepartamentoGtId",
                table: "Tabla_Municipios");

            migrationBuilder.DropColumn(
                name: "MunicipioGtId",
                table: "Tabla_Direcciones");

            migrationBuilder.RenameColumn(
                name: "idDepartamento",
                table: "Tabla_Municipios",
                newName: "idDepartamentos");

            migrationBuilder.RenameColumn(
                name: "idMunicipio",
                table: "Tabla_Direcciones",
                newName: "idMunicipios");

            migrationBuilder.CreateIndex(
                name: "IX_Tabla_Municipios_idDepartamentos",
                table: "Tabla_Municipios",
                column: "idDepartamentos");

            migrationBuilder.CreateIndex(
                name: "IX_Tabla_Direcciones_idMunicipios",
                table: "Tabla_Direcciones",
                column: "idMunicipios");

            migrationBuilder.AddForeignKey(
                name: "FK_Tabla_Direcciones_Tabla_Municipios_idMunicipios",
                table: "Tabla_Direcciones",
                column: "idMunicipios",
                principalTable: "Tabla_Municipios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tabla_Municipios_Tabla_Departamentos_idDepartamentos",
                table: "Tabla_Municipios",
                column: "idDepartamentos",
                principalTable: "Tabla_Departamentos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tabla_Direcciones_Tabla_Municipios_idMunicipios",
                table: "Tabla_Direcciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Tabla_Municipios_Tabla_Departamentos_idDepartamentos",
                table: "Tabla_Municipios");

            migrationBuilder.DropIndex(
                name: "IX_Tabla_Municipios_idDepartamentos",
                table: "Tabla_Municipios");

            migrationBuilder.DropIndex(
                name: "IX_Tabla_Direcciones_idMunicipios",
                table: "Tabla_Direcciones");

            migrationBuilder.RenameColumn(
                name: "idDepartamentos",
                table: "Tabla_Municipios",
                newName: "idDepartamento");

            migrationBuilder.RenameColumn(
                name: "idMunicipios",
                table: "Tabla_Direcciones",
                newName: "idMunicipio");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentoGtId",
                table: "Tabla_Municipios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MunicipioGtId",
                table: "Tabla_Direcciones",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tabla_Municipios_DepartamentoGtId",
                table: "Tabla_Municipios",
                column: "DepartamentoGtId");

            migrationBuilder.CreateIndex(
                name: "IX_Tabla_Direcciones_MunicipioGtId",
                table: "Tabla_Direcciones",
                column: "MunicipioGtId");

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
    }
}
