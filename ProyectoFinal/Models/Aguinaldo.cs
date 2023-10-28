using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Aguinaldo
    {
        [Key]
        public int Id { get; set; }
        public float DiasLaborados { get; set; }
        public float PromedioSalario { get; set; }
        public float TotalAguinaldo { get; set; }
        public string CUI { get; set; }
        public DateTime Fecha { get; set; }
        public ICollection<Nomina> Nomina { get; set; }
    }
}
