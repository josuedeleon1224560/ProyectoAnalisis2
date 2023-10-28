using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class indemnizacionUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Indemnizacion",
                table: "Nomina",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Indemnizacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PromedioSalarios = table.Column<float>(type: "real", nullable: false),
                    Comisiones = table.Column<float>(type: "real", nullable: true),
                    HorasExtras = table.Column<float>(type: "real", nullable: true),
                    SubTotal = table.Column<float>(type: "real", nullable: false),
                    Promedio = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    CUI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indemnizacion", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nomina_Indemnizacion",
                table: "Nomina",
                column: "Indemnizacion");

            migrationBuilder.AddForeignKey(
                name: "FK_Nomina_Indemnizacion_Indemnizacion",
                table: "Nomina",
                column: "Indemnizacion",
                principalTable: "Indemnizacion",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nomina_Indemnizacion_Indemnizacion",
                table: "Nomina");

            migrationBuilder.DropTable(
                name: "Indemnizacion");

            migrationBuilder.DropIndex(
                name: "IX_Nomina_Indemnizacion",
                table: "Nomina");

            migrationBuilder.DropColumn(
                name: "Indemnizacion",
                table: "Nomina");
        }
    }
}
