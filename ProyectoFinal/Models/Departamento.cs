using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Departamento
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
