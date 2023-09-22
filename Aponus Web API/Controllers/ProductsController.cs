using Aponus_Web_API.Business;
using Aponus_Web_API.Data_Transfer_objects;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
        public  Task<JsonResult> ListProducts(string? TypeId)
        {
            try
            {

                return new BS_Products().ListarProductos(TypeId);
            }
            catch (Exception)
            {
                throw; 
            }      


        }
        //Reemplazar por estos
        [HttpGet]
        [Route("ListProducts/{TypeId}/{IdDescription}")]
        public Task<JsonResult> ListProducts(string? TypeId, int? IdDescription)
        {
            try
            {

                return new BS_Products().ListarProductos(TypeId, IdDescription);
            }
            catch (Exception)
            {
                throw;
            }


        }

        [HttpGet]
        [Route("ListProducts/{TypeId}/{IdDescription}/{dn}")]
        public Task<JsonResult> ListProducts(string? TypeId, int? IdDescription, int Dn)
        {
            try
            {

                return new BS_Products().ListarProductos(TypeId, IdDescription, Dn);
            }
            catch (Exception)
            {
                throw;
            }


        }
        //Reemplazar por estos

        //Ver y eliminar
        /* [HttpGet]
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


         }*/

        //Ver y eliminar

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


        [HttpPost]
        //Reemplaza a ListParts
        [Route("NewListComponents")]
        public JsonResult NewListComponents(DTODetallesProducto Producto)
        {
            try
            {
                return new BS_Products().NewListarComponentesProducto(Producto);

            }
            catch (Exception e)
            {
                return Json(e);
            }
        }

        //Ver y eliminar
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
        //Ver y eliminar

        //Reemplazar por este
        [HttpGet]
        [Route("ListDN/{TypeId}/{IdDescription}")]
        public async Task<JsonResult> ListarDN(string? TypeId, int?IdDescription)
        {
            try
            {

                return await new BS_Products().ListarDN(TypeId, IdDescription);
            }
            catch (Exception)
            {
                throw;
            }

        }
        //Reemplazar por este


        [HttpPost]
        [Route("SaveProduct")]
        public IActionResult GuardarProducto(DTOProducto Producto)
        {
            try
            {
                new BS_Products().GuardarProducto(Producto);
                return new StatusCodeResult(StatusCodes.Status200OK); 
            }
            catch (DbUpdateException e ) 
            {   
                string Mensaje = e.InnerException.Message;
                return new JsonResult(Mensaje);
            }
        }


        [HttpPost]
        [Route("NewSaveProduct")]
        public IActionResult NuevoGuardarProducto(DTODetallesProducto Producto)
        {
            try
            {
                return new BS_Products().NuevoGuardarProducto(Producto);
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
                return new BS_Products().ActualizarComponentes(Producto);
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
