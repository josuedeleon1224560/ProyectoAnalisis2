using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class DepartamentoGt
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }

    }

}
