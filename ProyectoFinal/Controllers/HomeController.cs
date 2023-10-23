using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;


namespace ProyectoFinal.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(ILogger<HomeController> logger,IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("admin"))
            {
                // Redirige a los administradores a una página específica
                return RedirectToAction("Privacy", "Home");
            }
            else
            {
                // Redirige a otros usuarios a la página de inicio
                return RedirectToAction("Index", "Usuario");
            }
        }

        public IActionResult Privacy()
        {
         return View();
        }
        
    }
}