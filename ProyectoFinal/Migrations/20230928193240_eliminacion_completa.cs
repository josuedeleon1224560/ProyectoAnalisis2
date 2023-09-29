using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class eliminacion_completa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DireccionesUsuario_DireccionesId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DireccionesId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DireccionesId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdDireccion",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DireccionesId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdDireccion",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DireccionesId",
                table: "AspNetUsers",
                column: "DireccionesId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DireccionesUsuario_DireccionesId",
                table: "AspNetUsers",
                column: "DireccionesId",
                principalTable: "DireccionesUsuario",
                principalColumn: "Id");
        }
    }
}
