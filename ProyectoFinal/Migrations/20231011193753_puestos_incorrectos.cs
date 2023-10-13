using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class puestos_incorrectos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Puesto_PuestoId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Puesto");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_PuestoId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdPuesto",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PuestoId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPuesto",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PuestoId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Puesto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puesto", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PuestoId",
                table: "AspNetUsers",
                column: "PuestoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Puesto_PuestoId",
                table: "AspNetUsers",
                column: "PuestoId",
                principalTable: "Puesto",
                principalColumn: "Id");
        }
    }
}
