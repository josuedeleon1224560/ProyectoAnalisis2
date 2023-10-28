using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class asistenciaNueva1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asistencias_AspNetUsers_UsuarioAsistenciaId",
                table: "Asistencias");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioAsistenciaId",
                table: "Asistencias",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_AspNetUsers_UsuarioAsistenciaId",
                table: "Asistencias",
                column: "UsuarioAsistenciaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Asistencias_AspNetUsers_UsuarioAsistenciaId",
                table: "Asistencias");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioAsistenciaId",
                table: "Asistencias",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_AspNetUsers_UsuarioAsistenciaId",
                table: "Asistencias",
                column: "UsuarioAsistenciaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
