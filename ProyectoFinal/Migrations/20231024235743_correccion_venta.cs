using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class correccion_venta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ventas_Producto_idProducto",
                table: "Ventas");

            migrationBuilder.DropIndex(
                name: "IX_Ventas_idProducto",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Ventas");

            migrationBuilder.DropColumn(
                name: "idProducto",
                table: "Ventas");

            migrationBuilder.CreateTable(
                name: "VentaProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idVenta = table.Column<int>(type: "int", nullable: true),
                    idProducto = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VentaProducto_Producto_idProducto",
                        column: x => x.idProducto,
                        principalTable: "Producto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VentaProducto_Ventas_idVenta",
                        column: x => x.idVenta,
                        principalTable: "Ventas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VentaProducto_idProducto",
                table: "VentaProducto",
                column: "idProducto");

            migrationBuilder.CreateIndex(
                name: "IX_VentaProducto_idVenta",
                table: "VentaProducto",
                column: "idVenta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VentaProducto");

            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "Ventas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idProducto",
                table: "Ventas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_idProducto",
                table: "Ventas",
                column: "idProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Ventas_Producto_idProducto",
                table: "Ventas",
                column: "idProducto",
                principalTable: "Producto",
                principalColumn: "Id");
        }
    }
}
