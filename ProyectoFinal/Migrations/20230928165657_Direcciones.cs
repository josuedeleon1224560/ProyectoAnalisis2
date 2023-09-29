using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class Direcciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tabla_Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabla_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tabla_Municipios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabla_Municipios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tabla_Municipios_Tabla_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Tabla_Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tabla_Direcciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdMunicipio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabla_Direcciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tabla_Direcciones_Tabla_Municipios_IdMunicipio",
                        column: x => x.IdMunicipio,
                        principalTable: "Tabla_Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tabla_Direcciones_IdMunicipio",
                table: "Tabla_Direcciones",
                column: "IdMunicipio");

            migrationBuilder.CreateIndex(
                name: "IX_Tabla_Municipios_DepartamentoId",
                table: "Tabla_Municipios",
                column: "DepartamentoId");

          

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tabla_Direcciones");

            migrationBuilder.DropTable(
                name: "Tabla_Municipios");

            migrationBuilder.DropTable(
                name: "Tabla_Departamentos");

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPais = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departamento_Pais_IdPais",
                        column: x => x.IdPais,
                        principalTable: "Pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdDepartamento = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipio_Departamento_IdDepartamento",
                        column: x => x.IdDepartamento,
                        principalTable: "Departamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_IdPais",
                table: "Departamento",
                column: "IdPais");

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_IdDepartamento",
                table: "Municipio",
                column: "IdDepartamento");
        }
    }
}
