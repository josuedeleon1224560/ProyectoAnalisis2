using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class puestos_c : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "idPuestos",
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
                name: "IX_AspNetUsers_idPuestos",
                table: "AspNetUsers",
                column: "idPuestos");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Puesto_idPuestos",
                table: "AspNetUsers",
                column: "idPuestos",
                principalTable: "Puesto",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Puesto_idPuestos",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Puesto");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_idPuestos",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "idPuestos",
                table: "AspNetUsers");
        }
    }
}
