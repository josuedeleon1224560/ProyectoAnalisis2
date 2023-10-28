using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Producto
    {
        [Key] 
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public int Stock { get; set; }
        public bool? Existencia { get; set; }
    }
}
