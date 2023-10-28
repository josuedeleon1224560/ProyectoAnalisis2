using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Nomina
    {
        [Key]
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public string CUI { get; set; }
        public string Nombres { get; set; }
        public string Apellido { get; set; }
        public string PuestoS { get; set; }
        public string Departamento { get; set; }
        public float HorasLaboradas { get; set; }
        public float Salario { get; set; }
        public float? HorasExtras { get; set; }
        public float? PrecioHoraExtra { get; set; }
        public float? Ventas { get; set; }
        public float? Produccion { get; set; }
        public float? Comisiones { get; set; }
        public float Bonificaciones { get; set; }
        public float TotalDevengado { get; set; }
        public DateTime FechaNomina { get; set; }
        public float? IgssUsuario { get; set; }
        public float? ISR { get; set; }
        public float Anticipo { get; set; }
        public float? Prestamo { get; set; }
        public float TotalDescuentos { get; set; }
        public float TotalLiquido { get; set; }
        [ForeignKey("Bono14Nomina")]
        public Bono14? Bono14 { get; set; }
        [ForeignKey("AguinaldoNomina")]
        public Aguinaldo? Aguinaldo { get; set; }
        [ForeignKey("UsuarioNomina")]
        public AppUser? Usuario { get; set; }
        [ForeignKey("UsuarioPuesto")]
        public Puesto? Puesto { get; set; }
        [ForeignKey("CuotaPatronalNomina")]
        public CuotaPatronal? CuotaPAtronal { get; set; }
        [ForeignKey("VacacionesNomina")]
        public Vacaciones? Vacaciones { get; set; }
        [ForeignKey("Indemnizacion")]
        public Indemnizacion? Indemnizaciones { get; set; }
    }
}
