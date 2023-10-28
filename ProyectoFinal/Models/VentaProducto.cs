using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class VentaProducto
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("idVenta")]
        public Ventas? Venta { get; set; }

        [ForeignKey("idProducto")]
        public Producto? Producto { get; set; }

        public int Cantidad { get; set; }
    }
}
