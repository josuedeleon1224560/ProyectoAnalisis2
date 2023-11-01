namespace ProyectoFinal.ViewModels
{
    public class VerIndemnizacionViewModel
    {
        public int Id { get; set; }
        public float PromedioSalarios { get; set; }
        public float? Comisiones { get; set; }
        public float? HorasExtras { get; set; }
        public float SubTotal { get; set; }
        public float Promedio { get; set; }
        public float Total { get; set; }
        public string CUI { get; set; }
        public DateTime Fecha { get; set; }
    }
}
