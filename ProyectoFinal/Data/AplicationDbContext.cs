using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;

namespace ProyectoFinal.Data
{
    public class AplicationDbContext : IdentityDbContext<AppUser>
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }

        public DbSet<DepartamentoGt> Tabla_Departamentos { get; set; }
        public DbSet<MunicipioGt> Tabla_Municipios { get; set; }
        public DbSet<DireccionGt> Tabla_Direcciones { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Puesto> Puesto { get; set; }
        public DbSet<Mensaje> Mensajes { get; set; }
    }
}
