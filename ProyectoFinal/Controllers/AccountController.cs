﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
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
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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
        private readonly PuestoRepository _puestoRepository;


        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
        AplicationDbContext context, RoleManager<IdentityRole> roleManager, iPhotoService iPhotoService,
        DireccionRepository direccionRepository, PuestoRepository puestoRepository)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _iPhotoService = iPhotoService;
            _direccionRepository = direccionRepository;
            _puestoRepository = puestoRepository;
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
                        //return RedirectToAction("Index", "Home");
                    }
                }
                TempData["Error"] = "Credenciales incorrectas. Por favor intente denuevo.";
                return View(loginViewModel);
            }
            TempData["Error"] = "Credenciales incorrectas. Por favor intente denuevo.";
            return View(loginViewModel);
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Register()
        {
            var model = new RegisterViewModel();
            var roles = _roleManager.Roles.ToList();
            model.GeneroList = Enum.GetValues(typeof(Sexo))
                .Cast<Sexo>()
                .Select(s => new SelectListItem
                {
                    Text = s.ToString(),
                    Value = s.ToString()
                }).ToList();


            model.Roles = roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Name
            }).ToList();


            return View(model);
        }

        public JsonResult Departamento()
        {
            return new JsonResult(_direccionRepository.GetAllDepartamento());
        }
        public JsonResult DepartamentoTrabajo()
        {
            return new JsonResult(_puestoRepository.GetDepartamentos());
        }
        public JsonResult Puesto(int id)
        {
            return new JsonResult(_puestoRepository.GetAllPuestos(id));
        }
        public JsonResult Municipio(int id)
        {
            return new JsonResult(_direccionRepository.GetAllMunicipio(id));
        }
        public JsonResult Direccion(int id)
        {
            return new JsonResult(_direccionRepository.GetAllDirecciones(id));
        }

        public class StrongPasswordAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (value == null)
                {
                    return false; // La contraseña es nula, por lo que no cumple con los criterios
                }


                string password = value as string;

                // Define una expresión regular que cumple con los criterios
                string pattern = @"^(?=.*[A-Z])(?=.*[!@#$%^&*])(.{4,})$";

                // Utiliza Regex.IsMatch para verificar si la contraseña coincide con el patrón
                return Regex.IsMatch(password, pattern);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
         {
            var roles = _roleManager.Roles.ToList();
            registerViewModel.Roles = roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Name
            }).ToList();

            registerViewModel.GeneroList = Enum.GetValues(typeof(Sexo))
    .Cast<Sexo>()
    .Select(s => new SelectListItem
    {
        Text = s.ToString(),
        Value = s.ToString()
    }).ToList();


            var selectedRole = registerViewModel.SelectedRole;
            //var selectedGenero = registerViewModel.Genero;
            //var dept = registerViewModel.SelectedDepartamento;
            //var puesto = registerViewModel.SelectedPuesto;
            //var selecteDept = registerViewModel.idDepartamento;
            //var selectMunicipio = registerViewModel.idMunicipioSelected;
            //if (selectedRole == null)
            //{
            //    ModelState.AddModelError("SelectedRole", "Por favor, seleccione una opcion válida.");
            //    return View(registerViewModel);
            //}
            // if (selectedGenero == null)
            //{
            //    ModelState.AddModelError("Genero", "Por favor, seleccione una opcion válida.");
            //    return View(registerViewModel);
            //}
            // if(dept==2001)
            //{
            //    ModelState.AddModelError("SelectedDepartamento", "Por favor, seleccione una opcion válida.");
            //    return View(registerViewModel);
            //}
            // if (puesto == 2001)
            //{
            //    ModelState.AddModelError("SelectedPuesto", "Por favor, seleccione una opcion válida.");
            //    return View(registerViewModel);
            //}
            // if (selecteDept == 2001)
            //{
            //    ModelState.AddModelError("idDepartamento", "Por favor, seleccione una opcion válida.");
            //    return View(registerViewModel);
            //}
            // if (selectMunicipio==2001)
            //{
            //    ModelState.AddModelError("idMunicipioSelected", "Por favor, seleccione una opcion válida.");
            //    return View(registerViewModel);
            //}


            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
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
                TempData["Error"] = "El correo ya se encuentra registrado";
                return View(registerViewModel);
            }


            var userByCUI =  _context.Users.FirstOrDefault(u => u.CUI == registerViewModel.CUI);

            if (userByCUI != null)
            {
                TempData["Error"] = "Este CUI ya está siendo utilizado";
                return View(registerViewModel);
            }



            var direccionNueva = new DireccionGt
            {
                Name = registerViewModel.NombreDireccion,
                MunicipioGt = _context.Tabla_Municipios.FirstOrDefault(m => m.Id == registerViewModel.idMunicipioSelected)
            };


            var newUser = new AppUser()
            {
                Email = registerViewModel.EmailAddress,
                UserName = registerViewModel.EmailAddress,
                Nombres = registerViewModel.Nombres,
                Apellidos = registerViewModel.Apellidos,
                CUI = registerViewModel.CUI,
                Telefono = registerViewModel.Telefono,
                Date = registerViewModel.Date,  
                Genero = registerViewModel.Genero,
                Direcciones = direccionNueva,
                IdPuesto = _context.Puesto.FirstOrDefault(p=>p.Id == registerViewModel.SelectedPuesto)
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

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Cerrar la sesión del usuario
            await _signInManager.SignOutAsync();

            // Configurar las cabeceras HTTP para evitar el almacenamiento en caché
            Response.Headers["Cache-Control"] = "no-cache, no-store";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            // Redirigir al usuario a la página de inicio o a cualquier otra página deseada
            return RedirectToAction("Login", "Account");
        }

        public IActionResult AccessDenied()
        {
            return View(); // Puedes personalizar esta acción para mostrar la vista personalizada de acceso denegado
        }
    }
}
