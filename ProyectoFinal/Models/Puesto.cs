using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Puesto
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public float Salario { get; set; }
        [ForeignKey("IdDepartamento")]        
        public Departamento? Departamento { get; set; }
    }
}
