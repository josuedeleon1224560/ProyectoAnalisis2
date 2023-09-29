using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class pruebaDirecciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdDepartamento",
                table: "AspNetUsers",
                column: "IdDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdDireccion",
                table: "AspNetUsers",
                column: "IdDireccion");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdMunicipio",
                table: "AspNetUsers",
                column: "IdMunicipio");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tabla_Departamentos_IdDepartamento",
                table: "AspNetUsers",
                column: "IdDepartamento",
                principalTable: "Tabla_Departamentos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tabla_Direcciones_IdDireccion",
                table: "AspNetUsers",
                column: "IdDireccion",
                principalTable: "Tabla_Direcciones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tabla_Municipios_IdMunicipio",
                table: "AspNetUsers",
                column: "IdMunicipio",
                principalTable: "Tabla_Municipios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tabla_Departamentos_IdDepartamento",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tabla_Direcciones_IdDireccion",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tabla_Municipios_IdMunicipio",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdDepartamento",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdDireccion",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdMunicipio",
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
        }
    }
}
