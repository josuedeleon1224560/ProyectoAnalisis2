using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Data;
using ProyectoFinal.Interfaces;
using ProyectoFinal.Models;
using ProyectoFinal.Repository;
using ProyectoFinal.ViewModels;


namespace ProyectoFinal.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly DireccionRepository _direccionRepository;
        private readonly iPhotoService _photoService;


        public UserController(IUserRepository userRepository, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager,
            iPhotoService photoService, DireccionRepository direccionRepository)
        {
            _userRepository = userRepository;
            _roleManager = roleManager;
            _userManager = userManager;
            _direccionRepository = direccionRepository;
            _photoService = photoService;
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
                    Date = user.Date
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
            //Si se produce un error en buscar el id del usuario, en terminos de que no exista como tal, lo devuelve a la vista de todos los usuarios.
            if (user == null)
            {
                return RedirectToAction("Index", "User");
            }
            //Realiza lo mismo que en la línea de código 69 sin embargo lo realiza con el rol del usuario en específico.
            var roles = await _userManager.GetRolesAsync(user);
            //Se extraen los datos            
            var direccion = await _direccionRepository.GetDireccionById(user.IdDireccion);
            var municipio = await _direccionRepository.GetMunicipioById(direccion.idMunicipio);
            var departamento = await _direccionRepository.GetDepartamentoById(municipio.Id);
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
                DireccionUsuario = direccion.Name,
                MunicipioUsuario = municipio.Nombre,
                DepartamentoUsuario = departamento.Nombre
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
        public async Task<IActionResult> Edit(string id)
        {
            //Se realiza una creación de una variable de usuario asincronica del repositorio del usuario que hace un llamado al id especifico del id de un usuario seleccionado
            var user = await _userRepository.GetUserById(id);
            //Si el valor del usuario da resultado null mandar la vista del error.
            if(user==null)
            {
                return View("Error");
            }

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
                UrlAntecedentesPoliciacos = user.AntecedentesPoliciacos,
                UrlAntecedentesPenales = user.AntecedentesPenales,
                UrlDiplomas = user.Diplomas,
                UrlFotografia = user.Fotografia,
                UrlTitulos = user.Titulos,
                //DireccionName = direccion?.Name,
                //Municipio = municipio?.Nombre,
                //IdMunicipio = user.Direcciones.IdMunicipio,
                //Departamento = departamento?.Nombre,
                //IdDepartamento = user.Direcciones.MunicipioGt.DepartamentoId
            };
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
            //Si el modelo obtenido es correcto a los estandares requeridos ignora la condición, caso contrario devuelve a la vista de editar.
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Error al editar el perfil");
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

                //Se asignan los nuevos valores al usuario seleccionado.
                user.Nombres = userEditViewModel.Nombres;
                user.Apellidos = userEditViewModel.Apellidos;
                user.CUI = userEditViewModel.CUI;
                user.Telefono = userEditViewModel.Telefono;
                user.Date = (DateTime)userEditViewModel.Date;
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
    }
}
