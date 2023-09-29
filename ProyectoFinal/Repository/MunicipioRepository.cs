using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Repository
{
    public class MunicipioRepository
    {
        private readonly AplicationDbContext _context;

        public MunicipioRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MunicipioGt> GetMunicipioById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            // Buscar el municipio por su Id, incluyendo la propiedad de navegación DepartamentoGt
            var municipio = await _context.Tabla_Municipios
                .Include(m => m.DepartamentoGt)
                .FirstOrDefaultAsync(m => m.Id == id);

            return municipio;
        }
    }
}
