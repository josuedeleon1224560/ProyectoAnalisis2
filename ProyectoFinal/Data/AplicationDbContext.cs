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
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Nomina> Nomina { get; set; }
        public DbSet<VentaProducto> VentaProducto { get; set; }
        public DbSet<Bono14> Bono14 { get; set; }
        public DbSet<Aguinaldo> Aguinaldo { get; set; }
        public DbSet<Vacaciones> Vacaciones { get; set; }
        public DbSet<CuotaPatronal> CuotaPatronal { get; set; }
        public DbSet<Asistencia> Asistencias { get; set; }
        public DbSet<Indemnizacion> Indemnizacion { get; set; }

    }
}
