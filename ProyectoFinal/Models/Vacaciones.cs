using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Vacaciones
    {
        [Key]
        public int Id { get; set; }
        public float Sueldos { get; set; }
        public float? Comisiones { get; set; }
        public float? HorasExtras { get; set; }
        public float? Resultado { get; set; }      
        public string CUI { get; set; }
        public DateTime Fecha { get; set; }
        public ICollection<Nomina> Nomina { get; set; }
    }
}
