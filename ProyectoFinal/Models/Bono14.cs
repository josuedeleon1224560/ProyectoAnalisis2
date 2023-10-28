using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Bono14
    {
        [Key]
        public int Id { get; set; }
        public float TotalSalarios { get; set; }
        public float PromedioSalario { get; set; }
        public float? TotalComisiones { get; set; }
        public float? PromedioComisiones { get; set; }
        public float? SalarioAdicionalComisiones { get; set; }
        public float DiasLaborados { get; set; }
        public float Bono14Total { get; set; }
        public string CUI { get; set; }
        public DateTime Fecha { get; set; }
        public ICollection<Nomina> Nomina { get; set; }
    }
}
