using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoFinal.Data;
using ProyectoFinal.Models;
using System.ComponentModel.DataAnnotations;
namespace ProyectoFinal.ViewModels
{
    public class RegisterViewModel
    {
            [Display(Name = "Ingrese CUI")]
            [Required(ErrorMessage = "El CUI es necesario")]
            public string CUI { get; set; }

            [Display(Name = "Ingrese sus nombres")]
            [Required(ErrorMessage = "Nombres requeridos")]
            public string Nombres { get; set; }

            [Display(Name = "Ingrese sus apellidos")]
            [Required(ErrorMessage ="Apellido requerido")]
            public string Apellidos { get; set; }
            [Display(Name = "Ingrese su numero telefonico")]
            public int Telefono { get; set; }

            [Display(Name = "Ingrese su fecha de nacimiento")]
            [Required(ErrorMessage = "Fecha de nacimiento requerida")]
            public DateTime Date { get; set; }
            [Display(Name = "Email address")]
            [Required(ErrorMessage = "Email address is required")]
            public string EmailAddress { get; set; }
            [Required(ErrorMessage ="Escriba una contraseña")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
            //[Display(Name = "Confirm password")]
            //[Required(ErrorMessage = "Confirm password is required")]
            //[DataType(DataType.Password)]
            //[Compare("Password", ErrorMessage = "Password do not match")]
            //public string ConfirmPassword { get; set; }
        [Display(Name = "Ingrese sus antecedentes")]
            public IFormFile? AntecedentesPenales { get; set; }
        [Display(Name = "Ingrese sus policiacos")]
        public IFormFile? AntecedentesPoliciacos { get; set; }
        [Display(Name = "Ingrese su fotografia")]
        public IFormFile? Fotografia { get; set; }
        [Display(Name = "Ingrese sus diploma")]
        public IFormFile? Diplomas { get; set; }
        [Display(Name = "Ingrese sus titulos")]
        public IFormFile? Titulos { get; set; }
        [Display(Name = "Seleccione un Rol")]
        [Required(ErrorMessage ="Seleccione un Rol valido")]
        public string SelectedRole { get; set; } 
        public List<SelectListItem> Roles { get; set; }
        public int SelectedDepartamento { get; set; }
        public int SelectedPuesto { get; set; }

        [Required(ErrorMessage = "Seleccione Municipio Valido")]
        public int idMunicipioSelected { get; set; }
        public string NombreDireccion { get; set; }

    }
}
