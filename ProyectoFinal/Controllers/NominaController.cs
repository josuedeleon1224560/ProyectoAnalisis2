using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Migrations;
using ProyectoFinal.Models;
using ProyectoFinal.Repository;
using ProyectoFinal.ViewModels;

namespace ProyectoFinal.Controllers
{
    [Authorize(Roles = "admin")]
    public class NominaController : Controller
    {
        private readonly AplicationDbContext _context;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;

        public NominaController(AplicationDbContext context,
            IUserRepository userRepository, UserManager<AppUser> userManager)
        {
            _context = context;
            _userRepository = userRepository;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult UsuariosBuscar()
        {
            return new JsonResult(_context.Users.ToList());
        }

        public JsonResult UsuariosBuscado(string Id)
        {
            return new JsonResult(_context.Users.Include(u => u.IdPuesto).
                ThenInclude(d => d.Departamento).
                SingleOrDefault(id => id.Id == Id));
        }
        public async Task<IActionResult> Seleccionar()
        {
            return View();
        }

        public async Task<IActionResult> Select()
        {

            var users = _context.Users.ToList();
            var viewModel = new CreateNominaViewModel
            {
                UsuariosDisponibles = users,
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Select1()
        {

            var users = _context.Users.ToList();
            var viewModel = new CreateNominaBono14ViewModel
            {
                UsuariosDisponibles = users,
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Select2()
        {

            var users = _context.Users.ToList();
            var viewModel = new CreateNominaAguinaldoViewModel
            {
                UsuariosDisponibles = users,
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Select3()
        {

            var users = _context.Users.ToList();
            var viewModel = new CreateNominaVacacionesViewModel
            {
                UsuariosDisponibles = users,
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Select4()
        {

            var users = _context.Users.ToList();
            var viewModel = new CreateNominaIndemnizacionViewModel
            {
                UsuariosDisponibles = users,
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create2(CreateNominaViewModel model)
        {
            var usuario = _context.Users.Include(p => p.IdPuesto)
                .ThenInclude(d => d.Departamento)
                .SingleOrDefault(u => u.CUI == model.CUI);
            var Fecha_Inicio = model.INICIO;
            var Fecha_Final = model.FINAL;



            var result = _context.Users
    .Where(u => u.CUI == model.CUI)
    .Select(user => new
    {
        User = user,
        TotalHorasTrabajadas = _context.Asistencias
            .Where(a => a.UserId == user.Id && a.FechaRegistro >= Fecha_Inicio && a.FechaRegistro <= Fecha_Final)
            .Sum(a => a.HorasTrabajadas ?? 0),
        TotalHorasExtras = _context.Asistencias
            .Where(a => a.UserId == user.Id && a.FechaRegistro >= Fecha_Inicio && a.FechaRegistro <= Fecha_Final)
            .Sum(a => a.HorasExtras ?? 0)
    })
    .FirstOrDefault();

            if (result != null)
            {
                double totalHorasTrabajadas = result.TotalHorasTrabajadas;
                double totalHorasExtras = result.TotalHorasExtras;


                DateTime fechaActual = DateTime.Now;
                int añoActual = fechaActual.Year;
                var Enero_Inicio = new DateTime(añoActual, 1, 1);
                var Enero_Final = new DateTime(añoActual, 1, DateTime.DaysInMonth(añoActual, 1));

                var Febrero_Inicio = new DateTime(añoActual, 2, 1);
                var Febrero_Final = new DateTime(añoActual, 2, DateTime.DaysInMonth(añoActual, 2));

                var Marzo_Inicio = new DateTime(añoActual, 3, 1);
                var Marzo_Final = new DateTime(añoActual, 3, DateTime.DaysInMonth(añoActual, 3));

                var Abril_Inicio = new DateTime(añoActual, 4, 1);
                var Abril_Final = new DateTime(añoActual, 4, DateTime.DaysInMonth(añoActual, 4));

                var Mayo_Inicio = new DateTime(añoActual, 5, 1);
                var Mayo_Final = new DateTime(añoActual, 5, DateTime.DaysInMonth(añoActual, 5));

                var Junio_Inicio = new DateTime(añoActual, 6, 1);
                var Junio_Final = new DateTime(añoActual, 6, DateTime.DaysInMonth(añoActual, 6));

                var Julio_Inicio = new DateTime(añoActual, 7, 1);
                var Julio_Final = new DateTime(añoActual, 7, DateTime.DaysInMonth(añoActual, 7));

                var Agosto_Inicio = new DateTime(añoActual, 8, 1);
                var Agosto_Final = new DateTime(añoActual, 8, DateTime.DaysInMonth(añoActual, 8));

                var Septiembre_Inicio = new DateTime(añoActual, 9, 1);
                var Septiembre_Final = new DateTime(añoActual, 9, DateTime.DaysInMonth(añoActual, 9));

                var Octubre_Inicio = new DateTime(añoActual, 10, 1);
                var Octubre_Final = new DateTime(añoActual, 10, DateTime.DaysInMonth(añoActual, 10));

                var Noviembre_Inicio = new DateTime(añoActual, 11, 1);
                var Noviembre_Final = new DateTime(añoActual, 11, DateTime.DaysInMonth(añoActual, 11));

                var Diciembre_Inicio = new DateTime(añoActual, 12, 1);
                var Diciembre_Final = new DateTime(añoActual, 12, DateTime.DaysInMonth(añoActual, 12));

                if (usuario != null)
                {
                    var sueldoEnero = _context.Nomina
                    .Where(n => n.FechaNomina >= Enero_Inicio && n.FechaNomina <= Enero_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoFebrero = _context.Nomina
                    .Where(n => n.FechaNomina >= Febrero_Inicio && n.FechaNomina <= Febrero_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoMarzo = _context.Nomina
                    .Where(n => n.FechaNomina >= Marzo_Inicio && n.FechaNomina <= Marzo_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoAbril = _context.Nomina
                    .Where(n => n.FechaNomina >= Abril_Inicio && n.FechaNomina <= Abril_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoMayo = _context.Nomina
                    .Where(n => n.FechaNomina >= Mayo_Inicio && n.FechaNomina <= Mayo_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoJunio = _context.Nomina
                    .Where(n => n.FechaNomina >= Junio_Inicio && n.FechaNomina <= Junio_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoJulio = _context.Nomina
                    .Where(n => n.FechaNomina >= Julio_Inicio && n.FechaNomina <= Julio_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoAgosto = _context.Nomina
                    .Where(n => n.FechaNomina >= Agosto_Inicio && n.FechaNomina <= Agosto_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoSeptiembre = _context.Nomina
                    .Where(n => n.FechaNomina >= Septiembre_Inicio && n.FechaNomina <= Septiembre_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoOctubre = _context.Nomina
                    .Where(n => n.FechaNomina >= Octubre_Inicio && n.FechaNomina <= Octubre_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoNoviembre = _context.Nomina
                    .Where(n => n.FechaNomina >= Noviembre_Inicio && n.FechaNomina <= Noviembre_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoDiciembre = _context.Nomina
                    .Where(n => n.FechaNomina >= Diciembre_Inicio && n.FechaNomina <= Diciembre_Final && n.AppUserId == usuario.Id)
                    .ToList();



                    var viewModel = new CreateNominaViewModel
                    {
                        AppUserId = usuario.Id,
                        CUI = usuario.CUI,
                        Nombres = usuario.Nombres,
                        Apellidos = usuario.Apellidos,
                        Departamento = usuario.IdPuesto.Departamento.Nombre,
                        Puesto = usuario.IdPuesto.Nombre,
                        Salario = usuario.IdPuesto.Salario,
                        HorasExtras = (float)totalHorasExtras,
                        HorasLaboradas = (float)totalHorasTrabajadas,
                        INICIO = Fecha_Inicio,
                        FINAL = Fecha_Final,
                        SueldoEnero = sueldoEnero.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoFebrero = sueldoFebrero.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoMarzo = sueldoMarzo.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoAbril = sueldoAbril.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoJunio = sueldoJunio.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoMayo = sueldoMayo.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoJulio = sueldoJulio.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoAgosto = sueldoAgosto.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoSeptiembre = sueldoSeptiembre.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoOctubre = sueldoOctubre.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoNoviembre = sueldoNoviembre.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoDiciembre = sueldoDiciembre.Select(n => n.Salario)
                        .FirstOrDefault(),

                        ComisionesEnero = sueldoEnero.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesFebrero = sueldoFebrero.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesAbril = sueldoAbril.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesMayo = sueldoMayo.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesMarzo = sueldoMarzo.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesJunio = sueldoJunio.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesJulio = sueldoJulio.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesAgosto = sueldoAgosto.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesSeptiembre = sueldoSeptiembre.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesOctubre = sueldoOctubre.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault() ?? 0,
                        ComisionesNoviembre = sueldoNoviembre.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesDiciembre = sueldoDiciembre.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),

                        HoraEnero = sueldoEnero.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraFebrero = sueldoFebrero.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraAbril = sueldoAbril.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraMarzo = sueldoMarzo.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraMayo = sueldoMayo.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraJunio = sueldoJunio.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraJulio = sueldoJulio.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraAgosto = sueldoAgosto.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraSeptiembre = sueldoSeptiembre.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraOctubre = sueldoOctubre.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraNoviembre = sueldoNoviembre.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraDiciembre = sueldoDiciembre.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                    };
                    return View(viewModel);
                }
                return NotFound();
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Create3(CreateNominaBono14ViewModel model)
        {
            var usuario = _context.Users.Include(p => p.IdPuesto)
                .ThenInclude(d => d.Departamento)
                .SingleOrDefault(u => u.CUI == model.CUI);
            var Fecha_Inicio = model.INICIO;
            var Fecha_Final = model.FINAL;



            var result = _context.Users
    .Where(u => u.CUI == model.CUI)
    .Select(user => new
    {
        User = user,
        TotalHorasTrabajadas = _context.Asistencias
            .Where(a => a.UserId == user.Id && a.FechaRegistro >= Fecha_Inicio && a.FechaRegistro <= Fecha_Final)
            .Sum(a => a.HorasTrabajadas ?? 0),
        TotalHorasExtras = _context.Asistencias
            .Where(a => a.UserId == user.Id && a.FechaRegistro >= Fecha_Inicio && a.FechaRegistro <= Fecha_Final)
            .Sum(a => a.HorasExtras ?? 0)
    })
    .FirstOrDefault();

            if (result != null)
            {
                double totalHorasTrabajadas = result.TotalHorasTrabajadas;
                double totalHorasExtras = result.TotalHorasExtras;


                DateTime fechaActual = DateTime.Now;
                int añoActual = fechaActual.Year;
                var Enero_Inicio = new DateTime(añoActual, 1, 1);
                var Enero_Final = new DateTime(añoActual, 1, DateTime.DaysInMonth(añoActual, 1));

                var Febrero_Inicio = new DateTime(añoActual, 2, 1);
                var Febrero_Final = new DateTime(añoActual, 2, DateTime.DaysInMonth(añoActual, 2));

                var Marzo_Inicio = new DateTime(añoActual, 3, 1);
                var Marzo_Final = new DateTime(añoActual, 3, DateTime.DaysInMonth(añoActual, 3));

                var Abril_Inicio = new DateTime(añoActual, 4, 1);
                var Abril_Final = new DateTime(añoActual, 4, DateTime.DaysInMonth(añoActual, 4));

                var Mayo_Inicio = new DateTime(añoActual, 5, 1);
                var Mayo_Final = new DateTime(añoActual, 5, DateTime.DaysInMonth(añoActual, 5));

                var Junio_Inicio = new DateTime(añoActual, 6, 1);
                var Junio_Final = new DateTime(añoActual, 6, DateTime.DaysInMonth(añoActual, 6));

                var Julio_Inicio = new DateTime(añoActual, 7, 1);
                var Julio_Final = new DateTime(añoActual, 7, DateTime.DaysInMonth(añoActual, 7));

                var Agosto_Inicio = new DateTime(añoActual, 8, 1);
                var Agosto_Final = new DateTime(añoActual, 8, DateTime.DaysInMonth(añoActual, 8));

                var Septiembre_Inicio = new DateTime(añoActual, 9, 1);
                var Septiembre_Final = new DateTime(añoActual, 9, DateTime.DaysInMonth(añoActual, 9));

                var Octubre_Inicio = new DateTime(añoActual, 10, 1);
                var Octubre_Final = new DateTime(añoActual, 10, DateTime.DaysInMonth(añoActual, 10));

                var Noviembre_Inicio = new DateTime(añoActual, 11, 1);
                var Noviembre_Final = new DateTime(añoActual, 11, DateTime.DaysInMonth(añoActual, 11));

                var Diciembre_Inicio = new DateTime(añoActual, 12, 1);
                var Diciembre_Final = new DateTime(añoActual, 12, DateTime.DaysInMonth(añoActual, 12));

                if (usuario != null)
                {
                    var sueldoEnero = _context.Nomina
                    .Where(n => n.FechaNomina >= Enero_Inicio && n.FechaNomina <= Enero_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoFebrero = _context.Nomina
                    .Where(n => n.FechaNomina >= Febrero_Inicio && n.FechaNomina <= Febrero_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoMarzo = _context.Nomina
                    .Where(n => n.FechaNomina >= Marzo_Inicio && n.FechaNomina <= Marzo_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoAbril = _context.Nomina
                    .Where(n => n.FechaNomina >= Abril_Inicio && n.FechaNomina <= Abril_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoMayo = _context.Nomina
                    .Where(n => n.FechaNomina >= Mayo_Inicio && n.FechaNomina <= Mayo_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoJunio = _context.Nomina
                    .Where(n => n.FechaNomina >= Junio_Inicio && n.FechaNomina <= Junio_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoJulio = _context.Nomina
                    .Where(n => n.FechaNomina >= Julio_Inicio && n.FechaNomina <= Julio_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoAgosto = _context.Nomina
                    .Where(n => n.FechaNomina >= Agosto_Inicio && n.FechaNomina <= Agosto_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoSeptiembre = _context.Nomina
                    .Where(n => n.FechaNomina >= Septiembre_Inicio && n.FechaNomina <= Septiembre_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoOctubre = _context.Nomina
                    .Where(n => n.FechaNomina >= Octubre_Inicio && n.FechaNomina <= Octubre_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoNoviembre = _context.Nomina
                    .Where(n => n.FechaNomina >= Noviembre_Inicio && n.FechaNomina <= Noviembre_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoDiciembre = _context.Nomina
                    .Where(n => n.FechaNomina >= Diciembre_Inicio && n.FechaNomina <= Diciembre_Final && n.AppUserId == usuario.Id)
                    .ToList();



                    var viewModel = new CreateNominaBono14ViewModel
                    {
                        CUI = usuario.CUI,
                        Nombres = usuario.Nombres,
                        INICIO = Fecha_Inicio,
                        FINAL = Fecha_Final,
                        SueldoEnero = sueldoEnero.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoFebrero = sueldoFebrero.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoMarzo = sueldoMarzo.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoAbril = sueldoAbril.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoJunio = sueldoJunio.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoMayo = sueldoMayo.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoJulio = sueldoJulio.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoAgosto = sueldoAgosto.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoSeptiembre = sueldoSeptiembre.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoOctubre = sueldoOctubre.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoNoviembre = sueldoNoviembre.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoDiciembre = sueldoDiciembre.Select(n => n.Salario)
                        .FirstOrDefault(),

                        ComisionesEnero = sueldoEnero.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesFebrero = sueldoFebrero.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesAbril = sueldoAbril.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesMayo = sueldoMayo.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesMarzo = sueldoMarzo.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesJunio = sueldoJunio.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesJulio = sueldoJulio.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesAgosto = sueldoAgosto.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesSeptiembre = sueldoSeptiembre.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesOctubre = sueldoOctubre.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault() ?? 0,
                        ComisionesNoviembre = sueldoNoviembre.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesDiciembre = sueldoDiciembre.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),

                        HoraEnero = sueldoEnero.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraFebrero = sueldoFebrero.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraAbril = sueldoAbril.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraMarzo = sueldoMarzo.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraMayo = sueldoMayo.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraJunio = sueldoJunio.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraJulio = sueldoJulio.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraAgosto = sueldoAgosto.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraSeptiembre = sueldoSeptiembre.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraOctubre = sueldoOctubre.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraNoviembre = sueldoNoviembre.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraDiciembre = sueldoDiciembre.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                    };
                    return View(viewModel);
                }
                return NotFound();
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Create4(CreateNominaAguinaldoViewModel model)
        {
            var usuario = _context.Users.Include(p => p.IdPuesto)
                .ThenInclude(d => d.Departamento)
                .SingleOrDefault(u => u.CUI == model.CUI);
            var Fecha_Inicio = model.INICIO;
            var Fecha_Final = model.FINAL;



            var result = _context.Users
    .Where(u => u.CUI == model.CUI)
    .Select(user => new
    {
        User = user,
        TotalHorasTrabajadas = _context.Asistencias
            .Where(a => a.UserId == user.Id && a.FechaRegistro >= Fecha_Inicio && a.FechaRegistro <= Fecha_Final)
            .Sum(a => a.HorasTrabajadas ?? 0),
        TotalHorasExtras = _context.Asistencias
            .Where(a => a.UserId == user.Id && a.FechaRegistro >= Fecha_Inicio && a.FechaRegistro <= Fecha_Final)
            .Sum(a => a.HorasExtras ?? 0)
    })
    .FirstOrDefault();

            if (result != null)
            {
                double totalHorasTrabajadas = result.TotalHorasTrabajadas;
                double totalHorasExtras = result.TotalHorasExtras;


                DateTime fechaActual = DateTime.Now;
                int añoActual = fechaActual.Year;
                var Enero_Inicio = new DateTime(añoActual, 1, 1);
                var Enero_Final = new DateTime(añoActual, 1, DateTime.DaysInMonth(añoActual, 1));

                var Febrero_Inicio = new DateTime(añoActual, 2, 1);
                var Febrero_Final = new DateTime(añoActual, 2, DateTime.DaysInMonth(añoActual, 2));

                var Marzo_Inicio = new DateTime(añoActual, 3, 1);
                var Marzo_Final = new DateTime(añoActual, 3, DateTime.DaysInMonth(añoActual, 3));

                var Abril_Inicio = new DateTime(añoActual, 4, 1);
                var Abril_Final = new DateTime(añoActual, 4, DateTime.DaysInMonth(añoActual, 4));

                var Mayo_Inicio = new DateTime(añoActual, 5, 1);
                var Mayo_Final = new DateTime(añoActual, 5, DateTime.DaysInMonth(añoActual, 5));

                var Junio_Inicio = new DateTime(añoActual, 6, 1);
                var Junio_Final = new DateTime(añoActual, 6, DateTime.DaysInMonth(añoActual, 6));

                var Julio_Inicio = new DateTime(añoActual, 7, 1);
                var Julio_Final = new DateTime(añoActual, 7, DateTime.DaysInMonth(añoActual, 7));

                var Agosto_Inicio = new DateTime(añoActual, 8, 1);
                var Agosto_Final = new DateTime(añoActual, 8, DateTime.DaysInMonth(añoActual, 8));

                var Septiembre_Inicio = new DateTime(añoActual, 9, 1);
                var Septiembre_Final = new DateTime(añoActual, 9, DateTime.DaysInMonth(añoActual, 9));

                var Octubre_Inicio = new DateTime(añoActual, 10, 1);
                var Octubre_Final = new DateTime(añoActual, 10, DateTime.DaysInMonth(añoActual, 10));

                var Noviembre_Inicio = new DateTime(añoActual, 11, 1);
                var Noviembre_Final = new DateTime(añoActual, 11, DateTime.DaysInMonth(añoActual, 11));

                var Diciembre_Inicio = new DateTime(añoActual, 12, 1);
                var Diciembre_Final = new DateTime(añoActual, 12, DateTime.DaysInMonth(añoActual, 12));

                if (usuario != null)
                {
                    var sueldoEnero = _context.Nomina
                    .Where(n => n.FechaNomina >= Enero_Inicio && n.FechaNomina <= Enero_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoFebrero = _context.Nomina
                    .Where(n => n.FechaNomina >= Febrero_Inicio && n.FechaNomina <= Febrero_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoMarzo = _context.Nomina
                    .Where(n => n.FechaNomina >= Marzo_Inicio && n.FechaNomina <= Marzo_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoAbril = _context.Nomina
                    .Where(n => n.FechaNomina >= Abril_Inicio && n.FechaNomina <= Abril_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoMayo = _context.Nomina
                    .Where(n => n.FechaNomina >= Mayo_Inicio && n.FechaNomina <= Mayo_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoJunio = _context.Nomina
                    .Where(n => n.FechaNomina >= Junio_Inicio && n.FechaNomina <= Junio_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoJulio = _context.Nomina
                    .Where(n => n.FechaNomina >= Julio_Inicio && n.FechaNomina <= Julio_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoAgosto = _context.Nomina
                    .Where(n => n.FechaNomina >= Agosto_Inicio && n.FechaNomina <= Agosto_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoSeptiembre = _context.Nomina
                    .Where(n => n.FechaNomina >= Septiembre_Inicio && n.FechaNomina <= Septiembre_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoOctubre = _context.Nomina
                    .Where(n => n.FechaNomina >= Octubre_Inicio && n.FechaNomina <= Octubre_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoNoviembre = _context.Nomina
                    .Where(n => n.FechaNomina >= Noviembre_Inicio && n.FechaNomina <= Noviembre_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoDiciembre = _context.Nomina
                    .Where(n => n.FechaNomina >= Diciembre_Inicio && n.FechaNomina <= Diciembre_Final && n.AppUserId == usuario.Id)
                    .ToList();



                    var viewModel = new CreateNominaAguinaldoViewModel
                    {
                        CUI = usuario.CUI,
                        Nombres = usuario.Nombres,
                        INICIO = Fecha_Inicio,
                        FINAL = Fecha_Final,
                        SueldoEnero = sueldoEnero.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoFebrero = sueldoFebrero.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoMarzo = sueldoMarzo.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoAbril = sueldoAbril.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoJunio = sueldoJunio.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoMayo = sueldoMayo.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoJulio = sueldoJulio.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoAgosto = sueldoAgosto.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoSeptiembre = sueldoSeptiembre.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoOctubre = sueldoOctubre.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoNoviembre = sueldoNoviembre.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoDiciembre = sueldoDiciembre.Select(n => n.Salario)
                        .FirstOrDefault(),

                        ComisionesEnero = sueldoEnero.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesFebrero = sueldoFebrero.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesAbril = sueldoAbril.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesMayo = sueldoMayo.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesMarzo = sueldoMarzo.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesJunio = sueldoJunio.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesJulio = sueldoJulio.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesAgosto = sueldoAgosto.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesSeptiembre = sueldoSeptiembre.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesOctubre = sueldoOctubre.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault() ?? 0,
                        ComisionesNoviembre = sueldoNoviembre.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesDiciembre = sueldoDiciembre.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),

                        HoraEnero = sueldoEnero.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraFebrero = sueldoFebrero.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraAbril = sueldoAbril.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraMarzo = sueldoMarzo.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraMayo = sueldoMayo.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraJunio = sueldoJunio.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraJulio = sueldoJulio.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraAgosto = sueldoAgosto.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraSeptiembre = sueldoSeptiembre.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraOctubre = sueldoOctubre.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraNoviembre = sueldoNoviembre.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraDiciembre = sueldoDiciembre.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                    };
                    return View(viewModel);
                }
                return NotFound();
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create5(CreateNominaVacacionesViewModel model)
        {
            var usuario = _context.Users.Include(p => p.IdPuesto)
                .ThenInclude(d => d.Departamento)
                .SingleOrDefault(u => u.CUI == model.CUI);
            var Fecha_Inicio = model.INICIO;
            var Fecha_Final = model.FINAL;



            var result = _context.Users
    .Where(u => u.CUI == model.CUI)
    .Select(user => new
    {
        User = user,
        TotalHorasTrabajadas = _context.Asistencias
            .Where(a => a.UserId == user.Id && a.FechaRegistro >= Fecha_Inicio && a.FechaRegistro <= Fecha_Final)
            .Sum(a => a.HorasTrabajadas ?? 0),
        TotalHorasExtras = _context.Asistencias
            .Where(a => a.UserId == user.Id && a.FechaRegistro >= Fecha_Inicio && a.FechaRegistro <= Fecha_Final)
            .Sum(a => a.HorasExtras ?? 0)
    })
    .FirstOrDefault();

            if (result != null)
            {
                double totalHorasTrabajadas = result.TotalHorasTrabajadas;
                double totalHorasExtras = result.TotalHorasExtras;


                DateTime fechaActual = DateTime.Now;
                int añoActual = fechaActual.Year;
                var Enero_Inicio = new DateTime(añoActual, 1, 1);
                var Enero_Final = new DateTime(añoActual, 1, DateTime.DaysInMonth(añoActual, 1));

                var Febrero_Inicio = new DateTime(añoActual, 2, 1);
                var Febrero_Final = new DateTime(añoActual, 2, DateTime.DaysInMonth(añoActual, 2));

                var Marzo_Inicio = new DateTime(añoActual, 3, 1);
                var Marzo_Final = new DateTime(añoActual, 3, DateTime.DaysInMonth(añoActual, 3));

                var Abril_Inicio = new DateTime(añoActual, 4, 1);
                var Abril_Final = new DateTime(añoActual, 4, DateTime.DaysInMonth(añoActual, 4));

                var Mayo_Inicio = new DateTime(añoActual, 5, 1);
                var Mayo_Final = new DateTime(añoActual, 5, DateTime.DaysInMonth(añoActual, 5));

                var Junio_Inicio = new DateTime(añoActual, 6, 1);
                var Junio_Final = new DateTime(añoActual, 6, DateTime.DaysInMonth(añoActual, 6));

                var Julio_Inicio = new DateTime(añoActual, 7, 1);
                var Julio_Final = new DateTime(añoActual, 7, DateTime.DaysInMonth(añoActual, 7));

                var Agosto_Inicio = new DateTime(añoActual, 8, 1);
                var Agosto_Final = new DateTime(añoActual, 8, DateTime.DaysInMonth(añoActual, 8));

                var Septiembre_Inicio = new DateTime(añoActual, 9, 1);
                var Septiembre_Final = new DateTime(añoActual, 9, DateTime.DaysInMonth(añoActual, 9));

                var Octubre_Inicio = new DateTime(añoActual, 10, 1);
                var Octubre_Final = new DateTime(añoActual, 10, DateTime.DaysInMonth(añoActual, 10));

                var Noviembre_Inicio = new DateTime(añoActual, 11, 1);
                var Noviembre_Final = new DateTime(añoActual, 11, DateTime.DaysInMonth(añoActual, 11));

                var Diciembre_Inicio = new DateTime(añoActual, 12, 1);
                var Diciembre_Final = new DateTime(añoActual, 12, DateTime.DaysInMonth(añoActual, 12));

                if (usuario != null)
                {
                    var sueldoEnero = _context.Nomina
                    .Where(n => n.FechaNomina >= Enero_Inicio && n.FechaNomina <= Enero_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoFebrero = _context.Nomina
                    .Where(n => n.FechaNomina >= Febrero_Inicio && n.FechaNomina <= Febrero_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoMarzo = _context.Nomina
                    .Where(n => n.FechaNomina >= Marzo_Inicio && n.FechaNomina <= Marzo_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoAbril = _context.Nomina
                    .Where(n => n.FechaNomina >= Abril_Inicio && n.FechaNomina <= Abril_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoMayo = _context.Nomina
                    .Where(n => n.FechaNomina >= Mayo_Inicio && n.FechaNomina <= Mayo_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoJunio = _context.Nomina
                    .Where(n => n.FechaNomina >= Junio_Inicio && n.FechaNomina <= Junio_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoJulio = _context.Nomina
                    .Where(n => n.FechaNomina >= Julio_Inicio && n.FechaNomina <= Julio_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoAgosto = _context.Nomina
                    .Where(n => n.FechaNomina >= Agosto_Inicio && n.FechaNomina <= Agosto_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoSeptiembre = _context.Nomina
                    .Where(n => n.FechaNomina >= Septiembre_Inicio && n.FechaNomina <= Septiembre_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoOctubre = _context.Nomina
                    .Where(n => n.FechaNomina >= Octubre_Inicio && n.FechaNomina <= Octubre_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoNoviembre = _context.Nomina
                    .Where(n => n.FechaNomina >= Noviembre_Inicio && n.FechaNomina <= Noviembre_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoDiciembre = _context.Nomina
                    .Where(n => n.FechaNomina >= Diciembre_Inicio && n.FechaNomina <= Diciembre_Final && n.AppUserId == usuario.Id)
                    .ToList();



                    var viewModel = new CreateNominaVacacionesViewModel
                    {
                        CUI = usuario.CUI,
                        Nombres = usuario.Nombres,
                        INICIO = Fecha_Inicio,
                        FINAL = Fecha_Final,
                        SueldoEnero = sueldoEnero.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoFebrero = sueldoFebrero.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoMarzo = sueldoMarzo.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoAbril = sueldoAbril.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoJunio = sueldoJunio.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoMayo = sueldoMayo.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoJulio = sueldoJulio.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoAgosto = sueldoAgosto.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoSeptiembre = sueldoSeptiembre.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoOctubre = sueldoOctubre.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoNoviembre = sueldoNoviembre.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoDiciembre = sueldoDiciembre.Select(n => n.Salario)
                        .FirstOrDefault(),

                        ComisionesEnero = sueldoEnero.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesFebrero = sueldoFebrero.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesAbril = sueldoAbril.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesMayo = sueldoMayo.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesMarzo = sueldoMarzo.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesJunio = sueldoJunio.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesJulio = sueldoJulio.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesAgosto = sueldoAgosto.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesSeptiembre = sueldoSeptiembre.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesOctubre = sueldoOctubre.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault() ?? 0,
                        ComisionesNoviembre = sueldoNoviembre.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesDiciembre = sueldoDiciembre.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),

                        HoraEnero = sueldoEnero.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraFebrero = sueldoFebrero.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraAbril = sueldoAbril.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraMarzo = sueldoMarzo.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraMayo = sueldoMayo.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraJunio = sueldoJunio.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraJulio = sueldoJulio.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraAgosto = sueldoAgosto.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraSeptiembre = sueldoSeptiembre.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraOctubre = sueldoOctubre.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraNoviembre = sueldoNoviembre.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraDiciembre = sueldoDiciembre.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                    };
                    return View(viewModel);
                }
                return NotFound();
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Create6(CreateNominaIndemnizacionViewModel model)
        {
            var usuario = _context.Users.Include(p => p.IdPuesto)
                .ThenInclude(d => d.Departamento)
                .SingleOrDefault(u => u.CUI == model.CUI);
            var Fecha_Inicio = model.INICIO;
            var Fecha_Final = model.FINAL;



            var result = _context.Users
    .Where(u => u.CUI == model.CUI)
    .Select(user => new
    {
        User = user,
        TotalHorasTrabajadas = _context.Asistencias
            .Where(a => a.UserId == user.Id && a.FechaRegistro >= Fecha_Inicio && a.FechaRegistro <= Fecha_Final)
            .Sum(a => a.HorasTrabajadas ?? 0),
        TotalHorasExtras = _context.Asistencias
            .Where(a => a.UserId == user.Id && a.FechaRegistro >= Fecha_Inicio && a.FechaRegistro <= Fecha_Final)
            .Sum(a => a.HorasExtras ?? 0)
    })
    .FirstOrDefault();

            if (result != null)
            {
                double totalHorasTrabajadas = result.TotalHorasTrabajadas;
                double totalHorasExtras = result.TotalHorasExtras;


                DateTime fechaActual = DateTime.Now;
                int añoActual = fechaActual.Year;
                var Enero_Inicio = new DateTime(añoActual, 1, 1);
                var Enero_Final = new DateTime(añoActual, 1, DateTime.DaysInMonth(añoActual, 1));

                var Febrero_Inicio = new DateTime(añoActual, 2, 1);
                var Febrero_Final = new DateTime(añoActual, 2, DateTime.DaysInMonth(añoActual, 2));

                var Marzo_Inicio = new DateTime(añoActual, 3, 1);
                var Marzo_Final = new DateTime(añoActual, 3, DateTime.DaysInMonth(añoActual, 3));

                var Abril_Inicio = new DateTime(añoActual, 4, 1);
                var Abril_Final = new DateTime(añoActual, 4, DateTime.DaysInMonth(añoActual, 4));

                var Mayo_Inicio = new DateTime(añoActual, 5, 1);
                var Mayo_Final = new DateTime(añoActual, 5, DateTime.DaysInMonth(añoActual, 5));

                var Junio_Inicio = new DateTime(añoActual, 6, 1);
                var Junio_Final = new DateTime(añoActual, 6, DateTime.DaysInMonth(añoActual, 6));

                var Julio_Inicio = new DateTime(añoActual, 7, 1);
                var Julio_Final = new DateTime(añoActual, 7, DateTime.DaysInMonth(añoActual, 7));

                var Agosto_Inicio = new DateTime(añoActual, 8, 1);
                var Agosto_Final = new DateTime(añoActual, 8, DateTime.DaysInMonth(añoActual, 8));

                var Septiembre_Inicio = new DateTime(añoActual, 9, 1);
                var Septiembre_Final = new DateTime(añoActual, 9, DateTime.DaysInMonth(añoActual, 9));

                var Octubre_Inicio = new DateTime(añoActual, 10, 1);
                var Octubre_Final = new DateTime(añoActual, 10, DateTime.DaysInMonth(añoActual, 10));

                var Noviembre_Inicio = new DateTime(añoActual, 11, 1);
                var Noviembre_Final = new DateTime(añoActual, 11, DateTime.DaysInMonth(añoActual, 11));

                var Diciembre_Inicio = new DateTime(añoActual, 12, 1);
                var Diciembre_Final = new DateTime(añoActual, 12, DateTime.DaysInMonth(añoActual, 12));

                if (usuario != null)
                {
                    var sueldoEnero = _context.Nomina
                    .Where(n => n.FechaNomina >= Enero_Inicio && n.FechaNomina <= Enero_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoFebrero = _context.Nomina
                    .Where(n => n.FechaNomina >= Febrero_Inicio && n.FechaNomina <= Febrero_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoMarzo = _context.Nomina
                    .Where(n => n.FechaNomina >= Marzo_Inicio && n.FechaNomina <= Marzo_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoAbril = _context.Nomina
                    .Where(n => n.FechaNomina >= Abril_Inicio && n.FechaNomina <= Abril_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoMayo = _context.Nomina
                    .Where(n => n.FechaNomina >= Mayo_Inicio && n.FechaNomina <= Mayo_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoJunio = _context.Nomina
                    .Where(n => n.FechaNomina >= Junio_Inicio && n.FechaNomina <= Junio_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoJulio = _context.Nomina
                    .Where(n => n.FechaNomina >= Julio_Inicio && n.FechaNomina <= Julio_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoAgosto = _context.Nomina
                    .Where(n => n.FechaNomina >= Agosto_Inicio && n.FechaNomina <= Agosto_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoSeptiembre = _context.Nomina
                    .Where(n => n.FechaNomina >= Septiembre_Inicio && n.FechaNomina <= Septiembre_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoOctubre = _context.Nomina
                    .Where(n => n.FechaNomina >= Octubre_Inicio && n.FechaNomina <= Octubre_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoNoviembre = _context.Nomina
                    .Where(n => n.FechaNomina >= Noviembre_Inicio && n.FechaNomina <= Noviembre_Final && n.AppUserId == usuario.Id)
                    .ToList();

                    var sueldoDiciembre = _context.Nomina
                    .Where(n => n.FechaNomina >= Diciembre_Inicio && n.FechaNomina <= Diciembre_Final && n.AppUserId == usuario.Id)
                    .ToList();



                    var viewModel = new CreateNominaIndemnizacionViewModel
                    {
                        CUI = usuario.CUI,
                        Nombres = usuario.Nombres,
                        INICIO = Fecha_Inicio,
                        FINAL = Fecha_Final,
                        SueldoEnero = sueldoEnero.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoFebrero = sueldoFebrero.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoMarzo = sueldoMarzo.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoAbril = sueldoAbril.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoJunio = sueldoJunio.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoMayo = sueldoMayo.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoJulio = sueldoJulio.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoAgosto = sueldoAgosto.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoSeptiembre = sueldoSeptiembre.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoOctubre = sueldoOctubre.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoNoviembre = sueldoNoviembre.Select(n => n.Salario)
                        .FirstOrDefault(),
                        SueldoDiciembre = sueldoDiciembre.Select(n => n.Salario)
                        .FirstOrDefault(),

                        ComisionesEnero = sueldoEnero.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesFebrero = sueldoFebrero.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesAbril = sueldoAbril.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesMayo = sueldoMayo.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesMarzo = sueldoMarzo.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesJunio = sueldoJunio.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesJulio = sueldoJulio.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesAgosto = sueldoAgosto.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesSeptiembre = sueldoSeptiembre.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesOctubre = sueldoOctubre.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault() ?? 0,
                        ComisionesNoviembre = sueldoNoviembre.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        ComisionesDiciembre = sueldoDiciembre.Select(n => n.Comisiones)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),

                        HoraEnero = sueldoEnero.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraFebrero = sueldoFebrero.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraAbril = sueldoAbril.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraMarzo = sueldoMarzo.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraMayo = sueldoMayo.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraJunio = sueldoJunio.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraJulio = sueldoJulio.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraAgosto = sueldoAgosto.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraSeptiembre = sueldoSeptiembre.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraOctubre = sueldoOctubre.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraNoviembre = sueldoNoviembre.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                        HoraDiciembre = sueldoDiciembre.Select(n => n.HorasExtras)
                         .DefaultIfEmpty(0)
                        .FirstOrDefault(),
                    };
                    return View(viewModel);
                }
                return NotFound();
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Nomina(CreateNominaViewModel nomina)
        {            
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Error");
                TempData["ErrorMessage"] = "Hubo un error al procesar la solicitud.";
                return RedirectToAction("Select", "Nomina");
            }
            
            var nominas = new Nomina
            {
                Nombres = nomina.Nombres,
                AppUserId = nomina.AppUserId,
                Apellido = nomina.Apellidos,
                CUI = nomina.CUI,
                PuestoS = nomina.Puesto,
                Departamento = nomina.Departamento,
                PrecioHoraExtra = nomina.PrecioHoraExtra,
                HorasLaboradas = nomina.HorasLaboradas,
                HorasExtras = nomina.HorasExtras,
                Ventas = nomina.Ventas,
                Produccion = nomina.Produccion,
                Bonificaciones = nomina.Bonificaciones,
                TotalDevengado = nomina.TotalDevengado,
                IgssUsuario = nomina.IgssUsuario,
                ISR = nomina.ISR,
                Anticipo = nomina.Anticipo,
                Prestamo = nomina.Prestamo,
                TotalDescuentos = nomina.TotalDescuentos,
                TotalLiquido = nomina.TotalLiquido,
                Salario = nomina.Salario,
                FechaNomina = DateTime.Now,
                CuotaPAtronal = new CuotaPatronal
                {
                    CUI = nomina.CUI,
                    Sueldo = nomina.CuotaPatronal.Sueldo,
                    IGSS = nomina.CuotaPatronal.IGSS,
                    IRTRA = nomina.CuotaPatronal.IRTRA,
                    UsuarioId = nomina.AppUserId,
                    Fecha = DateTime.Now
                }

            };

            _context.Nomina.Add(nominas);
           await _context.SaveChangesAsync();

            return RedirectToAction("Confirmacion", "Nomina");

        }

        [HttpPost]
        public async Task<IActionResult> Bono14Async(CreateNominaBono14ViewModel nomina)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Error");
                TempData["ErrorMessage"] = "Hubo un error al procesar la solicitud.";
                return RedirectToAction("Select1", "Nomina");
            }
            var PagarBono14 = new Bono14
            {
                TotalSalarios = nomina.TotalSalarios,
                PromedioSalario = nomina.PromedioSalario,
                TotalComisiones = nomina.TotalComisiones,
                PromedioComisiones = nomina.PromedioComisiones,
                SalarioAdicionalComisiones = nomina.SalarioMasComisiones,
                DiasLaborados = nomina.DiasLaborados,
                Bono14Total = nomina.Bono14Total,
                CUI = nomina.CUI,
                Fecha = DateTime.Now
            };

            _context.Bono14.Add(PagarBono14);
            await _context.SaveChangesAsync();
            return RedirectToAction("Confirmacion", "Nomina");
        }

        [HttpPost]
        public async Task<IActionResult> Indemnizacion (CreateNominaIndemnizacionViewModel nomina)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Error");
                TempData["ErrorMessage"] = "Hubo un error al procesar la solicitud.";
                return RedirectToAction("Select4", "Nomina");
            }
            var despido = new Indemnizacion
            {
                PromedioSalarios = nomina.PromedioSalario,
                Comisiones = nomina.Comisiones,
                HorasExtras = nomina.HorasExtras,
                SubTotal = nomina.SubTotal,
                Promedio = nomina.Promedio,
                Total = nomina.SubTotal,
                CUI = nomina.CUI,
                Fecha = DateTime.Now
            };
            _context.Indemnizacion.Add(despido);
            await _context.SaveChangesAsync();
            return RedirectToAction("Confirmacion", "Nomina");


        }

        [HttpPost]
        public async Task<IActionResult> Aguinaldo(CreateNominaAguinaldoViewModel aguinaldo)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Error");
                TempData["ErrorMessage"] = "Hubo un error al procesar la solicitud.";
                return RedirectToAction("Select2", "Nomina");
            }
            var AguinaldUsuario = new Aguinaldo
            {
                DiasLaborados = aguinaldo.DiasLaborados,
                PromedioSalario = aguinaldo.PromedioSalario,
                TotalAguinaldo = aguinaldo.TotalAguinaldo,
                CUI = aguinaldo.CUI,
                Fecha = DateTime.Now
            };
            _context.Aguinaldo.Add(AguinaldUsuario);
            await _context.SaveChangesAsync();
            return RedirectToAction("Confirmacion", "Nomina");
        }


        [HttpPost]
        public async Task<IActionResult> Vacaciones(CreateNominaVacacionesViewModel vacaciones)
        {
            if (!ModelState.IsValid)
            {                
                ModelState.AddModelError("", "Error");
                TempData["ErrorMessage"] = "Hubo un error al procesar la solicitud.";
                return RedirectToAction("Select3", "Nomina");
            }

            var pagarVaca = new Vacaciones
            {
                Sueldos = vacaciones.Sueldos,
                Comisiones = vacaciones.Comisiones,
                HorasExtras = vacaciones.HorasExtras,
                Resultado = vacaciones.Resultado,
                CUI = vacaciones.CUI,
                Fecha = DateTime.Now
            };

            _context.Vacaciones.Add(pagarVaca);
            await _context.SaveChangesAsync();

            return RedirectToAction("Confirmacion", "Nomina");
        } 

        public async Task<IActionResult> Usuarios()
        {
            var users = await _userRepository.GetAllUsers();


            //Se obtiene una lista del modelo vista del usuario para utilizarse y se guarda en un result
            List<UserViewModel> result = new List<UserViewModel>();
            //Se hace un foreach para recorrer todos los datos del usuario 
            foreach (var user in users)
            {
                var puesto = _context.Users
    .Include(u => u.IdPuesto) // Incluye el puesto del usuario
    .ThenInclude(p => p.Departamento) // Incluye el departamento del puesto
    .SingleOrDefault(u => u.Id == user.Id);
                //Se crea la variable del modelo vista del Usuario haciendo una creación del objeto del Modelo Vista del usuario

                var userViewModel = new UserViewModel()
                {
                    //Se almacenan todos los datos de los usuarios con sus respectivos campos
                    Id = user.Id,
                    CUI = user.CUI,
                    Nombres = user.Nombres,
                    Apellidos = user.Apellidos,
                    Telefono = user.Telefono,
                    UrlAntePenales = user.AntecedentesPenales,
                    UrlAntePoli = user.AntecedentesPoliciacos,
                    UrlFotografia = user.Fotografia,
                    UrlDiplomas = user.Diplomas,
                    Date = user.Date,
                    NombrePuesto = puesto.IdPuesto.Nombre,
                    NombreDepartamentoPuesto = puesto.IdPuesto.Departamento.Nombre
                    //IdDireccion = user.IdDireccion,
                };
                // Obtener los roles del usuario
                var roles = await _userManager.GetRolesAsync(user);


                //Se agrega el resultado de la lista a la variable del modelo, esto con fines de guardar los Roles
                result.Add(userViewModel);
            }
            //Retornar el resultado en la vista de Usuarios
            return View(result);
        }

        public async Task<IActionResult> VerNominas(string id)
        {
            var user = await _userRepository.GetUserById(id);
            var cuotaPatronal = _context.Nomina
                .Include(u => u.CuotaPAtronal)
                .Where(i=>i.CUI == user.CUI)
                .ToList();
            if (cuotaPatronal.Count == 0)
            {
                return RedirectToAction("Usuarios", "Nomina");
            }
            var DatosNominaViewModelList = cuotaPatronal
                .Select(cuotaPatronal => new DatosNominasVerViewModel()
                {
                    CUI = cuotaPatronal.CUI,
                    Nombres = cuotaPatronal.Nombres,
                    HorasLaboradas = cuotaPatronal.HorasLaboradas,
                    Salario = cuotaPatronal.Salario,
                    HorasExtras = cuotaPatronal.HorasExtras,
                    Fecha = cuotaPatronal.FechaNomina,
                    ISR = cuotaPatronal.ISR,
                    Anticipo = cuotaPatronal.Anticipo,
                    Prestamo = cuotaPatronal.Prestamo,
                    TotalDescuentos = cuotaPatronal.TotalDescuentos,
                    TotalLiquido = cuotaPatronal.TotalLiquido,
                    SueldoPatronal = cuotaPatronal.CuotaPAtronal.Sueldo,
                    IGSSPatronal = cuotaPatronal.CuotaPAtronal.IGSS,
                    IRTRAPatronal = cuotaPatronal.CuotaPAtronal.IRTRA
                }).ToList();
            return View(DatosNominaViewModelList);
        }
        public async Task<IActionResult> VerBono14(string id)
        {
            var user = await _userRepository.GetUserById(id);
            var bono14 = _context.Bono14
                .Where(i => i.CUI == user.CUI)
                .ToList();
            if (bono14.Count == 0)
            {
                return RedirectToAction("Usuarios", "Nomina");
            }
            var DatosNominaViewModelList = bono14
                .Select(bono14 => new VerBono14ViewModel()
                {
                    CUI = bono14.CUI,
                    TotalComisiones = bono14.TotalComisiones,
                    TotalSalarios = bono14.TotalSalarios,
                    Bono14Total = bono14.Bono14Total,
                    DiasLaborados = bono14.DiasLaborados,
                    PromedioComisiones = bono14.PromedioComisiones,
                    PromedioSalario = bono14.PromedioSalario,
                    SalarioAdicionalComisiones = bono14.SalarioAdicionalComisiones,
                    Fecha = bono14.Fecha,
                    Id = bono14.Id
                }).ToList();
            return View(DatosNominaViewModelList);
        }
        public async Task<IActionResult> VerVacaciones(string id)
        {
            var user = await _userRepository.GetUserById(id);
            var vacaciones = _context.Vacaciones
                .Where(i => i.CUI == user.CUI)
                .ToList();
            if (vacaciones.Count == 0)
            {
                return RedirectToAction("Usuarios", "Nomina");
            }
            var DatosNominaViewModelList = vacaciones
                .Select(vacaciones => new VerVacacionesViewModel()
                {
                    CUI = vacaciones.CUI,
                    Id= vacaciones.Id,
                    Sueldos = vacaciones.Sueldos,
                    Comisiones = vacaciones.Comisiones,
                    HorasExtras = vacaciones.HorasExtras,
                    Resultado = vacaciones.Resultado,
                    Fecha = vacaciones.Fecha
                }).ToList();
            return View(DatosNominaViewModelList);
        }
        public async Task<IActionResult> VerAguinaldo(string id)
        {
            var user = await _userRepository.GetUserById(id);
            var aguinaldo = _context.Aguinaldo
                .Where(i => i.CUI == user.CUI)
                .ToList();
            if (aguinaldo.Count == 0)
            {
                return RedirectToAction("Usuarios", "Nomina");
            }
            var DatosNominaViewModelList = aguinaldo
                .Select(aguinaldo => new VerAguinaldoViewModel()
                {
                CUI = aguinaldo.CUI,
                Id = aguinaldo.Id,
                DiasLaborados = aguinaldo.DiasLaborados,
                PromedioSalario = aguinaldo.PromedioSalario,
                TotalAguinaldo = aguinaldo.PromedioSalario,
                Fecha = aguinaldo.Fecha                
                }).ToList();
            return View(DatosNominaViewModelList);
        }
        public async Task<IActionResult> VerIndemnizacion(string id)
        {
            var user = await _userRepository.GetUserById(id);
            var inde = _context.Indemnizacion
                .Where(i => i.CUI == user.CUI)
                .ToList();
            if (inde.Count == 0)
            {
                return RedirectToAction("Usuarios", "Nomina");
            }
            var DatosNominaViewModelList = inde
                .Select(inde => new VerIndemnizacionViewModel()
                {
                    Id = inde.Id,
                    Promedio = inde.Promedio,
                    PromedioSalarios = inde.PromedioSalarios,
                    Comisiones = inde.Comisiones,
                    HorasExtras = inde.HorasExtras,
                    SubTotal = inde.SubTotal,
                    Total = inde.Total,
                    CUI = inde.CUI,
                    Fecha = inde.Fecha
                }).ToList();
            return View(DatosNominaViewModelList);
        }

        public IActionResult Confirmacion()
        {
            return View();
        }
    }
}
