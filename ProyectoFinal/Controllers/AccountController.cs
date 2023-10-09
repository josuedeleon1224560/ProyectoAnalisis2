using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;      
using ProyectoFinal.Data;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Migrations;
using ProyectoFinal.Models;
using ProyectoFinal.Repository;
using ProyectoFinal.ViewModels;
using SQLitePCL;

namespace ProyectoFinal.Controllers
{
    public class AccountController : Controller
    {
        private readonly AplicationDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly iPhotoService _iPhotoService;
        private readonly DireccionRepository _direccionRepository;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
        AplicationDbContext context, RoleManager<IdentityRole> roleManager, iPhotoService iPhotoService,
        DireccionRepository direccionRepository)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _iPhotoService = iPhotoService;
            _direccionRepository = direccionRepository;
        }
        public IActionResult Login()
        {
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var response = new LoginViewModel();
                return View(response);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if(user!=null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                TempData["Error"] = "Credenciales incorrectas. Por favor intente denuevo.";
                return View(loginViewModel);
            }
            TempData["Error"] = "Credenciales incorrectas. Por favor intente denuevo.";
            return View(loginViewModel);
        }

        [Authorize(Roles = "admin")]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();
            var roles = _roleManager.Roles.ToList();
            var municipios = _direccionRepository.ListaMunicipios();

            model.Roles = roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Name
            }).ToList();

            //model.Departamento = departamentos.Select(r => new SelectListItem
            //{
            //    Text = r.Nombre,
            //    Value = r.Id.ToString()
            //}).ToList();
            //model.Municipio = municipios.Select(r => new SelectListItem
            //{
            //    Text = r.Nombre,
            //    Value = r.Id.ToString()
            //}).ToList();


            return View(model);
        }

        public JsonResult Departamento()
        {
            return new JsonResult(_direccionRepository.GetAllDepartamento());
        }

        public JsonResult Municipio(int id)
        {
            return new JsonResult(_direccionRepository.GetAllMunicipio(id));
        }
        public JsonResult Direccion(int id)
        {
            return new JsonResult(_direccionRepository.GetAllDirecciones(id));
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
         {
            if (!ModelState.IsValid)
            {
                var roles = _roleManager.Roles.ToList();
                registerViewModel.Roles = roles.Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                }).ToList();

                //registerViewModel.Direccioness = new DireccionGt();
                //List<SelectListItem> departamento = _context.Tabla_Departamentos
                //    .OrderBy(n => n.Nombre)
                //    .Select(n =>
                //    new SelectListItem
                //    {
                //        Value = n.Id.ToString(),
                //        Text = n.Nombre
                //    }).ToList();

                //registerViewModel.Departamento = departamento;
                //registerViewModel.Municipio = new List<SelectListItem>();
                var user = await _userManager.FindByEmailAsync(registerViewModel.EmailAddress);
                if (user != null)
                {
                    TempData["Error"] = "This email address is already in use";
                    return View(registerViewModel);
                }
                var newUser = new AppUser()
                {
                    Email = registerViewModel.EmailAddress,
                    UserName = registerViewModel.EmailAddress,
                    Nombres = registerViewModel.Nombres,
                    Apellidos = registerViewModel.Apellidos,
                    CUI = registerViewModel.CUI,
                    Telefono = registerViewModel.Telefono,
                    Date = registerViewModel.Date,
                    Direcciones = new DireccionGt
                    {
                        Name = registerViewModel.NombreDireccion,
                        idMunicipio = registerViewModel.idMunicipioSelected
                    }                    
                };



                if (registerViewModel.AntecedentesPenales != null)
                {
                    var photoPenales = await _iPhotoService.AddPhotosAsync(registerViewModel.AntecedentesPenales);
                    newUser.AntecedentesPenales = photoPenales.Url.ToString();
                }
                if (registerViewModel.AntecedentesPoliciacos != null)
                {
                    var photoPoliciacos = await _iPhotoService.AddPhotosAsync(registerViewModel.AntecedentesPoliciacos);
                    newUser.AntecedentesPoliciacos = photoPoliciacos.Url.ToString();
                }
                if (registerViewModel.Fotografia != null)
                {
                    var photo = await _iPhotoService.AddPhotosAsync(registerViewModel.Fotografia);
                    newUser.Fotografia = photo.Url.ToString();
                }
                if (registerViewModel.Diplomas != null)
                {
                    var photoDiplomas = await _iPhotoService.AddPhotosAsync(registerViewModel.Diplomas);
                    newUser.Diplomas = photoDiplomas.Url.ToString();
                }
                if (registerViewModel.Titulos != null)
                {
                    var photoTitulos = await _iPhotoService.AddPhotosAsync(registerViewModel.Titulos);
                    newUser.Titulos = photoTitulos.Url.ToString();
                }
                var newUserResponse = await _userManager.CreateAsync(newUser, registerViewModel.Password);

                if (newUserResponse.Succeeded)
                {
                    // Captura el rol seleccionado en el formulario
                    var selectedRole = registerViewModel.SelectedRole;

                    // Verifica que se haya seleccionado un rol
                    if (!string.IsNullOrEmpty(selectedRole))
                    {
                        // Asigna al usuario al rol seleccionado
                        await _userManager.AddToRoleAsync(newUser, selectedRole);
                    }

                    return RedirectToAction("Index", "Home");
                }
                return View(registerViewModel);
            }
            return View(registerViewModel);

        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();            
            return RedirectToAction("Login", "Account");
        }

        public IActionResult AccessDenied()
        {
            return View(); // Puedes personalizar esta acción para mostrar la vista personalizada de acceso denegado
        }
    }
}
