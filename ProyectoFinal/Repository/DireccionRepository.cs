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


        public List<DepartamentoGt> GetAllDepartamentoEditar()
        {
            return _context.Tabla_Departamentos.ToList();
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
            return await _context.Tabla_Direcciones.Include(i => i.Id).FirstOrDefaultAsync(i => i.Id == id);
        }

        //public async Task<AppUser> GetDireccionMunicipioById(string id)
        //{
        //        return await _context.Users.Include(u => u.Direcciones).ThenInclude(d=> d.MunicipioGt).SingleOrDefault(
        //            u=>u.Direcciones.idMunicipio ==)
        //}

        public async Task<MunicipioGt> MunicipioById(int? id)
        {
            return await _context.Tabla_Municipios.FindAsync(id);
        }

        public async Task<DepartamentoGt> GetDepartamentoById(int? id)
        {
            if (id == null)
            {
                return null;
            }

            // Buscar el municipio por su ID
            var municipio = await _context.Tabla_Municipios
                .Include(m => m.DepartamentoGt) // Incluir la propiedad de navegación al departamento
                .FirstOrDefaultAsync(m => m.Id == id);

            if (municipio == null)
            {
                return null;
            }

            // Obtener el departamento del municipio
            var departamento = municipio.DepartamentoGt;

            return departamento;
        }

        internal async Task<IEnumerable<DepartamentoGt>> GetAllDepartamentoAsync()
        {
            return (IEnumerable<DepartamentoGt>)await _context.Tabla_Municipios.ToListAsync();
        }

    }
}
