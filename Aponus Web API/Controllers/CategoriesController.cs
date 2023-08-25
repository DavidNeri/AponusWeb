using Aponus_Web_API.Acceso_a_Datos.Sistema;
using Aponus_Web_API.Models;
using Aponus_Web_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aponus_Web_API.Data_Transfer_Objects;
using Aponus_Web_API.Business;


namespace Aponus_Web_API.Controllers
{
     [Route("Aponus/[controller]")]
   // [Route("/*")]
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

    }
}
