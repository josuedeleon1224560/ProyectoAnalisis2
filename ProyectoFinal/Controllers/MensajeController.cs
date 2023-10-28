using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Data;
using ProyectoFinal.Models;
using ProyectoFinal.Repository;
using ProyectoFinal.ViewModels;

namespace ProyectoFinal.Controllers
{
    [Authorize]
    public class MensajeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AplicationDbContext _context;
        private readonly MensajesRepository _mensajesRepository;

        public MensajeController(UserManager<AppUser> userManager,
            AplicationDbContext context, MensajesRepository mensajesRepository) 
        {
            _userManager = userManager;
            _context = context;
            _mensajesRepository = mensajesRepository;
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(CreateMessageViewModel createMessageViewModel)
        {
            if (!ModelState.IsValid) return View(createMessageViewModel);

            var usuario = await _userManager.GetUserAsync(User);

            var nuevoMensaje = new Mensaje
            {
                Contenido = createMessageViewModel.Contenido,
                AppUserId = usuario.Id
            };

            _context.Mensajes.Add(nuevoMensaje);
            _context.SaveChanges();

            return RedirectToAction("Confirmacion");
        }
        [Authorize(Roles = "admin")]
        public IActionResult Confirmacion()
        {
            return View();
        }

        [Authorize(Roles ="admin")]
        public async Task<IActionResult> Index()
        {
            var mensajesPendientes = await _mensajesRepository.GetMensajes();
            return View(mensajesPendientes);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AprobarMensaje(int id)
        {
            var mensaje = await _mensajesRepository.Buscar(id);
            if(mensaje!=null)
            {
                mensaje.Estado = EstadoMensaje.Aprobado;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "admin")]
        public IActionResult RechazarMensaje(int id)
        {
            var mensaje = _context.Mensajes.Find(id);
            if(mensaje!=null)
            {
                mensaje.Estado = EstadoMensaje.Rechazado;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "admin")]
        public IActionResult SeleccionarUsuario()
        {
            var usuariosDisponibles = _context.Users.ToList();
            var viewModel = new SeleccionarUsuarioViewModel
            {
                UsuariosDisponibles = usuariosDisponibles,
                CUI = null
            };
            return View(viewModel);
        }
        [Authorize(Roles ="admin")]
        public IActionResult VerMensajesUsuario(string CUI)
        {
            var usuario = _context.Users.SingleOrDefault(u=>u.CUI == CUI);
            if (usuario != null)
            {
                var mensajesUsuario = _context.Mensajes.Where(m => m.AppUserId == usuario.Id).ToList();

                var viewModel = new ViewMensajesViewModel
                {
                    Usuario = usuario,
                    MensajesUsuario = mensajesUsuario
                };
                return View(viewModel);
            }
            return NotFound();
        }

    }
}
