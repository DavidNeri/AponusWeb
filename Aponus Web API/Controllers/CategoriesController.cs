using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Business;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly BS_Categorias BsCategorias;
        private readonly AponusContext AponusDBContext;
        public CategoriesController(AponusContext aponusDBContext, BS_Categorias _BsCategorias)
        {
            AponusDBContext = aponusDBContext;
            BsCategorias = _BsCategorias;
        }


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
                return BsCategorias.ListarDescripciones(IdTipo);            
        }


        [HttpPost]
        [Route("Products/Types/New")]
        public JsonResult AgregarTipo_Descripcion(DTOCategorias NuevaCategoria)
        {
            try
            {
                return BsCategorias.AgregarTipo(NuevaCategoria);
                
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
                return BsCategorias.EliminarTipoProducto(IdTipo);

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
                return await BsCategorias.AgregarDescripcion(NuevaCategoria);
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
                return BsCategorias.EliminarDescripcionProducto(IdDescription);

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
                return BsCategorias.Actualizar(ActualizarCategorias);
            }
            catch (DbUpdateException e)
            {

                string Mensaje = e.InnerException?.Message ?? e.Message;
                return new JsonResult(Mensaje);
            }


        }

        [HttpGet]
        [Route("Supplies/Descriptions/List")]
        public async Task<JsonResult> ListarNombreComponentes()
        {
            try
            {
                return await BsCategorias.ListarNombresComponentes();
            }
            catch (DbUpdateException e)
            {

                string Mensaje = e.InnerException?.Message ?? e.Message;
                return new JsonResult(Mensaje);
            }
        }


        

        [HttpPost]
        [Route("Supplies/Descriptions/New")]
        public IActionResult AgregarDescripcionCompoente ([FromBody] string nombreComponente)
        {
             try
             {
                 return  BsCategorias.AgregarDescripcionCompoente(nombreComponente);
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
                return BsCategorias.ModificarDescripcionCompoente(Descripcion);
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
