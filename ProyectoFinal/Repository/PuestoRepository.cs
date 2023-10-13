using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Repository
{
    public class PuestoRepository
    {
        private readonly AplicationDbContext _context;

        public PuestoRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Departamento> GetDepartamentos()
        {
            return _context.Departamento.ToList();
        }

        public IEnumerable<Puesto> GetAllPuestos(int id)
        {
            return _context.Puesto.Where(e => e.Departamento.Id == id).ToList();
        }




    }
}
