using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Repository
{
    public class DepartamentoRepository
    {
        private readonly AplicationDbContext _context;

        public DepartamentoRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DepartamentoGt> GetDepartamentoById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            // Buscar el departamento por su Id, incluyendo la propiedad de navegación MunicipiosGt
            var departamento = await _context.Tabla_Departamentos
                .FirstOrDefaultAsync(d => d.Id == id);

            return departamento;
        }
    }
}
