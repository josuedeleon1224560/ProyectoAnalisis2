namespace ProyectoFinal.ViewModels
{
    public class DatosNominasVerViewModel
    {
        public string CUI { get; set; }
        public string Nombres { get; set; }
        public float HorasLaboradas { get; set; }
        public float Salario { get; set; }
        public float? HorasExtras { get; set; }
        public DateTime Fecha { get; set; }
        public float? ISR { get; set; }
        public float Anticipo { get; set; }
        public float? Prestamo { get; set; }
        public float TotalDescuentos { get; set; }
        public float TotalLiquido { get; set; }
        public float? SueldoPatronal { get; set; }
        public float IGSSPatronal { get; set; }
        public float IRTRAPatronal { get; set; }
    }
}
