using Microsoft.AspNetCore.Identity;
using ProyectoFinal.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [Key]
        public string CUI { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        public string Genero { get; set; }
        public int? Telefono { get; set; }
        [Required]
        public DateTime Date { get; set; }
        //public int Edad { get; set; }
        //public string Puesto { get; set; }
        //public float Salario { get; set; }
        //public float Horas { get; set; }

        [ForeignKey("Direcciones")]
        public int? IdDireccion { get; set; }
        [ForeignKey("idPuestos")]
        public Puesto? IdPuesto { get; set; }
        public DireccionGt? Direcciones { get; set; }

        public ICollection<Mensaje> Mensajes { get; set; }
        public ICollection<Asistencia> Asistencias { get; set; }

        public string? AntecedentesPenales { get; set; }
        public string? AntecedentesPoliciacos { get; set; }
        public string? Fotografia { get; set; }
        public string? Diplomas { get; set; }
        public string? Titulos { get; set; }
    }
}
