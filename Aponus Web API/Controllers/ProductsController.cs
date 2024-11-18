using Aponus_Web_API.Modelos;
using Aponus_Web_API.Negocio;
using Aponus_Web_API.Objetos_de_Transferencia_de_Datos;
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
        [Route("List/{TypeId}/{IdDescription?}")]
        public JsonResult ListProducts(string TypeId, int? IdDescription)
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
        [Route("NewListComponents")]
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
    }
}
