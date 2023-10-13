using Microsoft.AspNetCore.Identity;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.ViewModels
{
    public class UserViewModel
    {
        public string CUI { get; set; }
        public string? Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int? Telefono { get; set; }
        public DateTime? Date { get; set; }

        public string? UrlAntePenales { get; set; }
        public string? UrlAntePoli { get; set; }
        public string? UrlFotografia { get; set; }
        public string? UrlDiplomas { get; set; }
        public string? Titulos { get; set; }

        public string RoleName { get; set;}
        public List<string> Roles { get; set; }

        public int? IdDireccion { get; set; }
        public string? DireccionUsuario { get; set; }
        public string? MunicipioUsuario { get; set; }
        public string? DepartamentoUsuario { get; set; }
        public DireccionGt DireccionName { get; set; }
    }


}
