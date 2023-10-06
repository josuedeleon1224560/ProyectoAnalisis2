using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class direccionesPrueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tabla_Direcciones_Tabla_Municipios_IdMunicipio",
                table: "Tabla_Direcciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Tabla_Municipios_Tabla_Departamentos_DepartamentoId",
                table: "Tabla_Municipios");

            migrationBuilder.RenameColumn(
                name: "DepartamentoId",
                table: "Tabla_Municipios",
                newName: "DepartamentoGtId");

            migrationBuilder.RenameIndex(
                name: "IX_Tabla_Municipios_DepartamentoId",
                table: "Tabla_Municipios",
                newName: "IX_Tabla_Municipios_DepartamentoGtId");

            migrationBuilder.RenameColumn(
                name: "IdMunicipio",
                table: "Tabla_Direcciones",
                newName: "MunicipioGtId");

            migrationBuilder.RenameIndex(
                name: "IX_Tabla_Direcciones_IdMunicipio",
                table: "Tabla_Direcciones",
                newName: "IX_Tabla_Direcciones_MunicipioGtId");

            migrationBuilder.AddColumn<int>(
                name: "IdDireccion",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdDireccion",
                table: "AspNetUsers",
                column: "IdDireccion");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tabla_Direcciones_IdDireccion",
                table: "AspNetUsers",
                column: "IdDireccion",
                principalTable: "Tabla_Direcciones",
                principalColumn: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tabla_Direcciones_IdDireccion",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tabla_Direcciones_Tabla_Municipios_MunicipioGtId",
                table: "Tabla_Direcciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Tabla_Municipios_Tabla_Departamentos_DepartamentoGtId",
                table: "Tabla_Municipios");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdDireccion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdDireccion",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "DepartamentoGtId",
                table: "Tabla_Municipios",
                newName: "DepartamentoId");

            migrationBuilder.RenameIndex(
                name: "IX_Tabla_Municipios_DepartamentoGtId",
                table: "Tabla_Municipios",
                newName: "IX_Tabla_Municipios_DepartamentoId");

            migrationBuilder.RenameColumn(
                name: "MunicipioGtId",
                table: "Tabla_Direcciones",
                newName: "IdMunicipio");

            migrationBuilder.RenameIndex(
                name: "IX_Tabla_Direcciones_MunicipioGtId",
                table: "Tabla_Direcciones",
                newName: "IX_Tabla_Direcciones_IdMunicipio");

            migrationBuilder.AddForeignKey(
                name: "FK_Tabla_Direcciones_Tabla_Municipios_IdMunicipio",
                table: "Tabla_Direcciones",
                column: "IdMunicipio",
                principalTable: "Tabla_Municipios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tabla_Municipios_Tabla_Departamentos_DepartamentoId",
                table: "Tabla_Municipios",
                column: "DepartamentoId",
                principalTable: "Tabla_Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
