using Aponus_Web_API.Business;
using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[Controller]")]
   [ApiController]
    public class ProductsController : Controller
    {
        [HttpGet]
        [Route("ListProducts")]
        public async Task<JsonResult> ListProducts() {
            try
            {
                return  new BS_Products().ListarProductos();
            }
            catch (Exception e )
            { 
                return Json(e);
            }
        }

        [HttpGet]
        [Route("ListProducts/{TypeId}")]
        public async Task<JsonResult> ListProducts(string? TypeId)
        {
            try
            {

                return new BS_Products().ListarProductos(TypeId);
            }
            catch (Exception e)
            {
                return Json(e); 
            }      


        }

        [HttpGet]
        [Route("ListProducts/{TypeId}/{DN}")]
        public  Task<DatosProducto> ListProducts(string? TypeId,int?dN)
        {
            try
            {

                return new BS_Products().ListarProductos(TypeId, dN);
            }
            catch (Exception )
            {
                throw;
            }


        }

        [HttpGet]
        [Route("ListParts/{productId}/{q=1}")]
        public async Task<JsonResult> ListParts(string? ProductId,int Q=1)
        {
            try
            {
                return new BS_Products().ListarInsumos(ProductId, Q);
                
                //return Json(a, new Newtonsoft.Json.JsonSerializerSettings());
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

                return await new BS_Products().ListarDN(TypeId);
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpPost]
        [Route("SaveProduct")]
        public IActionResult GuardarProducto(GuardarProducto Producto)
        {
            try
            {
                //return null;
                return new BS_Products().GuardarProducto(Producto);
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
