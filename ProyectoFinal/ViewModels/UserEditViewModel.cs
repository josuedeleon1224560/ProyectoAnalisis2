using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoFinal.Migrations;
using ProyectoFinal.Models;

namespace ProyectoFinal.ViewModels
{
    public class UserEditViewModel
    {
        public string CUI { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int? Telefono { get; set; }
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
        public string? DireccionName { get; set; }
        public int IdMunicipio { get; set; }
        //public List<SelectListItem>? Municipios { get; set; }
        public string? Municipio { get; set; }
        public int IdDepartamento { get; set; }
        //public List<SelectListItem>? Departamentos { get; set; }
        public string? Departamento { get; set; }

    }
}
