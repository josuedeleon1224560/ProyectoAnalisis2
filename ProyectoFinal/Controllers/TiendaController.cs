using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using ProyectoFinal.Models;
using ProyectoFinal.ViewModels;

namespace ProyectoFinal.Controllers
{
    public class TiendaController : Controller
    {
        private readonly AplicationDbContext _context;

        public TiendaController(AplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CrearVenta()
        {
            // Recupera la lista de productos disponibles
            var productos = _context.Producto.ToList();
            var usuariosDisponibles = _context.Users.ToList();

            // Crea una instancia del ViewModel con productos
            var viewModel = new TiendaViewModel
            {
                Productos = productos.Select(p => new ProductoViewModel
                {
                    ProductoId = p.Id,
                    Producto = p
                }).ToList(),

                UsuariosDisponibles = usuariosDisponibles,
                TipoPagoList = Enum.GetValues(typeof(TipoPago))
                .Cast<TipoPago>()
                .Select(s => new SelectListItem
                {
                    Text = s.ToString(),
                    Value = s.ToString()
                }).ToList()
            };

            // Otras configuraciones necesarias para el ViewModel

            return View(viewModel);
        }

        // POST: Ventas/CrearVenta
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearVenta(TiendaViewModel viewModel)
    {
            //var cantidad = new ProductoViewModel();
            //var productos = _context.Producto.ToList();
            //var usuariosDisponibles = _context.Users.ToList();

            //viewModel.Productos = productos.Select(p => new ProductoViewModel
            //{
            //    ProductoId = p.Id,
            //    ProductoNombre = p.Nombre,
            //    Cantidad = 
            //}).ToList();

            //viewModel.UsuariosDisponibles = usuariosDisponibles;
            //viewModel.TipoPagoList = Enum.GetValues(typeof(TipoPago))
            //.Cast<TipoPago>()
            //.Select(s => new SelectListItem
            //{
            //    Text = s.ToString(),
            //    Value = s.ToString()
            //}).ToList();

            if (ModelState.IsValid)
        {

            // Crea una nueva venta
            var venta = new Ventas
            {
                Pago = viewModel.Pago,
                Fecha = DateTime.Now,
                Usuario = _context.Users.FirstOrDefault(p=>p.Id == viewModel.UsuarioId)
                // Otras propiedades de venta, como Usuario
            };

            // Recorre los productos seleccionados y cantidades
            foreach (var productoModel in viewModel.Productos)
            {
                if (productoModel.Cantidad > 0)
                {
                    var producto = _context.Producto.FirstOrDefault(p => p.Id == productoModel.ProductoId+1);
                    
                    if (producto != null)
                    {
                        // Crea una entrada en VentaProducto
                        venta.ProductosEnVenta.Add(new VentaProducto
                        {
                           Producto = _context.Producto.FirstOrDefault(p => p.Id == producto.Id),
                           Venta = _context.Ventas.FirstOrDefault(p => p.Id == producto.Id),
                            Cantidad = productoModel.Cantidad
    });
                    }
                }
            }

            // Agrega la venta a la base de datos
            _context.Ventas.Add(venta);
await _context.SaveChangesAsync();

// Realiza cualquier otra acción necesaria

// Redirecciona o muestra un mensaje de éxito
return RedirectToAction("Index", "Tienda");
        }
            var productos = _context.Producto.ToList();
             var usuariosDisponibles = _context.Users.ToList();

            viewModel.Productos = productos.Select(p => new ProductoViewModel
            {
                ProductoId = p.Id,
                Producto = p
            }).ToList();

            viewModel.UsuariosDisponibles = usuariosDisponibles;
            viewModel.TipoPagoList = Enum.GetValues(typeof(TipoPago))
            .Cast<TipoPago>()
            .Select(s => new SelectListItem
            {
                Text = s.ToString(),
                Value = s.ToString()
            }).ToList();
        // Si la validación falla, muestra el formulario nuevamente
        return View(viewModel);
    }

    }


}
