using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string Nombre { get; set; }
    }
}
