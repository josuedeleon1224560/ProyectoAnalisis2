using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class completo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_DireccionesUsuario_DireccionId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DireccionesUsuario");

            migrationBuilder.RenameColumn(
                name: "DireccionId",
                table: "AspNetUsers",
                newName: "IdDireccion");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_DireccionId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_IdDireccion");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Tabla_Direcciones_IdDireccion",
                table: "AspNetUsers",
                column: "IdDireccion",
                principalTable: "Tabla_Direcciones",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Tabla_Direcciones_IdDireccion",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "IdDireccion",
                table: "AspNetUsers",
                newName: "DireccionId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_IdDireccion",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_DireccionId");

            migrationBuilder.CreateTable(
                name: "DireccionesUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartamentosId = table.Column<int>(type: "int", nullable: false),
                    DireccionesId = table.Column<int>(type: "int", nullable: false),
                    MunicipiosId = table.Column<int>(type: "int", nullable: false),
                    IdDepartamento = table.Column<int>(type: "int", nullable: true),
                    IdDireccion = table.Column<int>(type: "int", nullable: true),
                    IdMunicipio = table.Column<int>(type: "int", nullable: true)
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
                name: "FK_AspNetUsers_DireccionesUsuario_DireccionId",
                table: "AspNetUsers",
                column: "DireccionId",
                principalTable: "DireccionesUsuario",
                principalColumn: "Id");
        }
    }
}
