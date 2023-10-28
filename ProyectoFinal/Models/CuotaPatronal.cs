using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class CuotaPatronal
    {
        [Key]
        public int Id { get; set; }
        public float Sueldo { get; set; }
        public float IGSS { get; set; }
        public float IRTRA { get; set; }
        public string UsuarioId { get; set; }
        public string CUI { get; set; }
        public DateTime Fecha { get; set; }
        public ICollection<Nomina> Nomina { get; set; }
    }
}
