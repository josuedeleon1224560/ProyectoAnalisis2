using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;

namespace ProyectoFinal.Repository
{
    public class DireccionRepository
    {
        private readonly AplicationDbContext _context;

        public DireccionRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DepartamentoGt> GetAllDepartamento()
        {
            return  _context.Tabla_Departamentos.ToList();
        }

        public IEnumerable<MunicipioGt> GetAllMunicipio(int id)
        {
            return _context.Tabla_Municipios.Where(e => e.DepartamentoGt.Id == id).ToList();
        }
        public IEnumerable<DireccionGt> GetAllDirecciones(int id)
        {
            return _context.Tabla_Direcciones.Where(dir => dir.MunicipioGt.Id == id).ToList();
        }

        //public IEnumerable<MunicipioGt> GetAllMunicipiosByDepartamento(int departamentoId)
        //{
        //    return _context.Tabla_Municipios.Where(m => m.DepartamentoId == departamentoId).ToList();
        //}

        public async Task<DireccionGt> GetDireccionById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            // Buscar la dirección por su ID
            var direccion = await _context.Tabla_Direcciones
                .FirstOrDefaultAsync(d => d.Id == id);

            return direccion;
        }

        public async Task<MunicipioGt> GetMunicipioById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            // Buscar la dirección por su ID
            var municipio = await _context.Tabla_Municipios
                .FirstOrDefaultAsync(m => m.Id == id);

            return municipio;
        }
        public async Task<DepartamentoGt> GetDepartamentoById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            // Buscar la dirección por su ID
            var departamento = await _context.Tabla_Departamentos
                .FirstOrDefaultAsync(d => d.Id == id);

            return departamento;
        }

        internal async Task<IEnumerable<DepartamentoGt>> GetAllDepartamentoAsync()
        {
            return (IEnumerable<DepartamentoGt>)await _context.Tabla_Municipios.ToListAsync();
        }

    }
}
