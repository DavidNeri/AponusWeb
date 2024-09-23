using Aponus_Web_API.Acceso_a_Datos.Sistema;
using Aponus_Web_API.Models;
using Aponus_Web_API.Support;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Business;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;
using System.Linq;
using Aponus_Web_API.Data_Transfer_objects;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AponusContext AponusDBContext;
        public CategoriesController(AponusContext aponusDBContext){AponusDBContext = aponusDBContext;}


        [HttpGet]
        [Route("Products/Types/List")]
        public async Task<JsonResult> ListCategories() {
            

            List<ProductosTipo> TipoProductos = await AponusDBContext.ProductosTipos
                .OrderBy(x=> x.DescripcionTipo)
                .Where(x=>x.IdEstado!=0)
                .Select(x=> new ProductosTipo()
                {
                    IdTipo= x.IdTipo,
                    DescripcionTipo= x.DescripcionTipo,
                    IdEstado= x.IdEstado,
                })
                .ToListAsync();

            return new JsonResult(TipoProductos);
        }       

        [HttpGet]
        [Route("Products/Descriptions/List/{idTipo}")]
        public List<DTODescripciones> ListarDescripciones(string IdTipo)
        {            
                return new BS_Categorias().ListarDescripciones(IdTipo);            
        }


        [HttpPost]
        [Route("Products/Types/New")]
        public JsonResult AgregarTipo_Descripcion(DTOCategorias NuevaCategoria)
        {
            try
            {
                return new BS_Categorias().AgregarTipo(NuevaCategoria);
                
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPost]
        [Route("Products/Types/{TypeId}/Delete/")] //Continuar!!
        public IActionResult EliminarTipoProducto(string IdTipo)
        {
            try
            {
                return new BS_Categorias().EliminarTipoProducto(IdTipo);

            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }


        [HttpPost]
        [Route("Products/Descriptions/New")]
        public async Task<IActionResult> AgregarDescripcion(DTOCategorias NuevaCategoria)
        {
            try
            {
                return await new BS_Categorias().AgregarDescripcion(NuevaCategoria);
            }
            catch (Exception ex)
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
        [Route("Products/Descriptions/{IdDescription}/Delete/")]
        public IActionResult EliminarTipoProducto(int IdDescription)
        {
            try
            {
                return new BS_Categorias().EliminarDescripcionProducto(IdDescription);

            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
        [HttpPost]
        [Route("Products/Type-or-Description/Update")]
        public IActionResult ActualizarCategorias(DTOActualizarCategorias ActualizarCategorias)
        {
            try
            {
                return new BS_Categorias().Actualizar(ActualizarCategorias);
            }
            catch (DbUpdateException e)
            {

                string Mensaje = e.InnerException.Message;
                return new JsonResult(Mensaje);
            }


        }

        [HttpGet]
        [Route("Supplies/Descriptions/List")]
        public async Task<JsonResult> ListarNombreComponentes()
        {
            try
            {
                return await new BS_Categorias().ListarNombresComponentes();
            }
            catch (DbUpdateException e)
            {

                string Mensaje = e.InnerException.Message;
                return new JsonResult(Mensaje);
            }
        }


        

        [HttpPost]
        [Route("Supplies/Descriptions/New")]
        public IActionResult AgregarDescripcionCompoente ([FromBody] string nombreComponente)
        {
             try
             {
                 return  new BS_Categorias().AgregarDescripcionCompoente(nombreComponente);
             }
             catch (DbUpdateException ex)
             {

                 if (ex.InnerException != null)
                 {
                     return new ContentResult()
                     {
                         Content = ex.InnerException.Message,
                         ContentType = "text/plain",
                         StatusCode = 400,

                     };
                 }
                 else
                 {
                     return new ContentResult()
                     {
                         Content = ex.Message,
                         ContentType = "text/plain",
                         StatusCode = 400,

                     };
                 };
             }

            

        }

        
        [HttpPost]
        [Route("Supplies/Descriptions/Update")] //ModifyComponentDescription
        public IActionResult ModificarDescripcionCompoente( DTODescripcionComponentes Descripcion)
        {
            try
            {
                return new BS_Categorias().ModificarDescripcionCompoente(Descripcion);
            }
            catch (DbUpdateException ex)
            {

                if (ex.InnerException != null)
                {
                    return new ContentResult()
                    {
                        Content = ex.InnerException.Message,
                        ContentType = "text/plain",
                        StatusCode = 400,

                    };
                }
                else
                {
                    return new ContentResult()
                    {
                        Content = ex.Message,
                        ContentType = "text/plain",
                        StatusCode = 400,

                    };
                };
            }



        }

    }
}
