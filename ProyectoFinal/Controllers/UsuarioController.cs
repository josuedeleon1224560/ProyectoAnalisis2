using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;
using ProyectoFinal.Repository;
using ProyectoFinal.ViewModels;
using System.Security.Claims;

namespace ProyectoFinal.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly DireccionRepository _direccionRepository;
        private readonly iPhotoService _photoService;
        private readonly AplicationDbContext _aplicationDbContext;
        private readonly DireccionRepository _direccionRepository1;
        private readonly PuestoRepository _puestoRepository;

        public UsuarioController(ILogger<UsuarioController> logger, IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager,
            iPhotoService photoService, DireccionRepository direccionRepository,
            AplicationDbContext aplicationDbContext, DireccionRepository direccionRepository1,
            PuestoRepository puestoRepository)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _userRepository = userRepository;
            _roleManager = roleManager;
            _userManager = userManager;
            _direccionRepository = direccionRepository;
            _photoService = photoService;
            _aplicationDbContext = aplicationDbContext;
            _direccionRepository1 = direccionRepository1;
            _puestoRepository = puestoRepository;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(userId))
            {
                var user = await _userManager.FindByIdAsync(userId);
                var direccion = _aplicationDbContext.Users
    .Include(u => u.Direcciones) // Incluye las direcciones
    .ThenInclude(d => d.MunicipioGt) // Incluye los municipios
    .ThenInclude(m => m.DepartamentoGt) // Incluye los departamentos
    .SingleOrDefault(u => u.Id == user.Id);

                var puesto = _aplicationDbContext.Users
                    .Include(u => u.IdPuesto)
                    .ThenInclude(d => d.Departamento)
                    .SingleOrDefault(i => i.Id == user.Id);

                int idMunicipio = (int)direccion.Direcciones.MunicipioGt.Id;
                int departamento = (int)direccion.Direcciones.MunicipioGt.DepartamentoGt.Id;
                //Si se produce un error en buscar el id del usuario, en terminos de que no exista como tal, lo devuelve a la vista de todos los usuarios.
                if (user == null) return RedirectToAction("Index", "User");

                // Realiza una consulta para obtener el municipio utilizando la carga ansiosa
                //var municipio = await _direccionRepository.MunicipioById(municipioId);
                //Realiza lo mismo que en la línea de código 69 sin embargo lo realiza con el rol del usuario en específico.
                var roles = await _userManager.GetRolesAsync(user);
                //Se crea la variable del modelo vista del detalle Usuario haciendo una creación del objeto del Modelo Vista del detalle usuario
                var userDetailViewModel = new UserDetailViewModel()
                {
                    //Se almacenan todos los datos de los detalles del usuario con sus respectivos campos
                    Id = user.Id,
                    CUI = user.CUI,
                    Nombres = user.Nombres,
                    Apellidos = user.Apellidos,
                    Telefono = user.Telefono,
                    Date = user.Date,
                    AntecedentesPenales = user.AntecedentesPenales,
                    AntecedentesPoliciacos = user.AntecedentesPoliciacos,
                    Fotografia = user.Fotografia,
                    Diplomas = user.Diplomas,
                    Titulos = user.Titulos,
                    Roles = roles.ToList(),
                    DireccionId = direccion.IdDireccion,
                    MunicipioId = idMunicipio,
                    DepartamentoId = departamento,
                    DireccionUsuario = direccion.Direcciones.Name,
                    MunicipioUsuario = direccion.Direcciones.MunicipioGt.Nombre,
                    DepartamentoUsuario = direccion.Direcciones.MunicipioGt.DepartamentoGt.Nombre,
                    Puesto = puesto.IdPuesto.Nombre,
                    IdDepartamentoPuesto = puesto.IdPuesto.Departamento.Id,
                    DepartamentoPuesto = puesto.IdPuesto.Departamento.Nombre,
                    //DireccionUsuario = direccion.Name,
                    //MunicipioUsuario = municipio.Name,                
                    //DireccionId = user.IdDireccion,
                    //Direccion_Name = direccion?.Name,
                    //MunicipioId = user.Direcciones.IdMunicipio,
                    //Municipio_Name = municipio?.Nombre,
                    //DepartamentoId = user.Direcciones.MunicipioGt.DepartamentoId,
                    //Departamento_Name = departamento?.Nombre
                };

                //Retorna la vista con los datos
                return View(userDetailViewModel);
            }
            return RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> Detail()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(userId))
            {
                var usuario = await _userManager.FindByIdAsync(userId);
                //Se realiza una creación de una variable de usuario asincronica del repositorio del usuario que hace un llamado al id especifico del id de un usuario seleccionado
                var user = await _userRepository.GetUserById(usuario.Id);
                var direccion = _aplicationDbContext.Users
        .Include(u => u.Direcciones) // Incluye las direcciones
        .ThenInclude(d => d.MunicipioGt) // Incluye los municipios
        .ThenInclude(m => m.DepartamentoGt) // Incluye los departamentos
        .SingleOrDefault(u => u.Id == usuario.Id);

                var puesto = _aplicationDbContext.Users
                    .Include(u => u.IdPuesto)
                    .ThenInclude(d => d.Departamento)
                    .SingleOrDefault(i => i.Id == usuario.Id);

                int idMunicipio = (int)direccion.Direcciones.MunicipioGt.Id;
                int departamento = (int)direccion.Direcciones.MunicipioGt.DepartamentoGt.Id;
                //Si se produce un error en buscar el id del usuario, en terminos de que no exista como tal, lo devuelve a la vista de todos los usuarios.
                if (user == null) return RedirectToAction("Index", "User");

                // Realiza una consulta para obtener el municipio utilizando la carga ansiosa
                //var municipio = await _direccionRepository.MunicipioById(municipioId);
                //Realiza lo mismo que en la línea de código 69 sin embargo lo realiza con el rol del usuario en específico.
                var roles = await _userManager.GetRolesAsync(user);
                //Se crea la variable del modelo vista del detalle Usuario haciendo una creación del objeto del Modelo Vista del detalle usuario
                var userDetailViewModel = new UserDetailViewModel()
                {
                    //Se almacenan todos los datos de los detalles del usuario con sus respectivos campos
                    Id = user.Id,
                    CUI = user.CUI,
                    Nombres = user.Nombres,
                    Apellidos = user.Apellidos,
                    Telefono = user.Telefono,
                    Date = user.Date,
                    AntecedentesPenales = user.AntecedentesPenales,
                    AntecedentesPoliciacos = user.AntecedentesPoliciacos,
                    Fotografia = user.Fotografia,
                    Diplomas = user.Diplomas,
                    Titulos = user.Titulos,
                    Roles = roles.ToList(),
                    DireccionId = direccion.IdDireccion,
                    MunicipioId = idMunicipio,
                    DepartamentoId = departamento,
                    DireccionUsuario = direccion.Direcciones.Name,
                    MunicipioUsuario = direccion.Direcciones.MunicipioGt.Nombre,
                    DepartamentoUsuario = direccion.Direcciones.MunicipioGt.DepartamentoGt.Nombre,
                    Puesto = puesto.IdPuesto.Nombre,
                    IdDepartamentoPuesto = puesto.IdPuesto.Departamento.Id,
                    DepartamentoPuesto = puesto.IdPuesto.Departamento.Nombre,
                    //DireccionUsuario = direccion.Name,
                    //MunicipioUsuario = municipio.Name,                
                    //DireccionId = user.IdDireccion,
                    //Direccion_Name = direccion?.Name,
                    //MunicipioId = user.Direcciones.IdMunicipio,
                    //Municipio_Name = municipio?.Nombre,
                    //DepartamentoId = user.Direcciones.MunicipioGt.DepartamentoId,
                    //Departamento_Name = departamento?.Nombre
                };

                //Retorna la vista con los datos
                return View(userDetailViewModel);
            }
            return RedirectToAction("Login", "Account");
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(CreateMessageViewModel createMessageViewModel)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(userId))
            {
                if (!ModelState.IsValid) return View(createMessageViewModel);

                var usuario = await _userManager.GetUserAsync(User);

                var nuevoMensaje = new Mensaje
                {
                    Contenido = createMessageViewModel.Contenido,
                    AppUserId = usuario.Id
                };

                _aplicationDbContext.Mensajes.Add(nuevoMensaje);
                _aplicationDbContext.SaveChanges();

                return RedirectToAction("Confirmacion");
            }
            return RedirectToAction("Login", "Account");
        }


        public async Task<IActionResult> Mensajeria()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!string.IsNullOrEmpty(userId))
            {
                var usuario = await _userManager.FindByIdAsync(userId);
                //Se realiza una creación de una variable de usuario asincronica del repositorio del usuario que hace un llamado al id especifico del id de un usuario seleccionado
                var user = await _userRepository.GetUserById(usuario.Id);                
                if (user != null)
                {
                    var mensajesUsuario = _aplicationDbContext.Mensajes.Where(m => m.AppUserId == user.Id).ToList();

                    var viewModel = new ViewMensajesViewModel
                    {
                        Usuario = usuario,
                        MensajesUsuario = mensajesUsuario
                    };
                    return View(viewModel);
                }
                return NotFound();
            }
            return RedirectToAction("Login", "Account");
        }
    }
}
