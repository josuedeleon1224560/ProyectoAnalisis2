﻿using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Indemnizacion
    {
        [Key]
        public int Id { get; set; }
        public float PromedioSalarios { get; set; }
        public float? Comisiones { get; set; }
        public float? HorasExtras { get; set; }
        public float SubTotal { get; set; }
        public float Promedio { get; set; }
        public float Total { get; set; }
        public string CUI { get; set; }
        public DateTime Fecha { get; set; }
        public ICollection<Nomina> Nomina { get; set; }
    }
}