using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.ViewModels
{
    public class CreateMessageViewModel
    {
        [Required(ErrorMessage = "El campo Contenido es obligatorio.")]
        public string Contenido { get; set; }
    }
}
