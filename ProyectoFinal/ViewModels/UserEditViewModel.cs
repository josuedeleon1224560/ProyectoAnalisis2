using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoFinal.Migrations;
using ProyectoFinal.Models;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.ViewModels
{
    public class UserEditViewModel
    {
        [Display(Name = "Ingrese CUI")]
        [Required(ErrorMessage = "El CUI es necesario")]
        public string CUI { get; set; }
        [Display(Name = "Ingrese sus nombres")]
        [Required(ErrorMessage = "Nombres requeridos")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nombres validos de 3 a 50 caracteres")]
        public string Nombres { get; set; }
        [Display(Name = "Ingrese sus apellidos")]
        [Required(ErrorMessage = "Apellido requerido")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Apellidos validos de 3 a 100 caracteres")]
        public string Apellidos { get; set; }
        [Display(Name = "Ingrese su numero telefonico")]
        [Required(ErrorMessage = "El Telefono es necesario")]
        [Range(10000000, 100000000, ErrorMessage = "El numero telefono acepta 8 digitos")]
        public int? Telefono { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        public string? Email { get; set; }
        public string? UserName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Ingrese su fecha de nacimiento")]
        [Required(ErrorMessage = "Fecha de nacimiento requerida")]
        public DateTime? Date { get; set; }
        public IFormFile? AntecedentesPenales { get; set; }
        public string? UrlAntecedentesPenales { get; set; }
        public IFormFile? AntecedentesPoliciacos { get; set; }
        public string? UrlAntecedentesPoliciacos { get; set; }
        public IFormFile? Fotografia { get; set; }
        public string? UrlFotografia { get; set; }
        public IFormFile? Diplomas { get; set; }
        public string? UrlDiplomas { get; set; }
        public IFormFile? Titulos { get; set; }
        public string? UrlTitulos { get; set; }
        public int? idDireccion { get; set; }
        [Required(ErrorMessage = "Escriba una direccion")]
        public string? DireccionName { get; set; }
        [Required(ErrorMessage = "Seleccione una opcion Valida")]
        public int IdMunicipio { get; set; }
        //public List<SelectListItem>? Municipios { get; set; }
        public string? Municipio { get; set; }
        [Required(ErrorMessage = "Seleccione una opcion Valida")]
        public int IdDepartamento { get; set; }
        //public List<SelectListItem>? Departamentos { get; set; }

        public string? Departamento { get; set; }
        public string? SelectedRole { get; set; }
        public List<SelectListItem>? Roles { get; set; }
        public List<string>? RolesList { get; set; }
        public Direcciones? Direcciones { get; set; }
        public int IdPuesto { get; set; }
        public string? Puesto { get; set; }
        public int IdDepartamentoPuesto { get; set; }
        public string? DepartamentoPuesto { get; set; }
        public List<DepartamentoGt>? DepartamentoItems { get; set; }
        [Required(ErrorMessage = "Seleccione un Genero Valido")]
        public string Genero { get; set; }
        public List<SelectListItem>? GeneroList { get; set; }
    }
}
