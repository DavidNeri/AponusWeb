using Aponus_Web_API.Business;
using Aponus_Web_API.Data_Transfer_objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
   [ApiController]
    public class ProductsController : Controller
    {
        [HttpGet]
        [Route("List/{TypeId?}/{IdDescription?}")]
        public JsonResult ListProducts(string? TypeId, int? IdDescription)
        {
            try
            {
                return new BS_Stocks().ListarProductos(TypeId, IdDescription);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ListProducts")]
        public async Task<JsonResult> ListProducts() {
            try
            {
                return  new BS_Productos().ListarProductos();
            }
            catch (Exception e )
            { 
                return Json(e);
            }
        }

        [HttpPost]
        [Route("NewListComponents")]
        public JsonResult NewListComponents(DTODetallesProducto Producto)
        {
            try
            {
                return new BS_Productos().NewListarComponentesProducto(Producto);

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

                return await new BS_Productos().ListarDN(TypeId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("ListDN/{TypeId}/{IdDescription}")]
        public async Task<JsonResult> ListarDN(string? TypeId, int?IdDescription)
        {
            try
            {

                return await new BS_Productos().ListarDN(TypeId, IdDescription);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        [Route("NewSaveProduct")]
        public IActionResult NuevoGuardarProducto(DTODetallesProducto Producto)
        {
            try
            {
                return new BS_Productos().NuevoGuardarProducto(Producto);
            }
            catch (DbUpdateException e)
            {
                string Mensaje = e.InnerException.Message;
                return new JsonResult(Mensaje);
            }
        }


        [HttpPost]
        [Route("UpdateComponents")]
        public IActionResult ActualizarComponentes(List<DTOComponentesProducto> Producto)
        {
            try
            {
                return new BS_Productos().ActualizarComponentes(Producto);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException.Message != null)
                {
                    return new ContentResult()
                    {
                        Content = ex.InnerException.Message,
                        ContentType = "application/json",
                    };
                }
                else
                {
                    return new ContentResult()
                    {
                        Content = ex.Message,
                        ContentType = "application/json",
                    };
                }
            }
        }

    }
}
