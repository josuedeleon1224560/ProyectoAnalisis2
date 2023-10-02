using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class DireccionGt
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public MunicipioGt MunicipioGt { get; set; }
    }
}
