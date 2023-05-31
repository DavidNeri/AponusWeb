using Aponus_Web_API.Acceso_a_Datos.Sistema;
using Aponus_Web_API.Models;
using Aponus_Web_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aponus_Web_API.Data_Transfer_Objects;


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
            
                return new CategoriesServices().ListarDescripciones(IdTipo);
            
        }


        [HttpPost]
        [Route("Types/new")]
        public string? AgregarTipo_Descripcion(DTOCategorias NuevaCategoria)
        {
            try
            {
                 string? Id_Tipo = new CategoriesServices().AgregarTipo(NuevaCategoria);
                return Id_Tipo;
            }
            catch 
            {
                return null;
            }
           

        }


        [HttpPost]
        [Route("Descriptions/new")]
        public IActionResult AgregarDescripcion( DTOCategorias NuevaCategoria)
        {
            try
            {
                // return new CategoriesServices().    (NuevaCategoria);
                return null;
            }
            catch (DbUpdateException e)
            {

                string Mensaje = e.InnerException.Message;
                return new JsonResult(Mensaje);
            }


        }


    }
}
