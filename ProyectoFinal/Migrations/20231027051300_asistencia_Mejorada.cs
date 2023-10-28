using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class asistencia_Mejorada : Migration
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
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<double>(
                name: "HorasTrabajadas",
                table: "Asistencias",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "HorasExtras",
                table: "Asistencias",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_AspNetUsers_UsuarioAsistenciaId",
                table: "Asistencias",
                column: "UsuarioAsistenciaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
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
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "HorasTrabajadas",
                table: "Asistencias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "HorasExtras",
                table: "Asistencias",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Asistencias_AspNetUsers_UsuarioAsistenciaId",
                table: "Asistencias",
                column: "UsuarioAsistenciaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
