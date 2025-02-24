using Aponus_Web_API.Negocio;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
using Aponus_Web_API.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly BS_Productos BsProductos;

        public ProductsController(BS_Productos _BSProductos)
        {
            BsProductos = _BSProductos;
        }

        [HttpGet]
        [Route("List/{TypeId?}/{IdDescription?}")]
        [RequiredPermission("PRODUCTOS_DESCRIPCION","SELECT")]
        [RequiredPermission("PRODUCTOS","SELECT")]
        public JsonResult ListProducts(string? TypeId, int? IdDescription)
        {
            try
            {
                return BsProductos.ListarProductos(TypeId, IdDescription);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ListProducts/{IdProducto}")]
        [RequiredPermission("PRODUCTOS", "SELECT")]
        public JsonResult ListProducts(string IdProducto)
        {
            try
            {
                return BsProductos.MapeoDTOProducto(IdProducto);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }
        [HttpPost]
        [Route("Prices/Update")]
        [RequiredPermission("PRODUCTOS", "UPDATE")]
        public async Task<IActionResult> ActualizarPrecios(DTOProducto Producto)
        {
            try
            {
                return await BsProductos.ValidarDatosActualizarPrecios(Producto);
            }
            catch (Exception e)
            {
                return Json(e);
            }
        }


        [HttpPost]
        [Route("NewListComponents")]
        [RequiredPermission("PRODUCTOS", "SELECT")]
        [RequiredPermission("PRODUCTOS_COMPONENTES", "SELECT")]
        [RequiredPermission("COMPONENTES_DETALLE", "SELECT")]
        [RequiredPermission("COMPONENTES_DESCRIPCION", "SELECT")]
        [RequiredPermission("STOCK_INSUMOS", "SELECT")]
        public JsonResult NewListComponents(DTOProducto Producto)
        {
            try
            {
                return BsProductos.NewListarComponentesProducto(Producto);

            }
            catch (Exception e)
            {
                return Json(e);
            }
        }

        [HttpGet]
        [Route("ListDN/{TypeId}")]
        [RequiredPermission("PRODUCTOS", "SELECT")]
        public async Task<JsonResult> ListarDN(string? TypeId)
        {
            try
            {

                return await BsProductos.ListarDN(TypeId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ListDN/{TypeId}/{IdDescription}")]
        [RequiredPermission("PRODUCTOS", "SELECT")]
        public async Task<JsonResult> ListarDN(string? TypeId, int? IdDescription)
        {
            try
            {

                return await BsProductos.ListarDN(TypeId, IdDescription);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        [Route("Save")]
        [RequiredPermission("PRODUCTOS", "INSERT")]
        [RequiredPermission("PRODUCTOS", "UPDATE")]
        [RequiredPermission("PRODUCTOS_COMPONENTES", "INSERT")]
        [RequiredPermission("PRODUCTOS_COMPONENTES", "UPDATE")]
        [RequiredPermission("PRODUCTOS_COMPONENTES", "DELETE")]
        public IActionResult Guardar(DTOProducto Producto)
        {
            try
            {
                return BsProductos.ProcesarDatos(Producto);
            }
            catch (DbUpdateException e)
            {
                string Mensaje = e.InnerException?.Message ?? e.Message;
                return new JsonResult(Mensaje);
            }
        }


        [HttpPost]
        [Route("Components/Save")]
        [RequiredPermission("PRODUCTOS_COMPONENTES", "DELETE")]
        [RequiredPermission("PRODUCTOS_COMPONENTES", "INSERT")]
        [RequiredPermission("PRODUCTOS_COMPONENTES", "UPDATE")]
        public IActionResult ActualizarComponentes(List<DTOComponentesProducto> componentesProducto)
        {
            try
            {
                return BsProductos.ActualizarComponentes(componentesProducto);
            }
            catch (DbUpdateException ex)
            {
                return new ContentResult()
                {
                    Content = ex.InnerException?.Message ?? ex.Message,
                    ContentType = "application/json",
                    StatusCode = 400
                };
            }
        }



        [HttpPost]
        [Route("Delete/{IdProducto}")]
        [RequiredPermission("PRODUCTOS", "UPDATE")]
        [RequiredPermission("PRODUCTOS_COMPONENTES", "DELETE")]
        public async Task<IActionResult> EliminarProducto(string IdProducto)
        {
            try
            {
                return await BsProductos.ProcesarDatos(IdProducto);
            }
            catch (DbUpdateException ex)
            {
                return new ContentResult()
                {
                    Content = ex.InnerException?.Message ?? ex.Message,
                    ContentType = "application/json",
                    StatusCode = 400
                };
            }
        }
    }
}
