using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using ProyectoFinal.Models;
using ProyectoFinal.ViewModels;

namespace ProyectoFinal.Controllers
{

    [Authorize(Roles ="admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;


        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
        {
            if (!ModelState.IsValid) return View(createRoleViewModel);
            IdentityRole identityRole = new IdentityRole
                {
                    Name = createRoleViewModel.Nombre
                };

            IdentityResult result = await _roleManager.CreateAsync(identityRole);

            if(result.Succeeded)
            {
                return RedirectToAction("ListRoles", "Role");
            }

            foreach(IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(createRoleViewModel);
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if(role==null)
            {
                ViewBag.ErrorMessage = $"Role con Id = {id} no es encontrado";
                return View("NotFound");
            }

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name
            };

            foreach(var user in _userManager.Users)
            {
                if(await _userManager.IsInRoleAsync(user,role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel editRoleViewModel)
        {
            var role = await _roleManager.FindByIdAsync(editRoleViewModel.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role con Id = {editRoleViewModel.Id} no es encontrado";
                return View("NotFound");
            }
            else
            {
                role.Name = editRoleViewModel.RoleName;
                var result = await _roleManager.UpdateAsync(role);

                if(result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(editRoleViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await _roleManager.FindByIdAsync(roleId);

            if(role==null)
            {
                ViewBag.ErrorMessage = $"El Role del Id = {roleId} no es posible encontrarlo";
                return View("NotFound");
            }

            var model = new List<UserRoleViewModel>();

            foreach(var user in _userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };

                if(await _userManager.IsInRoleAsync(user,role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }
                model.Add(userRoleViewModel);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);

            if(role ==null)
            {
                ViewBag.ErrorMessage = $"Role del Id= {roleId} no es posible encontrarse";
                return View("NotFound");
            }

            for(int i=0;i<model.Count;i++)
            {
                var user = await _userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result = null;

                if (model[i].IsSelected)
                {
                    // Si el usuario ya tiene un rol, quítalo
                    var existingRoles = await _userManager.GetRolesAsync(user);
                    if (existingRoles.Any())
                    {
                        result = await _userManager.RemoveFromRolesAsync(user, existingRoles);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }

                            return View("Error");
                        }
                    }

                    // Luego, agrega el nuevo rol
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else
                {
                    // Si no está seleccionado, simplemente quita el rol
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                        continue;
                    else
                        return RedirectToAction("EditRole", new { Id = roleId });
                }

            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }
    }
}
