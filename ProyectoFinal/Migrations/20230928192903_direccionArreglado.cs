using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class direccionArreglado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "DireccionesUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDepartamento = table.Column<int>(type: "int", nullable: true),
                    DepartamentosId = table.Column<int>(type: "int", nullable: false),
                    IdMunicipio = table.Column<int>(type: "int", nullable: true),
                    MunicipiosId = table.Column<int>(type: "int", nullable: false),
                    IdDireccion = table.Column<int>(type: "int", nullable: true),
                    DireccionesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DireccionesUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DireccionesUsuario_Tabla_Departamentos_DepartamentosId",
                        column: x => x.DepartamentosId,
                        principalTable: "Tabla_Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DireccionesUsuario_Tabla_Direcciones_DireccionesId",
                        column: x => x.DireccionesId,
                        principalTable: "Tabla_Direcciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DireccionesUsuario_Tabla_Municipios_MunicipiosId",
                        column: x => x.MunicipiosId,
                        principalTable: "Tabla_Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DireccionesId",
                table: "AspNetUsers",
                column: "DireccionesId");

            migrationBuilder.CreateIndex(
                name: "IX_DireccionesUsuario_DepartamentosId",
                table: "DireccionesUsuario",
                column: "DepartamentosId");

            migrationBuilder.CreateIndex(
                name: "IX_DireccionesUsuario_DireccionesId",
                table: "DireccionesUsuario",
                column: "DireccionesId");

            migrationBuilder.CreateIndex(
                name: "IX_DireccionesUsuario_MunicipiosId",
                table: "DireccionesUsuario",
                column: "MunicipiosId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_DireccionesUsuario_DireccionesId",
                table: "AspNetUsers",
                column: "DireccionesId",
                principalTable: "DireccionesUsuario",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DireccionesUsuario_DireccionesId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DireccionesUsuario");

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
    }
}
