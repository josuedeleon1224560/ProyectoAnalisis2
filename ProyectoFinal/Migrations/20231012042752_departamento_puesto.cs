using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class departamento_puesto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdDepartamento",
                table: "Puesto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);

                });

            migrationBuilder.CreateIndex(
                name: "IX_Puesto_IdDepartamento",
                table: "Puesto",
                column: "IdDepartamento");

            migrationBuilder.AddForeignKey(
                name: "FK_Puesto_Departamento_IdDepartamento",
                table: "Puesto",
                column: "IdDepartamento",
                principalTable: "Departamento",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Puesto_Departamento_IdDepartamento",
                table: "Puesto");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropIndex(
                name: "IX_Puesto_IdDepartamento",
                table: "Puesto");

            migrationBuilder.DropColumn(
                name: "IdDepartamento",
                table: "Puesto");
        }
    }
}
