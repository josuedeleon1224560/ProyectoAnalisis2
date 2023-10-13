using ProyectoFinal.Migrations;
using ProyectoFinal.Models;

namespace ProyectoFinal.ViewModels
{
    public class UserDetailViewModel
    {
        public string CUI { get; set; }
        public string Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int? Telefono { get; set; }
        public DateTime? Date { get; set; }
        public string? AntecedentesPenales { get; set; }
        public string? AntecedentesPoliciacos { get; set; }
        public string? Fotografia { get; set; }
        public string? Diplomas { get; set; }
        public string? Titulos { get; set; }
        public List<string> Roles { get; set; }
        public string DireccionUsuario { get; set; }
        public string MunicipioUsuario { get; set; }
        public string DepartamentoUsuario { get; set; }
        public int? DireccionId { get; set; }
        //public string Direccion_Name { get; set; }
        public int? MunicipioId { get; set; }
        //public string Municipio_Name { get; set; }
        public int? DepartamentoId { get; set; }
        //public string Departamento_Name { get; set; }
    }
}
