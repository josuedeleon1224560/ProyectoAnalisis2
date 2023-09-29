using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class delete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tabla_Direcciones_IdDireccion",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdDireccion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdDireccion",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
