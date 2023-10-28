using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Ventas
    {
        [Key]
        public int Id { get; set; }
        public TipoPago Pago { get; set; }
        public DateTime Fecha { get; set; }
        [ForeignKey("idUsuario")]
        public AppUser? Usuario { get; set; }
        public ICollection<VentaProducto>? ProductosEnVenta { get; set; }
    }

    public enum TipoPago
    {
        Efectivo,
        Credito
    }
}
