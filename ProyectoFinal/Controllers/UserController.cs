using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;
using ProyectoFinal.Repository;
using ProyectoFinal.ViewModels;


namespace ProyectoFinal.Controllers
{
    [Authorize(Roles ="admin")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly DireccionRepository _direccionRepository;
        private readonly iPhotoService _photoService;
        private readonly AplicationDbContext _aplicationDbContext;
        private readonly DireccionRepository _direccionRepository1;
        private readonly PuestoRepository _puestoRepository;

        public UserController(IUserRepository userRepository, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager,
            iPhotoService photoService, DireccionRepository direccionRepository,
            AplicationDbContext aplicationDbContext, DireccionRepository direccionRepository1,
            PuestoRepository puestoRepository)
        {
            _userRepository = userRepository;
            _roleManager = roleManager;
            _userManager = userManager;
            _direccionRepository = direccionRepository;
            _photoService = photoService;
            _aplicationDbContext = aplicationDbContext;
            _direccionRepository1 = direccionRepository1;
            _puestoRepository = puestoRepository;
        }
        //Controlador encargado de ejecutar el Index desde un HttpGet para mostrar el resultado con la búsqueda de Users
        [HttpGet("Users")]
        public async Task<IActionResult> Index()
        {
            //Se buscan los usuarios del repositorio de la función obtener todos los usuarios para almacenarlos en una variable
            var users = await _userRepository.GetAllUsers();


            //Se obtiene una lista del modelo vista del usuario para utilizarse y se guarda en un result
            List<UserViewModel> result = new List<UserViewModel>();
            //Se hace un foreach para recorrer todos los datos del usuario 
            foreach (var user in users)
            {                
                var puesto = _aplicationDbContext.Users
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

        //Se realiza un llamado de tipo GET para extraer todos los datos del usuario de manera que se tengan a la disposición.
        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            //Se realiza una creación de una variable de usuario asincronica del repositorio del usuario que hace un llamado al id especifico del id de un usuario seleccionado
            var user = await _userRepository.GetUserById(id);
            var direccion = _aplicationDbContext.Users
    .Include(u => u.Direcciones) // Incluye las direcciones
    .ThenInclude(d => d.MunicipioGt) // Incluye los municipios
    .ThenInclude(m => m.DepartamentoGt) // Incluye los departamentos
    .SingleOrDefault(u => u.Id == id);

            var puesto = _aplicationDbContext.Users
                .Include(u => u.IdPuesto)
                .ThenInclude(d => d.Departamento)
                .SingleOrDefault(i => i.Id == id);

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
        //Se hace una accion de forma GET por defecto y se crea una función de manera que necesita el parámetro del id del usuario para editar ese perfil exactamente.

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

        public async Task<IActionResult> Edit(string id)
        {
            //Se realiza una creación de una variable de usuario asincronica del repositorio del usuario que hace un llamado al id especifico del id de un usuario seleccionado
            var user = await _userRepository.GetUserById(id);
            //Si el valor del usuario da resultado null mandar la vista del error.
            if(user==null)
            {
                return View("Error");
            }
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

            var roles = await _userManager.GetRolesAsync(user);
            ////var direccion = await _direccionRepository.GetDireccionById(user.IdDireccion);
            ////var municipio = await _direccionRepository.GetMunicipioById(direccion.IdMunicipio);
            ////var departamento = await _direccionRepository.GetDepartamentoById(municipio.DepartamentoId);
            //Se crea la variable del modelo vista de la edición del Usuario haciendo una creación del objeto del Modelo Vista de la edición del usuario
            var userEditViewModel = new UserEditViewModel()
            {
                CUI = user.CUI,
                Nombres = user.Nombres,
                Apellidos = user.Apellidos,
                Telefono = user.Telefono,
                Date = user.Date,
                Email = user.Email,
                UserName = user.Email,
                Genero = user.Genero,
                UrlAntecedentesPoliciacos = user.AntecedentesPoliciacos,
                UrlAntecedentesPenales = user.AntecedentesPenales,
                UrlDiplomas = user.Diplomas,
                UrlFotografia = user.Fotografia,
                UrlTitulos = user.Titulos,
                DireccionName = direccion.Direcciones.Name,
                Municipio = direccion.Direcciones.MunicipioGt.Nombre,
                Departamento = direccion.Direcciones.MunicipioGt.DepartamentoGt.Nombre,
                IdMunicipio = idMunicipio,
                IdDepartamento = departamento,
                Puesto = puesto.IdPuesto.Nombre,
                IdDepartamentoPuesto = puesto.IdPuesto.Departamento.Id,
                DepartamentoPuesto = puesto.IdPuesto.Departamento.Nombre,
                IdPuesto = puesto.IdPuesto.Id,
                RolesList = roles.ToList(),                
                //DireccionName = direccion?.Name,
                //Municipio = municipio?.Nombre,
                //IdMunicipio = user.Direcciones.IdMunicipio,
                //Departamento = departamento?.Nombre,
                //IdDepartamento = user.Direcciones.MunicipioGt.DepartamentoId
            };
            userEditViewModel.GeneroList = Enum.GetValues(typeof(Sexo))
            .Cast<Sexo>()
            .Select(s => new SelectListItem
            {
            Text = s.ToString(),
            Value = s.ToString()
            }).ToList();            

            //Retorna la vista con los datos actuales del usuario.
            return View(userEditViewModel);
        }

        //Se hace una accion de forma POST de envio de formulario se crea una función de manera que necesita el parámetro del id del usuario para editar ese perfil exactamente.
        //Llama también al modelo vista usuario de edición
        [HttpPost]        
        public async Task<IActionResult> Edit (string id, UserEditViewModel userEditViewModel)
        {
            //Se realiza una creación de una variable de usuario asincronica del repositorio del usuario que hace un llamado al id especifico del id de un usuario seleccionado
            var user = await _userRepository.GetUserById(id);

            userEditViewModel.GeneroList = Enum.GetValues(typeof(Sexo))
    .Cast<Sexo>()
    .Select(s => new SelectListItem
    {
        Text = s.ToString(),
        Value = s.ToString()
    }).ToList();
            //Si el modelo obtenido es correcto a los estandares requeridos ignora la condición, caso contrario devuelve a la vista de editar.
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Error al editar el perfil");

                // Reinitialize the 'GeneroList' in the userEditViewModel

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

                userEditViewModel.GeneroList = Enum.GetValues(typeof(Sexo))
                .Cast<Sexo>()
                .Select(s => new SelectListItem
                {
                    Text = s.ToString(),
                    Value = s.ToString()
                }).ToList();

                userEditViewModel.IdDepartamento = departamento;
                userEditViewModel.Departamento = direccion.Direcciones.MunicipioGt.DepartamentoGt.Nombre;
                userEditViewModel.Municipio = direccion.Direcciones.MunicipioGt.Nombre;
                userEditViewModel.IdMunicipio = idMunicipio;
                userEditViewModel.IdPuesto = puesto.IdPuesto.Id;
                userEditViewModel.Puesto = puesto.IdPuesto.Nombre;
                userEditViewModel.IdDepartamentoPuesto = puesto.IdPuesto.Departamento.Id;
                userEditViewModel.DepartamentoPuesto = puesto.IdPuesto.Departamento.Nombre;
                userEditViewModel.UrlAntecedentesPenales = user.AntecedentesPenales;
                userEditViewModel.UrlAntecedentesPoliciacos = user.AntecedentesPoliciacos;
                userEditViewModel.UrlDiplomas = user.Diplomas;
                userEditViewModel.UrlFotografia = user.Fotografia;
                userEditViewModel.UrlTitulos = user.Titulos;
                return View("Edit", userEditViewModel);
            }
            //Si el usuario no tiene campos nulos genera cambios
            if(user != null)
            {
                try
                {
                    //Verifica que el usuario haya editado la imagen para proceder a eliminar la imagen que tiene almacennado
                    if (!string.IsNullOrEmpty(user.AntecedentesPenales))
                    {
                        //Elimina asincronicamente la foto o el URL dentro del modelo y sigue el proceso.
                        await _photoService.DeletePhotoAsync(user.AntecedentesPenales);
                    }
                    //Verifica que el usuario haya editado la imagen para proceder a eliminar la imagen que tiene almacennado
                    if (!string.IsNullOrEmpty(user.Fotografia))
                    {
                        //Elimina asincronicamente la foto o el URL dentro del modelo y sigue el proceso.
                        await _photoService.DeletePhotoAsync(user.Fotografia);
                    }
                    //Verifica que el usuario haya editado la imagen para proceder a eliminar la imagen que tiene almacennado
                    if (!string.IsNullOrEmpty(user.AntecedentesPoliciacos))
                    {
                        //Elimina asincronicamente la foto o el URL dentro del modelo y sigue el proceso.
                        await _photoService.DeletePhotoAsync(user.AntecedentesPoliciacos);
                    }
                    //Verifica que el usuario haya editado la imagen para proceder a eliminar la imagen que tiene almacennado
                    if (!string.IsNullOrEmpty(user.Titulos))
                    {
                        //Elimina asincronicamente la foto o el URL dentro del modelo y sigue el proceso.
                        await _photoService.DeletePhotoAsync(user.Titulos);
                    }
                    //Verifica que el usuario haya editado la imagen para proceder a eliminar la imagen que tiene almacennado
                    if (!string.IsNullOrEmpty(user.Diplomas))
                    {
                        //Elimina asincronicamente la foto o el URL dentro del modelo y sigue el proceso.
                        await _photoService.DeletePhotoAsync(user.Diplomas);
                    }
                }
                //Si el try falla con respecto a la eliminación de la foto lanzará un catch de manera que seguirá la condición porque se provocó un error
                catch (Exception ex)
                {
                    //Retorna la vista de editar usuarios
                    ModelState.AddModelError("", "No se pudo eliminar la foto");
                    return View(userEditViewModel);
                }
                ////var direccion = await _direccionRepository.GetDireccionById(user.IdDireccion);
                ////var municipio = await _direccionRepository.GetMunicipioById(direccion.IdMunicipio);
                ////var departamento = await _direccionRepository.GetDepartamentoById(municipio.DepartamentoId);

                    var direccion = _aplicationDbContext.Users
                    .Include(u => u.Direcciones) // Incluye las direcciones
                    .ThenInclude(d => d.MunicipioGt) // Incluye los municipios
                    .ThenInclude(m => m.DepartamentoGt) // Incluye los departamentos
                    .SingleOrDefault(u => u.Id == id);

                    var puesto = _aplicationDbContext.Users
                    .Include(u => u.IdPuesto)
                    .ThenInclude(d => d.Departamento)
                    .SingleOrDefault(i => i.Id == id);


                //Se asignan los nuevos valores al usuario seleccionado.
                user.Nombres = userEditViewModel.Nombres;
                user.Apellidos = userEditViewModel.Apellidos;
                user.CUI = userEditViewModel.CUI;
                user.Telefono = userEditViewModel.Telefono;
                user.Date = (DateTime)userEditViewModel.Date;
                user.Email = userEditViewModel.Email;
                user.Genero = userEditViewModel.Genero;
                user.Direcciones.MunicipioGt.DepartamentoGt = _aplicationDbContext.Tabla_Departamentos.FirstOrDefault(m => m.Id == userEditViewModel.IdDepartamento);
                user.Direcciones.MunicipioGt = _aplicationDbContext.Tabla_Municipios.FirstOrDefault(m=>m.Id == userEditViewModel.IdMunicipio);
                user.IdPuesto = _aplicationDbContext.Puesto.FirstOrDefault(m => m.Id == userEditViewModel.IdPuesto);
                user.IdPuesto.Departamento = _aplicationDbContext.Departamento.FirstOrDefault(m => m.Id == userEditViewModel.IdDepartamentoPuesto);
                _aplicationDbContext.SaveChanges();




                ////user.Direcciones.Name = userEditViewModel.DireccionName;
                ////user.Direcciones.IdMunicipio = userEditViewModel.IdMunicipio;
                ////user.Direcciones.MunicipioGt.DepartamentoId = userEditViewModel.IdDepartamento;

                //Verifica que se haya subido algun archivo de lo contrario no ejecuta nada.
                try { 
                if (userEditViewModel.AntecedentesPenales != null)
                {
                    //Se empezará el proceso de subir fotos y almacenarlos en una variable si es que se subió algún archivo.
                    var photoPenales = await _photoService.AddPhotosAsync(userEditViewModel.AntecedentesPenales);
                    //Cambia el valor de la foto por la URL que genera el servicio de iCloudinary.
                    user.AntecedentesPenales = photoPenales.Url.ToString();
                }
                if (userEditViewModel.AntecedentesPoliciacos != null)
                {
                    var photoPoliciacos = await _photoService.AddPhotosAsync(userEditViewModel.AntecedentesPoliciacos);
                    user.AntecedentesPoliciacos = photoPoliciacos.Url.ToString();
                }
                if (userEditViewModel.Fotografia != null)
                {
                    var photo = await _photoService.AddPhotosAsync(userEditViewModel.Fotografia);
                    user.Fotografia = photo.Url.ToString();
                }
                if (userEditViewModel.Diplomas != null)
                {
                    var photoDiploma = await _photoService.AddPhotosAsync(userEditViewModel.Diplomas);
                    user.Diplomas = photoDiploma.Url.ToString();
                }
                if (userEditViewModel.Titulos != null)
                {
                    var photoTitulo = await _photoService.AddPhotosAsync(userEditViewModel.Titulos);
                    user.Titulos = photoTitulo.Url.ToString();
                }
                }
                catch (Exception ex)
                {
                    // Registra o imprime la excepción para obtener más detalles sobre el error.
                    Console.WriteLine($"Error en la carga de la foto: {ex.Message}");
                }

                //Se crea una variable que manda a llamar al EntityUser sobre un update sincronico del usuario.
                var updateResult = await _userManager.UpdateAsync(user);
                //Si el resultado es éxitoso y no genera algun error en la actualización de datos cumple la condición. Redirecciona al Index de los usuarios.
                if (updateResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    //Caso erroneo genera un error al actualizar el perfil y vuelve al usuario que se está editando.
                    ModelState.AddModelError("", "Error al actualizar el perfil");
                    return View(userEditViewModel);
                }
            }
            //Si el usuario tiene valor nulo devuelve denuevo la vista de editar usuario.
            else
            {

                return View(userEditViewModel);
            }
        }

        public IActionResult Mensajeria(string CUI)
        {
            var usuario = _aplicationDbContext.Users.SingleOrDefault(u => u.CUI == CUI);
            if (usuario != null)
            {
                var mensajesUsuario = _aplicationDbContext.Mensajes.Where(m => m.AppUserId == usuario.Id).ToList();

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
