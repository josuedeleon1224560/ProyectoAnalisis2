using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class nomina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aguinaldo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiasLaborados = table.Column<float>(type: "real", nullable: false),
                    PromedioSalario = table.Column<float>(type: "real", nullable: false),
                    TotalAguinaldo = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aguinaldo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bono14",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalSalarios = table.Column<float>(type: "real", nullable: false),
                    PromedioSalario = table.Column<float>(type: "real", nullable: false),
                    TotalComisiones = table.Column<float>(type: "real", nullable: true),
                    PromedioComisiones = table.Column<float>(type: "real", nullable: true),
                    SalarioAdicionalComisiones = table.Column<float>(type: "real", nullable: true),
                    DiasLaborados = table.Column<float>(type: "real", nullable: false),
                    Bono14Total = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bono14", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CuotaPatronal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sueldo = table.Column<float>(type: "real", nullable: false),
                    IGSS = table.Column<float>(type: "real", nullable: false),
                    IRTRA = table.Column<float>(type: "real", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CUI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuotaPatronal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vacaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sueldos = table.Column<float>(type: "real", nullable: false),
                    Comisiones = table.Column<float>(type: "real", nullable: true),
                    HorasExtras = table.Column<float>(type: "real", nullable: true),
                    Resultado = table.Column<float>(type: "real", nullable: true),
                    CUI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacaciones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nomina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CUI = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorasLaboradas = table.Column<float>(type: "real", nullable: false),
                    Salario = table.Column<float>(type: "real", nullable: false),
                    HorasExtras = table.Column<float>(type: "real", nullable: true),
                    FechaNomina = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IgssUsuario = table.Column<float>(type: "real", nullable: true),
                    ISR = table.Column<float>(type: "real", nullable: true),
                    Anticipo = table.Column<float>(type: "real", nullable: false),
                    Prestamo = table.Column<float>(type: "real", nullable: true),
                    TotalDescuentos = table.Column<float>(type: "real", nullable: false),
                    TotalLiquido = table.Column<float>(type: "real", nullable: false),
                    Bono14Nomina = table.Column<int>(type: "int", nullable: true),
                    AguinaldoNomina = table.Column<int>(type: "int", nullable: true),
                    UsuarioNomina = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UsuarioPuesto = table.Column<int>(type: "int", nullable: true),
                    CuotaPatronalNomina = table.Column<int>(type: "int", nullable: true),
                    VacacionesNomina = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nomina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nomina_Aguinaldo_AguinaldoNomina",
                        column: x => x.AguinaldoNomina,
                        principalTable: "Aguinaldo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nomina_AspNetUsers_UsuarioNomina",
                        column: x => x.UsuarioNomina,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nomina_Bono14_Bono14Nomina",
                        column: x => x.Bono14Nomina,
                        principalTable: "Bono14",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nomina_CuotaPatronal_CuotaPatronalNomina",
                        column: x => x.CuotaPatronalNomina,
                        principalTable: "CuotaPatronal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nomina_Puesto_UsuarioPuesto",
                        column: x => x.UsuarioPuesto,
                        principalTable: "Puesto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Nomina_Vacaciones_VacacionesNomina",
                        column: x => x.VacacionesNomina,
                        principalTable: "Vacaciones",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nomina_AguinaldoNomina",
                table: "Nomina",
                column: "AguinaldoNomina",
                unique: true,
                filter: "[AguinaldoNomina] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Nomina_Bono14Nomina",
                table: "Nomina",
                column: "Bono14Nomina",
                unique: true,
                filter: "[Bono14Nomina] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Nomina_CuotaPatronalNomina",
                table: "Nomina",
                column: "CuotaPatronalNomina",
                unique: true,
                filter: "[CuotaPatronalNomina] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Nomina_UsuarioNomina",
                table: "Nomina",
                column: "UsuarioNomina");

            migrationBuilder.CreateIndex(
                name: "IX_Nomina_UsuarioPuesto",
                table: "Nomina",
                column: "UsuarioPuesto");

            migrationBuilder.CreateIndex(
                name: "IX_Nomina_VacacionesNomina",
                table: "Nomina",
                column: "VacacionesNomina",
                unique: true,
                filter: "[VacacionesNomina] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nomina");

            migrationBuilder.DropTable(
                name: "Aguinaldo");

            migrationBuilder.DropTable(
                name: "Bono14");

            migrationBuilder.DropTable(
                name: "CuotaPatronal");

            migrationBuilder.DropTable(
                name: "Vacaciones");
        }
    }
}
