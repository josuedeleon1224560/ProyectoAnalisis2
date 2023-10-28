using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoFinal.Models;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.ViewModels
{
    public class TiendaViewModel
    {
        public TipoPago Pago { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public List<AppUser>? UsuariosDisponibles { get; set; }
        public string UsuarioId { get; set; }
        public List<SelectListItem>? TipoPagoList { get; set; }

        public string TipoPago { get; set; }

        public List<ProductoViewModel>? Productos { get; set; }
    }

    public class ProductoViewModel
    {
        public int ProductoId { get; set; }
        public string? ProductoNombre { get; set; }

        public Producto? Producto { get; set; }
        public int Cantidad { get; set; }
    }
}
