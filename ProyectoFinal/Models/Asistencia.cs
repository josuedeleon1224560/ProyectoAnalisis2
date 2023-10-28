using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Asistencia
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool EsEntrada { get; set; }
        public double? HorasTrabajadas { get; set; }
        public double? HorasExtras { get; set; }

        // Propiedad de navegación para relacionar con el usuario
        public AppUser? UsuarioAsistencia { get; set; }
    }
}
