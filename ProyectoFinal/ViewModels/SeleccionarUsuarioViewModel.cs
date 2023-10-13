using ProyectoFinal.Models;

namespace ProyectoFinal.ViewModels
{
    public class SeleccionarUsuarioViewModel
    {
        public List<AppUser> UsuariosDisponibles { get; set; }
        public string CUI { get; set; }
    }
}
