using ProyectoFinal.Models;

namespace ProyectoFinal.ViewModels
{
    public class CreateNominaViewModel
    {
        public List<AppUser>? UsuariosDisponibles { get; set; }
        public string AppUserId { get; set; }
        public string  CUI { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Puesto { get; set; }
        public string Departamento { get; set; }
        public DateTime INICIO { get; set; }
        public DateTime FINAL { get; set; }
        public float Salario { get; set; }
        public float? PrecioHoraExtra { get; set; }
        public float? Ventas { get; set; }
        public float? Comisiones { get; set; }
        public float? Produccion { get; set; }
        public float Bonificaciones { get; set; }
        public float HorasLaboradas { get; set; }
        public float? HorasExtras { get; set; }
        public DateTime Fecha { get; set; }
        public float? IgssUsuario { get; set; }
        public float? ISR { get; set; }
        public float Anticipo { get; set; }
        public float? Prestamo { get; set; }
        public float TotalDevengado { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public float TotalDescuentos { get; set; }
        public float TotalLiquido { get; set; }
        public CreateNominaCuotaPatronalViewModel? CuotaPatronal { get; set; }

        public float? SueldoEnero { get; set; }
        public float? SueldoFebrero { get; set; }
        public float? SueldoMarzo { get; set; }
        public float? SueldoAbril { get; set; }
        public float? SueldoMayo { get; set; }
        public float? SueldoJunio { get; set; }
        public float? SueldoJulio { get; set; }
        public float? SueldoAgosto { get; set; }
        public float? SueldoSeptiembre { get; set; }
        public float? SueldoOctubre { get; set; }
        public float? SueldoNoviembre { get; set; }
        public float? SueldoDiciembre { get; set; }

        public float? ComisionesEnero { get; set; }
        public float? ComisionesFebrero { get; set; }
        public float? ComisionesMarzo { get; set; }
        public float? ComisionesAbril { get; set; }
        public float? ComisionesMayo { get; set; }
        public float? ComisionesJunio { get; set; }
        public float? ComisionesJulio { get; set; }
        public float? ComisionesAgosto { get; set; }
        public float? ComisionesSeptiembre { get; set; }
        public float? ComisionesOctubre { get; set; }
        public float? ComisionesNoviembre { get; set; }
        public float? ComisionesDiciembre { get; set; }

        public float? HoraEnero { get; set; }
        public float? HoraFebrero { get; set; }
        public float? HoraMarzo { get; set; }
        public float? HoraAbril { get; set; }
        public float? HoraMayo { get; set; }
        public float? HoraJunio { get; set; }
        public float? HoraJulio { get; set; }
        public float? HoraAgosto { get; set; }
        public float? HoraSeptiembre { get; set; }
        public float? HoraOctubre { get; set; }
        public float? HoraNoviembre { get; set; }
        public float? HoraDiciembre { get; set; }


    }
    public class CreateNominaBono14ViewModel
    {
        public List<AppUser>? UsuariosDisponibles { get; set; }
        public string? Nombres { get; set; }
        public float TotalSalarios { get; set; }
        public float PromedioSalario { get; set; }
        public string? CUI { get; set; }
        public float? TotalComisiones { get; set; }
        public float? PromedioComisiones { get; set; }
        public float DiasLaborados { get; set; }
        public float Bono14Total { get; set; }
        public float? SalarioMasComisiones { get; set; }

        public float? SueldoEnero { get; set; }
        public float? SueldoFebrero { get; set; }
        public float? SueldoMarzo { get; set; }
        public float? SueldoAbril { get; set; }
        public float? SueldoMayo { get; set; }
        public float? SueldoJunio { get; set; }
        public float? SueldoJulio { get; set; }
        public float? SueldoAgosto { get; set; }
        public float? SueldoSeptiembre { get; set; }
        public float? SueldoOctubre { get; set; }
        public float? SueldoNoviembre { get; set; }
        public float? SueldoDiciembre { get; set; }
        public DateTime INICIO { get; set; }
        public DateTime FINAL { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public float? ComisionesEnero { get; set; }
        public float? ComisionesFebrero { get; set; }
        public float? ComisionesMarzo { get; set; }
        public float? ComisionesAbril { get; set; }
        public float? ComisionesMayo { get; set; }
        public float? ComisionesJunio { get; set; }
        public float? ComisionesJulio { get; set; }
        public float? ComisionesAgosto { get; set; }
        public float? ComisionesSeptiembre { get; set; }
        public float? ComisionesOctubre { get; set; }
        public float? ComisionesNoviembre { get; set; }
        public float? ComisionesDiciembre { get; set; }

        public float? HoraEnero { get; set; }
        public float? HoraFebrero { get; set; }
        public float? HoraMarzo { get; set; }
        public float? HoraAbril { get; set; }
        public float? HoraMayo { get; set; }
        public float? HoraJunio { get; set; }
        public float? HoraJulio { get; set; }
        public float? HoraAgosto { get; set; }
        public float? HoraSeptiembre { get; set; }
        public float? HoraOctubre { get; set; }
        public float? HoraNoviembre { get; set; }
        public float? HoraDiciembre { get; set; }
    }
    public class CreateNominaAguinaldoViewModel
    {
        public List<AppUser>? UsuariosDisponibles { get; set; }
        public float DiasLaborados { get; set; }
        public float PromedioSalario { get; set; }
        public string? CUI { get; set; }
        public string? Nombres { get; set; }
        public float TotalAguinaldo { get; set; }
        public DateTime INICIO { get; set; }
        public DateTime FINAL { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public float? SueldoEnero { get; set; }
        public float? SueldoFebrero { get; set; }
        public float? SueldoMarzo { get; set; }
        public float? SueldoAbril { get; set; }
        public float? SueldoMayo { get; set; }
        public float? SueldoJunio { get; set; }
        public float? SueldoJulio { get; set; }
        public float? SueldoAgosto { get; set; }
        public float? SueldoSeptiembre { get; set; }
        public float? SueldoOctubre { get; set; }
        public float? SueldoNoviembre { get; set; }
        public float? SueldoDiciembre { get; set; }

        public float? ComisionesEnero { get; set; }
        public float? ComisionesFebrero { get; set; }
        public float? ComisionesMarzo { get; set; }
        public float? ComisionesAbril { get; set; }
        public float? ComisionesMayo { get; set; }
        public float? ComisionesJunio { get; set; }
        public float? ComisionesJulio { get; set; }
        public float? ComisionesAgosto { get; set; }
        public float? ComisionesSeptiembre { get; set; }
        public float? ComisionesOctubre { get; set; }
        public float? ComisionesNoviembre { get; set; }
        public float? ComisionesDiciembre { get; set; }

        public float? HoraEnero { get; set; }
        public float? HoraFebrero { get; set; }
        public float? HoraMarzo { get; set; }
        public float? HoraAbril { get; set; }
        public float? HoraMayo { get; set; }
        public float? HoraJunio { get; set; }
        public float? HoraJulio { get; set; }
        public float? HoraAgosto { get; set; }
        public float? HoraSeptiembre { get; set; }
        public float? HoraOctubre { get; set; }
        public float? HoraNoviembre { get; set; }
        public float? HoraDiciembre { get; set; }
    }
    public class CreateNominaCuotaPatronalViewModel
        {
        public List<AppUser>? UsuariosDisponibles { get; set; }
        public float Sueldo { get; set; }
        public float IGSS { get; set; }
        public float IRTRA { get; set; }        
    }
    public class CreateNominaVacacionesViewModel
    {
        public List<AppUser>? UsuariosDisponibles { get; set; }
        public float Sueldos { get; set; }
        public float? Comisiones { get; set; }
        public float? HorasExtras { get; set; }
        public string? Nombres { get; set; }
        public string? CUI { get; set; }
        public float? Resultado { get; set; }
        public DateTime INICIO { get; set; }
        public DateTime FINAL { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public float? SueldoEnero { get; set; }
        public float? SueldoFebrero { get; set; }
        public float? SueldoMarzo { get; set; }
        public float? SueldoAbril { get; set; }
        public float? SueldoMayo { get; set; }
        public float? SueldoJunio { get; set; }
        public float? SueldoJulio { get; set; }
        public float? SueldoAgosto { get; set; }
        public float? SueldoSeptiembre { get; set; }
        public float? SueldoOctubre { get; set; }
        public float? SueldoNoviembre { get; set; }
        public float? SueldoDiciembre { get; set; }

        public float? ComisionesEnero { get; set; }
        public float? ComisionesFebrero { get; set; }
        public float? ComisionesMarzo { get; set; }
        public float? ComisionesAbril { get; set; }
        public float? ComisionesMayo { get; set; }
        public float? ComisionesJunio { get; set; }
        public float? ComisionesJulio { get; set; }
        public float? ComisionesAgosto { get; set; }
        public float? ComisionesSeptiembre { get; set; }
        public float? ComisionesOctubre { get; set; }
        public float? ComisionesNoviembre { get; set; }
        public float? ComisionesDiciembre { get; set; }

        public float? HoraEnero { get; set; }
        public float? HoraFebrero { get; set; }
        public float? HoraMarzo { get; set; }
        public float? HoraAbril { get; set; }
        public float? HoraMayo { get; set; }
        public float? HoraJunio { get; set; }
        public float? HoraJulio { get; set; }
        public float? HoraAgosto { get; set; }
        public float? HoraSeptiembre { get; set; }
        public float? HoraOctubre { get; set; }
        public float? HoraNoviembre { get; set; }
        public float? HoraDiciembre { get; set; }
    }
    public class CreateNominaIndemnizacionViewModel
    {
        public List<AppUser>? UsuariosDisponibles { get; set; }
        public float PromedioSalario { get; set; }
        public float? Comisiones { get; set; }
        public string? Nombres { get; set; }
        public string? CUI { get; set; }
        public float? HorasExtras { get; set; }
        public float SubTotal { get; set; }
        public float Promedio { get; set; }
        public float Indemnizacion { get; set; }

        public DateTime INICIO { get; set; }
        public DateTime FINAL { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }

        public float? SueldoEnero { get; set; }
        public float? SueldoFebrero { get; set; }
        public float? SueldoMarzo { get; set; }
        public float? SueldoAbril { get; set; }
        public float? SueldoMayo { get; set; }
        public float? SueldoJunio { get; set; }
        public float? SueldoJulio { get; set; }
        public float? SueldoAgosto { get; set; }
        public float? SueldoSeptiembre { get; set; }
        public float? SueldoOctubre { get; set; }
        public float? SueldoNoviembre { get; set; }
        public float? SueldoDiciembre { get; set; }

        public float? ComisionesEnero { get; set; }
        public float? ComisionesFebrero { get; set; }
        public float? ComisionesMarzo { get; set; }
        public float? ComisionesAbril { get; set; }
        public float? ComisionesMayo { get; set; }
        public float? ComisionesJunio { get; set; }
        public float? ComisionesJulio { get; set; }
        public float? ComisionesAgosto { get; set; }
        public float? ComisionesSeptiembre { get; set; }
        public float? ComisionesOctubre { get; set; }
        public float? ComisionesNoviembre { get; set; }
        public float? ComisionesDiciembre { get; set; }

        public float? HoraEnero { get; set; }
        public float? HoraFebrero { get; set; }
        public float? HoraMarzo { get; set; }
        public float? HoraAbril { get; set; }
        public float? HoraMayo { get; set; }
        public float? HoraJunio { get; set; }
        public float? HoraJulio { get; set; }
        public float? HoraAgosto { get; set; }
        public float? HoraSeptiembre { get; set; }
        public float? HoraOctubre { get; set; }
        public float? HoraNoviembre { get; set; }
        public float? HoraDiciembre { get; set; }
    }
}
