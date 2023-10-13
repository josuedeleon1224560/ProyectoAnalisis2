using CloudinaryDotNet;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class Mensaje
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public EstadoMensaje Estado { get; set; }        
        public string AppUserId { get; set; }
        public AppUser Appuser { get; set; }
    }

    public enum EstadoMensaje
    {
        Pendiente,
        Rechazado,
        Aprobado
    }
}
