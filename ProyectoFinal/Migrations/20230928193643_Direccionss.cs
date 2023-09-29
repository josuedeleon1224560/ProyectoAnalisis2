using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class Direccionss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DireccionId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DireccionId",
                table: "AspNetUsers",
                column: "DireccionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DireccionesUsuario_DireccionId",
                table: "AspNetUsers",
                column: "DireccionId",
                principalTable: "DireccionesUsuario",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DireccionesUsuario_DireccionId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DireccionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DireccionId",
                table: "AspNetUsers");
        }
    }
}
