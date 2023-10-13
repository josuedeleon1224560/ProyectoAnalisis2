using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class mensajeDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensaje_AspNetUsers_AppUserId",
                table: "Mensaje");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mensaje",
                table: "Mensaje");

            migrationBuilder.RenameTable(
                name: "Mensaje",
                newName: "Mensajes");

            migrationBuilder.RenameIndex(
                name: "IX_Mensaje_AppUserId",
                table: "Mensajes",
                newName: "IX_Mensajes_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mensajes",
                table: "Mensajes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensajes_AspNetUsers_AppUserId",
                table: "Mensajes",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mensajes_AspNetUsers_AppUserId",
                table: "Mensajes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mensajes",
                table: "Mensajes");

            migrationBuilder.RenameTable(
                name: "Mensajes",
                newName: "Mensaje");

            migrationBuilder.RenameIndex(
                name: "IX_Mensajes_AppUserId",
                table: "Mensaje",
                newName: "IX_Mensaje_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mensaje",
                table: "Mensaje",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mensaje_AspNetUsers_AppUserId",
                table: "Mensaje",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
