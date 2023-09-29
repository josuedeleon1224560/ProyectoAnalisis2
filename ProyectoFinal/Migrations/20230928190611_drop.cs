using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class drop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tabla_Departamentos_DepartamentoId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tabla_Direcciones_DireccionId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tabla_Municipios_MunicipioId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartamentoId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DireccionId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MunicipioId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DepartamentoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DireccionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdDepartamento",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdDireccion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdMunicipio",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MunicipioId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartamentoId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DireccionId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdDepartamento",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdDireccion",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdMunicipio",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MunicipioId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartamentoId",
                table: "AspNetUsers",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DireccionId",
                table: "AspNetUsers",
                column: "DireccionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MunicipioId",
                table: "AspNetUsers",
                column: "MunicipioId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tabla_Departamentos_DepartamentoId",
                table: "AspNetUsers",
                column: "DepartamentoId",
                principalTable: "Tabla_Departamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tabla_Direcciones_DireccionId",
                table: "AspNetUsers",
                column: "DireccionId",
                principalTable: "Tabla_Direcciones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tabla_Municipios_MunicipioId",
                table: "AspNetUsers",
                column: "MunicipioId",
                principalTable: "Tabla_Municipios",
                principalColumn: "Id");
        }
    }
}
