using Aponus_Web_API.Acceso_a_Datos.Sistema;
using Aponus_Web_API.Models;
using Aponus_Web_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Business;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Newtonsoft.Json;

namespace Aponus_Web_API.Controllers
{
    [Route("Aponus/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AponusContext AponusDBContext;

        public CategoriesController(AponusContext aponusDBContext)
        {
            AponusDBContext = aponusDBContext;
        }
        [HttpGet]
        [Route("ListCategories")]
        public async Task<JsonResult> ListCategories() {

            List<ProductosTipo> Lista_Tipos = await AponusDBContext.ProductosTipos.OrderBy(x
                => x.IdTipo).ToListAsync();
            Lista_Tipos.OrderBy(x => x.DescripcionTipo);
            return new JsonResult(Lista_Tipos);
        }

        [HttpGet]
        [Route("ListDescriptions/{idTipo}")]
        public List<DTODescripciones> ListarDescripciones(string IdTipo)
        {
            
                return new BS_Categories().ListarDescripciones(IdTipo);
            
        }


        [HttpPost]
        [Route("Types/new")]
        public JsonResult AgregarTipo_Descripcion(DTOCategorias NuevaCategoria)
        {
            try
            {
                return new BS_Categories().AgregarTipo(NuevaCategoria);
                
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }


        [HttpPost]
        [Route("Descriptions/new")]
        public IActionResult AgregarDescripcion( DTOCategorias NuevaCategoria)
        {
            try
            {
                return new BS_Categories().AgregarDescripcion(NuevaCategoria);
            }
            catch (DbUpdateException e)
            {

                string Mensaje = e.InnerException.Message;
                return new JsonResult(Mensaje);
            }
        }

        [HttpPost]
        [Route("Update")]
        public IActionResult ActualizarCategorias(DTOActualizarCategorias ActualizarCategorias)
        {
            try
            {
                return new BS_Categories().Actualizar(ActualizarCategorias);
            }
            catch (DbUpdateException e)
            {

                string Mensaje = e.InnerException.Message;
                return new JsonResult(Mensaje);
            }


        }

        [HttpGet]
        [Route("ListComponentesDescriptions")]
        public async Task<JsonResult> ListarNombreComponentes()
        {
            try
            {
                return await new BS_Categories().ListarNombresComponentes();
            }
            catch (DbUpdateException e)
            {

                string Mensaje = e.InnerException.Message;
                return new JsonResult(Mensaje);
            }


        }

        [HttpGet]
        [Route("GetNewComponentId/{ComponentDescription}")]
        public async Task<JsonResult> ObtenerNuevoIdComponente(string ComponentDescription)
        {
            try
            {
                return await new BS_Categories().ObtenerNuevoIdComponente(ComponentDescription);
            }
            catch (Exception e)
            {

                string Mensaje = e.InnerException.Message;
                return new JsonResult(Mensaje);
            }


        }

        [HttpPost]
        [Route("NewComponentDescription")]
        public IActionResult AgregarDescripcionCompoente ([FromBody] string nombreComponente)
        {
             try
             {
                 return  new BS_Categories().AgregarDescripcionCompoente(nombreComponente);
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
        [Route("ModifyComponentDescription")]
        public IActionResult ModificarDescripcionCompoente( DTODescripcionComponentes Descripcion)
        {
            try
            {
                return new BS_Categories().ModificarDescripcionCompoente(Descripcion);
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
