using Aponus_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<JsonResult> ListCategories(){

            List<ProductCategory> CategoryList = await AponusDBContext.ProductCategories.OrderBy(x
                => x.CategoryDescription).ToListAsync();
            CategoryList.OrderBy(x => x.CategoryDescription);
            return new JsonResult(CategoryList); 
        }
        // GET: CategoriesController
        
        
    }
}
