using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
       
        
        
        
    }
}
