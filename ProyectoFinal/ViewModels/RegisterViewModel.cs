using Microsoft.AspNetCore.Identity.UI.V4.Pages.Internal;
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
        [Range(999999999999, 10000000000000, ErrorMessage = "El CUI necesita 13 digitos")]
        public string CUI { get; set; }

            [Display(Name = "Ingrese sus nombres")]
            [Required(ErrorMessage = "Nombres requeridos")]
            [StringLength(50, MinimumLength =3,ErrorMessage ="Nombres validos de 3 a 50 caracteres")]
            public string Nombres { get; set; }

            [Display(Name = "Ingrese sus apellidos")]
            [Required(ErrorMessage ="Apellido requerido")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Apellidos validos de 3 a 100 caracteres")]
        public string Apellidos { get; set; }
            [Display(Name = "Ingrese su numero telefonico")]
        [Required(ErrorMessage = "El Telefono es necesario")]
        [Range(10000000, 100000000, ErrorMessage = "El numero telefono acepta 8 digitos")]
        public int Telefono { get; set; }

            [Display(Name = "Ingrese su fecha de nacimiento")]
            [Required(ErrorMessage = "Fecha de nacimiento requerida")]        
             public DateTime Date { get; set; }
            [Display(Name = "Email address")]
            [Required(ErrorMessage = "Email address is required")]
            public string EmailAddress { get; set; }
            [Required(ErrorMessage ="Escriba una contraseña con una mayuscula y un digito")]
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
        [Required(ErrorMessage = "Seleccione una opcion Valida")]
        public string? SelectedRole { get; set; }
        public List<SelectListItem>? Roles { get; set; }
        [Display(Name = "Departamento")]
        [Required(ErrorMessage = "Seleccione una opcion Valida")]
        public int SelectedDepartamento { get; set; }
        public int SelectedPuesto { get; set; }
        [Display(Name = "Municipio")]
        [Required(ErrorMessage = "Seleccione una opcion Valida")]
        public int idMunicipioSelected { get; set; }
        [Required(ErrorMessage = "Seleccione una opcion Valida")]
        public int idDepartamento { get; set; }

        [Required(ErrorMessage = "Seleccione un Genero Valido")]
        public string Genero { get; set; }
        public List<SelectListItem>? GeneroList { get; set; }

        [Required(ErrorMessage = "Escriba una direccion")]
        public string NombreDireccion { get; set; }

    }
}
