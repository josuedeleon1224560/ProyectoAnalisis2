using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Repository
{
    public class MensajesRepository
    {
        private readonly AplicationDbContext _context;

        public MensajesRepository(AplicationDbContext context) 
            {
            _context = context;
            }

        public async Task<IEnumerable<Mensaje>> GetMensajes()
        {
            return _context.Mensajes.Where(m => m.Estado == EstadoMensaje.Pendiente).ToList();
        }

        public async Task<IEnumerable<Mensaje>> ObtenerUsuario(string id)
        {
            return _context.Mensajes.Where(m=> m.AppUserId == id).ToList();
        }

        public async Task<Mensaje> Buscar(int id)
        {
            return _context.Mensajes.Find(id);
        }

    }
}
