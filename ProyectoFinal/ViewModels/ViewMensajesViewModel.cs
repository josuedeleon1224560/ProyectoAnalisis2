using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.ViewModels
{
    public class ViewMensajesViewModel
    {
        public AppUser Usuario { get; set; }
        public List<Mensaje> MensajesUsuario { get; set; }
    }
}
