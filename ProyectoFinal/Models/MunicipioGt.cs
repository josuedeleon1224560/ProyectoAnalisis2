using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class MunicipioGt
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        [ForeignKey("Departamento")]
        public int? idDepartamento { get; set; }
        public DepartamentoGt? DepartamentoGt { get; set; }
    }
}
