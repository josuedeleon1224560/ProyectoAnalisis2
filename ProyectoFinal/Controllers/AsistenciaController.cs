using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Data;
using ProyectoFinal.Models;
using ProyectoFinal.ViewModels;

namespace ProyectoFinal.Controllers
{
    public class AsistenciaController : Controller
    {
        private readonly AplicationDbContext _context;

        public AsistenciaController(AplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var asistencias = _context.Asistencias.ToList();
            return View(asistencias);
        }
        public IActionResult RegistrarHora()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarHora(AsistenciaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.CUI == model.UserId);

                if (user != null)
                {
                    bool esEntrada = model.EsEntrada;
                    DateTime horaActual = DateTime.Now; // Obtener la hora actual

                    if (esEntrada)
                    {
                        // Verifica si ya existe una hora de entrada para el usuario en la misma fecha
                        bool entradaDuplicada = _context.Asistencias.Any(a => a.UserId == user.Id && a.FechaRegistro.Date == horaActual.Date && a.EsEntrada);

                        if (entradaDuplicada)
                        {
                            TempData["MensajeError"] = "Ya has registrado una hora de entrada hoy.";
                        }
                        else
                        {
                            // Continúa y registra la hora de entrada automáticamente
                            var asistencia = new Asistencia
                            {
                                UserId = user.Id,
                                FechaRegistro = DateTime.Now, // Utiliza la hora actual
                                EsEntrada = true
                            };
                            _context.Asistencias.Add(asistencia);
                            _context.SaveChanges();
                            TempData["MensajeExito"] = "Entrada registrada con éxito.";
                        }
                    }
                    else
                    {
                        // Verifica si ya existe una hora de salida para el usuario en la misma fecha
                        bool salidaDuplicada = _context.Asistencias.Any(a => a.UserId == user.Id && a.FechaRegistro.Date == horaActual.Date && !a.EsEntrada);

                        if (salidaDuplicada)
                        {
                            TempData["MensajeError"] = "Ya has registrado una hora de salida hoy.";
                        }
                        else
                        {
                            // Calcula las horas trabajadas y las horas extras
                            var entrada = _context.Asistencias
                                .Where(a => a.UserId == user.Id && a.FechaRegistro.Date == horaActual.Date && a.EsEntrada)
                                .OrderByDescending(a => a.FechaRegistro)
                                .FirstOrDefault();

                            if (entrada != null)
                            {
                                TimeSpan tiempoTrabajado = horaActual - entrada.FechaRegistro;
                                double horasTrabajadas = tiempoTrabajado.TotalHours;
                                double horasExtras = 0;

                                if (horasTrabajadas > 8.5)
                                {
                                    horasExtras = horasTrabajadas - 8.5;
                                    horasTrabajadas = 8;
                                }

                                // Registra la hora de salida automáticamente
                                var asistencia = new Asistencia
                                {
                                    UserId = user.Id,
                                    FechaRegistro = horaActual, // Utiliza la hora actual
                                    EsEntrada = false,
                                    HorasTrabajadas = horasTrabajadas,
                                    HorasExtras = horasExtras
                                };

                                _context.Asistencias.Add(asistencia);
                                _context.SaveChanges();
                                TempData["MensajeExito"] = "Salida registrada con éxito.";
                            }
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("UserId", "Usuario no válido");
                }
            }
            else
            {
                // Si la validación falla, puedes mostrar mensajes de error de validación
                TempData["MensajeError"] = "Por favor, corrige los errores en el formulario.";
            }

            return View("RegistrarHora", model);
        }

    }
}