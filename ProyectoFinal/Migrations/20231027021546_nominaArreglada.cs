using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class nominaArreglada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Nomina_AguinaldoNomina",
                table: "Nomina");

            migrationBuilder.DropIndex(
                name: "IX_Nomina_Bono14Nomina",
                table: "Nomina");

            migrationBuilder.DropIndex(
                name: "IX_Nomina_CuotaPatronalNomina",
                table: "Nomina");

            migrationBuilder.DropIndex(
                name: "IX_Nomina_VacacionesNomina",
                table: "Nomina");

            migrationBuilder.CreateIndex(
                name: "IX_Nomina_AguinaldoNomina",
                table: "Nomina",
                column: "AguinaldoNomina");

            migrationBuilder.CreateIndex(
                name: "IX_Nomina_Bono14Nomina",
                table: "Nomina",
                column: "Bono14Nomina");

            migrationBuilder.CreateIndex(
                name: "IX_Nomina_CuotaPatronalNomina",
                table: "Nomina",
                column: "CuotaPatronalNomina");

            migrationBuilder.CreateIndex(
                name: "IX_Nomina_VacacionesNomina",
                table: "Nomina",
                column: "VacacionesNomina");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Nomina_AguinaldoNomina",
                table: "Nomina");

            migrationBuilder.DropIndex(
                name: "IX_Nomina_Bono14Nomina",
                table: "Nomina");

            migrationBuilder.DropIndex(
                name: "IX_Nomina_CuotaPatronalNomina",
                table: "Nomina");

            migrationBuilder.DropIndex(
                name: "IX_Nomina_VacacionesNomina",
                table: "Nomina");

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
                name: "IX_Nomina_VacacionesNomina",
                table: "Nomina",
                column: "VacacionesNomina",
                unique: true,
                filter: "[VacacionesNomina] IS NOT NULL");
        }
    }
}
